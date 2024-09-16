using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite spriteBrighter;
    [SerializeField] private Sprite spriteDarker;

    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _animator = GetComponent<Animator>();
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
        _animator.Play("BlueBlockVanish");

    }

    private void Vanish()
    {
        
        Destroy(this.gameObject);
    }

    
}
