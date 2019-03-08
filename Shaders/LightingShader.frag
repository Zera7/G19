uniform vec4 frag_LightColor;
uniform vec2 frag_LightOrigin;
uniform float frag_LightAttenuationRadius;
uniform vec2 frag_ScreenResolution;

void main()
{
	vec2 baseDistance = gl_FragCoord.xy;
	baseDistance.y = frag_ScreenResolution.y - baseDistance.y;
	
	float d = length(baseDistance.xy - frag_LightOrigin);
	float a = 1.0 - (d / frag_LightAttenuationRadius);

	//gl_FragColor = vec4(1.0 * a, 0.0, 0.0, 1.0 * a * 10.0);	
	gl_FragColor = vec4(1.0 * frag_LightColor.r, 1.0 * frag_LightColor.g, 1.0 * frag_LightColor.b, 1.0 * a);	

}
