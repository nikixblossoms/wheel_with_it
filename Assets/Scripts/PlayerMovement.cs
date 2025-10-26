using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject gameOver;

    private float move;

    public float speed;
    public float jump;
    public float jumpinc;
    private bool isDead = false;

    public CollectableManager cm;
    public MoneyManager mm;

    public Text moneyPopupText; // 👈 Add this reference

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moneyPopupText.gameObject.SetActive(false); // Hide initially
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (mm.moneyCount < 0)
        {
            jump = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
        }

        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            mm.moneyCount += 10;
            Destroy(other.gameObject);
            StartCoroutine(ShowMoneyPopup("+$10")); // 👈 Show popup
        }

        if (other.gameObject.CompareTag("Collectable"))
        {
            cm.coinCount++;
            jump += jumpinc;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }

    IEnumerator ShowMoneyPopup(string message)
    {
        moneyPopupText.text = message;
        moneyPopupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // Show for 1 second
        moneyPopupText.gameObject.SetActive(false);
    }

    public void Die()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        isDead = true;
    }
}
