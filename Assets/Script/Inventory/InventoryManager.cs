using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>(); //item inventory yang dimiliki

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) //add item ke inventory
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item) //remove item dari inventory
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }

    public enum AllItems //semua item yang tersedia di game
    {
        Cherry,
        Orange,
        Banana
    }
}
