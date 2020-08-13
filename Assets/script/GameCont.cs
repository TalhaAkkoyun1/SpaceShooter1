using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCont : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public int hazardCount;
    public GameObject gameOverPanel;
    public float spawnCounter;
    bool isGameOver = false;

    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnWait)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(hazard, spawnPosition, Quaternion.identity);

            spawnCounter = 0;
        }
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
        
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(0);

    } 

}

