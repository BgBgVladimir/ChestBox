using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public UnityAction action;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(action);
    }
}
