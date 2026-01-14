Shader "RUFA/ShaderProva"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _vel("Velocity", Float) = 2.0
        _Expansion("Ampiezza displacement", Range(0, 0.5)) = 0.5
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

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _vel;
            float _Expansion;

            fixed4 Multiply(fixed4 col1, fixed4 col2)
            {
                return col1 * col2;
            }

            v2f vert (appdata v)
            {

                float oscillazione = sin(_Time.y * _vel) * 0.5 + 0.5;
                v.vertex.xyz += v.normal * oscillazione * _Expansion;
                v2f o;
                // Trasforma la posizione del vertice in clipsace
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float oscillazione = sin( _Time.y * _vel);
                float redValue = oscillazione * 0.5 + 0.5;
                fixed4 multipliedValue = fixed4(redValue,0,0,1);
                fixed4 _texture = tex2D(_MainTex, i.uv)
                fixed4 col = Multiply(_texture, multipliedValue)
                return col;
            }
            ENDCG
        }
    }
}
