using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronemoviment3 : MonoBehaviour
{
    private Rigidbody droneRigidbody;
    private float speed = 20f;
    public GameObject Bullet;

    // Coordenadas l�mite
    private float minX = -15.6f;
    private float maxX = 15.6f;

    // Direcci�n actual del movimiento
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
        // Calcular la direcci�n del movimiento en el eje X
        float movementX = speed * movementDirection;

        // Aplicar la fuerza para el movimiento del dron en el eje X
        Vector3 movement = new Vector3(movementX, 0f, 0f);
        droneRigidbody.velocity = movement;

        // Verificar y corregir la posici�n dentro de los l�mites
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;

        // Verificar si se alcanz� alguno de los l�mites y cambiar la direcci�n de movimiento
        if (clampedPosition.x <= minX && movementDirection == -1)
        {
            movementDirection = 1; // Cambiar la direcci�n del movimiento hacia la derecha
        }
        else if (clampedPosition.x >= maxX && movementDirection == 1)
        {
            movementDirection = -1; // Cambiar la direcci�n del movimiento hacia la izquierda
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
                // Colisi�n con una bala y el objeto tiene el tag "Dron"
                // Destruir el dron
                Destroy(gameObject);

                
            }
        }
    }
}
