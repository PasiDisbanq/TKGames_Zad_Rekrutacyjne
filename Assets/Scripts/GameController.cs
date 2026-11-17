using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController UIController;
    [Header("Enemy Spawn")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Collider2D spawnArea;
    [SerializeField] private Transform leftBottom;
    [SerializeField] private Transform rightTop;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnDistanceFromPlayer = 1f;

    private int score = 0;

    private void Start()
    {
       SpawnEnemy();
       SpawnEnemy();
       UIController.UpdateScore(score);
    }

    private void SpawnEnemy()
    {
        Vector2 pos = GetRandomPos();
        
        //GetRandomPos until in area boundaries and in distance from player
        float distanceFromPlayer = (pos - (Vector2)playerTransform.position).sqrMagnitude;
        while (distanceFromPlayer < spawnDistanceFromPlayer*spawnDistanceFromPlayer || !spawnArea.OverlapPoint(pos))
            pos = GetRandomPos();
        
        var enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        enemy.OnDeath += HandleScoreIncrement;
        enemy.OnDeath += SpawnEnemy;
    }

    private void HandleScoreIncrement()
    {
        UIController.UpdateScore(++score);
    }

    private Vector2 GetRandomPos()
    {
        return new(
            UnityEngine.Random.Range(leftBottom.position.x, rightTop.position.x),
            UnityEngine.Random.Range(leftBottom.position.y, rightTop.position.y)
        );
    }
}
