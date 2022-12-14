Shader "KarimWizard/Paint/SupportShader"
{
    Properties
    {
        _Brush ("Brush", 2D) = "white" {}
        _Size ("Size", Range(0.1, 1.0)) = 0.2
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0
            
            sampler2D _Brush;
            float4 _Position;
            float _Size;
            
            float4 frag(v2f_customrendertexture In) : COLOR
            {   
                float4 OldColor = tex2D(_SelfTexture2D, In.localTexcoord.xy);

                float2 DrawCoord = In.localTexcoord.xy - _Position;
                DrawCoord /= _Size;
                DrawCoord += float2(0.5, 0.5);

                float4 NewColor = tex2D(_Brush, DrawCoord);

                return OldColor * NewColor;
            }
            ENDCG
        }
    }
}