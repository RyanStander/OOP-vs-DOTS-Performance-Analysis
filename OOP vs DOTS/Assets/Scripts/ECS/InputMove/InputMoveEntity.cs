using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.InputMove
{
    public class InputMoveEntity : MonoBehaviour
    {
        public GameObject Object;
        public Transform Transform;
        public float Speed;

        public class InputMoveEntityBaker : Baker<InputMoveEntity>
        {
            public override void Bake(InputMoveEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new InputMoveComponent
                    {
                        Object = GetEntity(authoring.Object, TransformUsageFlags.Dynamic),
                        Transform = new LocalTransform
                        {
                            Position = authoring.Transform.localPosition,
                            Rotation = authoring.Transform.localRotation,
                            Scale = authoring.Transform.localScale.x
                        },
                        Speed = authoring.Speed
                    });
            }
        }
    }
}