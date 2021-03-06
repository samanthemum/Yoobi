using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctionsPause : MonoBehaviour
{
    [SerializeField] PauseButtonController pauseButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip whichSound)
    {
        if (!disableOnce)
        {
            pauseButtonController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            disableOnce = false;
        }
    }
}
