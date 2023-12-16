using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mailBox : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public Sprite sprite;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoaded;
    }



    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoaded;
    }
    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = sprite;
        transform.GetChild(0).gameObject.SetActive(true);
    }    
    private void OnAfterSceneLoaded()
    {
        if(!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = sprite;
            boxCollider.enabled = false;
        }
    }
}
