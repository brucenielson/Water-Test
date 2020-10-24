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

    //Manage healthbar
    void Start ()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    //take damage while in rain
    private void Update()
    {
        if (rainEvent.isRaining == true)
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

    //Take damage from water bodies
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