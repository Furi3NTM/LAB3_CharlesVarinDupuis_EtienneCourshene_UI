using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] float speed; // The speed at which the wall moves
    [SerializeField] float distance; // The distance the wall moves in either direction
    [SerializeField] bool moveRightFirst; // Whether the wall should start moving to the right or left first

    private float startX; // The starting x-position of the wall
    private int direction = -1; // The direction in which the wall is currently moving (-1 for left, 1 for right)

    void Start()
    {
        startX = transform.position.x; // Get the starting x-position of the wall

        // Set the initial direction based on the 'moveRightFirst' flag
        if (moveRightFirst)
        {
            direction = 1;
        }
        else if(!moveRightFirst)
        {
            direction = -1;
        }
    }

    void Update()
    {
        // Calculate the new x-position of the wall using a sinusoidal function
        float newX = startX + distance * Mathf.Sin(Time.time * speed);

        // Determine if the direction of movement needs to be reversed
        if ((newX - startX) / distance > direction)
        {
            direction *= -1;
        }

        // Set the wall's position to the new x-position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
