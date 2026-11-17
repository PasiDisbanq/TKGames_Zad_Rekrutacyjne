using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private float velocity = 1f;
    [SerializeField] private int maxBounces = 2;

    private Vector2 direction = Vector2.zero;
    private int bouncesNumber = 0;

    public void Setup(Vector2 dir)
    {
        direction = dir;
        rgbd.AddForce(direction*velocity, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 
            MathF.Atan2(rgbd.linearVelocity.y, rgbd.linearVelocity.x) * Mathf.Rad2Deg - 90
        );
        if (bouncesNumber > maxBounces)
            Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            bouncesNumber++;
    }
}