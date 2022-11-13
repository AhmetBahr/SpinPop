using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public RectTransform playerMenu, shopMenu, settingsMenu, startMenu;

    void Start()
    {
     //   playerMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    void Update()
    {
        
    }

    public void ShopMenu()
    {
        playerMenu.DOAnchorPos(new Vector2(-1100,0), 0.25f);
        startMenu.DOAnchorPos(new Vector2(-1100, 0), 0.25f);

        shopMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);

    }

    public void NonShopMenu()
    {
        playerMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        startMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);

        shopMenu.DOAnchorPos(new Vector2(1100, 0), 0.25f);

    }

    public void SettingMenu()
    {
        playerMenu.DOAnchorPos(new Vector2(1100, 0), 0.25f);
        startMenu.DOAnchorPos(new Vector2(1100, 0), 0.25f);

        settingsMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void NonSettingMenu()
    {
        playerMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        startMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);

        settingsMenu.DOAnchorPos(new Vector2(-1100, 0), 0.25f);
      
    }

    public void startGame()
    {
        startMenu.DOAnchorPos(new Vector2(0, -2400), 0.5f);


    }

    public void stopGame()
    {
        startMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }

}
