using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; } = null;
    [SerializeField] private GameObject groundTiles;

    private int unvisitedTiles;


    [SerializeField] private Text tilesCounter;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        unvisitedTiles = 0;
        unvisitedTiles = groundTiles.transform.childCount;
        tilesCounter.text = unvisitedTiles.ToString();
        
        
    }

    public void AddVisitedTiles() 
    {
        unvisitedTiles--;
        tilesCounter.text = unvisitedTiles.ToString();
        
        if (unvisitedTiles == 0)
        {
            tilesCounter.text = "Cleared!";
        }
    }

    public void RemoveVisitedTiles()
    {
        unvisitedTiles++;
        tilesCounter.text = unvisitedTiles.ToString();
        
    }
}
