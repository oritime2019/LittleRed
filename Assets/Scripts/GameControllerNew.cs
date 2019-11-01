using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerNew : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    bool moveFlag;

    [SerializeField]
    bool FinishFlag;

    [SerializeField]
    GameObject FloorGroup;

    List<Transform> TerrainList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!moveFlag || !FinishFlag)
        {
            return;
        }


    }

    private float step
    {
        get
        {
            return speed * Time.deltaTime;
        }
    }
}
