using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsUI : UIController
{
    MenuUI menuUi;
    int highestLevel;
    [SerializeField]
    List<Button> btns;
    public UnityEvent OnBack { get; private set; } = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("highestLevel") < 1 || !PlayerPrefs.HasKey("highestLevel"))
            PlayerPrefs.SetInt("highestLevel", 1);
        menuUi = FindObjectOfType<MenuUI>(true);

        //btns = GetComponentsInChildren<Button>(true).ToList<Button>();

        UnlockLevels();
        menuUi.OnShowLevels.AddListener(Show);
        menuUi.OnWipe.AddListener(UnlockLevels);
    }

    public void back()
    {
        Hide();
        OnBack.Invoke();
    }
    public void lvlClick(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    void UnlockLevels()
    {
        foreach (Button b in btns)
        {
            b.interactable = false;
        }

        highestLevel = PlayerPrefs.GetInt("highestLevel");
        Debug.Log("Highest lvl:" + highestLevel);
        Debug.Log("btn count: " + btns.Count);
        for (int i = 0; i < highestLevel; i++)
        {
            btns[i].interactable = true;
        }
    }
}
