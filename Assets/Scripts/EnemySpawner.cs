using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //timer, enemyList ->> 스프레드 시트 연동 후 데이터 불러오기

    public Transform[] spawnPoint;
   
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //레벨 정보는 게임 타임에 맞춰서 다음 셀을 가져오는 방식?, level 변수를 index에 넣으면 될듯
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length-1);
        
        if (timer > (spawnData[level].spawnTime))
        {
            timer = 0;
            EnemySpawn(); 
        }
    }

    void EnemySpawn()
    {
        //위와 같이 index를 변경해서 enemykind를 변경함
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2));
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

 [System.Serializable]
public class SpawnData
{
    //여기에서 스프레드시트를 연동
    public string enemyCode;
    public int spriteType;
    public float spawnTime;
    public int enemyMaxHp;
    public float enemySpeed;
}
