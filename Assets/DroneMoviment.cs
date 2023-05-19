using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoviment : MonoBehaviour
{
    private Rigidbody droneRigidbody;
    private float speed = 25f;
    private int level = 1;
    private int kills = 0;
    private int fails = 0;
    private float xMin = -5f; // Mínimo valor del eje X
    private float xMax = 23f; // Máximo valor del eje X
    private float yMin = 2.5f; // Mínimo valor del eje Y
    private float yMax = 15.0f; // Máximo valor del eje Y
    private float zMin = 0.14f; // Mínimo valor del eje Z
    private float zMax = 7f; // Máximo valor del eje Z

    private Vector3 movementInput;

    void Start()
    {
        droneRigidbody = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody del dron
    }

    void FixedUpdate()
    {
        // Generar una dirección de movimiento aleatoria
        GenerateRandomMovement();

        // Aplicar la fuerza para el movimiento del dron
        Vector3 movement = movementInput * speed;
        droneRigidbody.AddForce(movement);

        // Verificar condiciones de aumento de nivel, bajas y fallas
        if (kills >= level)
        {
            RegisterKill();
        }

        if (fails >= level)
        {
            RegisterFail();
        }

        // Mantener al dron dentro de los márgenes
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, zMin, zMax);
        transform.position = clampedPosition;
    }

    public void IncreaseLevel()
    {
        level++; // Incrementar el nivel del dron
    }

    public void RegisterKill()
    {
        kills++; // Registrar una baja
        IncreaseLevel(); // Incrementar el nivel del dron
    }

    public void RegisterFail()
    {
        fails++; // Registrar una falla
    }

    private void GenerateRandomMovement()
    {
        // Generar una dirección de movimiento aleatoria
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        movementInput = new Vector3(randomX, randomY, randomZ).normalized;

        // Evitar colisiones con otros drones
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Drone") && collider.gameObject != gameObject)
            {
                // Generar nueva dirección de movimiento aleatoria si hay un dron cercano
                GenerateRandomMovement();
                break;
            }
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruir el dron al colisionar con una bala
            Destroy(gameObject);
        }
    }
}

