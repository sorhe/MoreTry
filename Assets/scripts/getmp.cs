using UnityEngine;
using System.Collections;

public class getmp : MonoBehaviour {
	RaycastHit hit;
	float  temp=0;
	public GameObject Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		aimtarget ();
		if (i) {
			istouch ();
		}

	}
	bool i=false ;
	void istouch(){
		Vector3 p = Camera .main .ScreenToWorldPoint (Input .mousePosition);
		p.y=0;
		if(hit.collider !=null)
		hit.collider .transform .position =p;

	}
	float temp1;
	//Vector3 mouse_temp;
	void aimtarget(){
		if (Input .GetMouseButtonDown (0)) {
			//mouse_temp =Input .mousePosition;
			Ray ray=Camera .main .ScreenPointToRay (Input.mousePosition );    
			if (Physics .Raycast (ray, out hit)&&hit.collider .transform .tag =="pmature") {
				//Destroy (hit.collider .gameObject );
				i=true ;
//				Vector3 p = Camera .main .ScreenToWorldPoint (Input .mousePosition);
//				p.y=0;
//				hit.collider .transform .position =p;
				temp +=1;





				
				
			}
			
		}
		temp1 = temp;
		if (Input .GetMouseButtonUp (0)) {
			i=false ;
		}
		
	}
	public string stringToEdit = "Hello World\nI've got 2 lines...";
	void OnGUI() {
		stringToEdit = GUI.TextArea(new Rect(10, 10, 100, 50), "your score:"+temp1.ToString() , 200);
	}

}
