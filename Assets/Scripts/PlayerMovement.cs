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
    public Animator anim;

    private int jumpCount = 0;
    private int maxJumps = 4;


    public CollectableManager cm;
    public MoneyManager mm;
    public StartMenu sm; // Reference to StartMenu

    public Text moneyPopupText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moneyPopupText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Prevent movement if start menu is still active
        if (sm != null && sm.startMenuPanel.activeSelf)
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("isRunning", false);
            return;
        }

        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (mm.moneyCount < 0)
        {
            jump = 0;
        }

        anim.SetBool("isRunning", Mathf.Abs(move) > 0.1f);


        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
            jumpCount++;
            
        }

        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Smoothly reset rotation to zero if the player is tilted/flipped
        if (Mathf.Abs(transform.rotation.eulerAngles.z) > 1f)
        {
            float currentZ = transform.rotation.eulerAngles.z;
            float targetZ = 0f;
            float smoothSpeed = 5f;

            Quaternion targetRotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(currentZ, targetZ, Time.deltaTime * smoothSpeed));
            transform.rotation = targetRotation;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            mm.moneyCount += 10;
            Destroy(other.gameObject);
            StartCoroutine(ShowMoneyPopup("+$10"));
        }

        if (other.gameObject.CompareTag("Collectable"))
        {
            cm.fuelCount += 5;
            StartCoroutine(cm.ShowFuelPopup("+5 Fuel"));
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }


    IEnumerator ShowMoneyPopup(string message)
    {
        moneyPopupText.text = message;
        moneyPopupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        moneyPopupText.gameObject.SetActive(false);
    }

    public void Die()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        isDead = true;
    }
}
