using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseEnemy : MonoBehaviour
{
    public int Hp;
    private Animator Anim;
    public bool IsSpecia ;
  
    private bool isReduce = false;
    private Vector3 startPos;
    private Vector3 EndPos;
    Tween tw;
    bool CanReduce = true;
    int JiCi;
    void Start()
    {
        JiCi = Hp;
      //  Anim = transform.GetChild(0).GetComponent<Animator>();
       
        if (gameObject.tag != "Static") {
            startPos = transform.GetChild(0).position;
            EndPos = transform.GetChild(1).position;
            if (Random.Range(0,2) == 1)
            {
                ToPos();
            }
            else
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FromPos();
            }
           
        }
    }

    public void ReduceHp() {
        if (!CanReduce)
        {
            return;
        }
        CanReduce = false;
        Hp -= 1;
        if (Hp <= 0)
        {
            //Anim.SetBool("Explode", true);
            if (IsSpecia)
            {
                SuipianAnim.anim.SetAnim(transform.position);
                GameObject.Find("ScoerAudios").GetComponent<AudioSource>().Play();
            }
            GameManager.Scoer += 1;
            
            if (gameObject.tag == "Static")
            {
                if (JiCi == 1)
                {
                    GameObject.Find("JiFenOne").GetComponent<AudioSource>().Play();
                }
                else if (JiCi == 2)
                {
                    GameObject.Find("JiFenTwo").GetComponent<AudioSource>().Play();
                }
                
                Debug.Log(JiCi);
            }
            Destroy(this.gameObject);
            
         
        }
        else
        {
            //if (gameObject.tag != "Static")
            //{
            //    tw.Pause();
            //    Anim.SetBool("BeHit", true);
            //}
            Debug.Log("Ê£ÓàÑªÁ¿£º" + Hp);
        }

    }

    float CD = 0f;
    private void Update()
    {
        if (!CanReduce)
        {
            CD += Time.deltaTime;
            if ( CD > 0.1f ) {
                CanReduce = true;
                CD = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag != "Static")
        {
            if (collision.gameObject.transform.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.ReduceHp();
            }
        }

    }
        // Update is called once per frame
    

    private void ToPos()
    {

        tw =  transform.DOMove(EndPos, Random.Range(2.5f,3.5f)).OnComplete(FromPos);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void FromPos()
    {

        tw =  transform.DOMove(startPos, Random.Range(2.5f, 3.5f)).OnComplete(ToPos);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
