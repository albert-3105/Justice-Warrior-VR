using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronemoviment3 : MonoBehaviour
{
    private Rigidbody droneRigidbody;
    private float speed = 20f;
    public GameObject Bullet;

    // Coordenadas límite
    private float minX = -15.6f;
    private float maxX = 15.6f;

    // Dirección actual del movimiento
    private int movementDirection = 1; // 1 para moverse hacia la derecha, -1 para moverse hacia la izquierda

    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos el componente Rigidbody del dron
        droneRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calcular la dirección del movimiento en el eje X
        float movementX = speed * movementDirection;

        // Aplicar la fuerza para el movimiento del dron en el eje X
        Vector3 movement = new Vector3(movementX, 0f, 0f);
        droneRigidbody.velocity = movement;

        // Verificar y corregir la posición dentro de los límites
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;

        // Verificar si se alcanzó alguno de los límites y cambiar la dirección de movimiento
        if (clampedPosition.x <= minX && movementDirection == -1)
        {
            movementDirection = 1; // Cambiar la dirección del movimiento hacia la derecha
        }
        else if (clampedPosition.x >= maxX && movementDirection == 1)
        {
            movementDirection = -1; // Cambiar la dirección del movimiento hacia la izquierda
        }
    }

    // Detectar colisiones
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Verificar si el objeto tiene el tag "Dron"
            if (gameObject.CompareTag("Drone"))
            {
                // Colisión con una bala y el objeto tiene el tag "Dron"
                // Destruir el dron
                Destroy(gameObject);

                
            }
        }
    }
}
