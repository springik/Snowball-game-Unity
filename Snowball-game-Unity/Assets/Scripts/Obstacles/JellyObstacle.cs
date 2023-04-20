using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collPoint = collision.contacts[0].point;
        float dis = Vector2.Distance(transform.position, collPoint);

        float force = 1 / dis;
        Vector2 dir = (new Vector2(transform.position.x, transform.position.y) - collPoint).normalized;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
    }
}
