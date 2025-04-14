using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform canvasParent;
    public GameObject bulletPrefab;
    public float bulletSpeed=20;
    public float timeBetweenShots=0.5f;
    private float lastTimeShot=0;
    public float bulletLifeTime=5;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time-lastTimeShot>timeBetweenShots){
            GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation, canvasParent);
            bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
            Destroy(bullet, bulletLifeTime);
        }
    }
}
