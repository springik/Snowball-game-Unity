using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Lost.AddListener(Show);
    }
}
