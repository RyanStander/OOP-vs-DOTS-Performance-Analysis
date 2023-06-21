using UnityEngine;

namespace OOP.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int numberOfEnemies = 10;
        [SerializeField] private float spawnRadius = 3f;
        [SerializeField] private uint randomSeed = 123;
    
        private void Start()
        {
            var random = new Unity.Mathematics.Random(randomSeed);
            
            //spawn enemies in a circle randomly around the spawner
            for (var i = 0; i < numberOfEnemies; i++)
            {
                var position = new Vector3(random.NextFloat(-spawnRadius, spawnRadius),
                    random.NextFloat(-spawnRadius, spawnRadius), 0);
                
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }
}
