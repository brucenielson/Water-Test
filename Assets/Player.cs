//using System.Collections;
//using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int maxHealth = 1000;
    public int currentHealth;
    bool canTakeDamage = true;
    public HealthBar healthbar;
    public static bool Raycast;
    RaycastHit hit;
    public RainEvent rainEvent;

    // Start is called once per frame
    void Start ()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    //teleport after death
    private void Update()
    {
        if (currentHealth < 1)
        {
            SceneManager.LoadScene("Water test");
        }
        if (rainEvent.timeUntilNextRainEvent == 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
                if (canTakeDamage)
                {
                    StartCoroutine(WaitForSeconds());
                    TakeDamage(100);
                }
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "WaterProNighttime")
        {
            if (canTakeDamage)
            {
                StartCoroutine(WaitForSeconds());
                TakeDamage(100);
            }
        }
         
    }

    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(1);
        canTakeDamage = true;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}