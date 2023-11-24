using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuipianAnim : MonoBehaviour
{
    public static SuipianAnim anim;
   
   
    void Start()
    {
        anim = this;
    }


    public void SetAnim(Vector3 pos) {
        ResetState();
        transform.position = pos;
        transform.DOMoveY(pos.y + 0.6f, 0.5f).OnComplete(() => {


            gameObject.SetActive(false);
            GameManager.SuiPian += 1;

        });


    }

    void ResetState() {

        gameObject.SetActive(true);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
