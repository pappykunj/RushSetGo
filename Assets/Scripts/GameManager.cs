using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Slider HealthBar;
    public Text timerText;
    public HealthBar healthBar;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private TileManager tileManager;

    private readonly float gameTime = 60f;
    
    private float currentTime;
    public bool stopTimer;

    // Start is called before the first frame update
    private void Start()
    {
        stopTimer = false;
        currentTime = gameTime;
        healthBar.SetMaxHealth(gameTime);
        healthBar.SetHealth(gameTime);
    }
 

    // Update is called once per frame
    private void Update()
    {
        if (!stopTimer)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                stopTimer = true; 
                playerController.GetComponent<PlayerController>().onDeath("Time ran out");
                
            }
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            // To Update the health bar
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();   
            healthBar.SetHealth(currentTime);

            if (currentTime < 33f) 
            {
                int rand = UnityEngine.Random.Range(0, 1000);
                if (rand < 1)
                {
                    tileManager.GetComponent<TileManager>().SpawnObj();
                }
            }
        }
        else { return; }
    }
    // To increase Life with 10 seconds when FirstAid collected
    public void LifeUpTen()
    {
        if ((currentTime + 10f) > 60f)
        {
            currentTime = 60f;
        }
        else
        {
            currentTime += 10f;
        }       
    }
    // To increase Life with 5 seconds when water collected
    public void LifeUpFive()
    {
        if ((currentTime + 5f) > 60f)
        {
            currentTime = 60f;
        }
        else
        {
            currentTime += 5f;
        }
    }
}
