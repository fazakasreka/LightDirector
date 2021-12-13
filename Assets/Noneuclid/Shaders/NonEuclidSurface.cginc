#ifndef NONEUCLIDSURFACE_INCLUDED
#define NONEUCLIDSURFACE_INCLUDED

#include "UnityStandardCore.cginc"
#include "CommonIncludes.cginc"

float LorentzSign;
float globalScale;

struct Input {
	float2 uv_MainTex;
	float3 vertexColor; // Vertex color stored here by vert() method
};

void vert(inout appdata_full v, out Input o)
{
	UNITY_INITIALIZE_OUTPUT(Input, o);
	o.vertexColor = v.color;
}

void surf(Input IN, inout SurfaceOutputStandard o)
{
	// Albedo comes from a texture tinted by color
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb * IN.vertexColor; // Combine normal color with the vertex color
	// Metallic and smoothness come from slider variables
	o.Metallic = _Metallic;
	o.Smoothness = _Glossiness;
	o.Alpha = c.a;
}

#endif // NONEUCLID_INCLUDED