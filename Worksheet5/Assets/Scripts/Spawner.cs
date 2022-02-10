using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> SpawnPoints = new List<Transform>();

    public Transform GetSpawnPoint()
    {
        int index = Random.Range(0, SpawnPoints.Count);
        return SpawnPoints[index];
    }
}
