using UnityEngine;
using System.Collections;

public class Knight_Control : MonoBehaviour
{
    private Lance_Control lance;
    private Animator anim_lance;
    private Animator anim_knight;

    public float DEF_CD = 1;
    public float DEF_TIME = 0.3f;
    public float ATK_CD = 1;
    public float ATK_TIME = 0.3f;
    public static Knight_Control Instance; // 設定Instance

    //初始化
    private void Awake()
    {
        lance = GetComponentInChildren<Lance_Control>();
        anim_knight = GetComponent<Animator>();
        anim_lance = lance.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DEF--------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.Z))
        {
            Defence();
        }

        if (Input.GetKey(KeyCode.X))
        {
            Attack();
        }

        StateMachine();
    }
    //動畫狀態機
    void StateMachine()
    {
        DEF_CD += Time.deltaTime;
        ATK_CD += Time.deltaTime;
        if (DEF_CD > 0)
        {
            anim_knight.SetFloat("Defence", 0);
        }
        //動畫狀態機
      
        if (ATK_CD > 0)
        {
            lance.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }

    }


    //DEF
    public void Defence()
    {
        if (DEF_CD > DEF_TIME)
        {
            DEF_CD = DEF_TIME*-1;
            anim_knight.SetFloat("Defence", 1);
        }
    }
    //ATk
    public void Attack()
    {
        if (ATK_CD > ATK_TIME)
        {
            ATK_CD = ATK_TIME * -1;
            anim_lance.SetTrigger("Attack");
            lance.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    //碰撞
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Lance")
        {
            if (DEF_CD < 0)
            {

                col.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                Debug.Log("!!");
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 200));
                Destroy(gameObject.GetComponent<Collider2D>());
                Destroy(gameObject, 3);
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Lance")
        {
            if (DEF_CD < 0)
            {

                col.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                Debug.Log("!!");
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 200));
                Destroy(gameObject.GetComponent<Collider2D>());
                Destroy(gameObject, 1);
                Invoke("GameOver", 0.5F);
               ;
            }
        }
    }

    void GameOver()
    {
        Game_Control.Instance.GameOver();
    }

    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            rigi.velocity = new Vector2(0, rigi.velocity.y);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }*/
}
