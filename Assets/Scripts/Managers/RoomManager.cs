using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    private List<IInteractiveObject> objects;

    private void Awake()
    {
        instance=this;
        objects=new List<IInteractiveObject>();
    }
    public void RoomReset()
    {
        foreach (IInteractiveObject interactiveObject in objects)
        {
            interactiveObject.ResetObject();
        }
    }
    public void RoomAddObject(IInteractiveObject interactiveObject)
    {
        objects.Add(interactiveObject);
    }
}
