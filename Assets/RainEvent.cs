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
        int RainDuration = Random.Range(minimumRainDuration, maximumRainDuration);
        StartCoroutine(Duration());
    }
    private void StopRain()
    {
        Debug.Log("Stopped rain");
        isRaining = false;
    }
    private IEnumerator Countdown()
    {
        Debug.Log("ya got 5 seconds before PAIN");
        while (timeUntilNextRainEvent > 0)
        {
            timeUntilNextRainEvent -= 1;
            yield return new WaitForSeconds(5);
        }
        StartRain();
    }
    private IEnumerator Duration()
    {
        Debug.Log("ya got 5 seconds before ya good");
        while (RainDuration > 0)
        {
            RainDuration -= 1;
            yield return new WaitForSeconds(5);
        }
        StopRain();
    }
}