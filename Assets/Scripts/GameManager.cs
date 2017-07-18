using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    float timeToEnd = 2;

	// Needs doors opening, and items disappearing
	void Update ()
    {
        var ennemies = GameObject.FindWithTag("Enemy");

        if(ennemies == null)
        {
            if(timeToEnd > 0)
            {
                timeToEnd -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Ennemies are dead");
            }
        }
	}

    
}
