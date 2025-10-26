using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuPanel;

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
    }
}