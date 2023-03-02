using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemyStat에서 관리
    public float enmSpeed;
    public float enmCurHp;
    public float enmMaxHp;
    public int enmPower;
    // 추후 애니메이션 추가될 때 작업  
    //public RuntimeAnimatorController[] aniCon;


    public Rigidbody2D target;

    public bool isEnemyDead ;

    Rigidbody2D rigid;
    Animator enemyAnim;
    SpriteRenderer spriter;
    EnemyTable eData;

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
        Vector2 nextVec = dirvec.normalized * enmSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isEnemyDead =false;
        enmCurHp = enmMaxHp;
    }

    public void Init(EnemyTable enmData)
    {
        //enemyAnim.runtimeAnimatorController = aniCon[enemyData.spriteType];
        enmSpeed = enmData.enmSpeed;
        enmMaxHp = enmData.enmMaxHp;
        enmCurHp = enmData.enmMaxHp;
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit");
            Player target = collision.gameObject.GetComponent<Player>();
            target.playerUnitStat.PlayerCurHp -= enmPower;
            Debug.Log(target.playerUnitStat.PlayerCurHp);
            //이후 데이터매니저의 플레이어 사망 체크 함수를 호출함.
            target.checkPlayerDead();
        }
    }

    public void checkEnmDead()
    {
        Debug.Log(enmCurHp);
        if (enmCurHp <= 0)
        {
            //경험치석 드랍
            GameManager.kill_enm_Count++;
            Debug.Log(GameManager.kill_enm_Count);
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
