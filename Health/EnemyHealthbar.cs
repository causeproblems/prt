using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private BossHealth bossHealth;        
    [SerializeField] private Image totalHealthBar;         
    [SerializeField] private Image currentHealthBar;       

    private float maxHealth;

    private void Start()
    {
        maxHealth = bossHealth.health; 
        totalHealthBar.fillAmount = 1f; 
    }

    private void Update()
    {
        currentHealthBar.fillAmount = bossHealth.health / maxHealth;
    }
}
