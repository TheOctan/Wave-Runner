using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventHandler : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void GameOver()
	{
        StartCoroutine(GameOverDelay());
	}

    public void OnRestart()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    private IEnumerator GameOverDelay()
	{
        yield return new WaitForSecondsRealtime(0.5f);
        gameOverPanel.SetActive(true);
        yield return null;
	}
}
