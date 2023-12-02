using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName Name;
    public void itemClicked()
    {
        InventoryManager.Instance.addItem(Name);
        this.gameObject.SetActive(false);
    }
}
