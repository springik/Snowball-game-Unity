using System;
using System.Collections;
using System.Collections.Generic;
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
        Lost.AddListener(Lose);
        Won.AddListener(Win);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Lose()
    {
        throw new NotImplementedException();
    }
    void Win()
    {
        throw new NotImplementedException();
    }
}
