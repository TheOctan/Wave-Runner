using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventHandler : MonoBehaviour
{
	public GameObject gameOverPanel;

	[Header("Text")]
	public TextMeshProUGUI currentScoreText;
	public TextMeshProUGUI bestScoreText;

	private int currentScore;
	private const string BEST_SCORE = "bestScore";

	private void Start()
	{
		currentScore = 0;
		bestScoreText.text = PlayerPrefs.GetInt(BEST_SCORE, 0).ToString();
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
		if (currentScore > PlayerPrefs.GetInt(BEST_SCORE))
		{
			PlayerPrefs.SetInt(BEST_SCORE, currentScore);
			bestScoreText.text = currentScore.ToString();
		}
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
