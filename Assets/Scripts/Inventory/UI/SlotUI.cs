using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    public ItemTooltip tooltip;
    private ItemDetails currentItem;
    private bool isSelected;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        EventHandler.CallItemSelected(currentItem, isSelected);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.gameObject.activeInHierarchy)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.UpdateItemName(currentItem.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip?.gameObject.SetActive(false);
    }
}
