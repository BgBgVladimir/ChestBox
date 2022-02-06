using UnityEngine;
using UnityEngine.EventSystems;

public interface IInteractiveObject
{
    public void OnClick();
    public void ResetObject();
}

public class InteractiveObject:MonoBehaviour
{
    public IInteractiveObject interactiveObject;

    private void OnMouseDown()
    {
        if(Vector3.Distance(PlayerManager.instance.transform.position,transform.position)>5f)   return;
        if(EventSystem.current.IsPointerOverGameObject())   return;
        interactiveObject.OnClick();
    }
    private void Start()
    {
        RoomManager.instance.RoomAddObject(interactiveObject);
    }
}