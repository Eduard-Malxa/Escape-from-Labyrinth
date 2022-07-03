using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUIParent;

    [SerializeField]
    private GameObject levelPassedUIParent;

    public static event Action GameOverAction;

    public static event Action LevelPassedAction;

    private void Start()
    {
        GameOverAction += OpenGameOver;
        LevelPassedAction += OpenLevelPassed;
    }

    private void OnDisable()
    {
        GameOverAction -= OpenGameOver;
        LevelPassedAction -= OpenLevelPassed;
    }

    public static void GameOver()
    {
        GameOverAction?.Invoke();
    }

    public static void LevelPassed()
    {
        LevelPassedAction?.Invoke();
    }

    private void OpenGameOver()
    {
        gameOverUIParent.SetActive(true);
    }

    private void OpenLevelPassed()
    {
        levelPassedUIParent.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
