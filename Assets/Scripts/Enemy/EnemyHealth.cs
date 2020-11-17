using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Image healthbarFillImage;
    [SerializeField] private Color maxHealthColor;
    [SerializeField] private Color minHealthColor;
    private int currentHealth;

    private void Start()
    {
        currentHealth = enemyStats.maxHealth;
        SetHealthbarUI();
    }

    public void DealDamage(int damage)
    {
        Debug.Log("test");
        currentHealth -= damage;
        CheckIfDead();
        SetHealthbarUI();
    }

    private void CheckIfDead()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthbarUI()
    {
        healthBarSlider.value = ((float)currentHealth / (float)enemyStats.maxHealth) * 100;
        healthbarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, (float)currentHealth / (float)enemyStats.maxHealth);
    }
}
