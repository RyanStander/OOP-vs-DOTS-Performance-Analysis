using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.MovingEntities
{
    public struct Movement: IComponentData
    {
        public float3 position;
        public float3 direction;
        public float speed;
    }
    
    /*[System.Serializable]
    public struct MoveEntityInDirectionComponent : IComponentData
    {
        public float3 direction;
    }
    
    [System.Serializable]
    public struct MovementSpeedComponent : IComponentData
    {
        public float speed;
    }

    public class Movement : MonoBehaviour
    {
        public MovementSpeedComponent speed;
        public MoveEntityInDirectionComponent direction;
    }
    
    public class MovementBaker : Baker<Movement>
    {
        public override void Bake(Movement authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            
            AddComponent(entity,authoring.speed);
            AddComponent(entity,authoring.direction);
        }
    }

    public readonly partial struct MovementInDirectionAspect : IAspect
    {
        public readonly RefRO<MoveEntityInDirectionComponent> moveInDirection;
        public readonly RefRO<MovementSpeedComponent> movementSpeed;
    }*/
}
