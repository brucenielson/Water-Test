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
    private bool countdownStarted;

    public void StartRainEventCountdown()
    {
        timeUntilNextRainEvent = Random.Range(minimumTimeUntilNextRainEvent, maximumTimeUntilNextRainEvent);
        countdownStarted = true;
        StartCoroutine(Countdown());
    }
    private void StartRain()
    {
        isRaining = true;
        int rainDuration = Random.Range(minimumRainDuration, maximumRainDuration);
    }
    private void StopRain()
    {
        //
    }
    private IEnumerator Countdown()
    {
        while (timeUntilNextRainEvent > 0)
        {
            timeUntilNextRainEvent -= 1;
            yield return new WaitForSeconds(60);
        }
        StartRain();
    }
}
