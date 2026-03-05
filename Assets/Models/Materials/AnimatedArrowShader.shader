Shader "Custom/AnimatedArrowShader" {

	Properties
	{
		_MyColor("Color", Color) = (1.0, 0.0, 0.0, 0.5)
		_EmissionColor("Emission Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_TransSpeed("Transparent Speed",Int) = 10
		_Delay("Delay", Int) = 5
	}
		SubShader{

			Tags{ "Queue" = "Transparent"  "RenderType" = "Transparent" }

			Zwrite Off
			Blend SrcAlpha OneMinusSrcAlpha

		Pass
	{
			CGPROGRAM


#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"


		struct appdata
		{
			float4 vertex: POSITION;
			float2 uv: TEXCOORD0;
		};
		struct v2f
		{
			float4 pos: SV_POSITION;
			float2 uv: TEXTCOORD0;
		};
		v2f vert(appdata v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}
		fixed4 _MyColor;
		int _TransSpeed;
		int _Delay;
		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 color = _MyColor;
		if (_Time.y < 1.0 && i.pos.z < 0.5)
		{
			color.a = 0.0;
		}
		else
		{
			color.a = _MyColor.a * sin((_Time.y + _Delay)  * _TransSpeed);
		}
			return color;
		}

		ENDCG
	}
	}

}
			