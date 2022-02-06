using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour , IInteractiveObject
{
    private InteractiveObject interactiveObject;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private items neededItem;

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
        GameManager.instance.EndGame();
        InventoryManager.instance.InventoryRemoweItem(neededItem);
        AudioManager.instance.PlayClick();
        AudioManager.instance.PlayGameEnd();
    }
    private void NoAction()
    {
        UIController.instance.AllMenuHide();
        AudioManager.instance.PlayClick();
    }
    private void OkAction()
    {
        UIController.instance.AllMenuHide();
        AudioManager.instance.PlayClick();
    }

    public void OnClick()
    {
        AudioManager.instance.PlayClick();
        if(InventoryManager.instance.InventoryHasItem(neededItem)) HasKey();
        else HasNotKey();
    }
    void HasNotKey()
    {
        UIController.instance.DialogClearAnswersContainer();
        UIController.instance.DialogSetQuestionText("You need a key!");
        UIController.instance.DialogAddItem("Ok",OkAction);
        UIController.instance.DialogShowMenu();
    }
    void HasKey()
    {
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
