using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiles : MonoBehaviour
{

    [SerializeField] private Sprite spriteVisited;
    [SerializeField] private Sprite spriteUnvisited;

    private SpriteRenderer _spriteRenderer;

    private bool visited;

    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        visited = false;
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            ChangeSprite();
            visited = true;

        }
        
    }


    private void ChangeSprite()
    {
        if (visited == false)
        {
            _spriteRenderer.sprite = spriteVisited;
            GameManager.Instance.AddVisitedTiles();
        }
        
    }


    public void ChangeTriggered()
    {
        if (visited)
        {
            _spriteRenderer.sprite = spriteUnvisited;
            visited = false;
            GameManager.Instance.RemoveVisitedTiles();
        }
        else
        {
            _spriteRenderer.sprite = spriteVisited;
            visited = true;
            GameManager.Instance.AddVisitedTiles();
        }
    }
}
