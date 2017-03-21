using UnityEngine;
using System.Collections;

public class Ground_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Knight")
        {
            Debug.Log("!!!!!");
        }
    }

  

}
