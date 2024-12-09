using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PureEnemyFighter : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    private int enemyCurrentHealth;
    public float decisionInterval = 0.3f; // Time between decisions
    private bool enemyIsActing = false;
    private bool enemyIsBlocking = false;
    
    public float enemyBlockDuration = 1f; // Duration of blocking
    public float primingDuration = 0.7f;   // Time spent in Priming state
    public float attackDuration = 0.5f;

    public float enemyAttackCooldown = 1f; // Cooldown between attacks
    public GameObject fightersprite; // the target for changing the sprite of the fighter
    public Sprite fighterPrime;
    public Sprite fighterAttack;
    public Sprite fighterBlock;
    public Sprite fighterNuetral;
    public int enemyDamage = 10;
    private enum EnemyState { Neutral, Priming, Attacking, Blocking }
    private Fighter target;              // Reference to the player

    // UI Reference 
    public HealthBar healthBar; 

    void Start()
    {
        target = FindObjectOfType<Fighter>(); // Assuming PlayerFighter is a subclass of Fighter

        InvokeRepeating(nameof(DecideAction), decisionInterval, decisionInterval);

        enemyCurrentHealth = enemyMaxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(enemyMaxHealth);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (enemyIsBlocking)
        {
            Debug.Log($"{gameObject.name} blocked the attack!");
            return;
        }

        enemyCurrentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(enemyCurrentHealth);
        }

        if (enemyCurrentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is defeated!");
            
            // Optionally disable the GameObject
            gameObject.SetActive(false);
        }
    }

    private void StartBlocking()
    {
        EnemyBlock();
    }
    public void EnemyBlock()
    {
        if (!enemyIsBlocking)
        {
            enemyIsActing = true;


            SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = fighterBlock;

            enemyIsBlocking = true;
            Debug.Log($"{gameObject.name} is blocking!");


            StartCoroutine(EnemyBlockCoroutine());
        }
    }

        private IEnumerator EnemyBlockCoroutine()
    {
        yield return new WaitForSeconds(enemyBlockDuration);
        enemyIsBlocking = false;
        Debug.Log($"{gameObject.name} stopped blocking!");
        
        //return to nuetral after blocking
        SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fighterNuetral;

        enemyIsActing = false;
    }

    private void DecideAction()
    {
        if (enemyIsActing) return; // Skip decision making if currently acting

        int randomChoice = Random.Range(0, 2); // 0 for attack, 1 for block
        if (randomChoice == 0)
        {
            StartCoroutine(PrimeAndAttack());
        }
        else
        {
            StartBlocking();
        }
    }

    private IEnumerator PrimeAndAttack()
    {
        enemyIsActing = true;

        // Visual feedback for Priming
        SpriteRenderer spriteRenderer = fightersprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fighterPrime;
        Debug.Log($"{gameObject.name} is priming to attack!");
        yield return new WaitForSeconds(primingDuration);

        // Attack the player
        spriteRenderer.sprite = fighterAttack;
        Debug.Log($"{gameObject.name} is attacking");
        target.TakeDamage(10);
        yield return new WaitForSeconds(attackDuration);


        // Return to Neutral state
        spriteRenderer.sprite = fighterNuetral;
        enemyIsActing = false;
        yield return new WaitForSeconds(enemyAttackCooldown); // Cooldown after attack
    }


}