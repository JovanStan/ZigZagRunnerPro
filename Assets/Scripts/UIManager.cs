using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public TextMeshProUGUI crystalsText;
	public TextMeshProUGUI crystalsGameOverText;
	public TextMeshProUGUI mostCrystalsText;

	public GameObject gameOverPanel;
	public GameObject pausePanel;

	public Toggle playMusicToggle;


	public void BackToMainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		Time.timeScale = 1f;
	}

	public void PauseGame()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0.0f;
	}

	public void UnpauseGame()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1.0f;
	}

	public void PlayMusic()
	{
		if (playMusicToggle.isOn)
		{
			AudioManager.instance.PlayBackgroundMusic();
		}
		else
		{
			AudioManager.instance.StopBackgroundMusic();
		}
	}
}
