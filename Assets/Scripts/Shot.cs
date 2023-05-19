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
        // Obtener el componente XRGrabInteractable adjunto al objeto
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        // Agregar un Listener al evento "activated" del componente XRGrabInteractable
        grabbable.activated.AddListener(FireBullet);
    }

    void Update()
    {
        // No se está utilizando en este caso
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (canShoot)
        {
            // Instanciar una nueva bala en la posición y rotación del spawnPoint
            GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            // Obtener el componente Rigidbody de la bala instanciada
            Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
            // Aplicar una velocidad inicial a la bala en la dirección hacia adelante del spawnPoint
            bulletRigidbody.velocity = spawnPoint.forward * fireSpeed;

            // Girar la bala para que se muestre en la orientación correcta
            spawnedBullet.transform.Rotate(new Vector3(-90f, 0f, 0f));

            // Destruir la bala después de 5 segundos
            Destroy(spawnedBullet, 5);

            // Desactivar la capacidad de disparar temporalmente
            canShoot = false;
            // Iniciar una corrutina para activar nuevamente la capacidad de disparar después del tiempo de enfriamiento
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator StartCooldown()
    {
        // Esperar durante el tiempo de enfriamiento
        yield return new WaitForSeconds(cooldownTime);
        // Permitir disparar nuevamente
        canShoot = true;
    }
}
