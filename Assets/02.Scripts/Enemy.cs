using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
