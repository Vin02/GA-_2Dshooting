using UnityEngine;

public class Bullet : MonoBehaviour
{

    // 총알을 위로 움직이게 하기

    public float Speed;
    void Update()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
