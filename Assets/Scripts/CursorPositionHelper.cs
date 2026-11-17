using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPositionHelper : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    public Vector2 GetCursorPosition => mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());   
    
}