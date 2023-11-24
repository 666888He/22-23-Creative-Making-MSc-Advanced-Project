using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;

   
    float Up = 0f;
    float Down = 1f;
    Tween t;
    private void Start()
    {
        Up = door.transform.position.y + 1.5219f;
        Down = door.transform.position.y;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //цебДоб
        CloseDoor();
    }


    public void OpenDoor() {

        t.Kill();

        t = door.transform.DOMoveY(Up, 2f);
        GameObject.Find("DoorOn").GetComponent<AudioSource>().Play();
    }



    public void CloseDoor() {



        t.Kill();
        t = door.transform.DOMoveY(Down, 2f);

    }
}
