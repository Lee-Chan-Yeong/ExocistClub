using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    //우사기 선택 여부
    public bool ChooseUsagie = false;
    Player player;
    //기본공격의 공격속도
    float delayTime= 0;
    int atkDamage =0;
    float waitTime;
    //기본공격의 애니메이션 속도
    float ubasicAttackSpeed;
    float atkDir = 0.1f;
    

    Animator anim;
    Collider2D AtkCol;
    SpriteRenderer spriteRenderer;
    
     

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        anim = GetComponent<Animator>();
        AtkCol = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AtkCol.enabled = false;
        
        delayTime = player.playerUnitStat.defaultPlayerAtkDelay;
        atkDamage = player.playerUnitStat.defaultPlayerAtk;
    }

    // Update is called once per frame
    void Update()
    {
        ubasicAttack();
    }

    void ubasicAttack()
    {   
        //때리는 도중에 방향이 바뀌어버림ㄷㄷ
        if (player.inputVec.x > 0)
        { 
            atkDir = 1f;
        }
        else if (player.inputVec.x < 0)
        {
            atkDir = -1f;
        }
        waitTime += Time.deltaTime;
        if (waitTime >= delayTime)
        {
            Debug.Log("슉");
            anim.SetFloat("AtkDir", atkDir);
            anim.SetTrigger("Attack");
            StartCoroutine(uBasicAtkEnabled());
           // anim.SetTrigger("Attack");
            waitTime = 0;
        }
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("뿅");
    }

    IEnumerator uBasicAtkEnabled()
    {
        
        AtkCol.enabled = true;
        yield return new WaitForSeconds(0.3f);
        AtkCol.enabled = false;
    }

}  
