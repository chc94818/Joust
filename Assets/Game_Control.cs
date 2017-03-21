using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Game_Control : MonoBehaviour {
    public GameObject ground;
    public GameObject Lancer;

    public float mapEnd=30;
    public float mapLength=20;
    public GameObject Player;
    private Horse_Control p;
    private float CYCLE_Time = 0.7f;
    private float CYCLE_CD = -0.5f;

    public Text ScoreText; //宣告一個ScoreText的text

    public int Score = 0; // 宣告一整數 Score

    public static Game_Control Instance; // 設定Instance，讓其他程式能讀取GameFunction
  
    public GameObject GameOverTitle; //宣告GameOverTitle物件
   
    public bool IsPlaying = true; // 宣告IsPlaying 的布林資料，並設定初始值false
    bool isAttack = false;
    bool isDefence = false;
    float width = Screen.width;
    
    //初始化
    private void Awake()
    {
       
        p = Player.GetComponent<Horse_Control>();
    }
    // Use this for initialization
    void Start () {
        
        Instance = this;
        GameOverTitle.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        #if UNITY_ANDROID 
                MobileInput();
        #endif
        if (IsPlaying)
        {
            if (isAttack)
            {
                p.GetComponentInChildren<Knight_Control>().Attack();
            }
            if (isDefence)
            {
                p.GetComponentInChildren<Knight_Control>().Defence();
            }

            GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (gameObject.transform.position.x - Enemy[i].transform.position.x > 30)
                {
                    Destroy(Enemy[i], 3);
                }
            }

            CYCLE_CD += Time.deltaTime;
            if (CYCLE_CD > CYCLE_Time)
            {
                CYCLE_CD = 0;
                CreatLancer();
            }


            gameObject.transform.position = p.transform.position;
            if (mapEnd - p.transform.position.x < mapLength)
            {
                CreatMap();
            }
        }
       
	}
    void MobileInput()
    {
        if (IsPlaying)
        {
            if (Input.touchCount == 1)
            {
                Debug.Log(Input.touches[0].position.x);
                //開始觸碰
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    if (Input.touches[0].position.x < width / 2)
                    {
                        isAttack = true;
                    }
                    else if (Input.touches[0].position.x > width / 2)
                    {
                        isDefence = true;
                    }

                    //手指移動
                }
                else if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    if (Input.touches[0].position.x < width / 2)
                    {
                        isAttack = true;
                    }
                    else if (Input.touches[0].position.x > width / 2)
                    {
                        isDefence = true;
                    }
                }


                //手指離開螢幕
                if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    if (Input.touches[0].position.x < width / 2)
                    {
                        isAttack = false;
                    }
                    else if (Input.touches[0].position.x > width / 2)
                    {
                        isDefence = false;
                    }
                }
            }
        }
        else
        {
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    GameStart();
                }
            }
        }
        
        
    }

    public void GameStart()
    {

        IsPlaying = true;
        GameOverTitle.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);

    }
    public void GameOver() //GameOver的Function

    {
        IsPlaying = false; //IsPlaying設定成false
        Camera_Control.Instance.Stop();
        GameOverTitle.SetActive(true); //GameOverTitle設定為ture

    }
    public void AddScore()

    {

        Score += 10; //分數+10

        ScoreText.text = "Score : " + Score; // 更改ScoreText的內容

    }

    public void Attack()
    {
        if (isAttack)
        {
            isAttack = false;
        }else
        {
            isAttack = true;
        }
    }

    public void Defence()
    {

        if (isDefence)
        {
            isDefence = false;
        }
        else
        {
            isDefence = true;
        }
    }




    void CreatMap()
    {
        Vector3 pos = new Vector3(mapEnd + mapLength/2, 0, 0);
        mapEnd += mapLength;
        Instantiate(ground, pos, gameObject.transform.rotation);
    }

    void CreatLancer()
    {
        Vector3 pos = new Vector3(p.transform.position.x+mapLength, -2.4f, 0);
        Instantiate(Lancer, pos, gameObject.transform.rotation);
    }
}
