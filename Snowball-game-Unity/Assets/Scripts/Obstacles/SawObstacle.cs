using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObstacle : KillerObstacles
{
    [SerializeField]
    float speed = 0.5f;
    [SerializeField]
    Vector3 finishPoint;
    float curr, target = 0;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        finishPoint = new Vector3(startPos.x + finishPoint.x, startPos.y + finishPoint.y, startPos.z + finishPoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        //kolébá se od 0 -> 1 a zpátky -> tímpádem se vrací zpìt
        if(curr == target)
            target = target == 0 ? 1 : 0;
        curr = Mathf.MoveTowards(curr, target, speed * Time.deltaTime);

        //Debug.Log(curr);
        Vector3 newPos = Vector3.Lerp(startPos, finishPoint, curr);
        transform.position = newPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayerKilled?.Invoke();
    }
}
