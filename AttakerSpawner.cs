using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attaka[] enemy; 

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttaker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    } 
    private void SpawnAttaker()
    {
        var attakaIndex = Random.Range(0, enemy.Length);
        Spawn(enemy[attakaIndex]);
    }

    private void Spawn(Attaka myAttaka)
    {
        Attaka newAttacker = Instantiate(myAttaka, transform.position,
       transform.rotation) as Attaka;
        newAttacker.transform.parent = transform;
    }

}
