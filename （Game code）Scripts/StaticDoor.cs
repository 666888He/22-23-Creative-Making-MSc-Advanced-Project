using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDoor : MonoBehaviour
{

    private PlayerController player;
    public Door door;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    //public  void OnCollisionStay2D(Collision2D collision)
    //{

    //    if (player.state == PlayerController.PlayerState.Attack && player.Attack && collision.gameObject.tag == "Player")
    //    {

    //        door.OpenDoor();


    //    }

    //}
    public void OpenDoor() {

        door.OpenDoor();
    }
   
}
