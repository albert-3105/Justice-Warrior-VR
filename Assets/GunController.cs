using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float sensitivity = 5.0f;

    private Vector3 _angles = Vector3.zero;
    private  readonly float _maxAngles = 60.0f;



    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");

            _angles.y += rotateHorizontal * sensitivity;
            _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);

            _angles.x += rotateHorizontal * sensitivity;
            _angles.x = Mathf.Clamp(_angles.x, -_maxAngles, _maxAngles);

            gameObject.transform.rotation = Quaternion.Euler(_angles);
        }
    }

}