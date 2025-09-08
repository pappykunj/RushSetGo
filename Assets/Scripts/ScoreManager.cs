using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    public Text scoreText;
    private float scoreToNextLevel = 10f;
    private readonly float maxDifficultyLevel = 10f;
    public float difficultyLevel = 1f;
    private bool isDead = false;
    public Text text;

    // Update is called once per frame
    private void Update()
    {
        if (isDead) { return; }
        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }
    // to level up and increase speed accordingly
    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel) { return; }
        scoreToNextLevel *= 2;
        difficultyLevel += 1f;
        GetComponent<PlayerController>().SpeedSetUp(difficultyLevel);
        Debug.Log(difficultyLevel);

    }

    //  to active the menu and set highscore
    public void MenuCall()
    {
        
        isDead = true;
        text.text = ((int)score).ToString();
        if (PlayerPrefs.GetFloat("HighScore") < score)
            PlayerPrefs.SetFloat("HighScore", score);
        
        score = 0f;
        Debug.Log("MenuCall");
        
        
    
    }
}
