using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField]
    float snowIncrement = 0.005f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Jestli se koule pohybuje, tak se zvìtšuje. Když se moc zvìtší, tak hráè prohraje
        if (rb.velocity.magnitude >= 0.3)
        {
            Vector3 increase = new Vector3((transform.localScale.x + snowIncrement), (transform.localScale.y + snowIncrement), 1);

            if (increase.magnitude > new Vector3(3f, 3f, 0).magnitude || increase.magnitude < new Vector3(0.8f, 0.8f, 0).magnitude)
                GameManager.Instance.Lost.Invoke();

            transform.localScale = increase;
        }
    }
}
