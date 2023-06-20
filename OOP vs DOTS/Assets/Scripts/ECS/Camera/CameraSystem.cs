using ECS.Player;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.Camera
{
    public partial struct CameraSystem : ISystem
    {
        private Entity target;
        private Random random;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Config.Camera>();
            random = new Random(123);
        }

        // Because this OnUpdate accesses managed objects, it cannot be Burst-compiled.
        public void OnUpdate(ref SystemState state)
        {
            if (target == Entity.Null)
            {
                var entityQuery = SystemAPI.QueryBuilder().WithAny<PlayerComponentData>().Build();
                var player = entityQuery.ToEntityArray(Allocator.Temp);
                
                if (player.Length == 0)
                    return;
                target = player[random.NextInt(player.Length)];
            }

            var cameraTransform = CameraSingleton.Instance.transform;
            var cameraPosition = cameraTransform.position;
            var playerPosition = SystemAPI.GetComponent<LocalToWorld>(target).Position;

            var newPosition =math.lerp(cameraPosition,playerPosition, 0.1f);
            newPosition.z = -1;
            
            cameraTransform.position = newPosition;
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}