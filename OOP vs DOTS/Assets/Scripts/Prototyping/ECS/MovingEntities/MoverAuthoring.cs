using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.MovingEntities
{
    /// <summary>
    /// This is the entity of the mover.
    /// </summary>
    public class MoverAuthoring : MonoBehaviour
    {
        public GameObject Object;
        public Transform Transform;
        public float Speed;
    }

    public class MoverBaker : Baker<MoverAuthoring>
    {
        public override void Bake(MoverAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Mover
            {
                //By default, each authoring GameObject turns into an Entity.
                //Given a GameObject (or authoring component), GetEntity looks up the resulting Entity.
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