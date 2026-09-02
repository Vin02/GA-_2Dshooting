using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 3f;

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
}