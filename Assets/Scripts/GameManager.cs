using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    float timeToEnd = 2f;
    

	// Needs doors opening, and items disappearing
	void Update ()
    {
        var ennemies = GameObject.FindWithTag("Enemy");
        var doors = GameObject.FindWithTag("Door");

        if(ennemies == null && doors != null)
        {
            doors.SetActive(false);
        }
	}

    
}
