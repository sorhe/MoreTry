Shader "fulei/FixedSpeater" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Vector (RGB)", Color) = (1,1,1,1)
		_DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
		_SpecularColor ("Speater Color", Color) =(1,1,1,1)
		_EmissionColor("Emmisive Color", Color) = (1,1,1,1)
		_AmbientColor ("Ambient Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Range(0.01, 1)) = 0.5
	}
	SubShader 
	{
		Pass
		{
			Tags { "RenderType"="Opaque" }
			LOD 200
			
			Color[_Color]
			
			Lighting on
			Material
			{
				Diffuse[_DiffuseColor]
				Specular[_SpecularColor]
				Emission[_EmissionColor]
				
				Ambient[_AmbientColor]
				Shininess[_Shininess]
			}
			SeparateSpecular on
			
			SetTexture[_MainTex]{ constantColor[_Color] combine texture * primary DOUBLE, texture * constant}
		}
		
	} 
}
