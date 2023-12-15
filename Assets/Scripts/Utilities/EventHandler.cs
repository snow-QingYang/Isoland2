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
    public static Action AfterSceneLoadedEvent;
    public static void CallAfterScenLoaded() 
    { 
        AfterSceneLoadedEvent?.Invoke();
    }

}

