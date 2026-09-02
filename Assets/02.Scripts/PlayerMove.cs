using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //필요 변수는 속도
    //키보드를 입력받아 이동하게 
    public float Speed;
   
    
    // 별 조건이 없다면 최대 프렘임 계속
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Debug.Log ($"Horizontal: {horizontal}, Vertical: {vertical}");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        
        transform.Translate(direction * Speed * Time.deltaTime);
        
        transform.position = transform.position + (Vector3)(direction * Speed * Time.deltaTime);
        
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
