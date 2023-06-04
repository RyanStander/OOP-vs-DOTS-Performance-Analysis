using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.MovingEntities
{
    public class MovementAuthoring : MonoBehaviour
    {
        public float3 direction= new Vector3(1,0,1);
        public float speed=4;
    }

    public class MovementBaker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Movement
            {
                position = authoring.transform.position,
                direction = authoring.direction,
                speed = authoring.speed
            });
        }
    }
}