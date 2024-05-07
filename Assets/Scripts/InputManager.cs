using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction walk;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        walk = playerInput.currentActionMap.FindAction("Walk");
    }
    private void Start()
    {
        playerInput.onActionTriggered += ManageActionTriggered;
    }

    private void Update()
    {
        Debug.Log
    }
    private void ManageActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
    }
}
