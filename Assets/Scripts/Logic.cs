using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float score = 0f;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private AudioSource gameOverMusic;

    private bool gameOverIsPlayed = false;

    private void Start()
    {
        backgroundMusic.Play();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Time.timeScale == 0f)
        {
            gameOverScreen.SetActive(true);
            if (backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }

            if (!gameOverIsPlayed)
            {
                gameOverMusic.Play();
                gameOverIsPlayed = true;
            }
        }
        else
        {
            gameOverScreen.SetActive(false);
            gameOverIsPlayed = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
        }
    }

    public void AddScore(int enemyLayer)
    {
        switch (enemyLayer)
        {
            case int layer when layer == LayerMask.NameToLayer("1stLine"):
                score += 10;
                break;
            case int layer when layer == LayerMask.NameToLayer("2ndLine"):
                score += 20;
                break;
            case int layer when layer == LayerMask.NameToLayer("3rdLine"):
                score += 30;
                break;
            case int layer when layer == LayerMask.NameToLayer("4thLine"):
                score += 40;
                break;
            case int layer when layer == LayerMask.NameToLayer("5thLine"):
                score += 50;
                break;
            case int layer when layer == LayerMask.NameToLayer("6thLine"):
                score += 60;
                break;
            case int layer when layer == LayerMask.NameToLayer("UFO"):
                score += 150;
                break;
            default:
                break;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
    
