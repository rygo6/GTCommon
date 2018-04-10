// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "GeoTetra/UnlitTextureCubeReflective"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Cube("Reflection Map", Cube) = "" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct vertexOutput
			{
				float2 uv : TEXCOORD0;
				float3 normalDir : TEXCOORD1;
				float3 viewDir : TEXCOORD2;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			uniform samplerCUBE _Cube;
			float4 _MainTex_ST;

			uniform float4 _Color;
			uniform float4 _UpperHemisphereColor;
			uniform float4 _LowerHemisphereColor;
			uniform float4 _UpVector;
			
			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				float4x4 modelMatrix = unity_ObjectToWorld;
				float4x4 modelMatrixInverse = unity_WorldToObject;

				output.viewDir = mul(modelMatrix, input.vertex).xyz
					- _WorldSpaceCameraPos;
				output.normalDir = normalize(
					mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);

				output.vertex = UnityObjectToClipPos(input.vertex);
				output.uv = TRANSFORM_TEX(input.uv, _MainTex);

				return output;
			}
			
			fixed4 frag (vertexOutput input) : COLOR
			{
				fixed4 col = tex2D(_MainTex, input.uv);
				float3 reflectedDir =
					reflect(input.viewDir, normalize(input.normalDir));
				col += texCUBE(_Cube, reflectedDir);
				return col;
			}
			ENDCG
		}
	}
}
