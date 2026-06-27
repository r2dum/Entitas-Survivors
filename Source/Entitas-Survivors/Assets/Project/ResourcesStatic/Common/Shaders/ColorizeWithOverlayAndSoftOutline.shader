Shader "Custom/URP_ColorizeWithOverlayAndSoftOutline"
{
    Properties
    {
        [MainTexture] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Intensity ("Color Intensity", Range(0,1)) = 0.5
        _OverlayColor ("Overlay Color", Color) = (1,1,1,1)
        _OverlayIntensity ("Overlay Intensity", Range(0,1)) = 0.0
        
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineSize ("Outline Size", Range(0, 25)) = 1.0
        _OutlineSmoothness ("Outline Smoothness", Range(1, 10)) = 2.0
        
        [HideInInspector] _FlipX ("Flip X", Float) = 0
    }

    SubShader
    {
        Tags 
        { 
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
            "RenderPipeline"="UniversalPipeline"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "SpriteOutlineAndColor"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                float4 color        : COLOR;
            };

            struct Varyings
            {
                float4 positionCS   : SV_POSITION;
                float2 uv           : TEXCOORD0;
                float4 color        : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_TexelSize;

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Color;
                float _Intensity;
                float4 _OverlayColor;
                float _OverlayIntensity;
                float4 _OutlineColor;
                float _OutlineSize;
                float _OutlineSmoothness;
                float _FlipX;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                if (_FlipX > 0.5) 
                {
                    input.uv.x = 1.0 - input.uv.x;
                }
                if (_MainTex_ST.z < 0) 
                {
                    input.uv.x = 1.0 - input.uv.x;
                }

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.color = input.color;
                
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 centerTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                float centerAlpha = centerTex.a;

                float2 texelStep = _MainTex_TexelSize.xy * _OutlineSize * 0.5; 

                float totalAlpha = 0.0;
                
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (x == 0 && y == 0) continue;
                        
                        float2 offset = float2(x, y) * texelStep;
                        totalAlpha += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv + offset).a;
                    }
                }

                float avgAlpha = totalAlpha / 8.0;
                float outlineAlpha = lerp(centerAlpha, avgAlpha, _OutlineSmoothness);

                float4 colorized = lerp(centerTex, _Color, _Intensity * centerAlpha);
                float4 finalSpriteColor = lerp(colorized, _OverlayColor, _OverlayIntensity * centerAlpha);
                
                finalSpriteColor *= input.color; 

                float4 finalColor;
                if (centerAlpha < outlineAlpha)
                {
                    finalColor = _OutlineColor * outlineAlpha;
                }
                else
                {
                    finalColor = finalSpriteColor;
                }

                return finalColor;
            }
            ENDHLSL
        }
    }
    Fallback "Sprites/Default"
}