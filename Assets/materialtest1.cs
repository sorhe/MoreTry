using UnityEngine;
using System.Collections;

public class materialtest1 : MonoBehaviour {
	Vector3 p1,p2;

	// Use this for initialization
	void Start () {
		p1 = new Vector3 (1,3,4);
		p2 = new Vector3 (2,-5,8);
	}
	
	// Update is called once per frame
	void Update () {
		print(Vector3 .Angle (p1, p2));
	}}
