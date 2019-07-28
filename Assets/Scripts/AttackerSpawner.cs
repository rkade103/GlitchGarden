using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;
    bool spawn = true;

	IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
	}
	
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var randomIndex = Random.Range(0, attackers.Length);
        Debug.Log("INDEX: " + randomIndex.ToString());
        Attacker attacker = attackers[randomIndex];
        Spawn(attacker);
    }

    private void Spawn(Attacker attackerToSpawn)
    {
        Attacker newAttacker = Instantiate(
                    attackerToSpawn,
                    transform.position,
                    transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
