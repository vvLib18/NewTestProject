using UnityEngine;

public class Spawner : MonoBehaviour {

    // 实例化对象
    public GameObject entityToSpawn;

    // ScriptableObject实例
    public SpawnManagerScriptableObject spawnManagerValues;

    int instanceNumber = 1;

	// Use this for initialization
	void Start () {
        SpawnEntities();
        spawnManagerValues.prefabName = "Hello";
	}
	
    void SpawnEntities() {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            GameObject currentEntity = Instantiate(entityToSpawn, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            currentEntity.name = spawnManagerValues.prefabName + instanceNumber;

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;

            instanceNumber++;
        }
    }

}
