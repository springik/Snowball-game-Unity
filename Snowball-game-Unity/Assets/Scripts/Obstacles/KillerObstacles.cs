using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillerObstacles : MonoBehaviour
{
    public UnityEvent PlayerKilled { get; protected set; } = new UnityEvent();
}
