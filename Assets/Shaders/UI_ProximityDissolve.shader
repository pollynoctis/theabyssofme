Shader "UI/ProximityDissolve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Mouse ("Mouse Position (World)", Vector) = (0,0,0,0)
        _Radius ("Erase Radius", Float) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Mouse;
            float _Radius;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 worldPos : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                // Получаем мировую позицию пикселя
                float4 world = mul(unity_ObjectToWorld, v.vertex);
                o.worldPos = world.xy;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dist = distance(i.worldPos, _Mouse.xy);

                // Если внутри радиуса — альфа = 0
                if (dist < _Radius)
                    return fixed4(0, 0, 0, 0);

                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
