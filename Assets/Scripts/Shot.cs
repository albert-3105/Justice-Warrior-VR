using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shot : MonoBehaviour
{
  
    public GameObject weapon;
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public float cooldownTime = 0.5f; 

    private bool canShoot = true; 

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
        if (canShoot)
        {
            GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = spawnPoint.forward * fireSpeed;

            spawnedBullet.transform.Rotate(new Vector3(-90f, 0f, 0f));

            Destroy(spawnedBullet, 5);

            canShoot = false; 
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true; 
    }
}