using UnityEngine;

public class HomingEnemy : Enemy
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    public override void EnemyMove()
    {
        // 1. 방향을 구한다.
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();

        // 2. 방향과 속도에 맞게 이동한다.
        transform.Translate(direction * _enemySpeed * Time.deltaTime);
    }
}