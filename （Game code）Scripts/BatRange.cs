using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.GetChild(0).GetComponent<Bat>().StartTo();
        }
    }
}
