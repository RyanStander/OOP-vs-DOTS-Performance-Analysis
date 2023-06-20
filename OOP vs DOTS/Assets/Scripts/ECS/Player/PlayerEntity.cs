using Unity.Entities;
using UnityEngine;

namespace ECS.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        public class PlayerAuthoringBaker : Baker<PlayerEntity>
        {
            public override void Bake(PlayerEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerComponentData());
            }
        }
    }

    public struct PlayerComponentData : IComponentData
    {
    }
}
