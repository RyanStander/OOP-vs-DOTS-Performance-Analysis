using Unity.Entities;

namespace ECS.MovingEntities
{
    public struct Mover : IComponentData
    {
        public Entity Object;
        public float Speed;
    }
}