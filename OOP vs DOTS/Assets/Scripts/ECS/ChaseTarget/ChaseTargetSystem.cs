using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.ChaseTarget
{
    public partial struct ChaseTargetSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = Time.deltaTime;
            // Queries for all Spawner components. Uses RefRW because this system wants
            // to read from and write to the component. If the system only needed read-only
            // access, it would use RefRO instead.
            foreach (RefRW<ChaseTargetComponent> chaseTargetComponent in SystemAPI.Query<RefRW<ChaseTargetComponent>>())
            {
                ChaseTarget(ref state, chaseTargetComponent, deltaTime);
            }
        }

        private void ChaseTarget(ref SystemState state, RefRW<ChaseTargetComponent> chaseTargetComponent,
            float deltaTime)
        {
            //move the chaser transform in the direction of the target transform by speed value
            Vector3 direction = chaseTargetComponent.ValueRO.TargetTransform.Position -
                            chaseTargetComponent.ValueRO.ChaserTransform.Position;
            var distance = direction.magnitude;
            direction.Normalize();
            var move = chaseTargetComponent.ValueRO.ChaserSpeed * deltaTime;
            
            if (move > distance)
            {
                move = distance;
            }
            
            //chaseTargetComponent.ValueRW.ChaserTransform.Translate(direction * move);
            chaseTargetComponent.ValueRW.ChaserTransform.Position += (float3)(direction * move);

            state.EntityManager.SetComponentData(chaseTargetComponent.ValueRW.ChaserObject,
                chaseTargetComponent.ValueRW.ChaserTransform);
        }
    }
}