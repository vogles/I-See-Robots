using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public SpawnPoint spawnPoint = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        spawnPoint.Spawn();
    }
}