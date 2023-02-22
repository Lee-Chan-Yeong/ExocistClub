using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public bool ChooseUsagie = false;
    Player player;
    float delayTime= 0;
    int atkDamage =0;
    float waitTime;
    

    Animator anim;
     

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        anim = GetComponent<Animator>();
        delayTime = player.playerUnitStat.defaultPlayerAtkDelay;
        atkDamage = player.playerUnitStat.defaultPlayerAtk;
    }

    // Update is called once per frame
    void Update()
    {
        basicAttack();
    }

    void basicAttack()
    {   
        waitTime += Time.deltaTime;
        if (waitTime >= delayTime)
        {
            Debug.Log("슉");
            anim.SetTrigger("Attack");
            waitTime = 0;
        }
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("뿅");
    }


}  
