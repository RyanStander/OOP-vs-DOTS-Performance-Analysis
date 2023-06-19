using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.MovingEntities
{
    /// <summary>
    /// This is the system of the mover.
    /// </summary>
    [BurstCompile]
    public partial struct MoverSystem : ISystem
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
            foreach (RefRW<Mover> mover in SystemAPI.Query<RefRW<Mover>>())
            {
                ProcessMover(ref state, mover, deltaTime);
            }
        }

        private void ProcessMover(ref SystemState state, RefRW<Mover> mover, float deltaTime)
        {
            //move the transform forward by speed value
            mover.ValueRW.Transform.Position += mover.ValueRW.Transform.Forward() * mover.ValueRO.Speed * deltaTime;
            
            state.EntityManager.SetComponentData(mover.ValueRW.Object, mover.ValueRW.Transform);
        }
    }
}