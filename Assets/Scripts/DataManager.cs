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
    
}
