using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Creature>() != null)
        {
            other.GetComponent<Creature>().PickupCoin();
            Destroy(this.gameObject);
            //Pickup();
        }

    }
    /*void Pickup() {
        GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
        tokenCounter.singleton.UpdateCoin();
    }*/

}
