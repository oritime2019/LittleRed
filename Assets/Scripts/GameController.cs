using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed = 10.0f;
    public bool moveFlag = false;
    public bool FinishFlag = true;
    public bool T1F = false;
    public bool T2F = false;
    public bool T3F = false;
    public bool T4F = false;
    public bool T5F = false;
    public bool T0F = false;

    [SerializeField]
    public GameObject Terrain0, Terrain1, Terrain2, Terrain3, Terrain4, Terrain5;
    public GameObject TerrainPos0, TerrainPos1, TerrainPos2, TerrainPos3, TerrainPos4, TerrainPos5;

    string[] target = new string[6] { "TerrainPos0", "TerrainPos1", "TerrainPos2", "TerrainPos3", "TerrainPos4", "TerrainPos5" };
    int[] targetNum = new int[6] { 5, 4, 3, 2, 1, 0 };
    int tarN = 0;



    void Start()
    {
        //Debug.Log(targetNum[1]);
        //Debug.Log(target[targetNum[1]]);
        moveFlag = true;
        Debug.Log("將moveflag改為true");
        FinishFlag = true;
    }

    void Update()
    {
        Debug.Log("UPDATE");
        if (moveFlag)
        {
            Debug.Log("偵測到moveflag改為true");
            if (FinishFlag)
            {
                Debug.Log("偵測到FinishFlag改為true");
                Debug.Log("剛做完一輪移動");

                float step = speed * Time.deltaTime;
                Terrain1.transform.position = Vector3.MoveTowards(Terrain1.transform.position, GameObject.Find(target[targetNum[tarN + 5]]).transform.position, step);
                Debug.Log(tarN + 5);
                if (Terrain1.transform.position == GameObject.Find(target[targetNum[tarN + 1]]).transform.position)
                {
                    Debug.Log("Terrain1");
                    T1F = true;
                    Debug.Log("T1:" + T1F);
                }
                Terrain2.transform.position = Vector3.MoveTowards(Terrain2.transform.position, GameObject.Find(target[targetNum[tarN + 4]]).transform.position, step);
                Debug.Log(tarN + 4);
                if (Terrain2.transform.position == GameObject.Find(target[targetNum[tarN + 2]]).transform.position)
                {
                    Debug.Log("Terrain2");
                    T2F = true;
                    Debug.Log("T2:" + T2F);
                }
                Terrain3.transform.position = Vector3.MoveTowards(Terrain3.transform.position, GameObject.Find(target[targetNum[tarN + 3]]).transform.position, step);
                Debug.Log(tarN + 3);
                if (Terrain3.transform.position == GameObject.Find(target[targetNum[tarN + 3]]).transform.position)
                {
                    Debug.Log("Terrain3");
                    T3F = true;
                    Debug.Log("T3:" + T3F);
                }
                Terrain4.transform.position = Vector3.MoveTowards(Terrain4.transform.position, GameObject.Find(target[targetNum[tarN + 2]]).transform.position, step);
                Debug.Log(tarN + 2);
                if (Terrain4.transform.position == GameObject.Find(target[targetNum[tarN + 4]]).transform.position)
                {
                    Debug.Log("Terrain4");
                    T4F = true;
                    Debug.Log("T4:" + T4F);
                }
                Terrain5.transform.position = Vector3.MoveTowards(Terrain5.transform.position, GameObject.Find(target[targetNum[tarN + 1]]).transform.position, step);
                Debug.Log(tarN + 1);
                if (Terrain5.transform.position == GameObject.Find(target[targetNum[tarN + 5]]).transform.position)
                {
                    Debug.Log("Terrain5");
                    T5F = true;
                    Debug.Log("T5:" + T5F);
                }
                Terrain0.transform.position = GameObject.Find(target[targetNum[tarN]]).transform.position;
                Debug.Log(tarN);
                if (Terrain0.transform.position == GameObject.Find(target[targetNum[tarN]]).transform.position)
                {
                    Debug.Log("Terrain0");
                    T0F = true;
                    Debug.Log("T0:" + T0F);
                }
                if (T1F & T2F & T3F & T4F & T5F & T0F)
                {
                    Debug.Log("所有地完成第一個點的移動  進入判斷");
                    FinishFlag = false;
                    Debug.Log("Terrain0");
                    Debug.Log("將FinishFlag改為false");
                    if (tarN == -1)
                    {
                        tarN = 4;
                        Terrain1.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將1回到0");
                        ChangTargetPoint();
                    }
                    else if (tarN == -2)
                    {
                        tarN = 3;
                        Terrain2.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將2回到0");
                        ChangTargetPoint();
                    }
                    else if (tarN == -3)
                    {
                        tarN = 2;
                        Terrain3.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將3回到0");
                        ChangTargetPoint();
                    }
                    else if (tarN == -4)
                    {
                        tarN = 1;
                        Terrain4.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將4回到0");
                        ChangTargetPoint();
                    }
                    else if (tarN == -5)
                    {
                        tarN = 0;
                        Terrain5.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將5回到0");
                        ChangTargetPoint();
                    }
                    else if (tarN == 0)
                    {
                        tarN = 5;
                        Terrain0.transform.position = GameObject.Find(target[targetNum[0]]).transform.position;
                        Debug.Log("將6回到0");
                        ChangTargetPoint();
                    }

                    T1F = false;
                    T2F = false;
                    T3F = false;
                    T4F = false;
                    T5F = false;
                    T0F = false;
                }
            }
        }
    }


    void ChangTargetPoint()
    {
        Debug.Log("更改各塊地的移動目標點");
        for (int n = 0; n == 5; n++)
        {
            Debug.Log(targetNum[n] + "!");
            if (targetNum[n] == 5)
            {
                Debug.Log(targetNum[n]);
                targetNum[n] = 0;
                Debug.Log("更改5到0");
            }
            else Debug.Log(targetNum[n]); targetNum[n]++; Debug.Log("更改從" + (n + 1) + "到" + n);

        }
        FinishFlag = true;
    }


}
