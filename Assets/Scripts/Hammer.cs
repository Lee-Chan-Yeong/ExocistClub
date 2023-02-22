using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public bool ChooseUsagie = false;
    public Player player;
    float delayTime;
    int atkDamage;
    

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
        float atkSpeed = 1 /delayTime;
        float waitTime = Time.deltaTime; 
        if (waitTime == delayTime)
        {
            anim.SetTrigger("Attack");
            Debug.Log("슉");
            waitTime = 0;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("뿅");
    }


}  
