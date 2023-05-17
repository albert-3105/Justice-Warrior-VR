using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (Time.time > shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 2);
            }
        }
    }
}
