using Unity.Entities;
using UnityEngine;

namespace ECS.Config
{
    public class ConfigEntity : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public float SafeZoneRadius;

        public class ConfigEntityBaker : Baker<ConfigEntity>
        {
            public override void Bake(ConfigEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity,
                    new ConfigEntityComponentData
                        {
                            PlayerPrefab = GetEntity(authoring.PlayerPrefab, TransformUsageFlags.Dynamic),
                            SafeZoneRadius = authoring.SafeZoneRadius
                        });
            }
        }
    }

    public struct ConfigEntityComponentData : IComponentData
    {
        public Entity PlayerPrefab;
        public float SafeZoneRadius;
    }
}
