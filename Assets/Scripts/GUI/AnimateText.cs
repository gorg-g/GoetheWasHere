using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateText : MonoBehaviour 
{
    public float AnimationSpeed = 0.001f;
    public int CharsPerAnimation = 5; //you can't get faster than framerate but you can take more chars at once

    Text textComponent;
    string wholeText = "";
    string textToDisplay = "";
    int startIndex = 0;

	void Start () 
    {
        textComponent = GetComponent<Text>();
        wholeText = textComponent.text;

        StartCoroutine(Animate(wholeText));
	}

    void OnEnable()
    {
        StartCoroutine(Animate(wholeText));
    }

    IEnumerator Animate(string textToAnimate)
    {
        while (startIndex < textToAnimate.Length)
        {
            try
            {
                textToDisplay += textToAnimate.Substring(startIndex, CharsPerAnimation);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                textToDisplay += textToAnimate.Substring(startIndex);
            }

            startIndex += CharsPerAnimation;

            textComponent.text = textToDisplay;
            yield return new WaitForSeconds(AnimationSpeed);
        }
    }

}
