using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warningmessages : MonoBehaviour
{

    public Text warningmesssage;
    public RainEvent rainEvent;
    public Indicator Indicator;
    public Indicator2 Indicator2;

    void Start()
    {
        StartCoroutine(Activator());
    }

    IEnumerator Activator()
    {
        while (true)
        {
            if (GetComponent <Indicator2>().enabled == true)
            {
                warningmesssage.text = "The clouds are gathering above you. Rain is coming.";
                StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
                yield return new WaitForSeconds(4);
                StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
                GetComponent<Indicator2>().enabled = false;
            }
            if (GetComponent<Indicator>().enabled == true)
            {
                warningmesssage.text = "The pressure has risen and the clouds have lifted. The rain has stopped.";
                StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
                yield return new WaitForSeconds(4);
                StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
                GetComponent<Indicator>().enabled = false;
            }
            yield return null;
        }
    }
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
