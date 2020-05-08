Shader "xray"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" "VisorSurface" = "Real"}
		ZWrite Off
		LOD 100
		Blend One One
		Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1; // Used to store the screen position for the frag shader
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
				o.screenPos = ComputeScreenPos(o.vertex); // calculate the screen pos from the clip pos
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                float4 clip = i.screenPos / i.screenPos.w;
				return fixed4(0.6, 0.6, 0.6, 1) * smoothstep(0, 0.05, clip.z);
            }
            ENDCG
        }
    }
}
