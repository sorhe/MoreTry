using UnityEngine;
using System.Collections;

public class Test2D : MonoBehaviour 
{
	public Sprite sp = null;

	Camera m_pMainCamera = null;

	void Awake()
	{
		if (Camera.allCameras.Length <= 0) {
			GameObject pCamera = new GameObject ("Fulei Camera");
			pCamera.tag = "MainCamera";
			m_pMainCamera = pCamera.AddComponent<Camera> ();
			pCamera.transform.position = new Vector3(0f,0f,-10.0f);
		}
		else 
		{
			m_pMainCamera = Camera.main;
		}
		if (null != m_pMainCamera) 
		{
			int nW = Screen.width;
			int nH = Screen.height;
			m_pMainCamera.depth = -1;
			m_pMainCamera.farClipPlane = 500.0f;
			m_pMainCamera.nearClipPlane = 0.03f;
			m_pMainCamera.orthographic = true;
			m_pMainCamera.orthographicSize = nH / 2.0f / 100.0f;
		}

		// Create 2D Object
		GameObject pObj = new GameObject ("2DObject");
		SpriteRenderer pRender = pObj.AddComponent<SpriteRenderer>();
		pRender.sprite = sp;

		// Create Material
		Material pMt = new Material (Shader.Find ("fulei/FLSpriteShader"));
		pMt.hideFlags = HideFlags.DontSave;
		pMt.shader.hideFlags = HideFlags.DontSave;
		//pMt.SetTexture ("_MainTex", sp.texture);

		pRender.material = pMt;

	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
