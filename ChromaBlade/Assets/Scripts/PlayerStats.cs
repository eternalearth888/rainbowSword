using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
	public float currentHealth;

	public Text ratioText;
    public Image currentHealthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		UpdateHealthBar();
    }

    // Update is called once per frame
    void UpdateHealthBar()
    {
		float healthRatio = currentHealth / maxHealth;
		currentHealthBar.rectTransform.localScale = new Vector3(healthRatio,1,1);
		ratioText.text = (healthRatio * 100).ToString() + "%";
    }

    public void TakeDamage(float taken){
        currentHealth -= taken;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        UpdateHealthBar();
    }

    public void RestoreHealth(float restored){
        currentHealth += restored;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }
}
