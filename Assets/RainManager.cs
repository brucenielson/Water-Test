using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour {
    public RainEvent rainEvent;
    // Use this for initialization
    void Start () {

        if (rainEvent.timeUntilNextRainEvent == 0)
        {
            rainEvent.StartRainEventCountdown();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
