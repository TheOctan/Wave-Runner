using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventHandler : MonoBehaviour
{
	public GameObject gameOverPanel;

	[Header("Text")]
	public TextMeshProUGUI bestScoreTitleText;
	public TextMeshProUGUI bestScoreText;

	public TextMeshProUGUI currentScoreTitleText;
	public TextMeshProUGUI currentScoreText;

	private Camera mainCamera;

	private int currentScore;
	private float hueValue;

	private const string BEST_SCORE = "bestScore";

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Start()
	{
		currentScore = 0;
		bestScoreText.text = PlayerPrefs.GetInt(BEST_SCORE, 0).ToString();
		hueValue = Random.Range(0, 10) / 10f;

		SetScore();
		SetBackgroundColor();
	}

	public void OnGameOver()
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

	public void OnGetItem()
	{
		SetBackgroundColor();
	}

	private void SetBackgroundColor()
	{
		var color = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
		mainCamera.backgroundColor = color;

		SetTextColor(bestScoreTitleText, color.grayscale);
		SetTextColor(bestScoreText, color.grayscale);
		SetTextColor(currentScoreTitleText, color.grayscale);
		SetTextColor(currentScoreText, color.grayscale);

		hueValue += 0.1f;
		if (hueValue >= 1)
		{
			hueValue = 0;
		}
	}

	private void SetTextColor(TMP_Text text, float grayScale)
	{
		var v = Mathf.Repeat(grayScale + 0.5f, 1f);
		text.color = new Color(v, v, v, text.color.a);
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
