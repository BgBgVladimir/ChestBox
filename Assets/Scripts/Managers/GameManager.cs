using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        UIController.instance.MainShowMenu();
    }
    
    public float gameTimer;

    public void InitNewGame()
    {
        AudioManager.instance.BackGroundGamePlay();
        InventoryManager.instance.InventoryReset();
        RoomManager.instance.RoomReset();
        PlayerManager.instance.PlayerReset();
        UIController.instance.AllMenuHide();
        UIController.instance.GameTimerShow();
        gameTimer=Time.time;
    }
    public void EndGame()
    {
        AudioManager.instance.BackGroundMainMenuPlay();
        PlayerManager.instance.enabled=false;

        gameTimer=Time.time-gameTimer;
        PlayerPrefs.SetFloat("CurrentTime",gameTimer);
        if(!PlayerPrefs.HasKey("BestTime")) PlayerPrefs.SetFloat("BestTime",gameTimer);

        float bestTime = PlayerPrefs.GetFloat("BestTime",0f);
        if(gameTimer<bestTime) PlayerPrefs.SetFloat("BestTime",gameTimer);
        UIController.instance.GameTimerHide();
        UIController.instance.GameEndShowMenu();
    }
}
