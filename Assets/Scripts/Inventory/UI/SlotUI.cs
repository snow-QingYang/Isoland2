using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public UnityEngine.UI.Image itemImage;
    private ItemDetails currentItem;
    public void SetItem(ItemDetails item)
    {
        currentItem = item;
        this.gameObject.SetActive(true);
        this.itemImage.sprite = item.itemSprite;
        this.itemImage.SetNativeSize();
    }
    public void setEmpty()
    {
        this.gameObject.SetActive(false);
    }

}
