using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GoogleSheetsToUnity;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    //차후 PlayerStat에서 관리
    //Enterlogasdf
    public int playerSpeed;



    [SerializeField]
    string selectCharacterCode;
    [SerializeField]
    private List<PlayerStats> playerStats;
    public PlayerUnitStat playerUnitStat;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SetStat();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movVec = inputVec * playerSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    
    //플레이어가 선택한 캐릭터에 따라 기본 스탯을 정의합니다.
    //이후 데이터 처리를 통해 전체값을 설정합니다.
    public void SetStat() 
    {
        for (int i = 0; i<15; i++)
        {
            if (selectCharacterCode == playerStats[i].Stats[0])
            {
                playerUnitStat = new PlayerUnitStat(playerStats[i].Stats[0], playerStats[i].Stats[1], playerStats[i].Stats[2], playerStats[i].Stats[3] ,playerStats[i].Stats[4],playerStats[i].Stats[5],playerStats[i].Stats[6],playerStats[i].Stats[7],playerStats[i].Stats[8],playerStats[i].Stats[9],playerStats[i].Stats[10],playerStats[i].Stats[11],playerStats[i].Stats[12]);
            }
        }
    }

    public void checkPlayerDead()
    {
        if (playerUnitStat.PlayerCurHp <= 0)
        {
            Debug.Log("너 죽었어");
            Debug.Log("게임오버호출");
        }
    }

}

[System.Serializable]
public class PlayerUnitStat
{
    
    public string characterUnitCode = "";
    public string CharacterEngName = "";
    public string CharacterKorName = "";
    public int defaultPlayerAtk = 0;
    public int defaultPlayerMaxHp = 0;
    public int playerCurHp = 0;
    public int PlayerCurHp 
    {
        get {return playerCurHp;}
        set {
            if (playerCurHp < 0)
                playerCurHp = 0;
            else
                playerCurHp = value;
        }
    }
    public int defaultPlayerArmor = 0;
    public float defaultPlayerSklDelay = 0.0f;
    public float defaultPlayerAtkDelay = 0.0f;
    public float defaultPlayerSpeed = 0.0f;
    public int playerLuk = 0;
    public int playerHpRegan = 0;
    public int playerHpSteal = 0;
    public int Evolving_State = 0;

    public PlayerUnitStat(string CharacterCode, string engName, string korName, string playerAtk, string playerMaxHp, string playerArmor, string playerSklDelay, string playerAtkDelay, string playerSpeed, string playerLuk, string playerHpRegan, string playerHpSteal, string Evolving_State)
    {
        this.characterUnitCode = CharacterCode;
        this.CharacterEngName = engName;
        this.CharacterKorName = korName;
        this.defaultPlayerAtk = int.Parse(playerAtk);
        this.defaultPlayerMaxHp = int.Parse(playerMaxHp);
        this.defaultPlayerArmor = int.Parse(playerArmor);
        this.defaultPlayerSklDelay = float.Parse(playerSklDelay);
        this.defaultPlayerAtkDelay = float.Parse(playerAtkDelay);
        this.defaultPlayerSpeed = float.Parse(playerSpeed);
        this.playerLuk = int.Parse(playerLuk);
        this.playerHpRegan = int.Parse(playerHpRegan);
        this.playerHpSteal = int.Parse(playerHpSteal);
        this.Evolving_State = int.Parse(Evolving_State);

        this.PlayerCurHp = this.defaultPlayerMaxHp;
    }

}
