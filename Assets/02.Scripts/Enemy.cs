using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 1000;
    public float Speed;
    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    public void DamageCheck(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            {
            Destroy(gameObject);
            }
        
    }
}
