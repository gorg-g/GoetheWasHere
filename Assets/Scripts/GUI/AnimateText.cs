using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateText : MonoBehaviour 
{
    public float AnimationSpeed = 0.001f;
    public int CharsPerAnimation = 5; //you can't get faster than framerate but you can take more chars at once

    Text textComponent;
    string textToDisplay = "";

	void Start () 
    {
        textComponent = GetComponent<Text>();
        string initText = textComponent.text;

        StartCoroutine(Animate(initText));
	}

    IEnumerator Animate(string textToAnimate)
    {
        int i = 0;
        while (i < textToAnimate.Length)
        {
            try
            {
                textToDisplay += textToAnimate.Substring(i, CharsPerAnimation);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                textToDisplay += textToAnimate.Substring(i);
            }

            i += CharsPerAnimation;

            textComponent.text = textToDisplay;
            yield return new WaitForSeconds(AnimationSpeed);
        }
    }

}
