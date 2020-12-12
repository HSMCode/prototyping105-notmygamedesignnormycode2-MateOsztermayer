using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;

    private bool restart;
    private bool gameOver;
    public int score;

    private void Start()
    { // Set score to '0', hide Game Over and Restart texts
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
       score = 0;
       UpdateScore();
       StartCoroutine (SpawnWaves());
    }

    private void LateUpdate()
    {
        if (restart == true)
        { // Restart game with 'R' and run game again
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            }
        }
    }

    // Obstacles spawn in waves
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            
        }
    }

    // Add score
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Update score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Toggle Game Over and Restart screen 
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over!";
        restart = true;
        restartText.text = "Press 'R' for restart";
    }
}
