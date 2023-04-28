using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsUI : MonoBehaviour
{
    MenuUI menuUi;
    int highestLevel;
    List<Button> btns;
    // Start is called before the first frame update
    void Start()
    {
        menuUi = FindObjectOfType<MenuUI>(true);

        highestLevel = PlayerPrefs.GetInt("highestLevel");
        btns = GetComponentsInChildren<Button>(true).ToList<Button>();
        for (int i = 0; i < highestLevel; i++)
        {
            btns[i].interactable = true;
        }
    }

    public void back()
    {
        gameObject.SetActive(false);
        menuUi.gameObject.SetActive(true);
    }
    public void lvlClick(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
