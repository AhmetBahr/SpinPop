using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBalls : MonoBehaviour
{
    [SerializeField]
    float Counter = 0;
    [SerializeField]
    private int yon = -1;
    [SerializeField]
    private int speed;


    void Start()
    {


    }

    private void Update()
    {


/*
        if (Input.GetMouseButtonDown(0))
        {
       
            turnR();
            
            
        }*/

    }



    public void turnR()
    {

        switch (yon)
        {
            case -1:

                transform.DOMove(new Vector3(-0.7f, 2.5f, 0), 1f);

                yon *= -1;


                break;
            case 1:
                transform.DOMove(new Vector3(0.7f, 2.5f, 0), 1f);

                yon *= -1;

                break;
        }


    }

}
