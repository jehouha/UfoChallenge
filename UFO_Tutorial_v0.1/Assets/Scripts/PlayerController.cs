using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    
    private Rigidbody2D rb2d;
    public float speed;

    // Score Variables
    
    private int count;
    public Text countText;
    public Text winText;
    public Text lossText;

    // Life Variables
    private int lives = 3;
    public Text lifeText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        SetLifeText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // Trigger pickups
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives--;
            SetLifeText();
        }
    }

    // UI scorekeeper
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count == 12)
        {
            transform.position = new Vector2(60.0f, 0.0f);
        }

        if (count >= 20)
        {
            winText.text = "You win! Game created by Julia Houha.";
            this.gameObject.SetActive(false);
        }

    }

    void SetLifeText()
    {
        lifeText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            lossText.text = "You lose! Game created by Julia Houha.";
            this.gameObject.SetActive(false);
        }
    }

}
