using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D front, back;
    public float speed = 900f;
    public Camera MainCamera;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        front.AddTorque(- horizontal * speed * Time.fixedDeltaTime);
        back.AddTorque(- horizontal * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.A))
        {
            front.AddTorque(- horizontal * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            back.AddTorque(- horizontal * speed * Time.deltaTime);
        }

    }
}
