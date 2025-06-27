using UnityEngine;
using System.Collections;


public class BossHealth : MonoBehaviour
{
    public int health = 30;
    public GameObject deathEffect;
    public GameObject healthbarUI;
    public GameObject activate;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private bool invulnerable;



    public void TakeDamage(int damage)
    {
        if (invulnerable)
            return;
        GetComponent<Animator>().SetTrigger("Hurt");
        StartCoroutine(Invunerability());
        health -= damage;

        if (health <= 10)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }
        
        if (health <= 0)
        {
            Die();
        }
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            yield return new WaitForSeconds(1);
            //yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        invulnerable = false;
    }
    void Die()
    {
        deathEffect.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        activate.SetActive(true);
        Destroy(gameObject);
        Destroy(healthbarUI);
    }
}