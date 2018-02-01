using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public TextMesh derText;
    public bool checking = false;

    public bool gameOver = false;


    void OnMouseDown()
    {
        TextChange();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    void TextChange()
    {
        if (!gameOver)
        {
            if (!checking)
            {
                derText.text = "1";
                checking = true;
            }
            else
            {
                derText.text = "0";
                checking = false;
            }
        }
    }

    public bool getChecking()
    {
        return checking;
    }

    public void reset()
    {
        if (checking == true)
        {
            derText.text = "0";
            checking = false;
        }
    }

    public void changeColor()
    {
        Material materialColored;
        materialColored = new Material(Shader.Find("Diffuse"));
        materialColored.color = new Color(0, 1, 0);
        this.GetComponent<Renderer>().material = materialColored;
    }

    public void changeColorBack()
    {
        Material materialColored;
        materialColored = new Material(Shader.Find("Diffuse"));
        materialColored.color = new Color(1, 1, 1);
        this.GetComponent<Renderer>().material = materialColored;
    }
}




