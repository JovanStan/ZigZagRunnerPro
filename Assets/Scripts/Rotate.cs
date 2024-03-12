using UnityEngine;

public class Rotate : MonoBehaviour
{
	private void Start()
	{
		Time.timeScale = 1.0f;
	}

	void Update()
    {
        transform.Rotate(0, 15 * Time.deltaTime, 0);
    }

}
