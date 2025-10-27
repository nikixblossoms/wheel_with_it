using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI ScoreText;
    private Vector2 startPos;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = player.position;
        score = (int)(player.position.x - startPos.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (score < player.position.x - startPos.x)
            score = (int)(player.position.x - startPos.x);

        ScoreText.text = score.ToString();
        
    }
}
