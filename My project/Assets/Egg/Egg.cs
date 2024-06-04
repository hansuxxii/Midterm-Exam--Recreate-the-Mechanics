using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    // Reference to the egg count UI text
    public Text eggCountText;
    public Text chickCountText;

    private void Start()
    {
        // Update the initial count of eggs
        UpdateEggCount();

        // Start the process of hatching the egg
        StartCoroutine(HatchEgg());
    }

    private IEnumerator HatchEgg()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Hatch the egg (instantiate a chick)
        HatchChick();

        // Destroy this egg object
        Destroy(gameObject);
    }

    private void HatchChick()
    {
        // Find the chick prefab (ensure you have a chick prefab in your Resources folder)
        GameObject chickPrefab = Resources.Load<GameObject>("chick");

        if (chickPrefab != null)
        {
            // Instantiate the chick at the egg's position
            Instantiate(chickPrefab, transform.position, transform.rotation);

            // Update the chick count UI
            UpdateChickCount();
        }
        else
        {
            Debug.LogError("Chick prefab not found in Resources folder!");
        }
    }

    private void UpdateEggCount()
    {
        // Update the egg count text
        int eggCount = FindObjectsOfType<Egg>().Length;
        eggCountText.text = "Eggs: " + eggCount;
    }

    private void UpdateChickCount()
    {
        // Update the chick count text
        int chickCount = FindObjectsOfType<Chick>().Length;
        chickCountText.text = "Chick: " + chickCount;
    }
}
