using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	RaycastHit hit;
	public GameObject[] target;
	public GameObject pppp;
	public Transform  mManager;
	System .DateTime now;
	// Use this for initialization
	void Start () {
		target = new GameObject[] {
			Resources .Load ("Prefabs/plant1start") as GameObject ,
			Resources .Load ("Prefabs/plant2start") as GameObject
				

		};
		//mManager = new GameObject ();

	}
	matureManager scp1;
	// Update is called once per frame
	void Update () {
		now = System.DateTime .Now;
		aimtarget ();



	}
	int i;
	void aimtarget(){
		if (Input .GetKeyDown (KeyCode .Alpha1)) {
			i = 0;
			print ("you choose p1");
		}
		if (Input .GetKeyDown (KeyCode .Alpha2)) {
			i = 1;
			print ("you choose p2");
		}
		if (Input .GetMouseButtonDown (0)) {
			
			Ray ray=Camera .main .ScreenPointToRay (Input .mousePosition );    
			if (Physics .Raycast (ray, out hit)&&hit.collider .transform .tag =="place") {
				Debug .DrawRay (ray.origin ,hit.point -ray.origin ,Color .blue );


				//int i=Random .Range (0,2);
				pppp=Instantiate (target[i],hit.collider .transform .position ,Quaternion .identity )as GameObject ;
				pppp.transform .parent =mManager ;
				matureManager script=pppp .GetComponent <matureManager >();

				script.planttype=i;

				script.timemin = now.Minute;
				script.timesec = now.Second;

			}

			
		}
		
	}

}

