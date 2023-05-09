using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoviment : MonoBehaviour
{
  private Rigidbody droneRigidbody;
  private Vector3 movementInput;
  private float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos el componente Rigidbody del dron
        droneRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
      void FixedUpdate()
    {
        // Aplicar la fuerza para el movimiento del dron
        Vector3 movement = transform.TransformDirection(movementInput) * speed;
        droneRigidbody.AddForce(movement);
    }
}