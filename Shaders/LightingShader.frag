uniform vec4 frag_LightColor;
uniform vec2 frag_LightOrigin;
uniform float frag_LightAttenuationRadius;
uniform vec2 frag_ScreenResolution;

uniform vec2 array[128];
uniform float arrayCount;

uniform sampler2D texture;

void main()
{
	vec2 texPos = gl_TexCoord[0].xy;
	vec4 backgroundColor = texture2D(texture, texPos);
	vec2 baseDistance = gl_FragCoord.xy;
	baseDistance.y = frag_ScreenResolution.y - baseDistance.y;

	float minDist = 8192.0;
	for(int i = 0; i < arrayCount; i++) 
	{
		float dist = length(baseDistance - array[i]);
		if (dist < minDist)
			minDist = dist;
	}

	float a = max(0, frag_LightAttenuationRadius - minDist) / frag_LightAttenuationRadius;
	vec3 newColor = frag_LightColor.rgb;

	gl_FragColor = vec4(newColor * a + backgroundColor.rgb * (1 - a), 1.0);
}
