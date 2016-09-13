Shader "sor/myshadertest1" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainColor("Color (RGB)",Color)=(1,1,1,1)
		_shininess("shininess",Range(0,1))=0.5
		_Ambient("_Ambient (RGB)",Color)=(1,1,1,1)
		_Emission("_Emission (RGB)",Color)=(1,1,1,1)
		_ESpecular("_Specular (RGB)",Color)=(1,1,1,1)
	}
	SubShader {
	Pass{
		Tags { "RenderType"="Opaque" }
		LOD 200
		Lighting on
	
		Material{
		Diffuse[_MainColor]
		Shininess[_shininess]
		Ambient[_Ambient]
		Specular[_ESpecular]
		Emission[_Emission]
		
		}
		SeparateSpecular on
		SetTexture[_MainTex]{combine texture*Primary DOUBLE }
		}
		

	} 
	
}
