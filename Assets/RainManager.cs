using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour {
    public RainEvent rainEvent;
    void Start () {

        if (rainEvent.timeUntilNextRainEvent == 0)
        {
            rainEvent.Start();
        }
    }

}
