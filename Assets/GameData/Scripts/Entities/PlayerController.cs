using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] Transform body;
    [SerializeField] PlayerStats playerStats;

    public Action<float> scoreInc;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        SizeDecrease();
    }

    void SizeDecrease()
    {
        if (transform.localScale.x > playerStats.minSize)
        {
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime/ playerStats.sizeDecreaseSpeed, transform.localScale.y - Time.deltaTime / playerStats.sizeDecreaseSpeed, transform.localScale.z - Time.deltaTime / playerStats.sizeDecreaseSpeed);
        }
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                rigidbody.velocity = -Vector3.right * playerStats.speed * Time.deltaTime;
                Rotate(-1);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rigidbody.velocity = Vector3.right * playerStats.speed * Time.deltaTime;
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
            rigidbody.velocity = Vector3.right * Input.GetAxisRaw("Horizontal") * playerStats.speed * Time.deltaTime;
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

    public void Eat(float score, Transform eatenObj = null)
    {
        if (transform.localScale.x< playerStats.maxSize)
        {
            float scoreSizeDiv = score / 5000;
            transform.localScale = new Vector3(transform.localScale.x+scoreSizeDiv, transform.localScale.y + scoreSizeDiv, transform.localScale.z + scoreSizeDiv);
        }
        scoreInc?.Invoke(score);
        eatenObj?.SetParent(body);
    }
}
