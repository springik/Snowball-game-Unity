using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : InLevelUIController
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Lost.AddListener(Show);
    }
}
