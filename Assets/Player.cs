//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int maxHealth = 1000;
    public int currentHealth;
    private Scene scene;

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
        if (currentHealth < 0)
        {
            SceneManager.LoadScene("waterTest");
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterProNighttime")
        {
            TakeDamage(100);
        }
          
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}