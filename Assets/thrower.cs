using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thrower : MonoBehaviour
{
    //[SerializeField] GameObject objectThrower;
    //[SerializeField] float speed = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destructible")) {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenu");
            
        }
    }
}
//objectThrower.Launch(Camera.main.ScreenToWorldPoint(input.mousePosition));

//old stuff
/*public void Launch()
{
    GameObject newObject = Instantiate(objectThrower, transform.position, Quaternion.identity);
    //Instantiate(objectThrower,transform.position,Quaternion.identity);
    //newObject.transform.rotation =
    //newObject.GetComponent<Rigidbody2D>().velocity = newObject.transform.up * speed;
    Destroy(newObject, 5);
}
private void Start()
{

}*/