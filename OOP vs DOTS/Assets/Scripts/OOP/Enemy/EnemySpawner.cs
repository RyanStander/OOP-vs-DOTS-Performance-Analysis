using UnityEngine;

namespace OOP.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int numberOfEnemies = 10;
        [SerializeField] private float spawnRadius = 3f;
    
        private void Start()
        {
            //spawn enemies in a circle randomly around the spawner
            for (var i = 0; i < numberOfEnemies; i++)
            {
                var spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
