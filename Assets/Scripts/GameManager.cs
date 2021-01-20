using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    private IEnumerator GameOverDelay()
	{
        yield return new WaitForSecondsRealtime(0.5f);
        gameOverPanel.SetActive(true);
        yield return null;
	}
}
