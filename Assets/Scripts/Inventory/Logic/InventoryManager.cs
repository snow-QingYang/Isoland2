using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>

{
    public ItemDataList_SO itemData;
    [SerializeField] private List<ItemName> itemList = new List<ItemName>();
    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsed;
    }


    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsed;
    }
    private void OnItemUsed(ItemName name)
    {
        var index = GetItemIndex(name);
        itemList.RemoveAt(index);

        if (itemList.Count == 0)
            EventHandler.CallUpdateUIEvent(null, -1);
    }
    private int GetItemIndex(ItemName name)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i]  == name)
            {
                return i;
            }
            
        }
        return -1;
    }
    public void addItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName)) 
        {
            itemList.Add(itemName);
            EventHandler.CallUpdateUIEvent(itemData.getItemDetails(itemName), itemList.Count - 1);
        }
    }
}
