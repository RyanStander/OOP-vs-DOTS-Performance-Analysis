using Unity.Entities;
using Unity.Transforms;

namespace ECS.InputMove
{
    public struct InputMoveComponent : IComponentData
    {
        public Entity Object;
        public LocalTransform Transform;
        public float Speed;
    }
}