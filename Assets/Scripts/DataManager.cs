using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager {get; private set;}
    
    
    public List<CharacterStats> PlayerableCharacters; 
    public SklTable sklTable;
    

    void Awake()
    {
        if (dataManager == null)
        {
            dataManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject); 

        SklTable sklTable = new SklTable();
         
    }
}

[System.Serializable]
public class SklTable
{
    //만들어진 스크립터블 오브젝트를 추가함.

    //u 우사기, s 한성아, d 유다민, c 치요, e 엠마, g 일반
    public List<ScriptableObject> uSklList;
    public List<ScriptableObject> sSklList;
    public List<ScriptableObject> dSklList;
    public List<ScriptableObject> cSklList;
    public List<ScriptableObject> eSklList;
    public List<ScriptableObject> gSklList;

}

[System.Serializable]
public class EnemyTable
{
    //각 변수는 이후 스크립터블 오브젝트로 옮겨 담을 예정.
    public string enmKeyNum; // enm의 고유키
    public EnmSpriteType enmSpriteType; // enmSpriteType으로 변경
    public string enmName; // enm 이름
    public int enmAtk;
    public int enmMaxHp;
    public float enmSpeed;
    public string enmGrade;
    public string ExpType;
    public int dropBoxCount;
    public string enmDescription;
    public float enmSpawnTime; //spawnTime은 이후 별도의 웨이브 밸런스 디자인에서 다루기로해요 ~

    public List<ScriptableObject> gr_TypeEnms;
    public List<ScriptableObject> blu_TypeEnms;
    public List<ScriptableObject> ye_TypeEnms;
    public List<ScriptableObject> rd_TypeEnms;
    public List<ScriptableObject> blk_TypeEnms;
}

public enum EnmSpriteType
{
    gr_H1,gr_H2,gr_H3
}

