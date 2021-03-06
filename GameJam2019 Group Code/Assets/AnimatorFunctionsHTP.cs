using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctionsHTP : MonoBehaviour
{
    [SerializeField] HowToPlayButtonController htpButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip whichSound)
    {
        if (!disableOnce)
        {
            htpButtonController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            disableOnce = false;
        }
    }
}
