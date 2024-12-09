using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool playerisBlocking = false;
    public float playerblockDuration = 1f; // Duration of blocking
    public float playerattackCooldown = 1f; // Cooldown between attacks
    private bool canAttack = true;
    public GameObject playerfightersprite; // the target for changing the sprite of the fighter
    public Sprite playerfighterAttack;
    public Sprite playerfighterBlock;
    public Sprite playerfighterNuetral;
    public int playerdamage = 10;
    private PureEnemyFighter enemy; // Reference to the enemy

    // UI Reference 
    public HealthBar healthBar; 

    void Start()
    {
        enemy = FindObjectOfType<PureEnemyFighter>();


        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    void Update()
{    if (Input.GetKeyDown(KeyCode.Space))
    {
        Attack();
    }

    if (Input.GetKeyDown(KeyCode.B))
    {
        Block();
    }
}

    public void TakeDamage(int damage)
    {
        if (playerisBlocking)
        {
            currentHealth += 10;
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
            HeartManager.Instance.RemoveHeart();
            Debug.Log($"{gameObject.name} is defeated!");
            
            // Optionally disable the GameObject
            gameObject.SetActive(false);
        }
    }

    public void Attack()
    {
        if (canAttack)
        {
            SpriteRenderer spriteRenderer = playerfightersprite.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = playerfighterAttack;            
            
            Debug.Log($"{gameObject.name} attacks {enemy.gameObject.name}");
            enemy.EnemyTakeDamage(playerdamage);
            StartCoroutine(AttackCooldown());
        }
        else
        {
            Debug.Log($"{gameObject.name} can't attack yet!");
        }
    }

    public void Block()
    {
        Debug.Log("1111111111111111111111111111111111111111111111111111111111111111111111111111111Block function called!");

        if (!playerisBlocking)
        {
            SpriteRenderer spriteRenderer = playerfightersprite.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = playerfighterBlock;

            StartCoroutine(BlockCoroutine());
        }
    }

    private IEnumerator BlockCoroutine()
    {
        SpriteRenderer spriteRenderer = playerfightersprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerfighterBlock;
        playerisBlocking = true;
        Debug.Log($"{gameObject.name} is blocking!");
        yield return new WaitForSeconds(playerblockDuration);
        playerisBlocking = false;
        spriteRenderer.sprite = playerfighterNuetral;
        Debug.Log($"{gameObject.name} stopped blocking!");
    }

    private IEnumerator AttackCooldown()
    {
        SpriteRenderer spriteRenderer = playerfightersprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerfighterAttack; 
        canAttack = false;
        yield return new WaitForSeconds(playerattackCooldown);
        canAttack = true;
        spriteRenderer.sprite = playerfighterNuetral;

    }
}