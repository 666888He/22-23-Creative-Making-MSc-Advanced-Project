using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;//���ﱼ���ٶ�
    public float jumpSpeed;//�����һ�ε����ٶ�
    public float doubleJumpSpeed;//����ڶ��ε����ٶ�
    public DataShow data;
    private Rigidbody2D myRigidbody;//�������
    public Animator myAnim;//�������
    private CapsuleCollider2D myFeet;//������ײ�����
    private bool isGround; //��¼���Ƿ�Ӵ�����
    private bool canDoubleJump;//�ж��ܷ���ж�����
    private float moveDir;
    private bool isOnLadder = false;
    private bool bridgeBottom = false;
    private bool bridgeTop = false;
    private bool CanReduce = true;
    public AudioClip RunAudio;
    public AudioClip JumpAudio ;
    public AudioClip AttackAudio;
   // AudioSource audio;



    public AudioSource audio;

    public GameObject RunAudios;
    public enum PlayerState { 
       Idle,
       Move,
       UpDown,
       Attack
    
    
    }


    private void Awake()
    {
        GameManager.PlayerHP = 15;
    }
    public PlayerState state = PlayerState.Idle;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//���ö���ĸ������
      
        myFeet = GetComponent<CapsuleCollider2D>();//���ö�������ײ�����

       // audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float s = Input.GetAxis("Horizontal");
        Run(s);



        Flip();//�����ܶ�ʱ�ز�ˮƽ��ת
        Jump();//ʵ��������Ծ�߼�
        CheckGrounded();//��������Ƿ�Ӵ�����
        SwitchAnimation();//ʵ��������Ծʱ�Ķ����л�
        Bridge();
        SwitchMode();//�л�����ģʽ
    }
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
       
        
      
    }

    public void ReduceHp() {

        if (CanReduce)
        {
            CanReduce = false;
            GameManager.PlayerHP -= 1;
         
            Debug.Log("����");
            if (GameManager.PlayerHP<=0)
            {
                Debug.Log("��Ϸ����");
                data.ShowEnd();


            }
        }





    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "Respawn")
    //    {
    //        this.transform.parent = null;
    //        this.transform.localScale = new Vector3(2, 2, 1);
    //    }
    //}
    public void Atk() {
        Attack = false;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Attack)
        {
 
            if (collision.gameObject.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
            {
                enemy.ReduceHp();
            }
            if (collision.gameObject.TryGetComponent<Door>(out Door door))
            {
                door.OpenDoor();
            }
            if (collision.gameObject.TryGetComponent<Bat>(out Bat bat))
            {
                bat.Reduce();
            }

        }
      //  Debug.Log("���빥����Χ");
        
    }
    void Flip()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (plyerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)//�����˶�
            {
                transform.localScale =  new Vector3(1.5f, 1.5f, 1);
            }
            if (myRigidbody.velocity.x < -0.1f)//�����˶�
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            }
            
        }
    }
    public void Run(float t)
    {
       
        if (OnMove)
        {
            return;
        }
        
        Vector2 playerVel = new Vector2(t * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
       
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", plyerHasXAxisSpeed);

        state = PlayerState.Move;

        RunAudios.SetActive(true) ;
        if (t!=0)
        { PlayAduio(RunAudio);
        }
        else
        {
            RunAudios.SetActive(false);

        }
       
        
    }

    void PlayAduio(AudioClip clip,bool isloop = true) {

        return;
        if (audio.clip == null||audio.clip.name != clip.name) {
            Debug.Log("����");
            audio.loop = isloop;
            audio.clip = clip;
            audio.Play();
        }
    
    
    }
   public  void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !OnMove &&!isOnLadder)
        {
           
          
            if (isGround)//�ڵ����ʱ��һ����
            {
                PlayAduio(JumpAudio,false);
                 Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
                isGround = false;
                myAnim.SetBool("Jump", true);
                myAnim.SetBool("Run", false);
                PlayAduio(JumpAudio,false);

                audio.clip = JumpAudio;
                audio.Play();
            }
            else
            {
                if (canDoubleJump)//�ڿ��пɽ��ж�����
                {
                    PlayAduio(JumpAudio, false);
                    myAnim.SetBool("Jump", true);
                    myAnim.SetBool("Run", false);
                    //   myAnim.SetBool("DoubleJump", true);
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                    myRigidbody.velocity = Vector2.up + doubleJumpVel;
                    canDoubleJump = false;
                    PlayAduio(JumpAudio, false);
                    audio.clip = JumpAudio;
                    audio.Play();
                }
            }
          
        }
           
       
    }
    void SwitchAnimation()
    {

        //myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("Jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)//�����ʼ���� �л����䶯��
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Idle", true);
            }
        }
        else if (isGround)//����䵽������ �л���������
        {
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Idle", true);
           // audio.Stop();
        }
       
    }
    public bool Attack = false;
     float CD = 0f;
     float CDHp = 0f;
    void SwitchMode()
    {
        if (!Attack)
        {
            CD += Time.deltaTime;
            if (CD>=0.1f)
            {
                Attack = true;
                CD = 0;
                myAnim.SetBool("Attack", false);
            }
        }

        if (!CanReduce)
        {
            CDHp += Time.deltaTime;
            if (CDHp >= 2f)
            {
                CanReduce = true;
                CDHp = 0;

            }

        }

        if (Input.GetKeyDown(KeyCode.Q) && Attack)
        {
            myAnim.SetBool("Attack", true);

            PlayAduio(AttackAudio,false);

            audio.clip = AttackAudio;
            audio.Play();


        }

    }
    float distance = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "Bridge")
        {
           
            isOnLadder = true;
           
            distance = collision.gameObject.transform.GetChild(0).transform.position.y - collision.gameObject.transform.GetChild(1).transform.position.y;
        }
        else

        if (collision.tag == "BridgeBottom")
        {
            bridgeBottom = true;
           
        }
        else

        if (collision.tag == "BirdgeTop")
        {
            bridgeTop = true;
          
          
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bridge")
        {
            isOnLadder = false;

           
        }else
        if (collision.tag == "BridgeBottom")
        {
            bridgeBottom = false;

        }else
        if (collision.tag == "BridgeTop")
        {
            bridgeTop = false;
         
           
        }
    }
    bool OnMove = false;
    private void Bridge() {

        if (isOnLadder)
        {
            if (bridgeTop)
            {

                if (Input.GetKeyDown(KeyCode.S) && !OnMove)
                {
                    OnMove = true;
                    // myFeet.isTrigger = true;
                    myAnim.SetBool("ladder", true);

                    transform.DOMove(new Vector3(transform.position.x, transform.position.y - distance, transform.position.z), 1f).OnComplete(() => { OnMove = false; bridgeTop = false; bridgeBottom = true; myAnim.SetBool("ladder", false); });
                }

            }
            else if (bridgeBottom)
            {

                if (Input.GetKeyDown(KeyCode.W) && !OnMove)
                {
                    OnMove = true;
                    myAnim.SetBool("ladder", true);
                    transform.DOMove(new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), 1f).OnComplete(() => { OnMove = false; bridgeTop = true; bridgeBottom = false; myAnim.SetBool("ladder", false); });
                }
            }
        }
       
           

        
    
    
    }

   
}