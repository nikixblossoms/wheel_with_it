using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public Text moneyText;
    public Text moneyLossPopup;

    private Color greenColor;
    private Color redColor;

    public StartMenu sm;

    void Start()
    {
        moneyCount = 50;

        ColorUtility.TryParseHtmlString("#113616", out greenColor);
        ColorUtility.TryParseHtmlString("#8a1616", out redColor);

        moneyLossPopup.gameObject.SetActive(false);

        StartCoroutine(WaitForGameStartThenDecreaseMoney());
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
            moneyText.text = ": " + moneyCount.ToString() + " (LOW ENERGY!)";
        }
    }

    IEnumerator WaitForGameStartThenDecreaseMoney()
    {
        // Wait until the start menu panel is no longer active
        while (sm.startMenuPanel.activeSelf)
        {
            yield return null; // wait for next frame
        }

        // Now start decreasing money
        StartCoroutine(DecreaseMoneyOverTime());
    }

    IEnumerator DecreaseMoneyOverTime()
    {
        while (moneyCount > -100)
        {
            yield return new WaitForSeconds(2f);
            moneyCount -= 5;
            StartCoroutine(ShowMoneyLossPopup("-5"));
        }
    }

    IEnumerator ShowMoneyLossPopup(string message)
    {
        moneyLossPopup.text = message;
        moneyLossPopup.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        moneyLossPopup.gameObject.SetActive(false);
    }
}
