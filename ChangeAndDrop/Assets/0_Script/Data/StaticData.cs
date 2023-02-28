using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    void Start()
    {
        SetStageData();
        SetMapData();
    }

    [SerializeField] StageSheet stageSheet;
    public static Dictionary<int, StageSheetData> StageData;

    public void SetStageData()
    {
        for (int i = 0; i < stageSheet.dataArray.Length; i++)
        {
            StageData.Add(stageSheet.dataArray[i].ID, stageSheet.dataArray[i]);
        }
    }

    [SerializeField] MapSheet mapSheet;
    public static Dictionary<int, MapSheetData> MapData;

    public void SetMapData()
    {
        for (int i = 0; i < mapSheet.dataArray.Length; i++)
        {
            MapData.Add(mapSheet.dataArray[i].ID, mapSheet.dataArray[i]);
        }
    }
}
