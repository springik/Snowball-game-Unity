using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

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

    //Mouse eventy, co zaøizují "pinkání" / "cvrnkání" do koule.
    #region pinkání :)
    private void OnMouseDown()
    {
        if(rb.velocity.magnitude < 0.3f)
        {
            initialMousePos = Input.mousePosition;
        }
    }
    private void OnMouseDrag()
    {
        //Debug.Log("mousedrag trigger");
        if(rb.velocity.magnitude < 0.3f)
        {
            Vector2 currMousePos = Input.mousePosition;
            dragDir = currMousePos - initialMousePos;
            //Debug.Log("dragDir: " + dragDir);
        }
    }
    private void OnMouseUp()
    {
        //Debug.Log("mouseup trigger");
        if(dragDir.magnitude > 0f)
        {
            Vector2 force = ((dragDir.normalized * -1) * speed); /// transform.localScale.magnitude
            rb.AddForce(force, ForceMode2D.Impulse);
            //Debug.Log("mouseup condition triggered with force: " + force.ToString());
            //Debug.Log("rb: " + rb);
        }
        dragDir = Vector2.zero;
        //Debug.Log("dragDir" + dragDir);
    }
    #endregion
}
