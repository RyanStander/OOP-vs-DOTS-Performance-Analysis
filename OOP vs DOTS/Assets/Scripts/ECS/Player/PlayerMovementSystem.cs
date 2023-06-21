using ECS.Config;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.Player
{
    public partial struct PlayerMovementSystem : ISystem
    {
        
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerMovementComponent>();
        }  
        
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = Time.deltaTime;

            foreach (var (transform, entity) in
                     SystemAPI.Query<RefRW<LocalTransform>>()
                         .WithAll<PlayerComponentData>()
                         .WithEntityAccess())
            {
                Move(ref state, transform, deltaTime);
            }
        }

        private void Move(ref SystemState state, RefRW<LocalTransform> transform, float deltaTime)
        {
            //Find the direction to move in based on the input
            var direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector3.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector3.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector3.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right;
            }

            const float speed = 1f;
            
            //Move the object in the direction of the input by the speed value
            var move = speed * deltaTime;
            transform.ValueRW.Position += (float3)(direction * move);

            /*//Set the transform of the object
            state.EntityManager.SetComponentData(transform.ValueRW.Object,
                transform.ValueRW.Transform);*/
        }
    }
}