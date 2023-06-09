using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 1.5f;
        Vector3 decrease = new Vector3((transform.localScale.x * 0.8f), (transform.localScale.y * 0.8f), 1);
        collision.gameObject.transform.localScale = decrease;
    }
}
