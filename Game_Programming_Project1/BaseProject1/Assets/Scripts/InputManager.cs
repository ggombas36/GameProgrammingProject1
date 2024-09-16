using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; } = null;
    private PlayerControls playerInput;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerInput = new PlayerControls();
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    public PlayerControls GetInputActions()
    {
        return playerInput;
    }
}
