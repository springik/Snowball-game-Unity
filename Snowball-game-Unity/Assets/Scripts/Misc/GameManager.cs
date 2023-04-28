using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public UnityEvent Lost { get; protected set; } = new UnityEvent();
    public UnityEvent Won { get; protected set; } = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        List<KillerObstacles> killerObstacles = FindObjectsOfType<KillerObstacles>().ToList<KillerObstacles>();
        foreach(KillerObstacles obstacle in killerObstacles)
        {
            obstacle.PlayerKilled.AddListener(Lose);
        }
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);

        Goal goal = FindFirstObjectByType<Goal>();
        goal?.Won.AddListener(Win);

        if(PlayerPrefs.GetInt("highestLevel") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("highestLevel", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetInt("highestLevel") + " level");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1.0f;
        }
    }

    void Lose()
    {
        Lost.Invoke();
        Time.timeScale = 0f;
    }
    void Win()
    {
        Won.Invoke();
        Time.timeScale = 0f;
    }
}
