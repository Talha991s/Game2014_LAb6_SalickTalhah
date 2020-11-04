using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivityHorizontal;
    public float joystickSensitivityVertical;
    public float horizontalspeed;
    public float jumpForce;
    public float maximumVelocity;
    public bool isGrounded;

    private Rigidbody2D rigidbody2D;

    private SpriteRenderer m_spriterenderer;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriterenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickSensitivityHorizontal)
            {
                rigidbody2D.AddForce(Vector2.right * horizontalspeed * Time.deltaTime);
                m_spriterenderer.flipX = false;

                m_animator.SetInteger("AnimState", 1);
            }
            else if (joystick.Horizontal < -joystickSensitivityHorizontal)
            {
                rigidbody2D.AddForce(Vector2.left * horizontalspeed * Time.deltaTime);
                m_spriterenderer.flipX = true;
                m_animator.SetInteger("AnimState", 1);
            }
            else if (joystick.Vertical > joystickSensitivityVertical)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce * Time.deltaTime);
                m_animator.SetInteger("AnimState", 2);
            }
            else
            {
                m_animator.SetInteger("AnimState", 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
