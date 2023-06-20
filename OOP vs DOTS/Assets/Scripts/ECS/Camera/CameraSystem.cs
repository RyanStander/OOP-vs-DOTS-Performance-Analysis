using ECS.InputMove;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Windows;
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
            state.RequireForUpdate<UnityEngine.Camera>();
            random = new Random(123);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (target == Entity.Null)
            {
                var entityQuery = SystemAPI.QueryBuilder().WithAny<InputMoveComponent>().Build();
                var player = entityQuery.ToEntityArray(Allocator.Temp);

                if (player.Length == 0)
                    return;

                target = player[random.NextInt(player.Length)];
            }

            var cameraTransform = CameraSingleton.Instance.transform;
            var playerTransform = SystemAPI.GetComponent<LocalToWorld>(target);
            cameraTransform.position = playerTransform.Position;
            /*cameraTransform.position -= 10.0f * (Vector3)playerTransform.Forward;
            cameraTransform.position += new Vector3(0, 5f, 0);
            cameraTransform.LookAt(playerTransform.Position);*/
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}