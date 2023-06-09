using ECS.Config;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace ECS.Player
{
    /// <summary>
    /// This system will only run once.
    /// </summary>
    public partial struct PlayerSpawningSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerSpawning>();
            state.RequireForUpdate<ConfigEntityComponentData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var config = SystemAPI.GetSingleton<ConfigEntityComponentData>();

            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            var players= new NativeArray<Entity>(1, Allocator.Temp);
            entityCommandBuffer.Instantiate(config.PlayerPrefab, players);

            entityCommandBuffer.Playback(state.EntityManager);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}