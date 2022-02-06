using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour , IInteractiveObject
{
    private InteractiveObject interactiveObject;

    [SerializeField]
    private items itemToTake;

    private void Start()
    {
        interactiveObject = gameObject.AddComponent<InteractiveObject>();
        interactiveObject.interactiveObject=this;
    }

    private void YesAction()
    {
        UIController.instance.AllMenuHide();
        InventoryManager.instance.InventoryAddItem(itemToTake);
        gameObject.SetActive(false);
        AudioManager.instance.PlayClick();
        AudioManager.instance.PlayKeyTake();
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
        UIController.instance.DialogSetQuestionText("Take?");
        UIController.instance.DialogAddItem("Yes",YesAction);
        UIController.instance.DialogAddItem("No",NoAction);
        UIController.instance.DialogShowMenu();
    }
    public void ResetObject()
    {
        gameObject.SetActive(true);
        interactiveObject.enabled=true;
    }
}
