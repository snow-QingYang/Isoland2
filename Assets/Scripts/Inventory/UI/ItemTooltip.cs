using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;
    public void UpdateItemName(ItemName name)
    {
        itemNameText.text = name switch
        {
            ItemName.Key => "Mailbox Key",
            ItemName.Ticket => "Ticket",
            _=> ""
        };
    }
}
