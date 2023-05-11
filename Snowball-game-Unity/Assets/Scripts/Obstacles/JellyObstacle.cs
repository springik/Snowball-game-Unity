using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObstacle : MonoBehaviour
{
    WaitForSeconds _waiter = new WaitForSeconds(1);
    [SerializeField] int _cooldownTime = 5;
    int _currCooldown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_currCooldown <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _currCooldown = _cooldownTime;
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        if(_currCooldown > 0)
        {
            _currCooldown--;
            yield return _waiter;
        }
    }
}
