using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.InputMove
{
    public partial struct InputMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = Time.deltaTime;

            foreach (RefRW<InputMoveComponent> inputMoveComponent in SystemAPI.Query<RefRW<InputMoveComponent>>())
            {
                Move(ref state, inputMoveComponent, deltaTime);
            }
        }

        private void Move(ref SystemState state, RefRW<InputMoveComponent> inputMoveComponent, float deltaTime)
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

            //Move the object in the direction of the input by the speed value
            var move = inputMoveComponent.ValueRO.Speed * deltaTime;
            inputMoveComponent.ValueRW.Transform.Position += (float3)(direction * move);

            //Set the transform of the object
            state.EntityManager.SetComponentData(inputMoveComponent.ValueRW.Object,
                inputMoveComponent.ValueRW.Transform);
        }


        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}