using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LM : MonoBehaviour {

    public static LM singleton;

	// Use this for initialization
	void Awake () {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
	}

    public static void ReloadLevel(int vLevel)
    {
        SceneManager.LoadScene(vLevel);
    }
}