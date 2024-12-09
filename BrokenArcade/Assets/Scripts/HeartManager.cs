using UnityEngine;
using UnityEngine.UI;  // Needed to access Image components

public class HeartManager : MonoBehaviour
{
    public static HeartManager Instance { get; private set; }  // Singleton instance

    public GameObject heartImage;   
    public Sprite heartFull;   
    public Sprite heartHalf;  
    public Sprite heartEmpty;  

    public int hearts = 3;     
    public int checks = 0;     

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void UpdateHeartSprite()
    {
        // Update the heart sprite based on the number of hearts
        SpriteRenderer spriteRenderer = heartImage.GetComponent<SpriteRenderer>();

        if (hearts == 3)
        {
            spriteRenderer.sprite = heartFull;
        }
        else if (hearts == 2)
        {
            spriteRenderer.sprite = heartHalf;
        }
        else if (hearts == 1)
        {
            spriteRenderer.sprite = heartHalf;
        }
        else if (hearts == 0)
        {
            spriteRenderer.sprite = heartEmpty;
        }
    }

    public void RemoveHeart()
    {
        if (hearts > 0)
        {
            hearts--;
            UpdateHeartSprite();
        }
    }

    // Call this to reset hearts to 3 (for example, after respawning)
    public void ResetHearts()
    {
        hearts = 3;
        UpdateHeartSprite();
    }

    // Call this to increase the checks count (e.g., after a player completes a certain task)
    public void AddCheck()
    {
        checks++;
    }

    // Call this to decrease the checks count (e.g., if a check is used)
    public void RemoveCheck()
    {
        if (checks > 0)
        {
            checks--;
        }
    }

    // Call this to reset the checks count (e.g., at the start of a new level)
    public void ResetChecks()
    {
        checks = 0;
    }
}
