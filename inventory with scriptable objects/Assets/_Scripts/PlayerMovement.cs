using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator an;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    private void Update()
    {
        ControllsAndAnimaiton();
    }

    Vector3 movDir;
    void ControllsAndAnimaiton()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movDir = new Vector3(x, y, 0).normalized;

        rb.velocity = movDir * speed * Time.deltaTime;

        if (movDir.y > 0.01f) an.Play("Up");
        else if (movDir.y < -0.01f) an.Play("Down");
        else if (movDir.x > 0.01f) an.Play("Right");
        else if (movDir.x < -0.01f) an.Play("Left");
        else an.Play("Idle");
    }
    private void FixedUpdate()
    {

    }
}
