using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject gameover;
    public NavMeshAgent player;
    public GameObject pauseMenu;
    public GameObject settingMenu;
    public GameObject winPanel;
    public GameObject intropanel;

    public bool dead = false;
    public bool paused = false;
    private Rigidbody rb;
    
    /// <summary>
    /// resets need on game start for replay ability
    /// </summary>
    void Start()
    {
       
        
        paused = false;
        gameover.SetActive(false);
        Time.timeScale = 1;
        dead = false;
    }

    /// <summary>
    /// player movement and win condition
    /// </summary>
    void Update()
    {
        // moves player to raycast
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                player.SetDestination(hit.point);
            }
        }
        // lets pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!dead && !paused)
            { 
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else if (paused && !dead)
            {
                pauseMenu.SetActive(false);
                settingMenu.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
        }

        if (player.transform.position.z <= -190f)
        {
            Win();
        }
    }
   /// <summary>
   /// kills player
   /// </summary>
   /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            GameOver();
        }
    }
   /// <summary>
   /// displays agme oevr panel
   /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
    }
/// <summary>
/// button functions
/// </summary>
    public void replay() => SceneManager.LoadScene(1);
    public void exit() => Application.Quit();
    public void MainMenu() => SceneManager.LoadScene(0);
    public void CLoseIntro() => intropanel.SetActive(false);
/// <summary>
/// win game
/// </summary>
    public void Win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        dead = true;
    }
    
/// <summary>
/// opens settings menu
/// </summary>
    public void settingsOpen()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
}
