using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    private Rigidbody2D phys;
    private PlayerInput playerInput;
    private InputAction walk;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        phys = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (playerInput != null)
            walk = playerInput.actions.FindAction("Walk");
    }
    void Update()
    {
        OnreActions.Walk(walk.ReadValue<float>(), phys);
    }
}
