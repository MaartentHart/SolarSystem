//Copyright Maarten 't Hart 2013
#include "stdafx.h"
#include "Geodesic.h"

const double sin60 = sqrt(3. / 4.);
static const Icosahedron icosahedron;
Segment segment;
TanArray tanArray(11);
int tanArrayGeneration = 11; 
struct GeodesicGridContainer
{
	std::vector<GeodesicGrid*> grids;
	~GeodesicGridContainer()
	{
		for (GeodesicGrid* grid:grids)
		{
			if (grid)
				delete grid; 
		}
	}

	GeodesicGrid*GetGrid(unsigned int generation)
	{
		if (grids.size() > generation)
		{
			if (grids[generation] != NULL)
				return grids[generation];
		}
		else
		{
			grids.resize(generation + 1);
		}

		//initialize a new GeodesicGrid with that generation. 
		grids[generation] = new GeodesicGrid(generation);
		return grids[generation];
	}

}geodesicGrids;


char FrontBitPos(int that)
{
	char out = 0;
	while (that != 0)
	{
		that >>= 1;
		out++;
	}
	return out - 1;
}

char LowestBitPos(int that)
{
	if (that == 0)
		return -1;
	char out = 0;
	while (!(that & 1))
	{
		that >>= 1;
		out++;
	}
	return out;
}

int TreeIndex2ArrayIndex(int that, unsigned short generation)
{
	if (that == 0) return 0;
	char FBP = FrontBitPos(that);
	char InvertFBP = generation - FBP;
	int NewLastBit = 1 << (InvertFBP - 1);
	int OldFrontBit = 1 << FBP;
	return ((that - OldFrontBit) << (InvertFBP)) + NewLastBit;
}

int ArrayIndex2TreeIndex(int that, unsigned short generation)
{
	if (that == 0) return 0;
	char LB = LowestBitPos(that) + 1;
	char InvertLB = generation - LB;
	return (that >> LB) + (1 << InvertLB);

}

TanPlane::TanPlane()
{

}

TanPlane::TanPlane(const Point3D&A, const Point3D&B, const Point3D&C)
{
	Point3D Mid = (C + B) / 2;
	ProjectionPoint = -Mid * 2;
	XVector = (Mid - A).Vector();
	YVector = (A - ProjectionPoint).Vector();
	ZVector = NormalVector(XVector, YVector);

	double Y2Mid = YVector.DistTo(Mid);
	double X2Mid = XVector.DistTo(Mid);
	SlicingPlaneVector = (YVector*X2Mid + XVector * -Y2Mid).Vector();
}

TanPlane::~TanPlane()
{

}

double TanPlane::TanOf(const Point3D&that) const
{
	Point3D Offset = that.Vector() - ProjectionPoint;
	double Xpart = XVector.DistTo(Offset);
	double Ypart = YVector.DistTo(Offset);
	return Ypart / Xpart;
}

Plane TanPlane::PlaneFromTan(double tan) const
{
	return Plane(ProjectionPoint, ProjectionPoint + XVector + YVector * tan, ProjectionPoint + ZVector);
}

Plane TanPlane::PlaneBase() const
{
	return Plane(ProjectionPoint, ProjectionPoint + YVector, ProjectionPoint + ZVector);
}

IcoTriangle::IcoTriangle()
{
	points = 0;
}

IcoTriangle::IcoTriangle(Point3D*p, long A, long B, long C)
{
	points = p; a = A; b = B; c = C;
	tanPlane[0] = TanPlane(points[a], points[b], points[c]);
	tanPlane[1] = TanPlane(points[b], points[c], points[a]);
	tanPlane[2] = TanPlane(points[c], points[a], points[b]);
}

IcoTriangle::~IcoTriangle()
{

}

Icosahedron::Icosahedron()
{
	Build();
}

Icosahedron::~Icosahedron()
{
}

char Icosahedron::SquareGridIndex(char IcoTriangleIndex)
{
	return icoTriangle[IcoTriangleIndex].pairedTriangleIndex;
}

bool Icosahedron::TriangleA(char IcoTriangleIndex)
{
	return icoTriangle[IcoTriangleIndex].pairedTriangleA;
}

Point3D Icosahedron::Corner(int index)
{
	if (index >= 12 || index < 0)
		return corner[0];
	return corner[index];
}

double Icosahedron::RibLength()
{
	return riblength;
}


void Icosahedron::Build()
{
	corner.resize(12);
	icoTriangle.resize(20);
	pair.resize(10);
	riblength = 4 / sqrt(10. + sqrt(20.));
	double A = riblength / 2;
	double B = sqrt(1 - Squared(riblength / 2));
	corner[0] = Point3D(A, B, 0);
	corner[1] = Point3D(B, 0, A);
	corner[2] = Point3D(0, A, B);
	corner[3] = Point3D(-A, B, 0);
	corner[4] = Point3D(B, 0, -A);
	corner[5] = Point3D(0, -A, B);
	corner[6] = Point3D(A, -B, 0);
	corner[7] = Point3D(-B, 0, A);
	corner[8] = Point3D(0, A, -B);
	corner[9] = Point3D(-A, -B, 0);
	corner[10] = Point3D(-B, 0, -A);
	corner[11] = Point3D(0, -A, -B);

	icoTriangle[0] = IcoTriangle(&corner[0], 1, 2, 0);
	icoTriangle[1] = IcoTriangle(&corner[0], 8, 4, 0);
	icoTriangle[2] = IcoTriangle(&corner[0], 6, 5, 1);
	icoTriangle[3] = IcoTriangle(&corner[0], 6, 4, 11);
	icoTriangle[4] = IcoTriangle(&corner[0], 2, 7, 3);
	icoTriangle[5] = IcoTriangle(&corner[0], 10, 8, 3);
	icoTriangle[6] = IcoTriangle(&corner[0], 9, 7, 5);
	icoTriangle[7] = IcoTriangle(&corner[0], 9, 11, 10);
	icoTriangle[8] = IcoTriangle(&corner[0], 0, 4, 1);
	icoTriangle[9] = IcoTriangle(&corner[0], 1, 4, 6);
	icoTriangle[10] = IcoTriangle(&corner[0], 3, 7, 10);
	icoTriangle[11] = IcoTriangle(&corner[0], 10, 7, 9);
	icoTriangle[12] = IcoTriangle(&corner[0], 2, 1, 5);
	icoTriangle[13] = IcoTriangle(&corner[0], 11, 4, 8);
	icoTriangle[14] = IcoTriangle(&corner[0], 5, 7, 2);
	icoTriangle[15] = IcoTriangle(&corner[0], 8, 10, 11);
	icoTriangle[16] = IcoTriangle(&corner[0], 3, 0, 2);
	icoTriangle[17] = IcoTriangle(&corner[0], 0, 3, 8);
	icoTriangle[18] = IcoTriangle(&corner[0], 5, 6, 9);
	icoTriangle[19] = IcoTriangle(&corner[0], 11, 9, 6);

	pair[0].A = 14;	pair[0].B = 12;
	pair[1].A = 0;	pair[1].B = 8;
	pair[2].A = 4;	pair[2].B = 16;
	pair[3].A = 17;	pair[3].B = 1;
	pair[4].A = 10;	pair[4].B = 5;
	pair[5].A = 15;	pair[5].B = 13;
	pair[6].A = 11;	pair[6].B = 7;
	pair[7].A = 19;	pair[7].B = 3;
	pair[8].A = 6;	pair[8].B = 18;
	pair[9].A = 2;	pair[9].B = 9;

	for (char n(0); n < 10; n++)
	{
		icoTriangle[pair[n].A].pairedTriangleIndex = n;
		icoTriangle[pair[n].B].pairedTriangleIndex = n;
		icoTriangle[pair[n].A].pairedTriangleA = true;
		icoTriangle[pair[n].B].pairedTriangleA = false;
	}

	for (char n(0); n < 20; n++)
		icoTriangle[n].nr = n;
	TPX = icoTriangle[0].tanPlane[0];
	TPY = icoTriangle[0].tanPlane[2];
	TPZ = icoTriangle[0].tanPlane[1];
}

char Icosahedron::IcoTriangleIndex(const Point3D&that) const
{
	Point3D Abs = that.Abs();//This coordinate does not contain negative values.

	char x = that.X == Abs.X ? 0 : 7;
	char y = that.Y == Abs.Y ? 0 : 7;
	char z = that.Z == Abs.Z ? 0 : 7;

	//Sending Abs coordinate to the tanplanes of section 0. 
	if (TPX.SlicingPlaneVector.DistTo(Abs) < 0)//overschrijdt eerste lijn. X gaat van - of + naar 0
		return (z & 1) | (y & 2) | 16;

	if (TPY.SlicingPlaneVector.DistTo(Abs) < 0)//overschrijdt tweede lijn. Y gaat van - of + naar 0
		return (z & 1) | (x & 2) | 12;

	if (TPZ.SlicingPlaneVector.DistTo(Abs) < 0)//overschrijdt derde lijn. Z gaat van - of + naar 0
		return (y & 1) | (x & 2) | 8;

	return (z & 1) | (y & 2) | (x & 4);//geen overschrijding, dus valt in 1 van de eerste 8 triangles. 
}

char Icosahedron::Direction(const Point3D&that) const
{
	Point3D Abs = that.Abs();//This coordinate does not contain negative values.

	char x = that.X == Abs.X ? 0 : 4;
	char y = that.Y == Abs.Y ? 0 : 2;
	char z = that.Z == Abs.Z ? 0 : 1;
	return x | y | z;
}

Segment::Segment() : IcoCorner(0), IcoRibMid(0), ArcTopSide(0), ArcTopFront(0), ProjectionPoint(0), Origin(0)
{
	TriangleLength = sqrt(Squared(Icosahedron().RibLength()) - Squared(Icosahedron().RibLength()*.5));
	IcoCorner.X = ProjectionPoint.X = -2. / 3. * TriangleLength;
	IcoRibMid.X = TriangleLength / 3.;
	IcoRibMid.Y = IcoCorner.Y = sqrt(1 - Squared(IcoCorner.X));
	ProjectionPoint.Y = IcoCorner.Y*-2.;
	ArcTopSide = IcoRibMid.Vector();
	ArcTopFront = Point3D(ArcTopSide.X / -2., ArcTopSide.Y, 0);
	IcoCorner2 = Point3D(IcoRibMid.X, IcoRibMid.Y, sqrt(1 - Squared(IcoRibMid.X) - Squared(IcoRibMid.Y)));
	TiltedCircle = Plane(IcoCorner2, IcoCorner);
	TopCircle = Plane(Point3D(0, 0, 1), 0);
}

Segment:: ~Segment()
{

}

double Segment::TanOf(const Point3D&that) const
{
	Point3D TanPoint = that - ProjectionPoint;
	return TanPoint.Y / TanPoint.X;
}

Point3D Segment::Rotate120(Point3D that) const
{
	that.Z = 1 - Squared(that.X) - Squared(that.Y);
	if (that.Z<0 && that.Z>-1E-8)
		that.Z = 0;
	else
		that.Z = sqrt(that.Z);

	return Point3D(-that.X / 2 - that.Z*sin60, that.Y, 0);
}

Plane Segment::PlaneFromTan(double that) const
{
	return Plane(ProjectionPoint, Point3D(1, that, 0) + ProjectionPoint, Point3D(1, that, 1) + ProjectionPoint);
}

double Segment::PrimaryTan(double oldtan) const
{
	Plane TanPlane = PlaneFromTan(oldtan);
	InfiniteLine ILine = TanPlane.Intersection(TopCircle);
	Point3D PointOnCircle = ILine.ReachDistance(1);
	PointOnCircle = Rotate120(PointOnCircle);
	return TanOf(PointOnCircle);
}

double Segment::SecondaryTan(double oldtan) const
{
	Plane TanPlane = PlaneFromTan(oldtan);
	InfiniteLine ILine = TanPlane.Intersection(TiltedCircle);
	Point3D PointOnCircle = ILine.ReachDistance(1);
	PointOnCircle = Rotate120(PointOnCircle);
	return TanOf(PointOnCircle);
}

const Icosahedron & MainIcosahedron()
{
	return icosahedron; 
}

const Segment & MainSegment()
{
	return segment; 
}

const TanArray & MainTanArray()
{
	return tanArray;
}

const GeodesicGrid* GetGeodesicGrid(unsigned int generation)
{
	return geodesicGrids.GetGrid(generation);
}

SectionRowOrColumn::SectionRowOrColumn()
{

}

SectionRowOrColumn::~SectionRowOrColumn()
{

}

void SectionRowOrColumn::Build(unsigned short generation, const TanPlane&tanPlane)
{
	int PointsPerRow = 1 << generation;
	slicingplanes.resize(PointsPerRow + 1);
	for (int n = 0; n < PointsPerRow; n++)
	{
		int ArrayIndex = TreeIndex2ArrayIndex(n, generation);
		slicingplanes[ArrayIndex] = tanPlane.PlaneFromTan(MainTanArray().Tangent[n]);
	}
	slicingplanes[PointsPerRow] = tanPlane.PlaneBase();
}

SquareGrid::SquareGrid()
{
	Parent = 0; 
}

SquareGrid:: ~SquareGrid()
{
	Parent = NULL;
}

void SquareGrid::Generate(GeodesicGrid*parent, char index /*0 to 9*/, unsigned short generation)
{
	Parent = parent;
	Pair = MainIcosahedron().pair[index];
	ARow.Build(generation, MainIcosahedron().icoTriangle[Pair.A].tanPlane[2]);
	ACol.Build(generation, MainIcosahedron().icoTriangle[Pair.A].tanPlane[0]);
	BRow.Build(generation, MainIcosahedron().icoTriangle[Pair.B].tanPlane[2]);
	BCol.Build(generation, MainIcosahedron().icoTriangle[Pair.B].tanPlane[0]);

	Pair = MainIcosahedron().pair[index];

	for (int row = 0; row < Parent->PointsPerRow; row++)
	{
		for (int column = 0; column < Parent->PointsPerRow; column++)
		{
			if (row + (Parent->PointsPerRow - column) <= (Parent->PointsPerRow))
			{
				Parent->points[Parent->PointIndex(index, row, column)] = ARow.slicingplanes[row]
					.Intersection(ACol.slicingplanes[Parent->PointsPerRow - column]).ReachDistance(1).CleanUp();
			}
			else
			{
				Parent->points[Parent->PointIndex(index, row, column)] = BRow.slicingplanes[Parent->PointsPerRow - row]
					.Intersection(BCol.slicingplanes[column]).ReachDistance(1).CleanUp();
			}
		}
	}
}

void MipMapIndices::UpScale(unsigned short parentGeneration, unsigned short childGeneration)
{
	for (int generation = parentGeneration; generation < childGeneration; generation++)
	{
		for (TriangleIndices&index : indices)
		{
			int a = UpScale(generation, index.a);
			int b = UpScale(generation, index.b);
			int c = UpScale(generation, index.c); 
			index.Set(a, b, c); 
		}
	}
}

int MipMapIndices::UpScale(unsigned short parentGeneration, int pointIndex)
{
	int dummyIndex = GenerationFactor(parentGeneration) * 10;
	if (pointIndex >= dummyIndex)
	{
		if (pointIndex == dummyIndex)
			return GenerationFactor(parentGeneration + 1)*10;
		else if (pointIndex == dummyIndex + 1)
			return GenerationFactor(parentGeneration + 1)*10 + 1;
		else
			throw CException("Out of bounds");
	}
	return GridCell(parentGeneration, pointIndex).Child(0).pointindex;
}

GeodesicGrid::GeodesicGrid()
{
 
}

GeodesicGrid::GeodesicGrid(unsigned short maxgeneration)
{
	if (tanArrayGeneration < maxgeneration + 1)
	{
		tanArrayGeneration = maxgeneration + 1; 
		tanArray = TanArray(tanArrayGeneration); 
	}
	MaxGeneration = maxgeneration;
	grids.resize(10);//making 10 grids. 
	//generatin 0 is the base icosahedron. For other generations, the following applies:
	//Ribs = 30 * 4^generation
	//Triangles = 20 * 4^generation
	//Gridcells = 10 * 4^generation
	//Punten = 10 * 4^generation + 2. 
	PointsPerSquare = GenerationFactor(maxgeneration);
	PointsPerRow = 1 << maxgeneration;
	points.resize(10 * PointsPerSquare + 2);
	indices.resize(20 * PointsPerSquare);
	for (size_t nr = 0; nr < grids.size(); ++nr)
	{
		grids[nr].Generate(this, (char) nr, maxgeneration);
	}
	points[PointsPerSquare * 10] = Icosahedron().Corner(7);
	points[PointsPerSquare * 10 + 1] = Icosahedron().Corner(4);

	//build the indices:
	int triangle(0);
	int a, b, c, d;

	for (char GridNr(0); GridNr < 10; GridNr++)
		for (int row(0); row < PointsPerRow; row++)
			for (int col(0); col < PointsPerRow; col++, triangle += 2)
			{
				a = PointIndex(GridNr, row, col);
				b = PointIndex(GridNr, row, col + 1);
				c = PointIndex(GridNr, row + 1, col + 1);
				d = PointIndex(GridNr, row + 1, col);
				indices[triangle].Set(a, b, c);
				indices[triangle + 1].Set(a, c, d);
			}


	//mipmapping
	mipMapIndices.resize(maxgeneration);
	MipMapIndices previous;
	previous.indices = indices; 
	for (int i = maxgeneration - 1; i >= 0; i--)
	{
		previous = InitializeMipMapIndices(i, previous.indices);
		mipMapIndices[i] = previous;
	}

	for (int i = 0; i < maxgeneration; i++)
	{
		mipMapIndices[i].UpScale(i, maxgeneration); 
	}

}

GeodesicGrid::~GeodesicGrid()
{

}

Point3D GeodesicGrid::Point(int that) const
{
	return points[that];
}

const std::vector<Point3D>& GeodesicGrid::PointList() const
{
	return points;
}

int GeodesicGrid::PointIndex(char squaregrid, int row, int column) const
{
	if (squaregrid & 1)	//odd
	{
		if (row == PointsPerRow)
		{
			if (column == 0)
				return Dummy2();

			squaregrid += 2;
			if (squaregrid == 11)
				squaregrid = 1;
			row = PointsPerRow - column;
			column = 0;
		}
		else if (column == PointsPerRow)
		{
			squaregrid += 1;
			if (squaregrid == 10)
				squaregrid = 0;
			column = 0;
		}
	}
	else //even
	{
		if (column == PointsPerRow)
		{
			if (row == 0)
				return Dummy1();

			squaregrid += 2;
			if (squaregrid == 10)
				squaregrid = 0;
			column = PointsPerRow - row;
			row = 0;
		}
		else if (column == PointsPerRow)
		{
			squaregrid += 1;
			row = 0;
		}
	}

	if (row > PointsPerRow || column > PointsPerRow)
	{
		throw new CException("Row or column index out of range");
	}

	return PointsPerSquare * squaregrid + row * PointsPerRow + column;
}

GridCell GeodesicGrid::Touch(Point3D position) const
{
	position.VectorMe();
	char icotriangleindex = Icosahedron().IcoTriangleIndex(position);//selects the triangle of the icosahedron.
	char squaregrid = Icosahedron().SquareGridIndex(icotriangleindex);
	bool TriangleA = Icosahedron().TriangleA(icotriangleindex);

	const IcoTriangle*icoTriangle = &MainIcosahedron().icoTriangle[icotriangleindex];

	double TanRow = icoTriangle->tanPlane[2].TanOf(position);
	double TanCol = icoTriangle->tanPlane[0].TanOf(position);
	
	unsigned int maxRowCol = 1 << MaxGeneration;
	int rowIndex = MainTanArray().TanIndex(TanRow, maxRowCol, true);
	int colIndex = MainTanArray().TanIndex(TanCol, maxRowCol, true);
	
	if (TriangleA)
		colIndex = maxRowCol - colIndex - 1;
	else
		rowIndex = maxRowCol - rowIndex - 1;

	return ::GridCell(*this, squaregrid, rowIndex, colIndex);
}

int GeodesicGrid::Dummy1() const
{
	return (int) (points.size() - 2);
}

int GeodesicGrid::Dummy2() const
{
	return (int) (points.size() - 1);
}

int GeodesicGrid::ToChildGeneration(int index, unsigned short parentGeneration, unsigned short childGeneration)const
{
	const GeodesicGrid*parentGrid = GetGeodesicGrid(parentGeneration);
	if (index == parentGrid->Dummy1())
		return GetGeodesicGrid(childGeneration)->Dummy1(); 
	if (index == parentGrid->Dummy2())
		return GetGeodesicGrid(childGeneration)->Dummy2();
	::GridCell gridCell = parentGrid->GridCell(index); 
	int row = gridCell.row;
	int column = gridCell.column;

	for (int generation = childGeneration; generation < parentGeneration; generation++)
	{
		row *= 2;
		column *= 2; 
	}

	return ::GridCell(gridCell.squaregrid, row, column, parentGeneration).pointindex; 
}


int GeodesicGrid::PointIndex(Point3D position) const
{
	return Touch(position).pointindex;
}

const std::vector<SquareGrid>& GeodesicGrid::Grids() const
{
	return grids;
}

const std::vector<TriangleIndices>& GeodesicGrid::GetTriangleIndices() const
{
	return indices;
}

unsigned short GeodesicGrid::Generation() const
{
	return MaxGeneration;
}

GridCell GeodesicGrid::GridCell(int index) const
{
	return ::GridCell (Generation(),index);
	/*
	gridcell.squaregrid = (char)(index / PointsPerSquare);
	unsigned long rem = index % PointsPerSquare;
	gridcell.row = rem / PointsPerRow;
	gridcell.column = rem % PointsPerRow;
	gridcell.InitializePointIndex();
	return gridcell;*/
}

const MipMapIndices & GeodesicGrid::GetMipMapIndices(unsigned short mipMapGeneration) const
{
	return mipMapIndices[mipMapGeneration];
}

const MipMapIndices GeodesicGrid::InitializeMipMapIndices(unsigned short mipMapGeneration, const std::vector<TriangleIndices>&parentIndices) const
{
	std::vector<TriangleIndices> indices;
	int sourceGeneration = mipMapGeneration + 1; 
	for (const TriangleIndices&index : parentIndices)
	{
		::GridCell a(sourceGeneration, index.a);
		//if the first has an even row and an even column, upscale the triangle.
		if (a.IsFirstChild())
		{
			::GridCell b(sourceGeneration, index.b);
			::GridCell c(sourceGeneration, index.c);
			TriangleIndices index;

			::GridCell parentA = a.Parent(); 

			//a: 0 0
			//b: 0 1
			//c: 1 1
			//d: 1 0 

			if (b.row == a.row)
			{
				//we are having triangle a, b, c
				::GridCell parentB = parentA.Neighbor(1);
				::GridCell parentC = parentA.Neighbor(5);
				index.Set(parentA.pointindex, parentB.pointindex, parentC.pointindex);
			}
			else
			{
				//we are having triangle a, c, d

				::GridCell parentC = parentA.Neighbor(5);
				::GridCell parentD = parentA.Neighbor(2);
				index.Set(parentA.pointindex, parentC.pointindex, parentD.pointindex);
			}

			indices.push_back(index); 
		}
	}
	 
	MipMapIndices mipMap;
	mipMap.indices = indices; 

	return mipMap; 
}

TanArray::TanArray(int generation) :Generation(generation)
{
	Tangent.resize((int)2 << generation);
	Tangent[0] = Segment().TanOf(Segment().IcoRibMid);//the first tan
	Tangent[1] = Segment().TanOf(Segment().ArcTopFront);
	unsigned int curgenbit(1);
	double CurPriTan, CurSecTan;
	for (unsigned int t(1); t < ((unsigned int)1) << generation; t++)
	{
		if (t >= curgenbit)
			curgenbit <<= 1;
		
		CurPriTan = Segment().PrimaryTan(Tangent[t]);
		CurSecTan = Segment().SecondaryTan(CurPriTan);
		int PIndex = TanIndex(CurPriTan, curgenbit, false);
		int CIndex = TanIndex(CurSecTan, curgenbit, false);
		Tangent[PIndex] = CurPriTan;
		Tangent[CIndex] = CurSecTan;
	}
}

TanArray::~TanArray()
{}

int TanArray::TanIndex(double tan, int generationbit, bool removegenerationbit) const
{
	int target = generationbit;
	int current = 1;
	while (target > current)
	{

		if (tan >= Tangent[current])
		{
			current = (current << 1) + 1;
		}
		else
		{
			current <<= 1;
		}
	}

	if (removegenerationbit)
		return current - generationbit;
	return current;
}

GridCell::GridCell() : row(0), column(0), pointindex(0), squaregrid(0), CornerDuplicateWarning(false), generation(0)
{
}

GridCell::GridCell(unsigned short generation) : row(0), column(0), pointindex(0), squaregrid(0), CornerDuplicateWarning(false)
{
	this->generation = generation;
}

GridCell::GridCell(const GeodesicGrid&grid) : row(0), column(0), pointindex(0), squaregrid(0), CornerDuplicateWarning(false)
{
	generation = grid.Generation();
}

GridCell::GridCell(const GeodesicGrid&grid, const ::Point3D&position)
{
	*this = grid.Touch(position);
}

GridCell::GridCell(const GeodesicGrid&grid, char squareGrid, int Row, int Column)
	: squaregrid(squareGrid), row(Row), column(Column), CornerDuplicateWarning(false)
{
	generation = grid.Generation();
	InitializePointIndex();
}

GridCell::GridCell(char squareGrid, int Row, int Column, unsigned short Generation)
	: squaregrid(squareGrid), row(Row), column(Column), generation(Generation), CornerDuplicateWarning(false)
{
	InitializePointIndex();
}

GridCell::GridCell(unsigned short Generation, int index)
{
	generation = Generation; 

	squaregrid = (char)(index / PointsPerSquare());
	unsigned long rem = index % PointsPerSquare();
	row = rem / PointsPerRow();
	column = rem % PointsPerRow();
	pointindex = index; 
}

int GridCell::PointsPerSquare(unsigned short generation) const
{
	return (1 << (generation * 2));
}

int GridCell::PointsPerSquare() const
{
	return PointsPerSquare(generation); 
}

int GridCell::PointsPerRow(unsigned short generation) const
{
	return 1 << generation;
}

int GridCell::PointsPerRow() const
{
	return PointsPerRow(generation);
}

int GridCell::InitializePointIndex()
{
	int pointsPerSquare = PointsPerSquare();
	int pointsPerRow = PointsPerRow();

	if (squaregrid & 1)	//odd
	{
		if (row == pointsPerRow)
		{
			if (column == 0)
				return 10 * pointsPerSquare + 2; //dummy2

			squaregrid += 2;
			if (squaregrid == 11)
				squaregrid = 1;
			row = pointsPerRow - column;
			column = 0;
		}
		else if (column == pointsPerRow)
		{
			squaregrid += 1;
			if (squaregrid == 10)
				squaregrid = 0;
			column = 0;
		}
	}
	else //even
	{
		if (column == pointsPerRow)
		{
			if (row == 0)
				return 10 * pointsPerSquare + 1; //dummy1

			squaregrid += 2;
			if (squaregrid == 10)
				squaregrid = 0;
			column = pointsPerRow - row;
			row = 0;
		}
		else if (column == pointsPerRow)
		{
			squaregrid += 1;
			row = 0;
		}
	}

	if (row > pointsPerRow || column > pointsPerRow)
	{
		throw new CException("Row or column index out of range");
	}

	return pointindex = pointsPerSquare * squaregrid + row * pointsPerRow + column;

}

//0 up, 1 right, 2 down, 3 left, 4 upleft, 5 downright. 
GridCell GridCell::Neighbor(char index) const
{
	GridCell neighbor = *this;
	int Bound = (1 << generation) - 1;

	//see document geodesic grid 20nov2013 figure 10. 
	//document is updated in april 2015
	//giving the neighbors of a geodesic point. 

	if (squaregrid == 10)
	{
		//Dummycell 
		if (column == 0)//dummycell1
		{
			neighbor.column = Bound;
			neighbor.row = 0;
			neighbor.squaregrid = index * 2;
			if (index == 5)
			{
				neighbor.squaregrid = 0;
				neighbor.CornerDuplicateWarning = true;
			}
			else if (index > 5)
			{
				throw std::domain_error("GRIDCELL::Neighbor value must be between 0 and 5");
			}
		}
		else//dummycell2
		{
			neighbor.column = 0;
			neighbor.row = Bound;
			neighbor.squaregrid = index * 2 + 1;
			if (index == 5)
			{
				neighbor.squaregrid = 1;
				neighbor.CornerDuplicateWarning = true;
			}
			else if (index > 5)
			{
				throw std::domain_error("GRIDCELL::Neighbor value must be between 0 and 5");
			}
		}
		neighbor.generation = generation; 
		neighbor.InitializePointIndex(); 
		return neighbor;
	}

	bool odd = (squaregrid & 1);

	switch (index)
	{
	case 0://0 up: row -1
		if (row == 0)
		{
			//change squaregrid. 
			if (odd)
			{
				neighbor.squaregrid--;
				neighbor.row = Bound;
			}
			else
			{
				if (squaregrid == 0)
					neighbor.squaregrid = 8;
				else
					neighbor.squaregrid -= 2;
				if (column == 0)
				{
					neighbor.CornerDuplicateWarning = true;
					if (neighbor.squaregrid == 0)
						neighbor.squaregrid = 9;
					else
						neighbor.squaregrid--;
				}
				else
				{
					neighbor.row = Bound - column + 1;
				}
				neighbor.column = Bound;
			}
		}
		else
			neighbor.row--;
		break;
	case 1://1 right: column +1
		if (column == Bound)
		{
			//change squaregrid;
			if (odd)
			{
				if (squaregrid == 9)
					neighbor.squaregrid = 0;
				else
					neighbor.squaregrid++;
				neighbor.column = 0;
				//complete
			}
			else
			{
				if (row == 0)
				{
					return DummyCell1(generation);
				}
				if (squaregrid == 8)
					neighbor.squaregrid = 0;
				else
					neighbor.squaregrid += 2;

				neighbor.row = 0;
				neighbor.column = Bound - row + 1;

			}
		}
		else
			neighbor.column++;
		break;
	case 2://2 down: row+1
		if (row == Bound)
		{
			//change squaregrid
			if (odd)
			{
				if (column == 0)
					return DummyCell2(generation);
				if (squaregrid == 9)
					neighbor.squaregrid = 1;
				else
					neighbor.squaregrid += 2;
				neighbor.column = 0;
				neighbor.row = Bound + 1 - column;
			}
			else
			{
				neighbor.squaregrid++;
				neighbor.row = 0;
			}
		}
		else
			neighbor.row++;

		break;
	case 3://3 left: column -1
		if (column == 0)
		{
			//change squaregrid
			if (odd)
			{
				if (row == 0)
				{
					neighbor.CornerDuplicateWarning = true;
					neighbor.squaregrid--;
				}
				else
				{
					if (squaregrid == 1)
						neighbor.squaregrid = 9;
					else
						neighbor.squaregrid -= 2;
					neighbor.column = Bound + 1 - row;
				}
				neighbor.row = Bound;
			}
			else
			{
				if (squaregrid == 0)
					neighbor.squaregrid = 9;
				else
					neighbor.squaregrid--;
				neighbor.column = Bound;
			}
		}
		else
			neighbor.column--;
		break;
	case 4: //upleft
		if (odd)
		{
			if (column == 0)
			{
				if (row == 0)
					neighbor = Neighbor(0).Neighbor(3);
				else
					neighbor = Neighbor(3).Neighbor(3);
				return neighbor;
			}
			else
			{
				neighbor = Neighbor(0).Neighbor(3);
				return neighbor;
			}
		}
		else
		{
			if (row == 0)
			{
				if (column == 0)
					neighbor = Neighbor(3).Neighbor(0);
				else
					neighbor = Neighbor(0).Neighbor(0);

				return neighbor;
			}
			else
			{
				neighbor = Neighbor(3).Neighbor(0);
				return neighbor;
			}

		}
		break;
	case 5: //downright
		if (odd)
		{
			neighbor = Neighbor(1).Neighbor(2);
			return neighbor;
		}
		else
		{
			neighbor = Neighbor(2).Neighbor(1);
			return neighbor;
		}
		break;
	default:
		throw std::domain_error("GRIDCELL::Neighbor value must be between 0 and 5");
	}
	neighbor.generation = generation; 
	neighbor.InitializePointIndex();
	return neighbor;
}

GridCell GridCell::Child(char index) const
{
	GridCell child = *this;
	child.generation++;
	child.row <<= 1;
	child.column <<= 1;
	if (index & 1)
		child.column++;
	if (index & 2)
		child.row++;
	child.InitializePointIndex();
	return child;
}

GridCell GridCell::Parent() const
{
	if (generation == 0)
		throw std::domain_error("generation cannot be negative. 0 is the root parent: an icosahedron cell");
	GridCell parent = *this;
	if (IsDummy())
	{
		if (column == 1)
			return DummyCell2(generation - 1);
		return DummyCell1(generation - 1);
	}
	parent.generation--;
	parent.row >>= 1;
	parent.column >>= 1;
	parent.InitializePointIndex(); 
	return parent;
}

Point3D GridCell::Point3D() const
{
	return GetGeodesicGrid(generation)->Point(pointindex); 
}

bool GridCell::IsDummy() const
{
	return squaregrid == 10; 
}

bool GridCell::IsFirstChild() const
{
	if (IsDummy())
		return true; 
	return (column & 1) == 0 && (row & 1) == 0;
}

GridCell DummyCell1(unsigned short generation)
{
	GridCell Dummy(generation);
	Dummy.squaregrid = 10;
	Dummy.pointindex = 10 * GenerationFactor(generation);

	return Dummy; 
}

GridCell DummyCell2(unsigned short generation)
{
	GridCell Dummy(generation);
	Dummy.squaregrid = 10;
	Dummy.column = 1;
	Dummy.pointindex = 10 * GenerationFactor(generation) + 1;
	return Dummy;
}

GridCellIterator::GridCellIterator()
{
	index = 0;
	Parent = NULL;
}

GridCellIterator::GridCellIterator(GridCellIterator*parent)
{
	Parent = parent;
	Current = Parent->Current.Neighbor(parent->index++);
	base = Parent->base;
	index = 0;
}

void GridCellEnumerator::Setup(const ::GridCell&that)
{
	generation = that.generation; 
	current = new GridCellIterator;
	current->Parent = NULL;
	current->base = this;
	current->Current = that;
	current->index = 0;
	int arraysize = ArraySizeForGeneration(that.generation);
	UseMask.resize(arraysize);
	ProcessedMask.resize(arraysize);
	std::fill(UseMask.begin(), UseMask.end(), false);
	std::fill(ProcessedMask.begin(), ProcessedMask.end(), false);
	Init = false;
	CurrentIsValid = true;
}

void GridCellEnumerator::StepBack()//sets current iterator back to a valid parent or to NULL. 
{
	do
	{
		GridCellIterator*stepback = current->Parent;
		delete current;
		current = stepback;
		if (current == NULL)
			return;
	} while (current->index == 6);
}

GridCellEnumerator::GridCellEnumerator(int index, unsigned short generation)
{
	Setup(GetGeodesicGrid(generation)->GridCell(index));
}

GridCellEnumerator::GridCellEnumerator(const ::Point3D&that, unsigned short generation)
{
	Setup(::GridCell(*GetGeodesicGrid(generation), that));
}

GridCellEnumerator::GridCellEnumerator(const ::GridCell&gridCell)
{
	Setup(gridCell);
}

GridCellEnumerator::GridCellEnumerator()
{
	current = NULL;
}

GridCellEnumerator::~GridCellEnumerator()
{
	delete current;
}

bool GridCellEnumerator::MoveNext()//goes to next gridcell. 
{
	if (current == NULL)
		return false;
	if (!Init)
	{
		Init = true;
		return true;
	}
	ProcessedMask[current->Current.pointindex] = true;
	if (CurrentIsValid)
		UseMask[current->Current.pointindex] = true;
	else
	{
		StepBack();
	}

	bool skip;
	do
	{
		skip = false;
		if (current == NULL)
			return false;
		current = new GridCellIterator(current);//getting a neighbor. 
		if (current->Current.CornerDuplicateWarning || ProcessedMask[current->Current.pointindex])
		{
			//point has already been processed. skipping.
			StepBack();
			skip = true;
		}
	} while (skip);
	CurrentIsValid = true;
	return true;
}

::GridCell GridCellEnumerator::GridCell() const
{
	return current->Current;
}

Point3D GridCellEnumerator::Point3D() const
{
	return GridCell().Point3D();
}

int GridCellEnumerator::Index() const
{
	return GridCell().pointindex;
}

void GridCellEnumerator::SetFalse()
{
	CurrentIsValid = false;
}
