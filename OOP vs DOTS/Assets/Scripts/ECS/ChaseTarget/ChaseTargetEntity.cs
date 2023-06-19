using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.ChaseTarget
{
    public class ChaseTargetEntity : MonoBehaviour
    {
        public GameObject ChaserObject;
        public Transform ChaserTransform;
        public float ChaserSpeed;
        public Transform TargetTransform;
    }
    
    public class ChaseTargetBaker : Baker<ChaseTargetEntity>
    {
        public override void Bake(ChaseTargetEntity authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new ChaseTargetComponent
            {
                ChaserObject = GetEntity(authoring.ChaserObject, TransformUsageFlags.Dynamic),
                ChaserTransform = new LocalTransform
                {
                    Position = authoring.ChaserTransform.localPosition,
                    Rotation = authoring.ChaserTransform.localRotation,
                    Scale = authoring.ChaserTransform.localScale.x
                },
                ChaserSpeed = authoring.ChaserSpeed,
                TargetTransform = new LocalTransform
                {
                    Position = authoring.TargetTransform.localPosition,
                    Rotation = authoring.TargetTransform.localRotation,
                    Scale = authoring.TargetTransform.localScale.x
                }
            });
        }
    }
}
