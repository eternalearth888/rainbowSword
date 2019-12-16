using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float taken){
        currentHealth -= taken;
    }

    public void RestoreHealth(float restored){
        currentHealth += restored;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
}
