using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 스페이스바를 누를 때 마다 총알을 생성해서 발사하고 싶음
    // 필요 속성 : 총알 프리팹/생성 위치(총구)
    public GameObject BulletPrefab;
    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Leftbullet = Instantiate(BulletPrefab);
            Leftbullet.transform.position = LeftFirePoint.transform.position;
            
            GameObject Rightbullet = Instantiate(BulletPrefab);
            Rightbullet.transform.position = RightFirePoint.transform.position;
        }
        
    }
}
