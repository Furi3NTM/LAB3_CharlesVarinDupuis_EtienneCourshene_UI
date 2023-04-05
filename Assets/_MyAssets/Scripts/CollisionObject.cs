using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public Color collisionColor = Color.red; // The color to change to when a collision is detected
    private Color initialColor; // The initial color of the object
    private bool isColliding = false; // Whether the object is currently colliding with another object
    private GameManager gameManager; 

    void Start()
    {
        initialColor = GetComponent<Renderer>().material.color; // Get the initial color of the object
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isColliding)
        {
            isColliding = true;
            GetComponent<Renderer>().material.color = collisionColor; // Change the color of the object on collision
       
            gameManager.AugmenterPointage();

            // Schedule a coroutine to change the color back after 4 seconds
            StartCoroutine(ResetColor());
        }
        
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds

        isColliding = false;
        GetComponent<Renderer>().material.color = initialColor; // Reset the color of the object
    }

}