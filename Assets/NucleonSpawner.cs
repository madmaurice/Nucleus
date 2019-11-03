using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NucleonSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;

    public float spawnDistance;

    public Nucleon[] nucleonPrefabs;
    
    float timeSinceLastSpawn;

    List<Nucleon> m_Nucleons = new List<Nucleon>();

    void FixedUpdate ()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }
    
    void SpawnNucleon () 
    {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);
        spawn.transform.position = Random.onUnitSphere * spawnDistance;
        
        m_Nucleons.Add(spawn);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var nucleon in m_Nucleons)
            {
                nucleon.enabled = false;
            }
            m_Nucleons.Clear();
        }
    }
}
