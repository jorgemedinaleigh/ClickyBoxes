using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public int mouseClicks;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseClicks++;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score = score + scoreToAdd - (mouseClicks - 1);
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0); 

        titleScreen.gameObject.SetActive(false);
    }
}
