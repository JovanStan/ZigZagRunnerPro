using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public bool gameStarted;

	private int crystals;
	private int mostCrystals;


	private const string MOST_CRYSTALS = "MOST_CRYSTALS";

	public RoadGenerator roadGenerator;

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

	private void Start()
	{
		Time.timeScale = 1f;
		mostCrystals = PlayerPrefs.GetInt(MOST_CRYSTALS, 0);
		UIManager.instance.crystalsText.text = "Crystals: " + crystals;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			StartGame();
		}
	}

	public void IncreaseScore()
	{
		crystals++;
		UIManager.instance.crystalsText.text = "Crystals: " + crystals;
	}

	private void CheckForHighScore()
	{
		if (crystals > mostCrystals)
		{
			mostCrystals = crystals;
			PlayerPrefs.SetInt(MOST_CRYSTALS, mostCrystals);
		}
	}

	public void StartGame()
	{
		gameStarted = true;
		roadGenerator.StartBuilding();
	}

	public void EndGame()
	{
		CheckForHighScore();
		UIManager.instance.crystalsText.gameObject.SetActive(false);
		UIManager.instance.crystalsGameOverText.text = "Crystals Collected: " + crystals;
		UIManager.instance.mostCrystalsText.text = "Most Crystals Collected: " + mostCrystals;
		UIManager.instance.gameOverPanel.SetActive(true);
		AudioManager.instance.PlayGameOverMusic();
		Time.timeScale = 0f;
	}

}
