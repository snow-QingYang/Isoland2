using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemAvailableList = new Dictionary<ItemName, bool>();

    private Dictionary<string, bool> interactiveStateList = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadedEvent += OnBeforeSceneUnloaded;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoaded;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }



    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoaded;
        EventHandler.BeforeSceneUnloadedEvent -= OnBeforeSceneUnloaded;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }
    private void OnBeforeSceneUnloaded()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableList.ContainsKey(item.Name))
            {
                itemAvailableList.Add(item.Name, true);
            }
        }
        foreach(var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateList.ContainsKey(item.name))
                interactiveStateList[item.name] = item.isDone;
            else
                interactiveStateList.Add(item.name, item.isDone);
        }
    }
    private void OnAfterSceneLoaded()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableList.ContainsKey(item.Name))
                itemAvailableList.Add(item.Name, true);
            else
                item.gameObject.SetActive(itemAvailableList[item.Name]);

        }
            foreach (var item in FindObjectsOfType<Interactive>())
            {
                if (interactiveStateList.ContainsKey(item.name))
                    item.isDone = interactiveStateList[item.name];
                else
                    interactiveStateList.Add(item.name, item.isDone);
            }

        
    }
    private void OnUpdateUIEvent(ItemDetails details, int arg2)
    {
        if (details != null)
        {
            itemAvailableList[details.itemName] = false;

        }
 
    }
}
