using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventHandler : MonoBehaviour
{
	public GameObject gameOverPanel;
	public TextMeshProUGUI currentScoreText;

	private int currentScore;

	private void Start()
	{
		currentScore = 0;
		SetScore();
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

	public void AddScore(int score)
	{
		currentScore += score;
		SetScore();
	}

	private IEnumerator GameOverDelay()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		gameOverPanel.SetActive(true);
		yield return null;
	}

	private void SetScore()
	{
		currentScoreText.text = currentScore.ToString();
	}
}
