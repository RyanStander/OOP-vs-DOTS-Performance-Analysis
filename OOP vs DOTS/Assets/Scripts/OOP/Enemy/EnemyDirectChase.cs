using System;
using UnityEngine;

namespace OOP.Enemy
{
    /// <summary>
    /// The enemy will move directly towards the player at a constant speed.
    /// </summary>
    public class EnemyDirectChase : MonoBehaviour
    {
        [SerializeField] private float speed = 0.5f;
        
        private Transform playerTransform;
        private void Awake()
        {
            //find player by player tag
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        private void FixedUpdate()
        {
            //find the direction to move in
            var direction = playerTransform.position - transform.position;
            direction.Normalize();
            
            //move the enemy in the direction of the player by the speed value
            var move = speed * Time.fixedDeltaTime;
            transform.position += direction * move;
        }
    }
}
