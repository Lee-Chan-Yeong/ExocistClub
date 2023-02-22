using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemyStat에서 관리
    public float enemySpeed;
    public float enemyHp;
    public float enemyMaxHp;
    public int enemyPower;
    // 추후 애니메이션 추가될 때 작업  
    //public RuntimeAnimatorController[] aniCon;


    public Rigidbody2D target;

    public bool isEnemyDead ;

    Rigidbody2D rigid;
    Animator enemyAnim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        enemyPower = 60;
    }

   
    void FixedUpdate()
    {
        if (isEnemyDead)
        {
            return;
        }

        Vector2 dirvec = target.position - rigid.position;
        Vector2 nextVec = dirvec.normalized * enemySpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isEnemyDead =false;
        enemyHp = enemyMaxHp;
    }

    public void Init(SpawnData enemyData)
    {
        //enemyAnim.runtimeAnimatorController = aniCon[enemyData.spriteType];
        enemySpeed = enemyData.enemySpeed;
        enemyMaxHp = enemyData.enemyMaxHp;
        enemyHp = enemyData.enemyMaxHp;
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit");
            Player target = collision.gameObject.GetComponent<Player>();
            target.playerUnitStat.PlayerCurHp -= enemyPower;
            Debug.Log(target.playerUnitStat.PlayerCurHp);
            target.checkPlayerDead();
        }
    }

    

    /* 스프라이트 flip // 적 스프라이트 제작 후 추가
    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
    */
}