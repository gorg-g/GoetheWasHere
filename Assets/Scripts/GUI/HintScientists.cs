using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScientists : MonoBehaviour
{

    public GameObject hintPrefab;
    public Button btn;
    public Text text;
    public int index;

    void Awake()
    {
        btn.onClick.AddListener(TaskOnClick);
        text.text = whichText(index);
    }


    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (hintPrefab.activeSelf)
        {
            hintPrefab.SetActive(false);
        }
        else
        {
            hintPrefab.SetActive(true);
        }
    }

    string whichText(int index)
    {
        switch (index)
        {
            case 0: //to find Humboldt
                return "I have to go downstairs in Humboldt's building and look for the rescue plan.";
                
            case 1:// to find 1st item
                return "I guess Humbi told me about some kind of matrix, element 6,1... What could it be? I think he likes art.";

            case 2:// to find Kirchhoff
                return "Maybe I should go to Kirchhoff's building. I remember something about Room 2013.";

            case 3:// to find 2nd Item
                return "Pretty sure there is something in the basement. I just feel it...";

            case 4:// to find Helmholtz
                return "Do u kno da wae? I sho u da wae! Run to Helmholtz's building's main entry! NOW! On the right!";

            case 5:// to find 3rd Item
                return "I don't know further, but what about climbing upstairs in Helmholtz and appreciating a nice picture of him.";

            case 6:// to find Zuse
                return "I heard on the streets that I need to go to Zusebau and scan a rescue plan. Just sayin'";

            case 7:// to find 4th Item
                return "Sometimes the solutions are so close! Maybe I should turn around - oh - a Zusebau-model!";

            case 8:// to find Goethe
                return "Humm.. didn't Zuse say something starting with 'Leib' and ending with 'nitz'. Heard that somewhere... Right - cookies!";
            
            case 420:
                return "Go to the campus map if u do not kno da wae, fgt? :DDD perkele, vitun aloittelija!";
        }
        return "";
    }
}
