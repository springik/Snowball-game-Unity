using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    protected void Show()
    {
        canvas.SetActive(true);
    }
    protected void Hide()
    {
        canvas.SetActive(false);
    }
}
