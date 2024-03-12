using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	private AudioSource audioSource;
	[SerializeField] private AudioClip gameOverMusic;
	private bool isGameOver = false;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayBackgroundMusic()
	{
		audioSource.Play();
	}

	public void StopBackgroundMusic()
	{
		audioSource.Stop();
	}

	public void PlayGameOverMusic()
	{
		if (!isGameOver) 
		{
			audioSource.Stop();
			audioSource.PlayOneShot(gameOverMusic);
			isGameOver = true;
		}
	}
}
