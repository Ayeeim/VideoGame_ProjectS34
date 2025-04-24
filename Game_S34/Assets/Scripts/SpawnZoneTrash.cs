using UnityEngine;

public class SpawnZoneTrash : MonoBehaviour
{
    [SerializeField] private GameObject[] trashPrefab;
    [SerializeField] Vector2 zoneSize;

    public bool test = false;

    public DaySystem daySystem;
    public int spawnedTrash;

    public int trashLeftCount = 0;
    private GameObject[] trashToFind;

    void Update()
    {
        if (test == true && daySystem.trashObjective > spawnedTrash)
        {
            GameObject instantiated = Instantiate(trashPrefab[Random.Range(0,3)]);

            instantiated.transform.position = new Vector2(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                );

            spawnedTrash++;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    public void trashDestroy()
    {
        trashToFind = GameObject.FindGameObjectsWithTag("Trash");
        trashLeftCount = trashToFind.Length;

        foreach (GameObject trash in trashToFind) 
        { 
            Destroy(trash); 
        }
    }
}
