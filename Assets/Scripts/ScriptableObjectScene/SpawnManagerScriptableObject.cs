using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject {
    [Header("预制件的名字")]
    public string prefabName;   // 预制件的名字
    [Space(5)]
    [Header("要创建的预制件的数量")]
    public int numberOfPrefabsToCreate; // 一共要创建多少个预制件
    [Space(5)]
    [Header("出生点")]
    public Vector3[] spawnPoints;   // 出生点
}
