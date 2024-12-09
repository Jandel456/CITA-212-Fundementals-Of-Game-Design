using System.Collections;
using UnityEngine;

public class EnemyFighter : Fighter
{
    private enum EnemyState { Neutral, Priming, Attacking, Blocking }
    private EnemyState currentState = EnemyState.Neutral;

    public float decisionInterval = 0.3f; // Time between decisions
    public float primingDuration = 1f;   // Time spent in Priming state
    private Fighter target;              // Reference to the player
    private bool isActing = false;
    public Sprite fighterPrime;


    void Start()
    {

        target = FindObjectOfType<Fighter>(); // Assuming PlayerFighter is a subclass of Fighter
        InvokeRepeating(nameof(DecideAction), decisionInterval, decisionInterval);
    }

    private void DecideAction()
    {
        if (isActing) return; // Skip decision-making if currently acting

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
        ChangeState(EnemyState.Priming);
        isActing = true;

        // Visual feedback for Priming (e.g., raising sword)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = fighterPrime;
        Debug.Log($"{gameObject.name} is priming to attack!");
        yield return new WaitForSeconds(primingDuration);

        // Attack the player
        ChangeState(EnemyState.Attacking);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = fighterAttack;
        Debug.Log($"{gameObject.name} is attacking {target.gameObject.name}");
        target.TakeDamage(10); // Example damage value

        // Return to Neutral state
        yield return new WaitForSeconds(attackCooldown); // Cooldown after attack
        ChangeState(EnemyState.Neutral);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = fighterNuetral;
        isActing = false;
    }

    private void StartBlocking()
    {
        ChangeState(EnemyState.Blocking);
        Block();
        isActing = true;

        // Return to Neutral state after blocking
        StartCoroutine(EndBlocking());
    }

    private IEnumerator EndBlocking()
    {
        yield return new WaitForSeconds(blockDuration);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = fighterNuetral;
        ChangeState(EnemyState.Neutral);
        isActing = false;
    }

    private void ChangeState(EnemyState newState)
    {
        currentState = newState;
        Debug.Log($"{gameObject.name} is now in state: {currentState}");
    }
}