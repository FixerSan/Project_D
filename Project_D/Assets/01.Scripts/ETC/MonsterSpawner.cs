using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public int monsterUID;
    public float SpawnDelay;
    private MonsterController monsterController;
    private bool isSpawning = false;
   
    private void Update()
    {
        CheckMonster();
    }

    private void CheckMonster()
    {
        if (isSpawning) return;
        if (monsterController == null)
        {
            SpawnMonster();
        }

        else if (monsterController.currentState == Define.MonsterState.Die)
            monsterController = null;
    }

    private void SpawnMonster()
    {
        isSpawning = true;
        StartCoroutine(SpawnMonsterRoutine());
    }

    private IEnumerator SpawnMonsterRoutine()
    {
        yield return new WaitForSeconds(SpawnDelay);
        monsterController = Managers.Object.SpawnMonster(monsterUID, transform.position);
        isSpawning = false;
    }
}
