using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction walk;
    private InputAction jump;
    private Rigidbody2D phys;
    private Coroutine friction;
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

    private void FixedUpdate()
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
                    friction = StartCoroutine(OnrePhysics.Friction(phys, walk.ReadValue<float>()));

                if (context.action.phase.ToString() == "Canceled")
                {
                    StopCoroutine(friction);
                    if (walk.ReadValue<float>() == 0)
                        StartCoroutine(OnrePhysics.StaticFriction(phys));
                }
                break;
            default:
                Debug.Log("NoMatched");
                break;
        }
    }
}
