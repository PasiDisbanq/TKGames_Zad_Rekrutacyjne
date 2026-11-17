using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputController : MonoBehaviour
{
    [SerializeField] private MovementController mc;

    private Vector2 dir = Vector2.zero;

    private void Update()
    {
       HandleInput(); 
    }

    private void HandleInput()
    {
        dir = Vector2.zero;

        if(Keyboard.current.wKey.isPressed)
            dir += Vector2.up;
        else if (Keyboard.current.sKey.isPressed)
            dir += Vector2.down;

        if (Keyboard.current.aKey.isPressed)
            dir += Vector2.left;
        else if (Keyboard.current.dKey.isPressed)
            dir += Vector2.right;
    }

    private void FixedUpdate()
    {
        if(dir != Vector2.zero)
            mc.Move(dir.normalized);
    }
}
