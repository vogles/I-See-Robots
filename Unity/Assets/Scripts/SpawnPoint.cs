﻿using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab = null;
    public CFX_SpawnSystem spawnSystem = null;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (!CFX_SpawnSystem.AllObjectsLoaded)
        {
            yield return null;
        }

        GameObject particles = CFX_SpawnSystem.GetNextObject(spawnSystem.objectsToPreload[0]);
        GameObject player = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);

        Transform trans = particles.transform;
        trans.position = transform.position;
        trans.parent = transform.parent;
        trans.localScale = Vector3.one;

        trans = player.transform;
        trans.position = transform.position;
        trans.parent = transform.parent;
        trans.localScale = Vector3.one * 2;

        GameCamera gameCamera = Camera.main.GetComponent<GameCamera>();
        gameCamera.target = player.transform;
    }
}