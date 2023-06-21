using ECS.Config;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;

namespace ECS.Enemy
{
    public partial struct EnemySpawningSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SkeletonSpawning>();
            state.RequireForUpdate<ConfigEntityComponentData>();
        }
        
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var config = SystemAPI.GetSingleton<ConfigEntityComponentData>();

            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            var enemies = new NativeArray<Entity>(config.SkeletonCount, Allocator.Temp);
            entityCommandBuffer.Instantiate(config.SkeletonPrefab, enemies);

            var spawnRadius = 3f;

            var random = new Random(123);
            
            //Randomly position the enemy around the point 0,0,0 in a spherical fashion
            for (int i = 0; i < enemies.Length; i++)
            {
                var position = new float3(random.NextFloat(-spawnRadius, spawnRadius),
                    random.NextFloat(-spawnRadius, spawnRadius), 0);
                
                entityCommandBuffer.SetComponent(enemies[i], new LocalTransform()
                {
                    Position = position,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }

            entityCommandBuffer.Playback(state.EntityManager);
        }

        public void OnDestroy(ref SystemState state)
        {
        }
    }
}