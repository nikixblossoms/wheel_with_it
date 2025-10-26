using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public Text moneyText;
    public Text moneyLossPopup; // Reference to the -$5 popup text

    private Color greenColor;
    private Color redColor;

    void Start()
    {
        moneyCount = 20;

        // Convert hex strings to Unity Color
        ColorUtility.TryParseHtmlString("#113616", out greenColor);
        ColorUtility.TryParseHtmlString("#8a1616", out redColor);

        moneyLossPopup.gameObject.SetActive(false); // Hide popup initially

        StartCoroutine(DecreaseMoneyOverTime());
    }

    void Update()
    {
        moneyText.text = ": $ " + moneyCount.ToString();

        if (moneyCount >= 0)
        {
            moneyText.color = greenColor;
        }
        else
        {
            moneyText.color = redColor;
            moneyText.text = ": $ " + moneyCount.ToString() + " (IN DEBT!)";
        }
    }

    IEnumerator DecreaseMoneyOverTime()
    {
        while (moneyCount > -100)
        {
            yield return new WaitForSeconds(2f);
            moneyCount -= 5;
            StartCoroutine(ShowMoneyLossPopup("-$5")); // Show popup
        }
    }

    IEnumerator ShowMoneyLossPopup(string message)
    {
        moneyLossPopup.text = message;
        moneyLossPopup.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // Show for 1 second
        moneyLossPopup.gameObject.SetActive(false);
    }
}
