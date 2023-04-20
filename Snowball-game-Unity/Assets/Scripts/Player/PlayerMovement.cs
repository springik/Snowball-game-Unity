using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    Vector2 initialMousePos;
    Vector2 dragDir;
    Rigidbody2D rb;
    public static UnityEvent OnLose = new UnityEvent();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(rb.velocity.magnitude >= 0.3)
        {
            Vector3 increase = new Vector3((transform.localScale.x * 1.005f), (transform.localScale.y * 1.005f), 1);
            if(increase.magnitude <= new Vector3(2, 2, 0).magnitude)
            {
                transform.localScale = increase;
                return;
            }
            OnLose.Invoke();
        }
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
            Vector2 force = ((dragDir.normalized * -1) * speed) / transform.localScale.magnitude;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        dragDir = Vector2.zero;
    }
}
