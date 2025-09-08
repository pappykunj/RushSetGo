using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    public Text scoreText;
    public RawImage backgroundImg;
    private bool isShowned;
    private float transition = 0f;
  
    
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);        
        isShowned = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isShowned) { return; }
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
    
    // To activate deathMenu
    public void ToggleEnd()
    {
        isShowned = true;
        Debug.Log("gameOver");
    }
    
    // for the play button
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the same scene
       
    }
    // for home menu button
    public void ToMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
    // To quit the game
    public void ExitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
