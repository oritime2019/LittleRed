using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TEST : MonoBehaviour
{
    [SerializeField]
		public GameObject C1,C2;

    void Start()
    {
        if(C1.transform.position==C2.transform.position){
			Debug.Log("TRUE");
			}else Debug.Log("FALSE");



    }

   
    void Update()
    {
        
    }
}
