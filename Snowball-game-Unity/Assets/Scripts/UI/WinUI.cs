using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Won.AddListener(Show);
    }
    public void LoadNextLevel()
    {

    }
}
