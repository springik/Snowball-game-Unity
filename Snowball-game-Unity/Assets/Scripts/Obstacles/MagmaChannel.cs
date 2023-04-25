using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaChannel : KillerObstacles
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayerKilled?.Invoke();
    }
}
