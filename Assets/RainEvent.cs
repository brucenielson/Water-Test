using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEvent : MonoBehaviour {

    public string warningMessage = "Rain Incoming! Get To Da Choppa!";
    public string eventOverMessage = "it has stopped raining.";
    public bool isRaining;
    public int minimumTimeUntilNextRainEvent;
    public int maximumTimeUntilNextRainEvent;
    public int timeUntilNextRainEvent;
    public int minimumRainDuration;
    public int maximumRainDuration;
    public int RainDuration;
    public int maximumRainfallWait;
    public int minimumRainfallWait;
    public int RainfallWait;

     public void Start()
    {
        StartCoroutine(Rain());
    }

    IEnumerator Rain()
    {
        //sets how long 1 minute is?
        var wait = new WaitForSeconds(5f);
        while (true)
        {
            //sets time until next rain event
            int timeUntilNextRainEvent = Random.Range(minimumTimeUntilNextRainEvent, maximumTimeUntilNextRainEvent);
            while (timeUntilNextRainEvent > 0)
            {
                //countdown til next rain event
                timeUntilNextRainEvent--;
                yield return wait;
            }
            //sets the rain duration
            isRaining = true;
            int RainDuration = Random.Range(minimumRainDuration, maximumRainDuration);
            while (RainDuration > 0)
            {
                //countdown until clear skies
                RainDuration--;
                yield return wait;
            }
            //stops the rain
            isRaining = false;
            //sets time until next rainfall
            int RainfallWait = Random.Range(minimumRainfallWait, maximumRainfallWait);
            while (RainfallWait > 0)
            {
                //countdown until clear skies
                RainfallWait--;
                yield return wait;
            }
            yield return null;
        }
    }
}