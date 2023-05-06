using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour

{
    public GameObject weapon;
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)

    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Vector3 bulletRotation = new Vector3(spawnPoint.rotation.eulerAngles.x + weapon.transform.rotation.eulerAngles.x, spawnPoint.eulerAngles.y + weapon.transform.rotation.eulerAngles.y, spawnPoint.eulerAngles.z + weapon.transform.rotation.eulerAngles.z);
        spawnedBullet.transform.rotation = Quaternion.Euler(bulletRotation);
         Quaternion rotation = Quaternion.Euler(0, 30, 0);
        

        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
       Destroy(spawnedBullet, 5);
    }
}
