using System.Collections;
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

        GameObject ship = (GameObject)Instantiate(Resources.Load("prefabs/falcon"));
        Instantiate(Resources.Load("prefabs/HUD"));
        Instantiate(Resources.Load("prefabs/healthbar"));
        HUD.Initialize();
        Destroy(GameObject.FindGameObjectWithTag("controlsButton"));
        Destroy(GameObject.FindGameObjectWithTag("quitButton"));
        Destroy(gameObject);
        Time.timeScale = 1;
    }

}

