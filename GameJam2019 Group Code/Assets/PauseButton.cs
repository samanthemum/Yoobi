using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] PauseButtonController pauseButtonController;
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    public PauseScript screen;

    // Update is called once per frame
    void Update()
    {
        if(screen.pause)
            if (pauseButtonController.index == thisIndex)
            {
                animator.SetBool("selected", true);
                if (Input.GetAxis("Submit") == 1)
                {
                    animator.SetBool("pressed", true);
                    if (thisIndex == 0)
                    {
                        screen.ScreenOff();
                    }
                    if (thisIndex == 1)
                    {
                        Initiate.Fade("Yoobi", Color.black, .7f);
                    }
                    if (thisIndex == 2)
                    {
                        Initiate.Fade("Start Menue", Color.black, .7f);
                    }
                }
                else if (animator.GetBool("pressed"))
                {
                    animator.SetBool("pressed", false);
                    //animatorFunctions.disableOnce = true;
                }
            }
            else
            {
                animator.SetBool("selected", false);
            }
        }
}

