using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public bool ChooseUsagie = false;
    public Player player;
    float delayTime;
    int atkDamage;
    

    Transform tf;
     

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
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
            transform.Rotate(Vector3.forward *atkSpeed*Time.deltaTime);
        }
    }

    void OnTriggerEnter2D (Collision2D collision)
    {

    }


}
