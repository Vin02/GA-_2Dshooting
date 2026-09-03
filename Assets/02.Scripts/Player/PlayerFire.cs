using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 스페이스바를 누를 때 마다 총알을 생성해서 발사하고 싶음
    // 필요 속성 : 총알 프리팹/생성 위치(총구)
    public GameObject bulletPrefab;
    public GameObject subbulletPrefableft;
    public GameObject subbulletPrefabright;
    public GameObject subbulletPrefabcenter;
    public Transform leftFirePoint;
    public Transform rightFirePoint;
    public Transform subleftFirePoint;
    public Transform subrightFirePoint;
    public Transform subcenterFirePoint;
    public bool AutoFire = false;
    public int hexagonCount = 9;
    public float spreadAngle = 80f;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
        
        GameObject subcenterbullet = Instantiate(subbulletPrefabcenter);
        subcenterbullet.transform.position = subcenterFirePoint.transform.position;
        
        for (int i = 0; i < hexagonCount; i++)
        {
            float angle = -spreadAngle / 2
                          + spreadAngle / (hexagonCount - 1) * i;

            Instantiate(
                subbulletPrefabcenter,
                subcenterFirePoint.position,
                Quaternion.Euler(0, 0, angle)
            );
        }
        
        GameObject subrightbullet = Instantiate(subbulletPrefabright);
        subrightbullet.transform.position = subrightFirePoint.transform.position;
        
        GameObject subleftbullet = Instantiate(subbulletPrefableft);
        subleftbullet.transform.position = subleftFirePoint.transform.position;
    }
}
