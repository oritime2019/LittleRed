using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController1 : MonoBehaviour
{
    public float speed = 10.0f;
    public bool moveFlag = false;
    public bool FinishFlag = true;

    [SerializeField]
    public GameObject Terrain0, Terrain1, Terrain2, Terrain3, Terrain4, Terrain5;
    public List<Transform> TerrainPosList = new List<Transform>();

    int[] targetNum = new int[6];
    int tarN = 0;

    List<bool> TFList = new List<bool>(6);

    float step
    {
        get
        {
            return speed * Time.deltaTime;
        }
    }

    void Start()
    {
        //Debug.Log(targetNum[1]);
        //Debug.Log(target[targetNum[1]]);
        moveFlag = true;
        //Debug.Log("將moveflag改為true");
        FinishFlag = true;

        initTarget();
    }

    void initTarget()
    {
        for (int i = 0; i < targetNum.Length; ++i)
        {
            targetNum[i] = targetNum.Length - i - 1;
            TFList.Add(false);
        }
    }

    void Update()
    {
        //Debug.Log("UPDATE");
        if (moveFlag)
        {
            //Debug.Log("偵測到moveflag改為true");
            if (FinishFlag)
            {
                //Debug.Log("偵測到FinishFlag改為true");
                //Debug.Log("剛做完一輪移動");

                terrainMovePos(Terrain1.transform, getTerrainPos(targetNum[tarN + 5]));
                if (Terrain1.transform.position == getTerrainPos(targetNum[tarN + 1]))
                {
                    TFList[1] = true;
                }

                terrainMovePos(Terrain2.transform, getTerrainPos(targetNum[tarN + 4]));
                if (Terrain2.transform.position == getTerrainPos(targetNum[tarN + 2]))
                {
                    TFList[2] = true;
                }

                terrainMovePos(Terrain3.transform, getTerrainPos(targetNum[tarN + 3]));
                if (Terrain3.transform.position == getTerrainPos(targetNum[tarN + 3]))
                {
                    TFList[3] = true;
                }

                terrainMovePos(Terrain4.transform, getTerrainPos(targetNum[tarN + 2]));
                if (Terrain4.transform.position == getTerrainPos(targetNum[tarN + 4]))
                {
                    TFList[4] = true;
                }

                terrainMovePos(Terrain5.transform, getTerrainPos(targetNum[tarN + 1]));
                if (Terrain5.transform.position == getTerrainPos(targetNum[tarN + 5]))
                {
                    TFList[5] = true;
                }

                terrainMovePos(Terrain0.transform, TerrainPosList[targetNum[tarN]].transform.position);
                if (Terrain0.transform.position == getTerrainPos(tarN))
                {
                    TFList[0] = true;
                }

                //只要List裡面有存在一個false值 就會回傳true
                if (TFList.Exists(value => value == false))
                {
                    return;
                }

                //Debug.Log("所有地完成第一個點的移動  進入判斷");
                FinishFlag = false;
                var zeroPos = getTerrainPos(targetNum[0]);

                tarN = targetNum.Length + tarN - 1;
                switch (tarN)
                {
                    case -1:
                        Terrain1.transform.position = zeroPos;
                        break;

                    case -2:
                        Terrain2.transform.position = zeroPos;
                        break;

                    case -3:
                        Terrain3.transform.position = zeroPos;
                        break;

                    case -4:
                        Terrain4.transform.position = zeroPos;
                        break;

                    case -5:
                        Terrain5.transform.position = zeroPos;
                        break;

                    case 0:
                        Terrain0.transform.position = zeroPos;
                        break;
                }
                ChangTargetPoint();

                TFList.ForEach(value => value = false);
            }
        }
    }

    private Vector3 getTerrainPos(int index)
    {
        return TerrainPosList[index].transform.position;
    }

    private void terrainMovePos(Transform target, Vector3 moveToPos)
    {
        target.position = Vector3.MoveTowards(target.position, moveToPos, step);
    }


    void ChangTargetPoint()
    {
        Debug.Log("更改各塊地的移動目標點");
        for (int n = 0; n == 5; n++)
        {
            Debug.Log($"${targetNum[n]}!");
            if (targetNum[n] == 5)
            {
                targetNum[n] = 0;
                Debug.Log("更改5到0");
                continue;
            }
            targetNum[n]++;
            Debug.Log($"更改從${n + 1}到${n}");
        }
        FinishFlag = true;
    }
}

