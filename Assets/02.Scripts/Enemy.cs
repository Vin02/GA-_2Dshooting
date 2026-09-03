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
            Destroy(gameObject);
            }
        
    }
}
