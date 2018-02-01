using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEndText : MonoBehaviour {

    public int index;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = whichText(index);
    }

    string whichText(int index)
    {
        switch (index)
        {
            case 0: //Humboldt
                return "Well played! Humboldt must be proud of you! Or not... just go talhing to him!";

            case 1: //Kirchhoff
                return "Well done! We got a racer over here! Maybe Kirchhoff will five you something nice too!";

            case 2: //Helmmoltz
                return "Wow! You're a professional! But remember, drink responsibly!";

            case 3: //Zuse 
                return "Hey, kind of a math genius here.. Well done!";

            case 4: //flooding rules
                return "This one is easy! You just need to convert the decimal \n number in the upper side of the screen to binary \n Remeber: abcd = a*8+b*4+c*2+d*1 \n Have fun and be fast!";

            case 5: //Pick-up item 1
                return "Easter time! Have yourself a dope easter egg!";

            case 6: //Pick-uo item 2
                return "Abracadabra! Now you can turn into Harry Potter!";

            case 7: //Pick-uo item 3
                return "Take it for you! But be careful, they are made with pure silver and kind of heavy!";

            case 8: //Pick-uo item 4
                return "And I, with the power of Lord, name you King Ilmenau!";
        }
        return "";
    }
}
