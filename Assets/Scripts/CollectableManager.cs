using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectableManager : MonoBehaviour
{
    public int fuelCount;
    public Text fuelPopupText; // Reference to popup UI

    void Start()
    {
        fuelPopupText.gameObject.SetActive(false); // Hide popup initially
    }

    public IEnumerator ShowFuelPopup(string message)
    {
        fuelPopupText.text = message;
        fuelPopupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // Show for 1 second
        fuelPopupText.gameObject.SetActive(false);
    }
}
