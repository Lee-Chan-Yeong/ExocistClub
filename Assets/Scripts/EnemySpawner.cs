using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //timer, enemyList ->> 스프레드 시트 연동 후 데이터 불러오기

    public Transform[] spawnPoint;
   
    //EnemyTable 자체를 불러와서 리스트를 사용하기
    public EnemyTable[] enmData;

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
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), enmData.Length-1);
        
        if (timer > (enmData[level].enmSpawnTime)) // enmSpawnTime은 이후 웨이브 데이터에서 받아오는걸로 패치
        {
            timer = 0;
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        //위와 같이 index를 변경해서 enemykind를 변경함
        EnemyTable spawnEnm =enmData[Random.Range(0,level+1)];
        GameObject enemy = GameManager.instance.pool.Get((int)spawnEnm.enmSpriteType);
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnEnm);
        //Debug.Log(enmData[level].enmMaxHp);
    }
}

