Shader "fulei/TextureShader" {
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color("Vertex Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCg.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _Color;
			
			struct v2f
			{
				float4 pos : POSITION;
				float2 tex : TEXCOORD0;
			};
			
			void vert(in appdata_base IN, out v2f OUT)
			{
				OUT.pos = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.tex = IN.texcoord.xy;
			}
			
			void frag(in v2f IN, out float4 col : COLOR)
			{
				col = tex2D(_MainTex, IN.tex) * _Color;
			}
			
			ENDCG
		}
	}
}
