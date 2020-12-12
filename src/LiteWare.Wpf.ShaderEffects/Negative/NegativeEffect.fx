// Sampler Registers //

sampler2D implicitInputSampler : register(S0);

// Pixel Shader //

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color = tex2D(implicitInputSampler, uv);
	return float4(1 - color.r, 1 - color.g, 1 - color.b, color.a);
}