using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player_Cont : MonoBehaviour
{

    [SerializeField]
    float Counter = 0;
    [SerializeField]
    private int yon;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float BgScore;

    private float upSpeed = 0.1f;

    //  0 = mavi
    //  1 = mor
    [SerializeField]
    private int colorint;

    public Color[] colors;

    [SerializeField]
    private GameObject gameObject;

    public int WeScore;
    public TextMeshProUGUI textP;

    public bool isDeat = false;
    public bool isPlay;

    public float level = 1;
    public Button OnPlayButton;

   

    MenuScript Referans_Kod1;
    UpBalls Referans_Kod2;
    DownBalls Referans_Kod3;


    public void Start()
    {
        GetComponent<Renderer>().material.color = colors[1];
        yon = 1;
        WeScore = 0;
        colorint = 1;
        speed = 3f;
        isPlay = false; 
        Referans_Kod1 = GameObject.Find("Bg").GetComponent<MenuScript>();
        Referans_Kod2 = GameObject.Find("Up").GetComponent<UpBalls>();
        Referans_Kod3 = GameObject.Find("Down").GetComponent<DownBalls>();

    }


    private void Update()
    {

        if (!isPlay)
        {
            Debug.Log("Öldü");

            return;
        }

        if (yon == 1)
            Counter += Time.deltaTime * speed;

        if (yon == -1)
            Counter += Time.deltaTime * speed * -1;


        float y = Counter;
        float x = 0;
        float z = 0;

        transform.position = new Vector3( x , y, z);


        if(BgScore == 3)
        {
            Referans_Kod1.BgRandomColor();
            BgScore = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)     //COLLIDER 
    {
        if (collision.gameObject.tag == "ScoreBallsB")      // MAVI TOP ICIN
        {
          
            if(colorint == 0)                                  //DOGRU RENK (MAVI)
            {
              //  Debug.Log("Touch Blue");

                yon *= -1;
                SkorUp();
                LevelUp();
                StartCoroutine(Wait()); 

            }


            if (colorint == 1)                                 //YANLIS RENK (PEMBE)
            {
                WeScore--;
                deat();
            }

        }
   
        if (collision.gameObject.tag == "ScoreBallsP")          // MOR RENK ICIN
        {
            if(colorint == 1)                                       //DOGRU RENK (MOR)
            {
              //  Debug.Log("Touch purple");

                yon *= -1;
                SkorUp();
                LevelUp();
                StartCoroutine( Wait()) ;
            }
                
            if (colorint == 0)                                        //YANLIS RENK
            {
                WeScore--;
                deat();
            }

        }
      
    }

    public void deat()
    {
        /*  isDeat = true;
          if (PlayerPrefs.GetFloat("HighScore") < WeScore)
          {
              PlayerPrefs.SetFloat("HighScore", WeScore);
          }
          if (0 < Money)
          {
              PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money", Money) + Money);
          }
        */


        //  dtmenu.ToogleMenu(WeScore);

        //   AdMob.ShowInterstitial();

        //Destroy(gameObject);
        isPlay = false;
        yon = 1;
        WeScore = 0;
        speed = 3f;
        transform.position = new Vector3(0, 0, 0);
        colorint = 1;
       

    }

    public void isStart()
    {
        isPlay = true;
       // OnPlayButton.enabled = false;
    }

    public void SkorUp()
    {
        BgScore++;
        WeScore++;
        textP.text = WeScore.ToString();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.05f);

        RandomColor();  

    }

    public void RandomColor()
    {

        colorint = Random.Range(0, 2);

        switch (colorint)
        {
            case 0:
                GetComponent<Renderer>().material.color = colors[0];
                break;
            case 1:
                GetComponent<Renderer>().material.color = colors[1];
                break;
        }

    //    Debug.Log(colorint);
    }
  
    public void LevelUp()
    {

        if (speed >= 5f)
        {
            speed = 5;
        }
        else 
        {
            speed += upSpeed;
        }

    }


    public void BallsMovie()
    {
        Referans_Kod2.turnR();
        Referans_Kod3.turnR();  

    }


}
