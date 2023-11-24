using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlamt : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 EndPos;
    Tween tw;
    private Vector3 offset;
    void Start()
    {
        startPos = transform.GetChild(0).position;
        EndPos = transform.GetChild(1).position;
        float t = Random.Range(0,3f);
        if (Random.Range(0, 2) == 1) {
            Invoke("ToPos", t);

        }
        else
        {
            Invoke("FromPos", t);
        }
       
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(transform);
    //        //float x = 1f / gameObject.transform.localScale.x;
    //        //float y = 1f / gameObject.transform.localScale.y;
    //        //Debug.Log(x);
    //        //Debug.Log(y);
    //        //collision.gameObject.transform.localScale = new Vector3(x * collision.gameObject.transform.localScale.x, collision.gameObject.transform.localScale.y * y, 1);
    //    }
    //}
    private void ToPos()
    {

        tw = transform.DOMove(EndPos, 2f).OnComplete(FromPos);
       
       // transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void FromPos()
    {

        tw = transform.DOMove(startPos, 2f).OnComplete(ToPos);
      //  transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
   

    
}
