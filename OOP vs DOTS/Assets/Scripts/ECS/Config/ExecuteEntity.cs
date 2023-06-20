using ECS.Camera;
using ECS.Player;
using Unity.Entities;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ECS.Config
{
    public class ExecuteEntity : MonoBehaviour
    {
        [Header("Player"), SerializeField] private bool playerEnabled;

        [Header("Camera"), SerializeField] private bool cameraEnabled;

        [Header("Safe Zone"), SerializeField] private bool safeZoneEnabled;

        [Header("Enemies"), SerializeField] private bool skeletonEnabled;

        public class ExecuteEntityBaker : Baker<ExecuteEntity>
        {
            public override void Bake(ExecuteEntity authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                if(authoring.playerEnabled) AddComponent<PlayerSpawning>(entity);
                if(authoring.playerEnabled) AddComponent<PlayerMovementComponent>(entity);
                
                if (authoring.cameraEnabled) AddComponent<Camera>(entity);
                if (authoring.safeZoneEnabled) AddComponent<SafeZone>(entity);
            }
        }
    }

    public struct Camera : IComponentData
    {
    }

    public struct SafeZone : IComponentData
    {
    }

    public struct PlayerSpawning : IComponentData
    {
    }
    
    public struct PlayerMovementComponent : IComponentData
    {
    }
}