using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
	public float currentHealth;

    public Image currentHealthBar;

    public static bool yellowAttacking;
    private float yellowTimer = 1.2f;

    public static bool crystalDeath;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        yellowAttacking = false;
        crystalDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
		float healthRatio = currentHealth / maxHealth;
		currentHealthBar.rectTransform.localScale = new Vector3(healthRatio,1,1);
        if(yellowAttacking){
            yellowTimer -= Time.deltaTime;
            if(yellowTimer <= 0){
                yellowAttacking = false;
                yellowTimer = 1.2f;
            }
        }
        if(crystalDeath){
            currentHealth = maxHealth;
            crystalDeath = false;
        }
    }

    public void TakeDamage(float taken){
        if(!yellowAttacking){
            currentHealth -= taken;
        }
        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void RestoreHealth(float restored){
        currentHealth += restored;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
}
