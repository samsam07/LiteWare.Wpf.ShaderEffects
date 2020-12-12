// Sampler Registers //

sampler2D implicitInputSampler : register(S0);

// Constants Registers //

float blurAngle : register(C0);
float blurMagnitude : register(C1);

// Pixel Shader //

float4 main(float2 uv : TEXCOORD) : COLOR
{
	const float STRENGTH = 0.0001;

	float2 offset;
	sincos(radians(blurAngle), offset.y, offset.x);
	offset *= blurMagnitude * STRENGTH;

	float4 output = 0;
	for (int i = 0; i < 15; i++)
	{
		output += tex2D(implicitInputSampler, uv - offset * i);
	}
	output /= 15;

	return output;
}