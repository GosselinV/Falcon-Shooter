﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 0;
    }
    public void HandleStartButton()
    {
        Time.timeScale = 1;
        GameObject ship = (GameObject)Instantiate(Resources.Load("prefabs/falcon"));
        Destroy(GameObject.FindGameObjectWithTag("controlsButton"));
        Destroy(gameObject);
    }

}
