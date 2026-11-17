using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShootingInputController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private BulletShootingController shooting;
    
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame) 
            return;
        
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var angle = Mathf.Rad2Deg * MathF.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
        shooting.Shoot(direction.normalized, transform.position);
    }
}
