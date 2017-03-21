using UnityEngine;
using System.Collections;

public class Horse_Control : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Animator anim;
    public float speed = 350;
    public int direct = 0;

    //初始化
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if(direct == 0)
        {
            Move(1);
            Direction(0);
        }
        else
        {
            Move(-1);
            Direction(1);
        }


        //左右移動--------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1);
            Direction(0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1);
            Direction(1);
        }
        //-----------------------------------------------------------------------------------
        //停止移動--------------------------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Move(0);
        }
        //-----------------------------------------------------------------------------------

       
    }
    

    //面對方向
    void Direction(int direction)
    {
        transform.eulerAngles = new Vector3(0, 180 * direction, 0);
    }

    //移動
    void Move(int direction)
    {
        rigi.velocity = new Vector2(direction * speed * Time.deltaTime, rigi.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(direction));
    }

  
    //碰撞
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
