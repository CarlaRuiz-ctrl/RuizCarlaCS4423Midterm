using System.Collections;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] Vector3 homePosition = new Vector3(0, -4, 0);
    [SerializeField] float originalSpeed = 2.0f;
    [SerializeField] float speed;
    bool isSpeedBoosted = false;
    Vector3 movementDirection = Vector3.left;

    void Start()
    {
        speed = originalSpeed; 
    }

    void Update()
    {
        Movement(movementDirection); 
    }

    public void Movement(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void PickupCoin()
    {
        
        tokenCounter.singleton.UpdateCoin();
        GetComponent<AudioSource>().Play();
        IncreaseSpeed(1.0f, 3.0f); // Increase speed temporarily
    }

    void IncreaseSpeed(float amount, float duration)
    {
        if (!isSpeedBoosted) // Only apply if not already boosted
        {
            isSpeedBoosted = true;
            speed += amount;
            StartCoroutine(SpeedBoostDuration(duration));
        }
    }

    IEnumerator SpeedBoostDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = originalSpeed; 
        isSpeedBoosted = false; // Allow speed boost to be applied again
    }
}

