//Vertex shader

//Radius of the planet in kilometers. 
uniform dvec3 uRadius;

//Vertical exxageration of the height map. Use 1.0 as no exxageration.
uniform double uExxageration; 

//Position of the geodesic grid vertex. 
attribute dvec3 aVertex;

//The height of the point in meters. 
attribute double aHeight;

//The color of the point. 
attribute vec3 aColor;

varying vec3 vColor;

void main()
{
	gl_Position = dvec4(aVertex, 1.0);
	double exxagerationScale = 1 + aHeight * uExxageration * 0.001;
	gl_Position.x *= uRadius.x * exxagerationScale;
	gl_Position.y *= uRadius.y * exxagerationScale;
	gl_Position.z *= uRadius.z * exxagerationScale;
	vColor = aColor;
}