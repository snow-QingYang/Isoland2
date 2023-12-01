using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));

    private bool canClick;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectAtMousePosition() != null)
            {
                clickAction(ObjectAtMousePosition().gameObject);
            }
        }
       
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
