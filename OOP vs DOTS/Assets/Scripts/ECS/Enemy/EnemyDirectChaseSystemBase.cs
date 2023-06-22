using ECS.Config;
using ECS.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.Enemy
{
    public struct EnemyDirectChaseJobComponentData : IComponentData
    {
        public LocalTransform EnemyTransform;
        public LocalTransform PlayerTransform;
    }

    public partial struct EnemyDirectChaseJob : IJobEntity
    {
        public float Speed;
        public float DeltaTime;

        // Adds one to every SampleComponent value
        void Execute(ref EnemyDirectChaseJobComponentData enemyDirectChaseJobComponentData)
        {
            Vector3 direction = enemyDirectChaseJobComponentData.PlayerTransform.Position -
                                enemyDirectChaseJobComponentData.EnemyTransform.Position;

            var distance = direction.magnitude;
            direction.Normalize();

            var move = Speed * DeltaTime;

            if (move > distance)
            {
                move = distance;
            }

            enemyDirectChaseJobComponentData.EnemyTransform.Position += (float3)(direction * move);
        }
    }

    [RequireMatchingQueriesForUpdate]
    public partial class EnemyDirectChaseSystemBase : SystemBase
    {
        // Query that matches QueryJob, specified for `DirectChase`
        EntityQuery enemyTransform;
        EntityQuery playerTransform;
        
        protected override void OnCreate()
        {
            // Query that contains all of Execute params found in `QueryJob` - as well as additional user specified component `PlayerComponentData`.
            enemyTransform = GetEntityQuery(ComponentType.ReadWrite<EnemyDirectChase>(),
                ComponentType.ReadOnly<LocalTransform>());
            playerTransform = GetEntityQuery(ComponentType.ReadOnly<PlayerComponentData>(),
                ComponentType.ReadOnly<LocalTransform>());
        }

        protected override void OnUpdate()
        {
            // Uses the enemyDirectChase query
            new EnemyDirectChaseJob().ScheduleParallel(enemyTransform);
        }
    }
}
