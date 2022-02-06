using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private Button startButton, exitButton;
    [SerializeField]
    private Text bestTime;

    [SerializeField]
    private GameObject DialogMenu;
    [SerializeField]
    private GameObject answersContainer;
    [SerializeField]
    private GameObject answerPrefab;
    [SerializeField]
    private Text questionText;
    
    [SerializeField]
    private GameObject GameEndMenu;
    [SerializeField]
    private Button tryAgainButton, exitButton2;
    [SerializeField]
    private Text bestTime2, currentTime;

    [SerializeField]
    private Text gameTimer;

    private void Awake()
    {
        instance=this;
        startButton.onClick.AddListener(ButtonStart);
        exitButton.onClick.AddListener(ButtonExit);

        tryAgainButton.onClick.AddListener(ButtonStart);
        exitButton2.onClick.AddListener(ButtonExit);
    }

    private void Start()
    {
        MainShowMenu();
    }

    private void Update()
    {
        gameTimer.text=FormatTime(Time.time - GameManager.instance.gameTimer);
    }
    public void AllMenuHide()
    {
        MainMenu.SetActive(false);
        DialogMenu.SetActive(false);
        GameEndMenu.SetActive(false);
    }

    public void MainShowMenu()
    {
        bestTime.text=$"Best Time: {FormatTime(PlayerPrefs.GetFloat("BestTime",0f))}";
        AllMenuHide();
        MainMenu.SetActive(true);
    }
    public void DialogShowMenu()
    {
        AllMenuHide();
        DialogMenu.SetActive(true);
    }
    public void GameEndShowMenu()
    {
        bestTime2.text=$"Best Time: {FormatTime(PlayerPrefs.GetFloat("BestTime",0f))}";
        currentTime.text=$"Current Time: {FormatTime(PlayerPrefs.GetFloat("CurrentTime",0f))}";
        AllMenuHide();
        GameEndMenu.SetActive(true);
    }
    public void GameTimerShow()
    {
        gameTimer.gameObject.SetActive(true);
    }
    public void GameTimerHide()
    {
        gameTimer.gameObject.SetActive(false);
    }

    public void DialogAddItem(string answer, UnityAction action)
    {
        GameObject newButton = GameObject.Instantiate(answerPrefab,answersContainer.transform);
        AnswerButton answerButton = newButton.GetComponent<AnswerButton>();
        answerButton.answerText.text=answer;
        answerButton.action=action;
    }
    public void DialogSetQuestionText(string _questionText)
    {
        questionText.text=_questionText;
    }

    public void DialogClearAnswersContainer()
    {
        for(int i=0; i<answersContainer.transform.childCount;i++)
        {
            Destroy(answersContainer.transform.GetChild(i).gameObject);
        }
    }

    private void ButtonStart()
    {
        GameManager.instance.InitNewGame();
    }
    private void ButtonExit()
    {
        Application.Quit();
    }

    private string FormatTime(float time)
    {
        int minutes = (int)time/60;
        int seconds = (int)time%60;
        return string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}