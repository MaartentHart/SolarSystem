uniform mat4 uMVP;
attribute vec2 aPosition;
attribute vec3 aColor;
attribute float aScale; 
varying vec3 vColor;
void main() 
{
	gl_Position = uMVP * vec4(aPosition, 0.0, 1.0);
	gl_Position.x *= aScale; 
	gl_Position.y *= aScale;
	gl_Position.z *= aScale;
	vColor = aColor;
}