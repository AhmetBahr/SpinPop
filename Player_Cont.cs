using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Cont : MonoBehaviour
{

    [SerializeField]
    float Counter = 0;
    [SerializeField]
    private int yon = -1;
    [SerializeField]
    private float speed;


    //  0 = mavi
    //  1 = mor
    [SerializeField]
    private int colorint = 0;

    public Color[] colors;

    [SerializeField]
    private GameObject gameObject;



    public int WeScore;
    public TextMeshProUGUI textP;
    public bool isDeat = false;


    public void Start()
    {
        GetComponent<Renderer>().material.color = colors[0];
        colorint = 0;
        WeScore = 0;
    }


    private void Update()
    {

        if (isDeat)
        {
            Debug.Log("Öldü");

            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isStart();
        }


        if (yon == 1)
            Counter += Time.deltaTime * speed;

        if (yon == -1)
            Counter += Time.deltaTime * speed * -1;


        float y = Counter;
        float x = 0;
        float z = 0;

        transform.position = new Vector3( x , y, z);

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

        Destroy(gameObject);

    }

    public void isStart()
    {
        speed = 2.5f;

    }

    public void SkorUp()
    {


        
        WeScore++;
        textP.text = WeScore.ToString();


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

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

        Debug.Log(colorint);
    }
  

}
