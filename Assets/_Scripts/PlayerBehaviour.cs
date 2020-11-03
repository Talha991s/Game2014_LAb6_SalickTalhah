using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivity;
    public float horizontalspeed;
    public float jumpForce;
    public float maximumVelocity;
    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        if(joystick.Horizontal > joystickSensitivity)
        {
            rigidbody2D.AddForce(Vector2.right * horizontalspeed * Time.deltaTime);
        }

        if (joystick.Horizontal < -joystickSensitivity)
        {
            rigidbody2D.AddForce(Vector2.left * horizontalspeed * Time.deltaTime);
        }
    }
}
