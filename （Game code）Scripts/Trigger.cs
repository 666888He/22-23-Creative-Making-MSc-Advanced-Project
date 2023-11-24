using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventManager.GetInstance.TriggerEvent(gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
     
        
        
          
            if (collision.gameObject.transform.TryGetComponent<Bat>(out Bat bat))
            {
                
                if (bat.Area == gameObject.name)
                {
                  
                    bat.ReturnPos();

                }
            }
       
        
       
      
    }
}
