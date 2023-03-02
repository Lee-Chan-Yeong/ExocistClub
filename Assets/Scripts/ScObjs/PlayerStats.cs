using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public string GS_Sheet = "";
    public string GS_WorkSheet = "";

    public List<string> Stats = new List<string>();
    public List<string> CharacterCode = new List<string>();
    public List<List<string>> Characters = new List<List<string>>();

    
    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        if (!(CharacterCode[0] == list[0].value))
            return;
        Stats.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "LocalNumber":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "Character_Eng_Name":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "Character_Kor_Name":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "PlayerAtk":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "playerMaxHp":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "armor":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "sklDelay":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "atkDelay":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "playerSpeed":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "Luk":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "hpRegan":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
                case "hpSteal":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);;
                    break;
                }
                case "Evolving_State":
                {
                    Stats.Add(list[i].value);
                    //Characters[listCount].Add(list[i].value);
                    break;
                }
            }
        }
        //listCount++;
        
    }

}

[CustomEditor(typeof(PlayerStats))]
public class DataEditor : Editor
{
    PlayerStats data;

    void OnEnable()
    {
        data = (PlayerStats)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("Read Character Stat");

        if (GUILayout.Button("Pull Datas from Sheet"))
        {
            UpdateStats(UpdateMethodOne);
        }
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.GS_Sheet, data.GS_WorkSheet), callback, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        //data.Characters.Clear();
        //data.listCount =0;
        
        foreach (string dataName in data.CharacterCode)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }
    
}



