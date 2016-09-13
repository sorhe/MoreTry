Shader "fulei/FLSpecular" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Vertex Color", Color) = (1,1,1,1)
		// 漫反射反射系数
		_Atten("Atten" , FLOAT) = 2
		// 高光的颜色
		_SpecularColor ("Specular Color", Color)=(1,1,1,1)
		// 表面光泽度，如果无穷大表示不会产生镜面反射
		_Shininess("Shininess", Range(1, 40)) = 5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _Color;
			uniform float _Atten;
			uniform float4 _SpecularColor;
			uniform float _Shininess;

			struct v2f {
				float4 pos : SV_POSITION;
				float2 tex : TEXCOORD0;
				float3 nol : TEXCOORD1;
				float4 wps : TEXCOORD2;
			};
			
			void vert (in appdata_base IN, out v2f o) 
			{
				o.pos = mul(UNITY_MATRIX_MVP, IN.vertex);
				o.tex = IN.texcoord.xy;
				o.nol = IN.normal;
				o.wps = o.pos;
			}
			
			void frag(in v2f IN, out float4 col : COLOR) 
			{
				
				// 将物体的法向量方向转化到自身坐标系中，并且归一化计算
				float3 normalDir = normalize( float3( mul( float4(IN.nol, 0), _World2Object) ) );
				// 将灯的方向归一化，方便进行点乘计算
				float3 lightDir = normalize( _WorldSpaceLightPos0.xyz );
				
				float3 C = _Atten * _LightColor0 * _Color.rgb;
				
				// 获取漫反射颜色
				float3 diffuseColor = C * max(0, dot(normalDir, lightDir) );
				
				// 高光计算
				// 首先计算摄像机的角度
				float3 viewDir = normalize( _WorldSpaceCameraPos.xyz - IN.wps.xyz );//normalize( WorldSpaceViewDir(IN.wps) );
				// 计算高光颜色值
				float3 SC = _LightColor0.rgb * _SpecularColor.rgb;
				// 计算高光颜色
				float3 specularColor = SC * pow( max(0, dot( reflect(-1 * lightDir, normalDir), viewDir) ), _Shininess );
				
				float3 ambientLighting = float3(UNITY_LIGHTMODEL_AMBIENT) * diffuseColor;
				
				float4 resultColor = float4(ambientLighting + diffuseColor + specularColor, 1.0f);
				
				col = tex2D(_MainTex, IN.tex);
				
				col *= resultColor;
			}
			ENDCG	
		}
	} 
	FallBack "Diffuse"
}
