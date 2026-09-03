using UnityEngine;

public class DownEnemy : Enemy
{
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.down;
    }

    public override void EnemyMove()
    {
        transform.position += (Vector3)(direction * _enemySpeed * Time.deltaTime);
    }
}