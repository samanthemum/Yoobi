using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXIT : MonoBehaviour
{
	[SerializeField] HowToPlayButtonController menuButtonController;
	[SerializeField] Animator animator;
	//[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

	// Update is called once per frame
	void Update()
	{
		if (menuButtonController.index == thisIndex)
		{
			animator.SetBool("selected", true);
			if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
				if (thisIndex == 0)
				{
					Debug.Log("We have Quit The Game");
					Application.Quit();
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
