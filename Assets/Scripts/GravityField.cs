using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    [SerializeField] private CursorPositionHelper cursor;
    [SerializeField] private float force = 1f;
    [SerializeField] private float radius = 2f;

    private bool enabled = false;
    
    public void ToggleEnabled(bool val)
    {
        enabled = val;
    }

    private void Update()
    {
        if (!enabled) return;
        
        transform.position = cursor.GetCursorPosition;
        List<Bullet> bullets = GetAllBullets();
        bullets.ForEach(x => x.ApplyGravityFieldForce(transform.position, force));
    }

    List<Bullet> GetAllBullets()
    {
        return Physics2D.OverlapCircleAll(transform.position, radius)
            .Where(x => x.CompareTag("Bullet"))
            .Select(x => x.GetComponent<Bullet>())
            .ToList();
    }
}