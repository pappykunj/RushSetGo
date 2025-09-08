using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{   
    [SerializeField] private Text highScoreText;

    // Start is called before the first frame update
    private void Start()
    { 
        // HighScore collected from registry of system
        highScoreText.text = "HighScore: " + ((int) PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    
    public void ToGame()
    {
        // To play the Game
        SceneManager.LoadScene("Game");
    }

    // To quit the game
    public void ExitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }

}
