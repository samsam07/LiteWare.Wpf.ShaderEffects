// Sampler Registers //

sampler2D implicitInputSampler : register(S0);

// Constants Registers //

float2 blurCenter : register(C0);
float blurMagnitude : register(C1);

// Pixel Shader //

float4 main(float2 uv : TEXCOORD) : COLOR
{
	const float STRENGTH = 0.02;

	uv -= blurCenter;

	float4 c = 0;
	for (int i = 0; i < 15; i++)
	{
		float scale = 1.0 + (blurMagnitude * STRENGTH) * (i / 14.0);
		c += tex2D(implicitInputSampler, uv * scale + blurCenter);
	}
	c /= 15;

	return c;
}