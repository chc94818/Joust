using UnityEngine;
using System.Collections;

public class Lance_Control : MonoBehaviour {
    
    //初始化
    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DEF--------------------------------------------------------------------------
       
        
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
