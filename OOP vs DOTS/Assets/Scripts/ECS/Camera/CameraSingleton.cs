using UnityEngine;

namespace ECS.Camera
{
    public class CameraSingleton : MonoBehaviour
    {
        public static UnityEngine.Camera Instance;

        private void Awake()
        {
            Instance = GetComponent<UnityEngine.Camera>();
        }
    }
}
