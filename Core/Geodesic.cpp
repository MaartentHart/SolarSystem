//Copyright Maarten 't Hart 2013
#include "stdafx.h"
#include "Geodesic.h"

const double sin60 = sqrt(3. / 4.);
static const Icosahedron icosahedron;
Segment segment;
TanArray tanArray(11);
int tanArrayGeneration = 11; 
std::vector<GeodesicGrid*> geodesicGrids;

char FrontBitPos(unsigned long that)
{
	char out = 0;
	while (that != 0)
	{
		that >>= 1;
		out++;
	}
	return out - 1;
}

char LowestBitPos(unsigned long that)
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

unsigned long TreeIndex2ArrayIndex(unsigned long that, unsigned short generation)
{
	if (that == 0) return 0;
	char FBP = FrontBitPos(that);
	char InvertFBP = generation - FBP;
	unsigned long NewLastBit = 1 << (InvertFBP - 1);
	unsigned long OldFrontBit = 1 << FBP;
	return ((that - OldFrontBit) << (InvertFBP)) + NewLastBit;
}

unsigned long ArrayIndex2TreeIndex(unsigned long that, unsigned short generation)
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

const GeodesicGrid & GetGeodesicGrid(unsigned int generation)
{
	if (geodesicGrids.size() > generation)
		if (geodesicGrids[generation] != NULL)
			return *geodesicGrids[generation];
	//initialize a new GeodesicGrid with that generation. 
	geodesicGrids[generation] = &GeodesicGrid(generation);
	return *geodesicGrids[generation];
}

SectionRowOrColumn::SectionRowOrColumn()
{

}

SectionRowOrColumn::~SectionRowOrColumn()
{

}

void SectionRowOrColumn::Build(unsigned short generation, const TanPlane&tanPlane)
{
	unsigned long PointsPerRow = 1 << generation;
	slicingplanes.resize(PointsPerRow + 1);
	for (unsigned long n = 0; n < PointsPerRow; n++)
	{
		unsigned long ArrayIndex = TreeIndex2ArrayIndex(n, generation);
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

	for (unsigned long row = 0; row < Parent->PointsPerRow; row++)
	{
		for (unsigned long column = 0; column < Parent->PointsPerRow; column++)
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
	unsigned long triangle(0);
	unsigned long a, b, c, d;

	for (char GridNr(0); GridNr < 10; GridNr++)
		for (unsigned long row(0); row < PointsPerRow; row++)
			for (unsigned long col(0); col < PointsPerRow; col++, triangle += 2)
			{
				a = PointIndex(GridNr, row, col);
				b = PointIndex(GridNr, row, col + 1);
				c = PointIndex(GridNr, row + 1, col + 1);
				d = PointIndex(GridNr, row + 1, col);
				indices[triangle].Set(a, b, c);
				indices[triangle + 1].Set(a, c, d);
			}

	if (geodesicGrids.size()<maxgeneration)
	{
		int prevSize = (int) geodesicGrids.size();
		geodesicGrids.resize(maxgeneration + 1);
		for (int i = prevSize; i < maxgeneration + 1; i++)
			geodesicGrids[i] = 0;
	}

	if (geodesicGrids[maxgeneration] == NULL)
		geodesicGrids[maxgeneration] = this; 
}

GeodesicGrid::~GeodesicGrid()
{

}

Point3D GeodesicGrid::Point(unsigned long that) const
{
	return points[that];
}

const std::vector<Point3D>& GeodesicGrid::PointList() const
{
	return points;
}

unsigned long GeodesicGrid::PointIndex(char squaregrid, unsigned long row, unsigned long column) const
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
	unsigned long rowIndex = MainTanArray().TanIndex(TanRow, maxRowCol, true);
	unsigned long colIndex = MainTanArray().TanIndex(TanCol, maxRowCol, true);
	
	if (TriangleA)
		colIndex = maxRowCol - colIndex - 1;
	else
		rowIndex = maxRowCol - rowIndex - 1;

	return ::GridCell(*this, squaregrid, rowIndex, colIndex);
}

unsigned long GeodesicGrid::Dummy1() const
{
	return (unsigned long) (points.size() - 2);
}

unsigned long GeodesicGrid::Dummy2() const
{
	return (unsigned long) (points.size() - 1);
}

unsigned long GeodesicGrid::PointIndex(Point3D position) const
{
	return Touch(position).pointindex;
}

const std::vector<SquareGrid>& GeodesicGrid::Grids() const
{
	return grids;
}

const std::vector<TriangleIndices>& GeodesicGrid::TriangleIndices() const
{
	return indices;
}

unsigned short GeodesicGrid::Generation() const
{
	return MaxGeneration;
}

GridCell GeodesicGrid::GridCell(unsigned long index) const
{
	::GridCell gridcell(Generation());
	gridcell.squaregrid = (char)(index / PointsPerSquare);
	unsigned long rem = index % PointsPerSquare;
	gridcell.row = rem / PointsPerRow;
	gridcell.column = rem % PointsPerRow;
	gridcell.PointIndex();
	return gridcell;
}

TanArray::TanArray(int generation) :Generation(generation)
{
	Tangent.resize((unsigned long)2 << generation);
	Tangent[0] = Segment().TanOf(Segment().IcoRibMid);//the first tan
	Tangent[1] = Segment().TanOf(Segment().ArcTopFront);
	unsigned int curgenbit(1);
	double CurPriTan, CurSecTan;
	for (unsigned long t(1); t < ((unsigned long)1) << generation; t++)
	{
		if (t >= curgenbit)
			curgenbit <<= 1;
		
		CurPriTan = Segment().PrimaryTan(Tangent[t]);
		CurSecTan = Segment().SecondaryTan(CurPriTan);
		unsigned long PIndex = TanIndex(CurPriTan, curgenbit, false);
		unsigned long CIndex = TanIndex(CurSecTan, curgenbit, false);
		Tangent[PIndex] = CurPriTan;
		Tangent[CIndex] = CurSecTan;
	}
}

TanArray::~TanArray()
{}

unsigned long TanArray::TanIndex(double tan, int generationbit, bool removegenerationbit) const
{
	unsigned long target = generationbit;
	unsigned long current = 1;
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

GridCell::GridCell(const GeodesicGrid&grid, char squareGrid, unsigned long Row, unsigned long Column)
	: squaregrid(squareGrid), row(Row), column(Column), CornerDuplicateWarning(false)
{
	generation = grid.Generation();
	PointIndex(grid);
}

GridCell::GridCell(char squareGrid, unsigned long Row, unsigned long Column, unsigned short Generation)
	: squaregrid(squareGrid), row(Row), column(Column), generation(Generation), CornerDuplicateWarning(false)
{
	PointIndex(GetGeodesicGrid(Generation));
}

unsigned long GridCell::PointIndex()
{
	return PointIndex(GetGeodesicGrid(generation));
}

unsigned long GridCell::PointIndex(const GeodesicGrid&grid)
{
	if (grid.Generation() == generation)
		return pointindex = grid.PointIndex(squaregrid, row, column);
	else if (grid.Generation() > generation)
	{
		unsigned short gendif = grid.Generation() - generation;
		return pointindex = grid.PointIndex(squaregrid, row << gendif, column << gendif);//needs testing
	}
	else
	{
		unsigned short gendif = generation - grid.Generation();
		return pointindex = grid.PointIndex(squaregrid, row >> gendif, column >> gendif);//needs testing
	}
}

GridCell GridCell::Neighbor(char index) const
{
	GridCell neighbor = *this;
	unsigned long Bound = (1 << generation) - 1;

	//see document geodesic grid 20nov2013 figure 10. 
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
		neighbor.PointIndex(GetGeodesicGrid(generation));
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

	neighbor.PointIndex(GetGeodesicGrid(generation));
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
	child.PointIndex();
	return child;//not tested.
}

GridCell GridCell::Parent() const
{
	if (generation == 0)
		throw std::domain_error("generation cannot be negative. 0 is the root parent: an icosahedron cell");
	GridCell parent = *this;
	parent.generation--;
	parent.row >>= 1;
	parent.column >>= 1;
	return parent;//not tested. 
}

Point3D GridCell::Point3D() const
{
	return GetGeodesicGrid(generation).Point(pointindex); 
}

GridCell DummyCell1(unsigned short generation)
{
	GridCell Dummy(generation);
	Dummy.squaregrid = 10;
	Dummy.PointIndex();
	return Dummy;
}

GridCell DummyCell2(unsigned short generation)
{
	GridCell Dummy(generation);
	Dummy.squaregrid = 10;
	Dummy.column = 1;
	Dummy.PointIndex();
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
	unsigned long arraysize = ArraySizeForGeneration(that.generation);
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

GridCellEnumerator::GridCellEnumerator(unsigned long index, unsigned short generation)
{
	Setup(GetGeodesicGrid(generation).GridCell(index));
}

GridCellEnumerator::GridCellEnumerator(const ::Point3D&that, unsigned short generation)
{
	Setup(::GridCell(GetGeodesicGrid(generation), that));
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

unsigned long GridCellEnumerator::Index() const
{
	return GridCell().pointindex;
}

void GridCellEnumerator::SetFalse()
{
	CurrentIsValid = false;
}
