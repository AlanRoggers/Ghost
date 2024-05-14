using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public BoxCollider2D roof;
    private PlayerInput playerInput;
    private InputAction walk;
    private InputAction jump;
    private Rigidbody2D phys;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        phys = GetComponent<Rigidbody2D>();
        walk = playerInput.currentActionMap.FindAction("Walk");
        jump = playerInput.currentActionMap.FindAction("Jump");
    }
    private void Start()
    {
        playerInput.onActionTriggered += ManageActionTriggered;
    }

    private void Update()
    {
        OnreActions.Walk(walk.ReadValue<float>(), phys);
    }
    private void ManageActionTriggered(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Jump":
                if (context.action.phase.ToString() == "Performed")
                {
                    Debug.Log("Jump");
                    OnreActions.Jump(phys);
                }
                else if (context.action.phase.ToString() == "Canceled")
                    Debug.Log("KeyReleased");
                break;
            case "Walk":
                if (context.action.phase.ToString() == "Started")
                    StartCoroutine(OnrePhysics.DynamicFriction(roof.sharedMaterial));
                else if (context.action.phase.ToString() == "Canceled")
                    StartCoroutine(OnrePhysics.StaticFriction(roof.sharedMaterial));
                break;
            default:
                Debug.Log("NoMatched");
                break;
        }
    }
}
