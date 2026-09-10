using UnityEngine;
using UnityEngine.Serialization;

public abstract class Enemy : MonoBehaviour
{
    [FormerlySerializedAs("Health")] [SerializeField] private float _health = 1000;
    [FormerlySerializedAs("EnemySpeed")] [SerializeField] protected float _enemySpeed;
    
    private void Update()
    {
            EnemyMove();
    }

    public abstract void EnemyMove();
    

    public void DamageCheck(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            // 싱글톤 패턴
            // 전역적으로 접근 가능
            // 인스턴스가 하나임을 보장한다..
            ScoreManager scoreManager = ScoreManager.Instance;
            scoreManager.AddScore(100);
            Destroy(gameObject);
            }
        
    }
}
