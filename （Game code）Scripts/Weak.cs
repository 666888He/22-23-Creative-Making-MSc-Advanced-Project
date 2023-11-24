using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    public DataShow data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(YanShi());
            
        }
    }

    IEnumerator YanShi()
    {
        yield return new WaitForSeconds(3);
        data.ShowEnd();
    }
}
