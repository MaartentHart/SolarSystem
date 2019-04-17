//Copyright Maarten 't Hart 2013
#pragma once
#include "Point3D.h"
#include "Element3D.h"
#include <vector>

struct GeodesicGrid;
struct SquareGrid;
struct GridCell;
struct GridCellEnumerator;
class GridCellIterator;
struct TanArray; 

inline unsigned long GenerationFactor(unsigned int Generation)
{
	return (1 << (Generation * 2));
}

inline unsigned long ArraySizeForGeneration(unsigned short Generation)
{
	return GenerationFactor(Generation) * 10 + 2;
}

struct TanPlane//a tanplane is a plane that holds information about the projection point for a segment. 
//It is possible to get a slicing plane by sending a tan to the "PlaneFromTan" function for grid building
//It is also useful for finding the gridpoint. The Icosahedron has 60 tanplanes. (3 for each triangle)
{
	TanPlane();
	TanPlane(const Point3D&A /*first corner*/, const Point3D&B /*second corner*/, const Point3D&C /*third corner*/);
	~TanPlane();

	Point3D ProjectionPoint;
	Point3D XVector;
	Point3D YVector;
	Point3D ZVector;
	Point3D SlicingPlaneVector;

	//gives the tan of a point relative to this plane 
	double TanOf(const Point3D&that) const; 
	Plane PlaneFromTan(double Tan) const;
	Plane PlaneBase() const;
};

//two triangles combined into a rectangle, which makes it easier to form grids. 
struct PairedIcoTriangle
{
	char A;
	char B;
};

struct IcoTriangle : public Triangle
{
	char nr;
	char pairedTriangleIndex;
	bool pairedTriangleA;
	TanPlane tanPlane[3];

	IcoTriangle();
	IcoTriangle(Point3D*p, long A, long B, long C);
	~IcoTriangle();
};

struct Icosahedron
{
protected:
	std::vector<Point3D> corner;
	std::vector<IcoTriangle> icoTriangle;
	double riblength;
	std::vector<PairedIcoTriangle> pair;
	TanPlane TPX;
	TanPlane TPY;
	TanPlane TPZ;
	friend struct GeodesicGrid;
	friend struct SquareGrid;
public:

	Icosahedron();
	~Icosahedron();

	char SquareGridIndex(char IcoTriangleIndex);
	bool TriangleA(char IcoTriangleIndex);
	Point3D Corner(int index);
	double RibLength();
	void Build();
	char IcoTriangleIndex(const Point3D&that) const;
	char Direction(const Point3D&there) const;
};

struct Segment
{
	Point3D IcoCorner, IcoRibMid, ArcTopSide, ArcTopFront, ProjectionPoint, Origin, IcoCorner2;
	double TriangleLength;
	Plane TiltedCircle;
	Plane TopCircle;

	Segment();
	~Segment();

	double TanOf(const Point3D&that)const;
	Point3D Rotate120(Point3D that)const;//van primairy point naar secondary point
	Plane PlaneFromTan(double tan)const;
	double PrimaryTan(double oldtan) const;//only used for building the array see home geodesic.dgn
	double SecondaryTan(double oldtan) const;//only used for building the array see home geodesic.dgn
};

const Icosahedron& MainIcosahedron();
const Segment&MainSegment();
const TanArray&MainTanArray();

//Gets a geodesic grid by generation, and puts a new geodesic grid into a vector if it did not yet exist. 
const GeodesicGrid&GetGeodesicGrid(unsigned int generation);

struct SectionRowOrColumn
{
	std::vector<Plane> slicingplanes;

	SectionRowOrColumn();
	~SectionRowOrColumn();

	void Build(unsigned short generation, const TanPlane&TanPlane);
};

//the geodesic grid has 10 squaregrids, which are the 10 paired triangles of the icosahedron. 
//The grids are "square" in the sence that they have an equal amount of rows and columns.
struct SquareGrid{
	GeodesicGrid*Parent;
	PairedIcoTriangle Pair;
	char Index;
	SectionRowOrColumn ARow, ACol, BRow, BCol;

	SquareGrid();
	~SquareGrid();
	void Generate(GeodesicGrid*parent, char index /*0 to 9*/, unsigned short generation);
};

struct GeodesicGrid
{
	std::vector<Point3D> points;
private:
	std::vector<TriangleIndices> indices;
	std::vector<SquareGrid> grids;
	unsigned long PointsPerSquare;
	unsigned long PointsPerRow;
	unsigned short MaxGeneration;

public:

	GeodesicGrid();
	GeodesicGrid(unsigned short maxgeneration);
	~GeodesicGrid();

	Point3D Point(unsigned long index) const;
	const std::vector<Point3D>& PointList() const;
	unsigned long PointIndex(char squaregrid, unsigned long row, unsigned long column) const;
	GridCell Touch(Point3D there)const;
	unsigned long Dummy1() const;
	unsigned long Dummy2() const;
	unsigned long PointIndex(Point3D position) const;
	const std::vector<SquareGrid>& Grids() const;
	const std::vector<TriangleIndices>& TriangleIndices() const;
	unsigned short Generation()const;
	GridCell GridCell(unsigned long index) const;

	friend struct SquareGrid;
	friend struct SectionRowOrColumn;
};

struct TanArray
{
	std::vector<double> Tangens;
	int Generation;

	TanArray(int generation);
	~TanArray();

	unsigned long TanIndex(double tan, int generation, bool removegenerationbit = true) const;//returns the index of the tangens in the tangensarray - with the first 1 of the index removed.

};

struct GridCell
{
	char squaregrid;
	unsigned short generation;
	unsigned long row, column, pointindex;

	bool CornerDuplicateWarning;
	//usually false. Only true when this may be a duplicate gridcell is generated from 1 of the 12 cornerpoints.
	//points have 6 neighbors, except for the corners, which have 5. In stead of throwing an exception,
	//the program gives a valid duplicate with this warning attached to it. 
	GridCell(); 
	GridCell(unsigned short generation);
	GridCell(const GeodesicGrid&grid);
	GridCell(const GeodesicGrid&grid, const Point3D&position);
	GridCell(const GeodesicGrid&grid, char squareGrid, unsigned long Row, unsigned long Column);
	GridCell(char squareGrid, unsigned long Row, unsigned long Column, unsigned short Generation);
	
	inline bool operator==(const GridCell&that) const
	{
		return (squaregrid == that.squaregrid) && (generation == that.generation) &&
			(row == that.row) && (column == that.column) && (pointindex == that.pointindex);
	}

	unsigned long PointIndex();
	unsigned long PointIndex(const GeodesicGrid&grid);//recalculates the pointindex. If it is already correct this is a waste of time, use pointindex in stead. 
	GridCell Neighbor(char index) const; //0 up, 1 right, 2 down, 3 left, 4 upleft, 5 downright. 
	GridCell Child(char index) const; //generation up, row and column * 2. 0 is top left, 1 is top right, 2 is bottom left, 3 is bottom right. 
	GridCell Parent() const; //generation down, row and column shift 1 bit, or devided by 2. 
	Point3D Point3D()const;
};

GridCell DummyCell1(unsigned short generation);
GridCell DummyCell2(unsigned short generation);

class GridCellIterator//this struct is used by GRIDCELLENMURATOR. Do not use, use GRIDCELLENUMERATOR.
{
	GridCellIterator*Parent;
	GridCellEnumerator*base;
	char index;
	GridCell Current;

	GridCellIterator();
	GridCellIterator(GridCellIterator*parent);

	friend GridCellEnumerator;
};

struct GridCellEnumerator//itterating through a contiguous area on the geodesic grid. 
{
private:
	bool Init;
	std::vector<bool> ProcessedMask;
	std::vector<bool> UseMask;
	GridCellIterator*current;
	bool CurrentIsValid;
	//the geodesic grid generation. 
	unsigned short generation;

	void Setup(const GridCell&that);
	void StepBack();
	
public:
	//index is the start position of the enumartor. Generation is the generation of the geodesic grid. 
	GridCellEnumerator(unsigned long index, unsigned short generation);
	//point3d is the start position of the enumarator. Generation is the generation of the geodesic grid. 
	GridCellEnumerator(const Point3D&there, unsigned short generation);
	//gridCell is the start position of the enumarator. 
	GridCellEnumerator(const GridCell&gridCell);
	GridCellEnumerator();
	~GridCellEnumerator();

	bool MoveNext();
	::GridCell GridCell() const;
	::Point3D Point3D() const;
	unsigned long Index() const;
	void SetFalse();
};