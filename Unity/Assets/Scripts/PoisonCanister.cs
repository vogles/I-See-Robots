using UnityEngine;
using System.Collections;

public class PoisonCanister : MonoBehaviour
{
    public CFX_SpawnSystem spawnSystem = null;
    public GameObject poisonSmoke = null;
    public GameObject poisonRain = null;

    public Transform poisonSpawnPoint = null;
    public Transform poisonRainSP = null;
    public Switch activatedSwitch = null;

    public float poisonRainDelay = 3f;
    // Use this for initialization
    void Start()
    {
        if (activatedSwitch != null)
            activatedSwitch.OnSwitchActivate += OnActivatePoison;
    }

    void OnActivatePoison()
    {
        StartCoroutine(ReleasePoison());
    }

    IEnumerator ReleasePoison()
    {
        while (!CFX_SpawnSystem.AllObjectsLoaded) 
        {
            yield return null;
        }

        GameObject poison = CFX_SpawnSystem.GetNextObject(spawnSystem.objectsToPreload[1]);
        Transform poisonTrans = poison.transform;

        poisonTrans.parent = poisonSpawnPoint.transform.parent;
        poisonTrans.localScale = Vector3.one;
        poisonTrans.localPosition = Vector3.zero;

        GameObject.FindObjectOfType<MusicControl>().PlayWin();
        yield return new WaitForSeconds(poisonRainDelay);

        // No rain, but I might be able to add the panicking humans!
    }
}