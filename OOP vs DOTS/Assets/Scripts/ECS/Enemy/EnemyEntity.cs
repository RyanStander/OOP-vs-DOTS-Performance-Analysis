using Unity.Entities;
using UnityEngine;

namespace ECS.Enemy
{
    public class EnemyEntity : MonoBehaviour
    {
        private class Baker : Baker<EnemyEntity>
        {
            public override void Bake(EnemyEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<EnemyComponentData>(entity);
            }
        }
    }

    // A tag component to identify the enemy entities.
    public struct EnemyComponentData : IComponentData
    {
    }
}