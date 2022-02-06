using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private List<items> inventory;

    private void Start()
    {
        instance=this;
    }
    public void InventoryReset()
    {
        inventory=new List<items>();
    }
    public void InventoryAddItem(items item)
    {
        inventory.Add(item);
    }
    public bool InventoryHasItem(items item)
    {
        if(inventory.Contains(item))
        {
            return true;
        }
        return false;
    }
    public void InventoryRemoweItem(items item)
    {
        if(inventory.Contains(item))
        {
            inventory.Remove(item);
        }
    }
}