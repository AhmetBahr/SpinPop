using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private int Bgcolorint = 0;
    public Color[] colors;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void BgRandomColor()
    {

        //  Bgcolorint = Random.Range(0, 5);

        Bgcolorint++;

        switch (Bgcolorint)
        {
            case 0:
                GetComponent<Renderer>().material.color = colors[0];
                break;
            case 1:
                GetComponent<Renderer>().material.color = colors[1];
                break;
            case 2:
                GetComponent<Renderer>().material.color = colors[2];
                break;
            case 3:
                GetComponent<Renderer>().material.color = colors[3];
                break;
            case 4:
                GetComponent<Renderer>().material.color = colors[4];
                break;
            case 5:
                GetComponent<Renderer>().material.color = colors[5];
                break;
            case 6:
                GetComponent<Renderer>().material.color = colors[6];
                break;
            case 7:
                GetComponent<Renderer>().material.color = colors[7];
                Bgcolorint=-1;
                break;


        }
        Debug.Log(Bgcolorint);
    }

}
