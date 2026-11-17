using UnityEngine;
using UnityEngine.InputSystem;

public class GravityFieldInputController : MonoBehaviour
{
    [SerializeField] private GravityField gravity;

    void Update()
    {
        gravity.ToggleEnabled(Mouse.current.rightButton.isPressed);
    }
}