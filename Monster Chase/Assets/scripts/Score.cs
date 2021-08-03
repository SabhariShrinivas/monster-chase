using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] Text scoreText;
    float score = 0;
    float timer;
    public bool isAlive;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text =  "Score : "+ score.ToString();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                score += 5;
                timer = 0;
                UpdateScore(score);
            }
        }
        
    }
    public void UpdateScore(float score)
    {
        scoreText.text = "Score :" + score.ToString();
    }
    public void StopScore()
    {
        isAlive = false;
    }
 
}
