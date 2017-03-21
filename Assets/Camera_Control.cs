using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {
    public GameObject Player;
    private Horse_Control p;
    public float x_offset = 5f;
    public static Camera_Control Instance; // 設定Instance，讓其他程式能讀取GameFunction
    public bool IsPlaying = true;
    //初始化
    private void Awake()
    {
        p = Player.transform.GetComponent<Horse_Control>();
    }
    // Use this for initialization
    void Start () {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (IsPlaying)
        {
            transform.position = new Vector3(p.transform.position.x + x_offset, transform.position.y, -10);

        }
    }

    public void Stop()
    {
        IsPlaying = false;
    }
    

}
