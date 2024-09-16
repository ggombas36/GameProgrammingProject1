using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class InteractionSystem : MonoBehaviour
{
    private PlayerControls playerInput;
    private bool canInteract = true;

    public List<IInteractable> interactablesList = new List<IInteractable>();

    private void Start()
    {
        playerInput = InputManager.Instance.GetInputActions();
        playerInput.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (canInteract && interactablesList.Count != 0)
        {
            for (int i = 0; i < interactablesList.Count; i++)
            {
                interactablesList[i].Interact();
                
            }
            
        }
    }

    private void OnDestroy()
    {
        playerInput.Player.Interact.performed -= Interact_performed;
    }

    public void SwitchInteraction(bool enable)
    {
        canInteract = enable;
    }

    public void SetInteractable(IInteractable _interactable)
    {
        interactablesList.Add(_interactable);
    }

    public void RemoveInteractable(IInteractable _interactable)
    {
 
        interactablesList.Remove(_interactable);
        
    }




}
