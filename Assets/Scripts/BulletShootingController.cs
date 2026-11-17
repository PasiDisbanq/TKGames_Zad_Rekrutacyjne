using UnityEngine;

public class BulletShootingController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    public void Shoot(Vector2 dir, Vector2 startingPosition)
    {
        var bullet = Instantiate(bulletPrefab, startingPosition, Quaternion.identity);
        bullet.Setup(dir);
    }

}
