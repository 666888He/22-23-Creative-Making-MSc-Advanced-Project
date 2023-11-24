using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody)) {

            rigidbody.drag += 2f;
            if (collision.gameObject.tag =="SwimPool")
            {
                rigidbody.gravityScale -= 0.5f;
            }
           
           
        }
        if (collision.transform.tag == "Player")
        {
            GameObject.Find("WaterAudio").GetComponent<AudioSource>().Play();
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {

            rigidbody.drag -= 2f;
            if (collision.gameObject.tag == "SwimPool")
            {
                rigidbody.gravityScale += 0.5f;
                rigidbody.AddForce(new Vector2(0,-0.2f));
               
            }
            

        }


       
    }
}
