
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public float sensitivity = 5.0f;

    private Vector3 _angles = Vector3.zero;
    private readonly float _maxAngles = 60.0f;

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            float rotateHorizontal = Mouse.current.delta.x.ReadValue();
            float rotateVertical = Mouse.current.delta.y.ReadValue();

            _angles.y += rotateHorizontal * sensitivity;
            _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);

            _angles.x += rotateVertical * sensitivity;
            _angles.x = Mathf.Clamp(_angles.x, -_maxAngles, _maxAngles);

            gameObject.transform.rotation = Quaternion.Euler(_angles);
        }
    }
}
