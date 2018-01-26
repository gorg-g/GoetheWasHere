using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPGameManager : MiniGameManager 
{   
    public byte nCupsHit;

	// Update is called once per frame
	void Update () 
    {
        if (nCupsHit == 10)
        {
            EndGame();
        }
		
	}
}
