using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetting : MonoBehaviour
{
    public static void QuickGoToScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}