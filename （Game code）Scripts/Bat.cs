using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class Bat : MonoBehaviour
{
    private float speed;
    public int AreaIndex;
    public string Area;
    public int Hp;
   
    bool istoPlayer = false;
    Transform player;
    Animator animator;

    Vector3 StartPos;
    bool CanReduce = true;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        speed = Random.Range(0.6f, 1.2f);
     //   EventManager.GetInstance.StartListening(Area, StartTo);
        animator = GetComponent<Animator>();
        animator.speed = 0;
       
    }

    public void StartTo() {

        if (int.Parse(Area) == AreaIndex) {
            player = GameObject.Find("Player").transform;
            istoPlayer = true;
            animator.speed = 1;
        }
    
    
    }

    public void ReturnPos() {

        transform.DOMove(StartPos, Random.Range(1, 3));
        istoPlayer = false;
    }

  

    // Update is called once per frame
    void Update()
    {
        if (istoPlayer)
        {

            transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * speed);

        }
        
        
    }

    public void Reduce() {

        if (!CanReduce)
        {
            return;
        }
        CanReduce = false;
        Hp -= 1;
        if (Hp <= 0)
        {
            //Anim.SetBool("Explode", true);
            Destroy(transform.parent.gameObject);
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
}
