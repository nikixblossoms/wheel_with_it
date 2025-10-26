using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public Text moneyText;

    private Color greenColor;
    private Color redColor;

    void Start()
    {
        moneyCount = 20;

        // Convert hex strings to Unity Color
        ColorUtility.TryParseHtmlString("#113616", out greenColor);
        ColorUtility.TryParseHtmlString("#8a1616", out redColor);

        StartCoroutine(DecreaseMoneyOverTime());
    }

    void Update()
    {
        moneyText.text = ": " + moneyCount.ToString();

        if (moneyCount >= 0)
        {
            moneyText.color = greenColor;
        }
        else
        {
            moneyText.color = redColor;
            moneyText.text = ": " + moneyCount.ToString() + " (IN DEBT!)";
        }
    }

    IEnumerator DecreaseMoneyOverTime()
    {
        while (moneyCount > -100) // Optional lower limit
        {
            yield return new WaitForSeconds(2f);
            moneyCount -= 5;
        }
    }
}
