using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 3f;
    public int Damage = 20;

    public bool IsCapsule = false;

    public GameObject HexagonPrefab;
    public int HexagonCount = 42;

    static int colorIndex = 0;

    Color[] colors =
    {
        Color.red,
        new Color(1f, 0.5f, 0f),
        Color.yellow,
        Color.green,
        Color.blue,
        new Color(0.2f, 0f, 0.5f),
        new Color(0.5f, 0f, 1f)
    };

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = colors[colorIndex];

        colorIndex++;

        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    void Update()
    {
        Vector2 direction = Vector2.up;

        transform.Translate(direction * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.DamageCheck(Damage);
            }

            if (IsCapsule)
            {
                Vector2 hitPoint = collision.GetContact(0).point;

                FireHexagons(hitPoint);
            }
        }

        Destroy(gameObject);
    }

    private void FireHexagons(Vector2 hitPoint)
    {
        Debug.Log("Capsule 폭발!");

        for (int i = 0; i < HexagonCount; i++)
        {
            float angle = 360f / HexagonCount * i;

            // 각도를 방향 벡터로 변환
            float radian = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(
                Mathf.Sin(radian),
                Mathf.Cos(radian)
            );

            // 충돌 지점에서 조금 떨어진 곳에서 생성
            Vector2 spawnPosition = hitPoint + direction * 0.5f;

            GameObject hexagon = Instantiate(
                HexagonPrefab,
                spawnPosition,
                Quaternion.Euler(0, 0, -angle)
            );
        }
    }
}