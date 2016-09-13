using UnityEngine;
using System.Collections;

public class MyWater : MonoBehaviour 
{

	Material m_pMaterial = null;
	// Use this for initialization
	void Start () {	
		Renderer pRender = gameObject.GetComponent<Renderer> ();
		m_pMaterial = pRender.material;
	}
	
	// Update is called once per frame
	void Update () {
		if (null != m_pMaterial) 
		{
			m_pMaterial.SetFloat("_MyTime", Time.deltaTime);
		}
	}
}
