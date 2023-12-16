using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));

    private ItemName currentItem;

    public RectTransform Hand;

    private bool isHoldItem;
    private bool canClick;
    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
    }



    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
    }
    private void Update()
    {
        if (Hand.gameObject.activeInHierarchy)
            Hand.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectAtMousePosition() != null)
            {
                clickAction(ObjectAtMousePosition().gameObject);
            }
        }
       
    }
    private void OnItemSelectedEvent(ItemDetails details, bool isSelected)
    {
        isHoldItem = isSelected;
        if(isSelected)
        {
            currentItem = details.itemName;
        }
        Hand.gameObject.SetActive(isHoldItem);
    }
    /// <summary>
    /// 鼠标点击事件
    /// </summary>
    /// <param name="clickObject"></param>
    private void clickAction(GameObject clickObject)
    {
        switch(clickObject.tag)
        {
            case "Teleport":
                var teleport =clickObject.GetComponent<Teleport>();
                teleport?.teleportToScene();
                break;
            case "Item":
                var item =clickObject.GetComponent<Item>();
                item?.itemClicked();
                break;
            case "Interactive":
                var interactive = clickObject.GetComponent<Interactive>();
                if (isHoldItem)
                    interactive?.CheckItem(currentItem);
                else
                {
                    interactive?.EmptyClicked();
                }
                break;
        }
    }
    /// <summary>
    /// 检测鼠标点击范围的碰撞体
    /// </summary>
    /// <returns></returns>
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
