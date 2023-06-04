using Unity.Entities;
using Unity.Transforms;

namespace ECS.MovingEntities
{
    /// <summary>
    /// This is the component of the mover.
    /// </summary>
    public struct Mover : IComponentData
    {
        public Entity Object;
        public LocalTransform Transform;
        public float Speed;
    }
}