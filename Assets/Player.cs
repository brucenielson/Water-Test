//using System.Collections;
//using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int maxHealth = 1000;
    public int currentHealth;
    private Scene scene;
    bool canTakeDamage = true;
    public HealthBar healthbar;
    public Collider collider;

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