using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public float gameTime;
    //웨이브 내 적 처치 수
    public static int kill_enm_Count;
    //우사기 적 처치 수
    public static int u_arouse_Count;
    public string selectCharacterCode;

    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
    }

    /*
    void enm_Count()
    {
        kill_enm_count++;
        if (selectCharacterCode == "Usagie_first" || selectCharacterCode == "Usagie_Second" || selectCharacterCode == "Usagie_Third")
        {

        }
    }
    */
}
