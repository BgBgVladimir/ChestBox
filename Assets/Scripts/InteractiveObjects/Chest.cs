using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour , IInteractiveObject
{
    private InteractiveObject interactiveObject;

    [SerializeField]
    private Animator animator;


    private void Start()
    {
        interactiveObject = gameObject.AddComponent<InteractiveObject>();
        interactiveObject.interactiveObject=this;
    }
    private void YesAction()
    {
        animator.Play("Open");
        interactiveObject.enabled=false;
        UIController.instance.AllMenuHide();
        GetComponent<BoxCollider>().enabled=false;
        AudioManager.instance.PlayClick();
        AudioManager.instance.PlayChestOpen();
    }
    private void NoAction()
    {
        UIController.instance.AllMenuHide();
        AudioManager.instance.PlayClick();
    }
    public void OnClick()
    {
        AudioManager.instance.PlayClick();
        UIController.instance.DialogClearAnswersContainer();
        UIController.instance.DialogSetQuestionText("Open?");
        UIController.instance.DialogAddItem("Yes",YesAction);
        UIController.instance.DialogAddItem("No",NoAction);
        UIController.instance.DialogShowMenu();
    }
    public void ResetObject()
    {
        gameObject.SetActive(true);
        animator.Play("Reset");
        if(TryGetComponent(out RandomPlacer randomPlacer)) randomPlacer.RePlace();
        if(TryGetComponent(out BoxCollider collider)) collider.enabled=true;
        interactiveObject.enabled=true;
    }
}
