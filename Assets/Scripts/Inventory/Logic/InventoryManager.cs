using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>

{
    public ItemDataList_SO itemData;
    [SerializeField] private List<ItemName> itemList = new List<ItemName>();

    public void addItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName)) 
        {
            itemList.Add(itemName);
            EventHandler.CallUpdateUIEvent(itemData.getItemDetails(itemName), itemList.Count - 1);
        }
    }
}
