﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");

        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        // Uses p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    // Reloads the level
    public void Reload()
    {
        LM.ReloadLevel(2);
    }
    
    // Controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    // Shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    
    // Hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    
    // Loads inputted level
    public void LoadLevel(int level)
    {
        LM.ReloadLevel(level);
    }
}