using Unity.Entities;
using Unity.Transforms;

namespace ECS.ChaseTarget
{
    public struct ChaseTargetComponent : IComponentData
    {
        public Entity ChaserObject;
        public LocalTransform ChaserTransform;
        public float ChaserSpeed;
        public LocalTransform TargetTransform;
    }
}
