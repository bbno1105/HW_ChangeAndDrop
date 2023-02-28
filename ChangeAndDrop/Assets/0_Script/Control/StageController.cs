using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // START - MAP ~ MAP - FINISH
    StageSheetData nowStageData;
    int startBallCount;
    public int StartBallCount { get { return startBallCount; } set { startBallCount = value; } }
    int clearCount;
    public int ClearCount { get { return clearCount; } set { clearCount = value; } }
    
    Queue<int> nowMapList = new Queue<int>();
    
    [SerializeField] Transform mapParent;
    [SerializeField] GameObject mapPrefab;
    [SerializeField] GameObject checkBoxPrefab;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        SettingStageData();
    }

    void SettingStageData()
    {
        if (StaticData.StageData.TryGetValue(GameManager.Instance.NowStage, out nowStageData))
        {
            StartBallCount = nowStageData.Startballcount;
            ClearCount = nowStageData.Clearcount;
            SettingMapData(nowStageData.Maplist);
        }
    }

    void SettingMapData(string _mapList)
    {
        string[] mapData = _mapList.Split(',');
        foreach (string data in mapData)
        {
            nowMapList.Enqueue(int.Parse(data));
        }
        UnityEngine.Debug.Log(nowMapList);
    }

    void SettingMap(int _mapType)
    {
        
        switch (_mapType)
        {
            case 0: // NONE
                {
                    GameObject map = Instantiate(mapPrefab,mapParent);
                }
                break;

            case 1: // TRAP
                {
                    GameObject map = Instantiate(mapPrefab, mapParent);
                    map.transform.GetChild(1).gameObject.SetActive(true);
                    TrapSetting trap = map.GetComponentInChildren<TrapSetting>();
                    // Æ®·¦¼¼ÆÃ
                }
                break;

            case 2: // OBSTACLE
                {
                    GameObject map = Instantiate(mapPrefab, mapParent);
                    map.transform.GetChild(2).gameObject.SetActive(true);
                }
                break;

            case 3: // CHECKBLOCK
                {
                    GameObject map = Instantiate(mapPrefab, mapParent);
                    map.transform.GetChild(3).gameObject.SetActive(true);

                }
                break;

            case 4: // CHECKBOX
                {
                    GameObject map = Instantiate(checkBoxPrefab, mapParent);

                }
                break;

            default:
                break;
        }
    }
}
