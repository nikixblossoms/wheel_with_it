using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

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
    
     public void Die()
    {
        Time.timeScale = 0f; // Pause the game
        gameOver.SetActive(true);
        isDead = true;
        
    }
}
