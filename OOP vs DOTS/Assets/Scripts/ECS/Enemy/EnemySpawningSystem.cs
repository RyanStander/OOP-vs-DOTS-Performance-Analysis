using ECS.Config;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Rendering;

namespace ECS.Enemy
{
    public partial struct EnemySpawningSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SkeletonSpawning>();
            state.RequireForUpdate<ConfigEntityComponentData>(); 
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var config = SystemAPI.GetSingleton<ConfigEntityComponentData>();

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var enemies = new NativeArray<Entity>(config.SkeletonCount, Allocator.Temp);
            ecb.Instantiate(config.SkeletonPrefab, enemies);

            ecb.Playback(state.EntityManager);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}