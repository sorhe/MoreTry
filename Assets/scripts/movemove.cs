using UnityEngine;
using System.Collections;

public class movemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector2 temp = floor.renderer .material .mainTextureOffset;
//		temp .x+= 0.4f*Time.deltaTime ;
//		temp.y += 0.4f * Time .deltaTime;
//		floor .renderer .material .mainTextureOffset  = temp;
	}
	void OnTriggerStay(Collider  collider) {
		if (collider .tag == "getplants") {
			Destroy (gameObject,0.5f);
			print ("ok");
		}
	}
}
