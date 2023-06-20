using System;
using UnityEngine;

namespace OOP.Player
{
    /// <summary>
    /// Based on the speed value, this will move the 2d sprite either up down left or right on the screen.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private void FixedUpdate()
        {
            //Find the direction to move in based on the input
            var direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector3.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector3.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector3.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right;
            }
            
            //Move the object in the direction of the input by the speed value
            var move = speed * Time.fixedDeltaTime;
            
            transform.position += direction * move;
        }
    }
}
