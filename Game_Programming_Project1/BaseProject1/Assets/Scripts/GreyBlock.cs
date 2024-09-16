using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GreyBlock : MonoBehaviour, IInteractable
{

    [SerializeField] private Vector2 groundCheckSize = new Vector2(1f, 0.1f);

    [SerializeField] private LayerMask groundTilesLayerMask;

    private Collider2D[] groundTilesArr;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite spriteBrighter;
    [SerializeField] private Sprite spriteDarker;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<InteractionSystem>().SetInteractable(this);
            _spriteRenderer.sprite = spriteDarker;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            col.GetComponent<InteractionSystem>().RemoveInteractable(this);
            _spriteRenderer.sprite = spriteBrighter;
        }
    }

    public void Interact()
    {
        
        groundTilesArr = Physics2D.OverlapBoxAll(this.transform.position, groundCheckSize, 0f, groundTilesLayerMask);
        
        for (int i = 0; i < groundTilesArr.Length; i++)
        {
            groundTilesArr[i].GetComponent<GroundTiles>().ChangeTriggered();
        }

    }

    

}
