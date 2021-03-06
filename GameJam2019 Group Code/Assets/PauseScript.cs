using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool visible = false;
    public bool pause = false;
    public CanvasGroup screen;
    void Start()
    {
        screen.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!visible)
            {
                ScreenOn();
            }
            else
            {
                ScreenOff();
            }
        }
    }
    public void ScreenOff()
    {
        visible = false;
        pause = false;
        screen.alpha = 0f;
    }

    public void ScreenOn()
    {
        visible = true;
        pause = true;
        screen.alpha = .90f;
    }

    public void ReturnToMenu()
    {
        if (pause)
        {
            Initiate.Fade("Start Menue", Color.black, .7f);
        }
    }

    public void RestartLevel()
    {
        if (pause)
        {
            Initiate.Fade("Yoobi", Color.black, .7f);
        }
    }
}


