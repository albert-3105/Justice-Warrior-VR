
using UnityEngine;

public class GunController1 : MonoBehaviour
{

    public float sensitivity = 5.0f;
    public GameObject dart;
    public float dartSpeed = 10.0f;
    private Vector3 _angles = Vector3.zero;
    private readonly float _maxAngles = 60.0f;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButton(1))
        {
            FireDart();
        }
        if (Input.GetMouseButton(0))
        {

            Cursor.lockState = CursorLockMode.Locked;
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");

            _angles.y += rotateHorizontal * sensitivity;
            _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);


            _angles.x -= rotateVertical * sensitivity;
            _angles.x = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);


            gameObject.transform.rotation = Quaternion.Euler(_angles);

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void FireDart()
    {
        GameObject newDart = Instantiate(dart);
        newDart.transform.position = transform.position;
        newDart.transform.position = transform.position;


        newDart.GetComponent<Rigidbody>().velocity = newDart.transform.forward * dartSpeed;
    }
}

