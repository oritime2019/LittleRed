using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController2 : MonoBehaviour
{
    static float speed = 10.0f;
    bool moveFlag = false;
    bool FinishFlag = true;


    [SerializeField]
    public List<GameObject> TerrainGoList = new List<GameObject>();
    public List<Transform> TerrainTranList = new List<Transform>();

    List<bool> TFBool = new List<bool>(6);
    int[] targetNum = new int[7] { 5, 0, 1, 2, 3, 4, 6 };   //記錄各個terrain接下來要移動往哪個點，例:targetNum[0]=5，terrain0接下來要往pos5移動。
                                                            //int tarN=0;
    float step;

    void Start()
    {
        step = speed * Time.deltaTime;
        moveFlag = true;
        FinishFlag = true;

        for (int i = 0; i < TFBool.Count; ++i)
        {
            TFBool.Add(false);
        }
    }

    void Update()
    {
        if (moveFlag)
        {
            if (FinishFlag)
            {
                Debug.Log("移動地板中 , 偵測到FinishFlag改為true");

                for (int i = 1; i < TerrainGoList.Count; ++i)
                {
                    moveTerrain(TerrainGoList[i].transform, TerrainTranList[targetNum[i]]);
                }

                moveTerrain(TerrainGoList[0].transform, TerrainTranList[targetNum[0]]);

                checkIsArrival();
            }
        }
    }

    void moveTerrain(Transform terrain, Transform moveToPos)
    {
        terrain.position = Vector3.MoveTowards(terrain.transform.position, moveToPos.position, step);
    }

    void checkIsArrival()
    {
        if (!TFBool.Exists(element => !element))
        {
            FinishFlag = false;
            TFBool.ForEach(element => element = false);
            roundEnd();
            Debug.Log($"所有地完成第一個點的移動, 將FinishFlag改為${FinishFlag}，地板不再移動 將T0-T5改為false");
            return;
        }

        for (int i = 0; i < TFBool.Count; ++i)
        {
            var itemValue = TFBool[i];
            if (!itemValue && TerrainGoList[i].transform.position == TerrainTranList[targetNum[i]].position)
            {
                itemValue = true;
                Debug.Log($"T${i}F:${itemValue}");
            }
        }
    }

    void roundEnd()
    {
        if (!Array.Exists(targetNum, element => element == 0))
        {
            return;
        }

        var zeroIdx = Array.IndexOf(targetNum, 0);
        Debug.Log($"判斷T{zeroIdx}在最尾端");
        ChangeTargetPoint(TerrainGoList[zeroIdx].transform, zeroIdx);
        //FinishTurn();
    }

    void ChangeTargetPoint(Transform Terrain, int lastT)
    {
        Debug.Log("更改各塊地的移動目標點");
        for (int n = 0; n < 5; n++)
        {
            if (n == lastT)
            {
                Debug.Log("最尾端:更改T" + lastT + "下輪目標點從Pos" + targetNum[n] + "更改成Pos5");
                targetNum[n] = 5;
                continue;
            }

            Debug.Log("更改從" + targetNum[n] + "到" + (targetNum[n] - 1));
            targetNum[n]--;

        }
        Debug.Log("實際將尾端地形T" + lastT + "瞬移到頭端");
        Terrain.transform.position = TerrainTranList[6].position;
    }

    void FinishTurn()
    {
        Debug.Log("FinishFlag改為TRUE，地形再度移動");
        FinishFlag = true;
    }
}