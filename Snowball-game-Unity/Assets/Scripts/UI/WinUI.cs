using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : InLevelUIController, ICanLoadNextLvl
{
    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            Time.timeScale = 1.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Won.AddListener(Show);
    }
}
