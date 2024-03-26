using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the movement
    private Vector3 startPosition;
    private float screenWidth;

    void Start()
    {
        if (Camera.main != null)
        {
            startPosition = transform.position;
            screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }
        else
        {
            Debug.LogError("Main Camera not found. Please ensure your camera is tagged as 'Main Camera'.");
        }

    }

    void Update()
    {
        // Move the object to the right each frame
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Check if the object has moved off the right side of the screen
        if (transform.position.x - transform.localScale.x / 2 > screenWidth)
        {
            // If so, move it back to the left side
            transform.position = new Vector3(-screenWidth - transform.localScale.x / 2, startPosition.y, startPosition.z);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Creature>() != null)
        {
            tokenCounter.singleton.DecreaseCoin();
            Destroy(this.gameObject);
            //Pickup();
        }
        Debug.Log("Trigger entered by: " + other.gameObject.name);
    }
}