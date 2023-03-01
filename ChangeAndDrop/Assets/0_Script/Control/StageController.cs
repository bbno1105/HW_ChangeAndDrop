using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // START - MAP ~ MAP - FINISH
    StageSheetData nowStageData = new StageSheetData();

    int startBallCount;
    public int StartBallCount { get { return startBallCount; } set { startBallCount = value; } }
    int clearCount;
    public int ClearCount { get { return clearCount; } set { clearCount = value; } }
    
    [SerializeField] Transform mapParent;
    [SerializeField] GameObject mapStartPrefab;
    [SerializeField] GameObject mapPrefab;
    [SerializeField] GameObject mapCheckBoxPrefab;
    [SerializeField] GameObject mapFinishPrefab;

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
            SettingMapData(nowStageData);

            BallController.Instance.BallCount = nowStageData.Startballcount;
            GameManager.Instance.NextBox();
        }
    }

    void SettingMapData(StageSheetData _stageData)
    {
        Vector3 mapPosition = Vector3.zero;

        // ½ÃÀÛ
        GameObject startMap = Instantiate(mapStartPrefab, mapPosition, Quaternion.identity, mapParent);
        GameManager.Instance.boxList.Enqueue(startMap.GetComponentInChildren<Box>());
        mapPosition = new Vector3(mapPosition.x, mapPosition.y - 2, mapPosition.z);

        // ¸Ê
        foreach (int data in _stageData.Maplist)
        {
            SettingMap(data, ref mapPosition);
        }

        // ÇÇ´Ï½¬
        GameObject finishMap = Instantiate(mapFinishPrefab, mapPosition, Quaternion.identity, mapParent);
        finishMap.GetComponentInChildren<Box>().CheckCount = _stageData.Clearcount;
        GameManager.Instance.boxList.Enqueue(finishMap.GetComponentInChildren<Box>());
    }

    void SettingMap(int _mapID, ref Vector3 _mapPosition)
    {
        if (StaticData.MapData.TryGetValue(_mapID, out MapSheetData mapSheetData))
        {
            int movePositionY = 0;

            switch (mapSheetData.Type)
            {
                case 0: // NONE
                    {
                        GameObject map = Instantiate(mapPrefab, _mapPosition, Quaternion.identity, mapParent);

                        movePositionY = 2;
                    }
                    break;

                case 1: // TRAP
                    {
                        GameObject map = Instantiate(mapPrefab, _mapPosition, Quaternion.identity, mapParent);
                        map.transform.GetChild(1).gameObject.SetActive(true);
                        TrapSetting trapSetting = map.GetComponentInChildren<TrapSetting>();
                        // Æ®·¦¼¼ÆÃ
                        trapSetting.TrapStartPosition = mapSheetData.Trapstartposition;
                        trapSetting.IsMoveTrap = mapSheetData.Ismovetrap;
                        trapSetting.MoveRight = mapSheetData.Moveright;
                        trapSetting.MoveSpeed = mapSheetData.Movespeed;

                        foreach (Trap trap in map.GetComponentsInChildren<Trap>())
                        {
                            switch (trap.TrapColor)
                            {
                                case COLORSTATE.BLUE:
                                    trap.BonusValue = mapSheetData.Createblue;
                                    break;
                                case COLORSTATE.ORANGE:
                                    trap.BonusValue = mapSheetData.Createorange;
                                    break;
                                default:
                                    break;
                            }
                        }

                        movePositionY = 2;
                    }
                    break;

                case 2: // OBSTACLE
                    {
                        GameObject map = Instantiate(mapPrefab, _mapPosition, Quaternion.identity, mapParent);
                        GameObject obstacle = map.transform.GetChild(2).gameObject;
                        obstacle.SetActive(true);
                        // Àå¾Ö¹°
                        switch (mapSheetData.Obstacletype)
                        {
                            case 0: // ÁÂ
                                obstacle.transform.GetChild(0).gameObject.SetActive(true);
                                obstacle.transform.GetChild(1).gameObject.SetActive(false);
                                break;

                            case 1: // ¿ì
                                obstacle.transform.GetChild(0).gameObject.SetActive(false);
                                obstacle.transform.GetChild(1).gameObject.SetActive(true);
                                break;

                            case 2: // ¾çÂÊ
                                obstacle.transform.GetChild(0).gameObject.SetActive(true);
                                obstacle.transform.GetChild(1).gameObject.SetActive(true);
                                break;

                            default:
                                break;
                        }
                        movePositionY = 2;
                    }
                    break;

                case 3: // CHECKBLOCK
                    {
                        GameObject map = Instantiate(mapPrefab, _mapPosition, Quaternion.identity, mapParent);
                        map.transform.GetChild(3).gameObject.SetActive(true);
                        CheckBlock checkBlock = map.GetComponentInChildren<CheckBlock>();
                        // Æ®·¦¼¼ÆÃ
                        checkBlock.CheckCount = mapSheetData.Checkcount;

                        movePositionY = 2;
                    }
                    break;

                case 4: // CHECKBOX
                    {
                        GameObject map = Instantiate(mapCheckBoxPrefab, _mapPosition, Quaternion.identity, mapParent);
                        Box box = map.GetComponentInChildren<Box>();
                        box.CheckCount = mapSheetData.Checkcount;
                        GameManager.Instance.boxList.Enqueue(box);

                        movePositionY = 4;
                    }
                    break;

                default:
                    break;
            }

            _mapPosition = new Vector3(_mapPosition.x, _mapPosition.y - movePositionY, _mapPosition.z);
        }
    }
}
