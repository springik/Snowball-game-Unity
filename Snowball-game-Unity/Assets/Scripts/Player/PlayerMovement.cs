using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    Vector2 initialMousePos;
    Vector2 dragDir;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if(rb.velocity.magnitude < 0.3)
            initialMousePos = Input.mousePosition;
    }
    private void OnMouseDrag()
    {
        if(rb.velocity.magnitude < 0.3)
        {
            Vector2 currMousePos = Input.mousePosition;
            dragDir = currMousePos - initialMousePos;
        }
    }
    private void OnMouseUp()
    {
        if(dragDir.magnitude > 0)
        {
            Vector2 force = (dragDir.normalized * -1) * speed;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        dragDir = Vector2.zero;
    }
}
