using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Text winText;
	public Text scoreText;
    public float speed;



    private Rigidbody rb;
	private int score;

    void Start()
    {
		winText.text = "";
		SetScoreText();
		score = 0;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
			score += 1;
			SetScoreText();
			if (score == 15){
				winText.text = "You Win!";
			}
        }
    }

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString();
	}
}

// Destroy(other.gameObject);