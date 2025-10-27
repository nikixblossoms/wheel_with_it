using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject MoneyCanvas;

    public GameObject ScoreCanvas;

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        MoneyCanvas.SetActive(true);
        ScoreCanvas.SetActive(true);
    }
}