using UnityEngine;
using System.Collections;

public class TestMaterials3D : MonoBehaviour 
{
	#region Properties
	private Transform m_pTransform;
	#endregion

	// Use this for initialization
	void Start () 
	{
		GameObject pEmpty = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Transform pTr = pEmpty.GetComponent<Transform> ();
		pTr.position = Vector3.zero;
		pTr.rotation = Quaternion.identity;
		pTr.localScale = Vector3.one;

		Destroy (pEmpty.GetComponent<Collider>());

		// 新建一个材质球

		//string strMyShader = "Shader \"MySahder\"{ Properties{ _Color(\"RGB\", Color)=(1,1,1,1) } SubShader{ Pass{ Tags{\"RenderType\"=\"Opaque\"} \r\nLOD 200\r\n CGPROGRAM \r\n #pragma vertex vert \r\n #pragma fragment frag \r\n uniform float4 _Color; \r\nfloat4 vert( in float4 pos ) :POSITION { return mul(UNITY_MATRIX_MVP, pos); }\r\n float4 frag () : COLOR { return _Color; } \r\nENDCG} }}";

		Material pMaterial = new Material (Shader.Find( "fulei/RgbShader"));
		pMaterial.hideFlags = HideFlags.DontSave;
		pMaterial.shader.hideFlags = HideFlags.DontSave;
		pMaterial.SetColor ("_VectorColor", Color.yellow);

		pEmpty.GetComponent<MeshRenderer> ().material = pMaterial;

		MeshFilter pFilter = pEmpty.GetComponent<MeshFilter> ();


		Destroy (this);
	}

}
