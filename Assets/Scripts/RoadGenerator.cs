using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Vector3 lastPos;
    [SerializeField] private float offset = 0.707f;

	private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateRoadPart", 1f, .2f);
    }


    public void CreateRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
			spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
		}

        GameObject road = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = road.transform.position;

        // activate crystal at every fifth road block
        roadCount++;
        if(roadCount % 5 == 0)
        {
            road.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
