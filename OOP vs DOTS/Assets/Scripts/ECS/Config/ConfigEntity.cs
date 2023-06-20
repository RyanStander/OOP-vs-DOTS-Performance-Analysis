using Unity.Entities;
using UnityEngine;

namespace ECS.Config
{
    public class ConfigEntity : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public float SafeZoneRadius;
        
        public GameObject SkeletonPrefab;
        public int SkeletonCount=10;

        public class ConfigEntityBaker : Baker<ConfigEntity>
        {
            public override void Bake(ConfigEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity,
                    new ConfigEntityComponentData
                        {
                            PlayerPrefab = GetEntity(authoring.PlayerPrefab, TransformUsageFlags.Dynamic),
                            SafeZoneRadius = authoring.SafeZoneRadius,
                            
                            SkeletonPrefab = GetEntity(authoring.SkeletonPrefab, TransformUsageFlags.Dynamic),
                            SkeletonCount = authoring.SkeletonCount
                        });
            }
        }
    }

    public struct ConfigEntityComponentData : IComponentData
    {
        public Entity PlayerPrefab;
        public float SafeZoneRadius;
        
        public Entity SkeletonPrefab;
        public int SkeletonCount;
    }
}
