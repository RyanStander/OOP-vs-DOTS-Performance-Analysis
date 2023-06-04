using Unity.Entities;
using UnityEngine;

namespace ECS.MovingEntities
{
    public class MoverAuthoring : MonoBehaviour
    {
        public GameObject Object;
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
                Speed = authoring.Speed
            });
        }
    }
}