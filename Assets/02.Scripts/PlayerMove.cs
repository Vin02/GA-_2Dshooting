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
            
    }
}
