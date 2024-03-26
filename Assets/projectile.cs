using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the horizontal movement
    public float verticalSpeed = 5.0f; // Speed of the vertical movement
    public float amplitude = 1.0f; // Height of the vertical movement

    private Vector3 startPosition;
    private float screenWidth;
    private float time;

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
        time = 0f;
    }

    void Update()
    {
        // Increment time
        time += Time.deltaTime;

        // Move the object to the right each frame
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Add vertical movement based on a sine wave
        float newY = Mathf.Sin(time * verticalSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + newY, transform.position.z);

        // Check if the object has moved off the right side of the screen
        if (transform.position.x - transform.localScale.x / 2 > screenWidth)
        {
            // If so, move it back to the left side and reset the time to keep the movement smooth
            transform.position = new Vector3(-screenWidth - transform.localScale.x / 2, startPosition.y, startPosition.z);
            time = 0f; // Resetting time to avoid sudden jump in vertical position
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Creature>() != null)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        Debug.Log("Trigger entered by: " + other.gameObject.name);
    }
}

