using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour
{
    public void GameScene(string sceneName)
    {
        SceneManager.LoadScene(1);
    }

    public void MenuScene(string sceneName)
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlayScene(string sceneName)
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
