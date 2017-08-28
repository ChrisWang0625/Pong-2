using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public string sceneToLoad;

    public int secondsTillSceneLoad;

	// Use this for initialization
	void Start () {

        Invoke("OpenNextScene", secondsTillSceneLoad);
		
	}
	
    void OpenNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
