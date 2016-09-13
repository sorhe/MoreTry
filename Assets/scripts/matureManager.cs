using UnityEngine;
using System.Collections;

public class matureManager : MonoBehaviour {
	private float maturetime=5;
	//float counttime=0;
	public int planttype;
	public GameObject[] target;
	public Transform  mManager;
	public float timemin;
	public float timesec;
	public float stimemin;
	public float  stimesec;
	System .DateTime now1;
	// Use this for initialization
	void Start () {

		target = new GameObject[] {
			Resources .Load ("Prefabs/plant1mature") as GameObject ,
			Resources .Load ("Prefabs/plant2mature") as GameObject
			
			
		};
	}
	bool i=true ;
	// Update is called once per frame
	void Update () {

		now1 = System.DateTime .Now;
		stimemin = now1.Minute;
		stimesec = now1.Second;
//		counttime += Time.deltaTime;
//		if (counttime>maturetime ) 
//		{
//			isMature ();
//			//Debug .Log (planttype);
//			counttime =0;
//		}

		if (delta == maturetime&&i==true) {
			isMature ();
			i=false ;
		}

		caltulatetime ();	
	}
	float delta=0;
	void caltulatetime(){
		delta = (stimemin - timemin) * 60 + (stimesec - timesec);
		print (delta);
	}
	void isMature(){


			GameObject plant = Instantiate (target [planttype], transform.position, transform .rotation ) as GameObject;
		plant .transform .parent = mManager;
		Destroy (gameObject,0.1f);
			
		
	}
}
