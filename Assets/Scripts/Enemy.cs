using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemyStat에서 관리
    public float enemySpeed;
    public float enmCurHp;
    public float enemyMaxHp;
    public int enmAtk;
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
        enmCurHp = enemyMaxHp;
    }

    public void Init(EnemyTable enemyData)
    {
        //enemyAnim.runtimeAnimatorController = aniCon[enemyData.spriteType]; // 적 스프라이트 제작 후 추가
        enemySpeed = enemyData.enmSpeed;
        enemyMaxHp = enemyData.enmMaxHp;
        enmCurHp = enemyData.enmMaxHp;
        enmAtk = enemyData.enmAtk;
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player target = collision.gameObject.GetComponent<Player>();
            target.playerUnitStat.PlayerCurHp -= enmAtk;
            //Debug.Log(target.playerUnitStat.PlayerCurHp);
            target.checkPlayerDead();
        }
    }

    public void checkEnmDead()
    {
        Debug.Log(enmCurHp);
        if (enmCurHp <= 0)
        {
            //경험치석 드랍
            //적 처치 수 ++ , 플레이어가 우사기면 다른 변수에 ++
            gameObject.SetActive(false);
        }
    }

    

    /* 스프라이트 flip // 적 스프라이트 제작 후 추가
    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
    */
}
