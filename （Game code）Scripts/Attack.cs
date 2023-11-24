using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayerController player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void Atk() {

        player.Atk();


    }
}
