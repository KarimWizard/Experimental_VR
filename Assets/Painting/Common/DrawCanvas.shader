Shader "KarimWizard/Paint/DrawCanvas"
{
    Properties
    {
        _Paint  ("Paint" , 2D) = "white" {}
        _Origin ("Origin", 2D) = "white" {} 
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
            #include "UnityCG.cginc"

            #pragma surface Surf Lambert
            #pragma target  3.0

            struct Input
            {
                float2 uv_Origin;
                float2 uv_Paint;
            };

            sampler2D _Origin;
            sampler2D _Paint;

            void Surf (Input In, inout SurfaceOutput Out)
            {
                fixed4 TextureOrigin = tex2D(_Origin, In.uv_Origin);
                fixed4 TexturePaint  = tex2D(_Paint , In.uv_Paint );

                Out.Albedo = TextureOrigin.rgb * TexturePaint.rgb;
            }
        ENDCG
    }
}
