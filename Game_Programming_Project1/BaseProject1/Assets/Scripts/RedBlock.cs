using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite spriteBrighter;
    [SerializeField] private Sprite spriteDarker;

    [SerializeField] private float blockSpeed;

    private Collider2D playerPosition;

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
            playerPosition = col;
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

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = this.transform.up * 0;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }

    public void Interact()
    {

        //move
        this.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;

        if (playerPosition.transform.position.y >= this.transform.position.y)
        {
            this.GetComponent<Rigidbody2D>().velocity = -this.transform.up * blockSpeed;

        } else
        {
            this.GetComponent<Rigidbody2D>().velocity = this.transform.up * blockSpeed;
        }
        

    }

}
