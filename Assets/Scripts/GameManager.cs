using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public int mouseClicks;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
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

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
