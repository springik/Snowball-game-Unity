using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaChannel : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float effectRange = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < effectRange)
        {
            Vector3 descrease = new Vector3((player.transform.localScale.x / 2f), (player.transform.localScale.y / 2f), 1);
            player.transform.localScale = descrease;
        }
    }
}
