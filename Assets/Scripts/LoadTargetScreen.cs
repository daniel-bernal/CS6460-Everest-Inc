using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTargetScreen : MonoBehaviour {

    public __appManager app;

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();
    }

    public void LoadSceneNum(int num)
    {
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + num + ", SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings!");
            return;
        }
        app.lastSceneNum = SceneManager.GetActiveScene().buildIndex;
        LoadingScreenManager.LoadScene(num);
    }

    public void LoadLastScene()
    {
        if (app.lastSceneNum < 0 || app.lastSceneNum >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + app.lastSceneNum + ", SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings!");
            return;
        }
        LoadingScreenManager.LoadScene(app.lastSceneNum);
    }
}
