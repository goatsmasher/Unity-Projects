using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Text scoreText, restartText, gameOverText;
    private bool restart, gameOver;
    private int score;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Vector3 spawnValues;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
	void Update(){
		if (restart){
			if (Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
		scoreText.text = "Final Score: " + score;
        gameOver = true;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


}
