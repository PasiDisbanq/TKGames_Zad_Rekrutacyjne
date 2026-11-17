using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private float movementAcceleration = 1f;
    [SerializeField] private float maxVelocity = 1f;

    public void Move(Vector2 direction)
    {
        rgbd.AddForce(direction * movementAcceleration);
        if (rgbd.linearVelocity.sqrMagnitude > maxVelocity * maxVelocity)
            rgbd.linearVelocity = direction * maxVelocity;
    }
}
