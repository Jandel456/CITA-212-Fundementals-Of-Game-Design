using UnityEngine;

public class PackageCustomerRemover : MonoBehaviour
{
    public int numberToRemove = 8; // Number of packages to remove

    void Start()
    {
        // Find all GameObjects with the tag "Package"
        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
        GameObject[] customer = GameObject.FindGameObjectsWithTag("Customer");

        // Check if there are enough packages to remove
        if (packages.Length < numberToRemove)
        {
            Debug.LogWarning("Not enough packages to remove. Adjusting to available count.");
            numberToRemove = packages.Length;
        }

            if (customer.Length < numberToRemove)
        {
            Debug.LogWarning("Not enough customers to remove. Adjusting to available count.");
            numberToRemove = customer.Length;
        }

        // Create a list of indices and shuffle it for random selection
        System.Random prandom = new System.Random();
        int[] pindices = new int[packages.Length];
        for (int i = 0; i < pindices.Length; i++)
        {
            pindices[i] = i;
        }

        System.Random crandom = new System.Random();
        int[] cindices = new int[customer.Length];
        for (int i = 0; i < cindices.Length; i++)
        {
            cindices[i] = i;
        }

        // Shuffle the indices array
        for (int i = pindices.Length - 1; i > 0; i--)
        {
            int j = prandom.Next(i + 1);
            (pindices[i], pindices[j]) = (pindices[j], pindices[i]); // Swap
        }

        for (int i = cindices.Length - 1; i > 0; i--)
        {
            int j = crandom.Next(i + 1);
            (cindices[i], cindices[j]) = (cindices[j], cindices[i]); // Swap
        }

        // Delete the first objects
        for (int i = 0; i < numberToRemove; i++)
        {
            Destroy(packages[pindices[i]]);
        }
        
        for (int i = 0; i < numberToRemove; i++)
        {
            Destroy(customer[cindices[i]]);
        }
    }
}