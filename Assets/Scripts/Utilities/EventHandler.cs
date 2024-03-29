using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> UpdateUIEvent;
    public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        UpdateUIEvent?.Invoke(itemDetails, index);
    }
    public static event Action BeforeSceneUnloadedEvent;
    public static void CallBeforeSceneUnloaded()
    {
        BeforeSceneUnloadedEvent?.Invoke();
    }
    public static event Action AfterSceneLoadedEvent;
    public static void CallAfterSceneLoaded() 
    { 
        AfterSceneLoadedEvent?.Invoke();
    }
    public static event Action<ItemDetails, bool> ItemSelectedEvent;
    public static void CallItemSelected(ItemDetails itemDetails, bool isSelected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, isSelected);
    }

    public static event Action<ItemName> ItemUsedEvent;
    public static void CallItemUsed(ItemName name)
    {
        ItemUsedEvent?.Invoke(name);
    }
}

