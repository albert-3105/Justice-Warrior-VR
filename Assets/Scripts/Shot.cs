using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class Shot : MonoBehaviour
{
    public int cantBalas; // Variable cantidad de balas
    public int cantTotalBalas; // Variable cantidad de balas totales

    public TextMeshProUGUI cantBalasTMP;
    public TextMeshProUGUI cantTotalBalasTMP;

    public GameController gameController;
    public GameObject weapon;
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public float cooldownTime = 0.25f;

    private bool canShoot = true;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (canShoot)
        {
            if (cantBalas > 0)
            {
                GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = spawnPoint.forward * fireSpeed;

                spawnedBullet.transform.Rotate(new Vector3(-90f, 0f, 0f));

                Destroy(spawnedBullet, 5);

                cantBalas--;
                UpdateBulletCountText();

                canShoot = false;
                StartCoroutine(StartCooldown());
            }
            else
            {
                Debug.Log("¡No quedan balas! Recarga el arma.");
            }
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    public void RecargarArma()
    {
        if (cantBalas < cantTotalBalas)
        {
            int balasRestantes = cantTotalBalas - cantBalas;
            cantBalas += balasRestantes;
            UpdateBulletCountText();

            Debug.Log("¡Arma recargada! Se agregaron " + balasRestantes + " balas.");
        }
        else
        {
            Debug.Log("No necesitas recargar el arma en este momento.");
        }
    }

    private void UpdateBulletCountText()
    {
         cantBalasTMP.text = cantBalas.ToString();
        cantTotalBalasTMP.text = cantTotalBalas.ToString();
    }
}
