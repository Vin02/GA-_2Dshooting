using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 스페이스바를 누를 때 마다 총알을 생성해서 발사하고 싶음
    // 필요 속성 : 총알 프리팹/생성 위치(총구)
    public GameObject bulletPrefab;
    public Transform leftFirePoint;
    public Transform rightFirePoint;
    public bool AutoFire = false;
    public float timer = 1f;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || AutoFire)
            {
                Fire();
                timer = 1f;
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            AutoFire = !AutoFire;
        }

        
        
    }

    private void Fire()
    {
        GameObject leftbullet = Instantiate(bulletPrefab);
        leftbullet.transform.position = leftFirePoint.transform.position;
            
        GameObject rightbullet = Instantiate(bulletPrefab);
        rightbullet.transform.position = rightFirePoint.transform.position;
    }
}
