using Unity.Mathematics;
using UnityEngine;

namespace OOP.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        private void OnValidate()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            var newPosition = playerTransform.position;
            newPosition.z = transform.position.z;
            transform.position = math.lerp(transform.position, newPosition, 0.1f);
        }
    }
}