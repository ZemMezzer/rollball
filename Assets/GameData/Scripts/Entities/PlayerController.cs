using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                rigidbody.velocity = -Vector3.right * speed * Time.deltaTime;
                Rotate(-1);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rigidbody.velocity = Vector3.right * speed * Time.deltaTime;
                Rotate(1);
            }
        }
        else
        {
            Rotate(0);
            rigidbody.velocity = Vector3.zero;
        }
        if (Application.isEditor)
        {
            rigidbody.velocity = Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            Rotate(Input.GetAxisRaw("Horizontal"));
        }
    }

    private Quaternion targetRotation;
    private void Rotate(float inputValue)
    {
        float Angle = Mathf.Atan2(inputValue, 1);
        Angle = Mathf.Rad2Deg * Angle;
        targetRotation = Quaternion.Euler(0, Angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
    }
}
