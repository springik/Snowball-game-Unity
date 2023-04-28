using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    LevelsUI levelsUI;

    // Start is called before the first frame update
    void Start()
    {
        levelsUI = FindObjectOfType<LevelsUI>(true);
    }

    public void quit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
    public void showLevels()
    {
        gameObject.SetActive(false);
        levelsUI.gameObject.SetActive(true);
    }
}
