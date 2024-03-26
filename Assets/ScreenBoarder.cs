using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoarder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player collides with the screen boundary, stop its movement
        if (collision.gameObject.CompareTag("Destructible"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
