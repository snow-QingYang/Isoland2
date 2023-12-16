using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requiredItem;
    public bool isDone;

    public void CheckItem(ItemName name)
    {
        if (name == requiredItem && !isDone)
        {
            isDone = true;
            OnClickedAction();
        }
    }
    /// <summary>
    /// Abstract method for interactive 
    /// </summary>
    protected virtual void OnClickedAction()
    {

    }
    public virtual void EmptyClicked()
    {
        Debug.Log("empty clicked");
    }
}
