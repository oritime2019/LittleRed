using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{	
    public static float speed =10.0f;
	public bool moveFlag=false;
	public bool FinishFlag=true;
	public bool T1F=false;
	public bool T2F=false;
	public bool T3F=false;
	public bool T4F=false;
	public bool T5F=false;
	public bool T0F=false;

	[SerializeField]
	public GameObject Terrain0,Terrain1,Terrain2,Terrain3,Terrain4,Terrain5;
	public List<Transform> TerrainTranList = new List<Transform>();

	int[] targetNum =new int[7]{5,0,1,2,3,4,6};   //記錄各個terrain接下來要移動往哪個點，例:targetNum[0]=5，terrain0接下來要往pos5移動。
	//int tarN=0;
	float step ; 
	

    void Start(){
		//Debug.Log(targetNum[1]);
		//Debug.Log(target[targetNum[1]]);
		step =  speed * Time.deltaTime;
		moveFlag=true;
		Debug.Log("將moveflag改為true");
		FinishFlag=true;
    }

	 void Update(){
		Debug.Log("UPDATE");
		if(moveFlag){
			Debug.Log("偵測到moveflag改為true");
			if(FinishFlag){
				Debug.Log("偵測到FinishFlag改為true");
				Debug.Log("移動地板中");				
				moveTerrain(Terrain1.transform,TerrainTranList[targetNum[1]]);
				moveTerrain(Terrain2.transform,TerrainTranList[targetNum[2]]);
				moveTerrain(Terrain3.transform,TerrainTranList[targetNum[3]]);
				moveTerrain(Terrain4.transform,TerrainTranList[targetNum[4]]);
				moveTerrain(Terrain5.transform,TerrainTranList[targetNum[5]]);
				moveTerrain(Terrain0.transform,TerrainTranList[targetNum[0]]);					
			}
		}
    }
	
	void moveTerrain(Transform terrain,Transform moveToPos)
	{
	terrain.position = Vector3.MoveTowards(terrain.transform.position, moveToPos.position, step);
	checkIsArrival();
	}

	void checkIsArrival(){
		if(T1F&T2F&T3F&T4F&T5F&T0F){
			Debug.Log("所有地完成第一個點的移動");
			Debug.Log("將FinishFlag改為false，地板不再移動");
			FinishFlag=false;
			Debug.Log("將T0-T5改為false");
			T1F=false;
			T2F=false;
			T3F=false;
			T4F=false;
			T5F=false;
			T0F=false;	
			roundEnd();
		}			
		else if(T1F==false){
			if(Terrain1.transform.position==TerrainTranList[targetNum[1]].position){
				T1F=true;
				Debug.Log("T1:"+T1F);
			}
		}
		else if(T2F==false){
			if(Terrain2.transform.position==TerrainTranList[targetNum[2]].position){
				T2F=true;
				Debug.Log("T2:"+T2F);
			}
		}
		else if(T3F==false){
			if(Terrain3.transform.position==TerrainTranList[targetNum[3]].position){
				T3F=true;
				Debug.Log("T3:"+T3F);
			}
		}
		else if(T4F==false){
			if(Terrain4.transform.position==TerrainTranList[targetNum[4]].position){
				T4F=true;
				Debug.Log("T4:"+T4F);
			}
		}
		else if(T5F==false){
			if(Terrain5.transform.position==TerrainTranList[targetNum[5]].position){
				T5F=true;
				Debug.Log("T5:"+T5F);
			}
		}
		else if(T0F==false){
			if(Terrain0.transform.position==TerrainTranList[targetNum[0]].position){
				T0F=true;
				Debug.Log("T0:"+T0F);
			}
		}

	}

	void roundEnd(){	
		if(targetNum[1]==0){
			Debug.Log("判斷T1在最尾端");
			ChangTargetPoint(Terrain1.transform,1);
			FinishTurn();
		}
		if(targetNum[2]==0){
			Debug.Log("判斷T2在最尾端");
			ChangTargetPoint(Terrain2.transform,2);
			FinishTurn();
		}
		if(targetNum[3]==0){
			Debug.Log("判斷T3在最尾端");
			ChangTargetPoint(Terrain3.transform,3);
			FinishTurn();
		}
		if(targetNum[4]==0){
			Debug.Log("判斷T4在最尾端");
			ChangTargetPoint(Terrain4.transform,4);
			FinishTurn();
		}
		if(targetNum[5]==0){
			Debug.Log("判斷T5在最尾端");
			ChangTargetPoint(Terrain5.transform,5);
			FinishTurn();
		}
		if(targetNum[0]==0){
			Debug.Log("判斷T0在最尾端");
			ChangTargetPoint(Terrain0.transform,0);
			FinishTurn();
		}	

	}

	void ChangTargetPoint(Transform Terrain,int lastT){
		Debug.Log("更改各塊地的移動目標點");
		for(int n=0;n<5;n++){	
			if(n==lastT){
				Debug.Log("最尾端:更改T"+lastT+"下輪目標點從Pos"+targetNum[n]+"更改成Pos5");
				targetNum[n]=5;
			}
			else{
			Debug.Log("更改從"+targetNum[n]+"到"+(targetNum[n]-1));
			targetNum[n]--;
			}
		}
		Debug.Log("實際將尾端地形T"+lastT+"瞬移到頭端");
		Terrain.transform.position = TerrainTranList[6].position;
	}

	void FinishTurn(){
		Debug.Log("FinishFlag改為TRUE，地形再度移動");
		FinishFlag=true;
	}  
}
