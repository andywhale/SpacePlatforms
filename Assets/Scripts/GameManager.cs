using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //private float timer = 100.0f;
    //const float TIMERMAX = 100.0f;

    private int level = 0;

    private bool gameOver = false;

    public void FixedUpdate()
    {
        if (!GameIsOver())
        {
            UpdateScore();
        }
        if (GvrControllerInput.AppButton)
            NextLevel();
    }

    public bool GameIsOver()
    {
        return gameOver;
    }

    private void UpdateScore()
    {
        float totalScore = 0;
        GameObject[] artefacts = GameObject.FindGameObjectsWithTag("Artefact");
        float totalArtefacts = artefacts.Length;
        for (var i = 0; i < artefacts.Length; i++)
        {
            totalScore += artefacts[i].GetComponent<Asteroid>().getScore();
        }
        float totalComplete = totalScore / totalArtefacts;
        GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<Image>().fillAmount = totalComplete;
        if (Mathf.Approximately(totalComplete, 1))
        {
            NextLevel();
        } 
    }

    private void NextLevel()
    {
        level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetLevel()
    {
        return level;
    }

    //private void UpdateTimer()
    //{
    //    if (Mathf.Approximately(timer, 0.0f) || timer < 0.0f)
    //    {
    //        gameOver = true;
    //        RestartCurrentLevel();
    //    }
    //    else
    //    {
    //        timer -= Time.deltaTime;
    //    }
    //    UpdateTimerUI();
    //}

    //void UpdateTimerUI()
    //{
    //    GameObject[] timers = GameObject.FindGameObjectsWithTag("TimerUI");
    //    for (var i = 0; i < timers.Length; i++)
    //    {
    //        timers[i].GetComponent<TimerScript>().UpdateTimer(timer, TIMERMAX);
    //    }
    //}

    void Start () {
        
    }
}
