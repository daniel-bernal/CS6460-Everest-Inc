using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
        LoadingScreenManager.LoadScene(1);
    }
	
}
