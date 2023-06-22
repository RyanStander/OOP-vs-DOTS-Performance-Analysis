﻿using ECS.Config;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Enemy
{
    public struct SpawnPosition : IComponentData
    {
        public float3 Value;
    }

    [RequireMatchingQueriesForUpdate]
    public partial class EcsSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            // Local variable captured in ForEach
            var random = new Random(123);
            var spawnRadius = 3f;

            Entities
                .ForEach(
                    (ref SpawnPosition position, in SkeletonSpawning skeletonSpawning) =>
                    {
                        position = new SpawnPosition()
                        {
                            Value = new float3(random.NextFloat(-spawnRadius, spawnRadius),
                                random.NextFloat(-spawnRadius, spawnRadius), 0)
                        };
                    }
                )
                .ScheduleParallel();
        }
    }
}