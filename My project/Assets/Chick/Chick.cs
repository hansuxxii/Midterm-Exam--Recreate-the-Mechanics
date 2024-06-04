using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Chick : MonoBehaviour
{
    public Text chickCountText;
    public Text henCountText;
    public Text roosterCountText;

    private void Start()
    {
        // Update the initial count of chicks
        UpdateChickCount();

        // Start the process of maturing the chick
        StartCoroutine(MatureChick());
    }

    private IEnumerator MatureChick()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Mature the chick into either a hen or a rooster
        Mature();

        // Destroy this chick object
        Destroy(gameObject);
    }

    private void Mature()
    {
        // Decide randomly whether the chick matures into a hen or a rooster
        bool isHen = Random.value > 0.5f;
        GameObject maturePrefab;

        if (isHen)
        {
            maturePrefab = Resources.Load<GameObject>("hen");
            if (maturePrefab != null)
            {
                Instantiate(maturePrefab, transform.position, transform.rotation);
                UpdateHenCount();
            }
        }
        else
        {
            maturePrefab = Resources.Load<GameObject>("rooster");
            if (maturePrefab != null)
            {
                Instantiate(maturePrefab, transform.position, transform.rotation);
                UpdateRoosterCount();
            }
        }
    }

    private void UpdateChickCount()
    {
        int chickCount = FindObjectsOfType<Chick>().Length;
        chickCountText.text = "Chicks: " + chickCount;
    }

    private void UpdateHenCount()
    {
        int henCount = FindObjectsOfType<Hen>().Length;
        henCountText.text = "Hens: " + henCount;
    }

    private void UpdateRoosterCount()
    {
        int roosterCount = FindObjectsOfType<Rooster>().Length;
        roosterCountText.text = "Roosters: " + roosterCount;
    }
}
