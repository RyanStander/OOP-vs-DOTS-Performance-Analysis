using System.Linq;
using ECS.Config;
using ECS.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.Enemy
{
    public partial struct EnemyDirectChaseSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemyDirectChase>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = Time.deltaTime;


            foreach (var (transform, entity) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<EnemyComponentData>()
                         .WithEntityAccess())
            {
                DirectChase(ref state, transform, deltaTime);
            }
        }

        private void DirectChase(ref SystemState state, RefRW<LocalTransform> transform, float deltaTime)
        {
            LocalTransform? playerToFollow = null;

            foreach (var (playerTransform, entity) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<PlayerComponentData>()
                         .WithEntityAccess())
            {
                playerToFollow = playerTransform.ValueRO;
                break;
            }

            if (!playerToFollow.HasValue)
                return;


            //move the chaser transform in the direction of the target transform by speed value
            Vector3 direction = playerToFollow.Value.Position - transform.ValueRO.Position;

            var distance = direction.magnitude;
            direction.Normalize();

            const float speed = 0.5f;

            var move = speed * deltaTime;

            if (move > distance)
            {
                move = distance;
            }
            
            transform.ValueRW.Position += (float3)(direction * move);
        }


        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}