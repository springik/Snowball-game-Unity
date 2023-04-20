using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
