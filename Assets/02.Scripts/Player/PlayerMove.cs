using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //필요 변수는 속도
    //키보드를 입력받아 이동하게 
    public float Speed;
    public float minX = -2.4f;
    public float maxX = 2.4f;
    public float minY = -5f;
    public float maxY = 0f;
   
    
    // 별 조건이 없다면 최대 프렘임 계속
    private void Update()
    {
        Move();
        Accelerate();

    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Debug.Log ($"Horizontal: {horizontal}, Vertical: {vertical}");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        
        transform.position = transform.position + (Vector3)(direction * Speed * Time.deltaTime);

        Vector3 pos = transform.position;

        if (pos.x > maxX)
        {
            pos.x = minX;
        }

        if (pos.x < minX)
        {
            pos.x = maxX;
        }

        if (pos.y > maxY)
        {
            pos.y = maxY;
        }

        if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.position = pos;
    }
        
    private void Accelerate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Speed += 1;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Speed -= 1;
        }
    }
}
