using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isBlocking = false;
    public float blockDuration = 1f; // Duration of blocking
    public float attackCooldown = 1f; // Cooldown between attacks
    private bool canAttack = true;
    public Sprite fighterAttack;
    public Sprite fighterBlock;
    public Sprite fighterNuetral;
    public int damage = 10;
    public GameObject fightersprite; // the target for changing the sprite of the fighter
    public Button blockButton;
    public Fighter playerFighter;



    // UI Reference 
    public HealthBar healthBar; 

    void Start()
    {
        blockButton.onClick.AddListener(playerFighter.Block);

        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            Debug.Log($"{gameObject.name} blocked the attack!");
            return;
        }

        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is defeated!");
            
            // Optionally disable the GameObject
            gameObject.SetActive(false);
        }
    }

    public void Attack(Fighter target)
    {
        if (canAttack)
        {
            SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = fighterAttack;            
            
            Debug.Log($"{gameObject.name} attacks {target.gameObject.name}");
            target.TakeDamage(damage); 
            StartCoroutine(AttackCooldown());
            spriteRenderer.sprite = fighterNuetral;
        }
        else
        {
            Debug.Log($"{gameObject.name} can't attack yet!");
        }
    }

    public void Block()
    {
        Debug.Log("1111111111111111111111111111111111111111111111111111111111111111111111111111111Block function called!");

        if (!isBlocking)
        {
            SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = fighterBlock;

            StartCoroutine(BlockCoroutine());
        }
    }

    private IEnumerator BlockCoroutine()
    {
        isBlocking = true;
        Debug.Log($"{gameObject.name} is blocking!");
        yield return new WaitForSeconds(blockDuration);
        isBlocking = false;
        SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fighterNuetral;
        Debug.Log($"{gameObject.name} stopped blocking!");
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}