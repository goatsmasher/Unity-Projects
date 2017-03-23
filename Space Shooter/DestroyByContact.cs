using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bolt")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController'");
        }
    }
}
