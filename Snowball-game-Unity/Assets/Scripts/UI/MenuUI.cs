using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MenuUI : UIController
{
    LevelsUI levelsUI;
    public UnityEvent OnWipe { get; private set; } = new UnityEvent();
    public UnityEvent OnShowLevels { get; private set; } = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        levelsUI = FindObjectOfType<LevelsUI>(true);
        levelsUI.OnBack.AddListener(Show);
    }

    public void quit()
    {
        Application.Quit();
        //EditorApplication.ExitPlaymode();
    }
    public void showLevels()
    {
        Hide();
        OnShowLevels.Invoke();
    }
    public void WipeProgress()
    {
        PlayerPrefs.SetInt("highestLevel", 1);
        OnWipe.Invoke();
    }
}
