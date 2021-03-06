﻿using CGNamespaces.ExtraFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F_Point = System.Windows.Point;

namespace ChaosGame {
    class GameManager {

        #region Variables controlling the rules of the game. This will be removed.
        public bool rule1 = false; //Vertex can't be chosen twice in a row.
        public bool rule2 = false; //Vertex can't be n position from last vertex.
        public int rule2val = 0; //Position n for this rule.
        public bool rule3 = false;
        #endregion
        #region Game creation variables and methods
        //Internal tools
        private Random rng = new Random();
        /* totalWeight can be -1, -2, 0 or a positive integer:
         * -1: Vertices have different weights, and this will become the sum of all of them.
         * -2: All vertices have equal weight and thus it'll become 0.
         * 0: All vertices have a weight of 1.*/
        private int totalWeight = -1;
        private bool checkWeight = true;
        private Point lastPoint = new Point(-1, -1); //-1, -1 represents a null point.
        private Point nullPoint = new Point(-1, -1); //to compare points to this "null"
        /*The size of this will be defined later by the rules in List<Rules> Rules.
         * To avoid unnecessary calculations, this array only holds n previous vertices,
         * where n is the highest number of previous vertices needed by any rule.
         *** The index [0] is the most recent vertex. When a new vertex is added, all other
         * vertices are pushed one position backwards (from 0 to 1, etc). If the array is
         * of size 0, it will not store anything.*/
        private int[] vertexCache;
        //private Vertex[] lastChosenVertices = null;

        //Visual variables:
        public Bitmap MemoryBitmap { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color MemoryBitmapBGColor { get; private set; }

        public int VertexSize { get; private set; }
        public Color VertexColor { get; private set; }
        public bool KeepVerticesOnTop { get; private set; }

        public int GpSize { get; private set; }
        public Color GpColor { get; private set; }

        //Rules variables:
        public List<Vertex> Vertices { get; private set; }
        public bool DrawSides { get; private set; }
        public Color SideColor { get; private set; }
        public Point Seed { get; private set; }
        public float CompressionRatio { get; private set; } //Todo: change to decimal IF it's not any slower.
        public float Rotation { get; private set; }
        public List<Rule> Rules { get; private set; }
        public int IterationsToIgnore { get; private set; }

        //IFS variables:
        public bool UseIfs { get; private set; }
        public List<IFSFormula> IfsFormulas { get; private set; }
        public float IfsMagnificationX { get; private set; }
        public float IfsMagnificationY { get; private set; }
        public Point CenterPoint { get; private set; }
        public bool DrawAxes { get; private set; }
        private float ifsWeight;
        private F_Point lastIfsPoint;

        public GameManager() {
            Height = 700;
            Width = 700;
            MemoryBitmapBGColor = Color.Transparent;

            VertexSize = 15;
            VertexColor = Color.Red;
            KeepVerticesOnTop = true;
             
            GpSize = 2;
            GpColor = Color.Black;
            Vertices = new List<Vertex>() {
                new Vertex(350, 100),
                new Vertex(100, 600),
                new Vertex(600, 600)
            };
            DrawSides = false;
            SideColor = Color.FromArgb(255, 192, 0);

            UseIfs = false;

            CompressionRatio = 2.0f;
            Rotation = 0.0f;
            Rules = new List<Rule>();
            IterationsToIgnore = 0;
        }

        public void AssignVisualVariablesAndLoadImage(string filePath, int vertexSize, Color vertexColor, bool keepVerticesOnTop, int gpSize, Color gpColor) {
            VertexSize = vertexSize;
            VertexColor = vertexColor;
            KeepVerticesOnTop = keepVerticesOnTop;
            GpSize = gpSize;
            GpColor = gpColor;

            LoadImageFromFile(filePath);
            Width = MemoryBitmap.Width;
            Height = MemoryBitmap.Height;
        }

        public void AssignVisualVariables(int width, int height, Color bitmapBgColor, int vertexSize, Color vertexColor, bool keepVerticesOnTop, int gpSize, Color gpColor) {
            Width = width;
            Height = height;
            MemoryBitmapBGColor = bitmapBgColor;

            VertexSize = vertexSize;
            VertexColor = vertexColor;
            KeepVerticesOnTop = keepVerticesOnTop;
            GpSize = gpSize;
            GpColor = gpColor;

            GenerateBitmap();
        }

        public void AssignRulesVariables(List<Vertex> vertices, bool drawSides, Color sidedColor, float compressionRatio, float rotation, List<Rule> rules, int iterationsToIgnore) {
            UseIfs = false;

            Vertices = ReplicateList(vertices);
            DrawSides = drawSides;
            SideColor = sidedColor;

            CompressionRatio = compressionRatio;
            Rotation = rotation;
            Rules = rules;
            IterationsToIgnore = iterationsToIgnore;
            //Assign the correct compression, rotation and weight to each individual vertex based on their values.
            RecalculateVerticesCompressionRatio();
            RecalculateVerticesRotation();
            RecalculateVerticesWeight();

            int requiredCache = 0;
            foreach(Rule r in Rules) {
                if (r.RequiredVertexCache > requiredCache) requiredCache = r.RequiredVertexCache;
            }
            vertexCache = new int[requiredCache + 1];
            for(int i = 0; i < vertexCache.Length; i++) vertexCache[i] = -1;
        }

        public void AssignIFSVariables(List<IFSFormula> ifsFormulas, Point centerPoint, float magnificationX, float magnificationY, bool drawAxes, int iterationsToIgnore) {
            UseIfs = true;
            IfsFormulas = ReplicateList(ifsFormulas);
            IfsMagnificationX = magnificationX;
            IfsMagnificationY = magnificationY;
            CenterPoint = centerPoint;
            DrawAxes = drawAxes;
            IterationsToIgnore = iterationsToIgnore;

            CalculateIFSWeight();
            Vertices = null;

            if (DrawAxes) DrawCoordinateAxes();
        }

        public void AssignSeed(Point seed) {
            Seed = seed;
        }

        private void GenerateBitmap() {
            MemoryBitmap = new Bitmap(Width, Height); //Todo: if the dimensions are too big, the program will throw an InvalidArgument exception.
            if (MemoryBitmapBGColor.A != 0) {
                for (int x = 0; x < MemoryBitmap.Width; x++) {
                    for (int y = 0; y < MemoryBitmap.Height; y++) MemoryBitmap.SetPixel(x, y, MemoryBitmapBGColor);
                }
            }
        }

        public void ClearBitmap() => GenerateBitmap();
        #endregion

        #region Public methods to interact with the game from an external class
        public Bitmap GetPreviewBitmap(List<Vertex> vertices, float zoom, bool drawSides, Color sideColor) {
            Bitmap previewBM = (Bitmap)MemoryBitmap.Clone();

            DrawSides = drawSides;
            SideColor = sideColor;
            DrawVertices(vertices, previewBM);
            return previewBM;
        }

        public Bitmap GetPreviewIFSBitmap(Point centerPoint, float zoom) {
            Bitmap previewBM = (Bitmap)MemoryBitmap.Clone();
            
            DrawCoordinateAxes(centerPoint, previewBM);
            return previewBM;
        }

        public Point GetAutomaticSeed() {
            if (UseIfs) return new Point(0, 0);

            RecalculateVerticesCompressionRatio();
            RecalculateVerticesRotation();
            TryGetNextPoint(Vertices[0].Point, 1, out Point nextPoint);
            return nextPoint;
        }
        //At this moment, there is no option to highlight the seed, so the method with no parameters is the only one used by the form.
        public void DrawSeed() => DrawSeed(false, Color.Transparent);
        public void DrawSeed(bool highlightGeneration, Color highlightColor) {
            Color color = (highlightGeneration) ? highlightColor : GpColor;
            if (IterationsToIgnore == 0) {
                DrawPoint(Seed, GpSize, GpColor);
            }
            else {
                IterationsToIgnore--;
            }

            if (!UseIfs) lastPoint = Seed;
            else lastIfsPoint = new F_Point(Seed.X, Seed.Y);
        }

        public void DrawNextFrame(int iterations) => DrawNextFrame(iterations, false, Color.Transparent);
        public void DrawNextFrame(int iterations, bool highlightGeneration, Color highlightColor) {
            if (lastPoint != nullPoint && IterationsToIgnore == 0) {
                DrawPoint(lastPoint, GpSize, GpColor);
            }
            //ClearBitmap();
            //foreach (Vertex v in Vertices) v.rotation += 1.0f;

            Vertex chosenVertex = null;

            for (int i = 0; i < iterations; i++) {
                //Not using IFS ? Regular iteration : IFS iteration.
                lastPoint = (!UseIfs) ? DoNextIteration(out chosenVertex) : DoNextIFSIteration();
                if (IterationsToIgnore == 0) {
                    DrawPoint(lastPoint, GpSize, GpColor);
                }
            }
            if(IterationsToIgnore == 0) {
                if (highlightGeneration) DrawPoint(lastPoint, GpSize, highlightColor);
                if (KeepVerticesOnTop && !UseIfs) DrawVertices();
                //This will crash if IFS is activated, so highlightGeneration should always be false when UseIfs is true.
                if (highlightGeneration && !UseIfs) DrawPoint(chosenVertex.Point, VertexSize, highlightColor); //Warning: bug potential here.
            }
        }
        #endregion

        #region Methods that control the logic of the game
        private Point DoNextIteration(out Vertex chosenVertex) {
            int chosenIndex;
            chosenVertex = null;

            bool isVertexValid;
            do {
                int randomInt = rng.Next(totalWeight);
                isVertexValid = true;

                if (checkWeight) {
                    chosenIndex = GetChosenIndex(randomInt);
                }
                else {
                    chosenIndex = randomInt;
                }

                chosenVertex = Vertices[chosenIndex];

                foreach(Rule r in Rules) {
                    isVertexValid = r.IsVertexValid(chosenIndex, Vertices.Count, vertexCache);
                    if (!isVertexValid) break;
                }

            }
            while (!isVertexValid);

            //If lastChosenVertices has to store values, do so:
            if(vertexCache != null) {
                //First push all values one index deeper.
                for (int i = 0; i < vertexCache.Length; i++) {
                    if (i + 1 >= vertexCache.Length) break;
                    else {
                        vertexCache[i + 1] = vertexCache[i];
                    }
                }
                //And now add the new value.
                vertexCache[0] = chosenIndex;
            }

            if(IterationsToIgnore > 0) IterationsToIgnore--;

            if (TryGetNextPoint(lastPoint, chosenIndex, out Point nextPoint)) {
                return nextPoint;
            }
            else {
                return DoNextIteration(out chosenVertex);
            }
        }
        //In this case, "lastPoint" only tracks which pixels are being painted on the bitmap, but the actual point generated by the last iteration is saved in "lastIfsPoint".
        private Point DoNextIFSIteration() {
            int chosenIndex = GetChosenFormula((float)rng.NextDouble() * ifsWeight);
            IFSFormula f = IfsFormulas[chosenIndex];
            F_Point p = lastIfsPoint;
            double realX = (f.a * p.X) + (f.b * p.Y) + f.e;
            double realY = (f.c * p.X) + (f.d * p.Y) + f.f;
            lastIfsPoint = new F_Point(realX, realY);

            int x = (int)Math.Round(realX * IfsMagnificationX) + CenterPoint.X;
            int y = - (int)Math.Round(realY * IfsMagnificationY) + CenterPoint.Y;

            return new Point(x, y);
        }

        private bool TryGetNextPoint(Point currentPoint, int vertexIndex, out Point nextPoint) {
            Vertex chosenVertex = Vertices[vertexIndex];
            int x = (int)ExtraMath.MiddleValueByCompression(currentPoint.X, chosenVertex.X, chosenVertex.compressionRatio);
            int y = (int)ExtraMath.MiddleValueByCompression(currentPoint.Y, chosenVertex.Y, chosenVertex.compressionRatio);

            nextPoint = new Point(x, y);

            Point rotationCenter = chosenVertex.Point;
            foreach (Rule r in Rules) {
                rotationCenter = r.AlterCenterOfRotation(vertexIndex, chosenVertex.Point);
            }
            nextPoint = ExtraMath.RotatePointAroundOrigin(nextPoint, rotationCenter, chosenVertex.rotation);

            foreach(Rule r in Rules) {
                return r.IsPointValid(nextPoint, MemoryBitmap);
            }
            
            return true;
        }
        #endregion

        #region Methods to manage the bitmap
        public void DrawVertices() => DrawVertices(Vertices, MemoryBitmap);
        public void DrawVertices(List<Vertex> vertices, Bitmap bitmap) {
            if (DrawSides && vertices.Count >= 2) {
                DrawLine(vertices[vertices.Count - 1].Point, vertices[0].Point, SideColor, bitmap);
                for (int i = 0; i < vertices.Count - 1; i++) {
                    DrawLine(vertices[i].Point, vertices[i + 1].Point, SideColor, bitmap);
                }
            }
            foreach (Vertex v in vertices) {
                DrawPoint(v.Point, VertexSize, VertexColor, bitmap);
            }
            /*foreach (Vertex v in Vertices) {
                DrawPoint(v.Point, VertexSize, VertexColor);
            }*/
        }

        public void DrawCoordinateAxes() => DrawCoordinateAxes(CenterPoint, MemoryBitmap);
        public void DrawCoordinateAxes(Point centerPoint, Bitmap bitmap) {
            DrawLine(new Point(0, centerPoint.Y), new Point(Width, centerPoint.Y), Color.FromArgb(128, 0, 0, 0), bitmap);
            //The vertical axis is done in two lines so it doesn't intercept the horizontal axis.
            DrawLine(new Point(centerPoint.X, 0), new Point(centerPoint.X, centerPoint.Y - 1), Color.FromArgb(128, 0, 0, 0), bitmap);
            DrawLine(new Point(centerPoint.X, centerPoint.Y + 1), new Point(centerPoint.X, Height), Color.FromArgb(128, 0, 0, 0), bitmap);
        }
        #endregion

        #region Methods that directly interact with the bitmap
        private void DrawPoint(Point point, int radius, Color color) => DrawPoint(point, radius, color, MemoryBitmap);
        private void DrawPoint(Point point, int radius, Color color, Bitmap bitmap) {
            SolidBrush brush = new SolidBrush(color);

            using (Graphics g = Graphics.FromImage(bitmap)) {
                if (radius > 0 && radius < 3) {
                    g.FillRectangle(brush, point.X, point.Y, radius, radius);
                }
                else if (radius > 1) {
                    int radiusOffset = (int)(radius / 2f);
                    g.FillEllipse(brush, point.X - radiusOffset, point.Y - radiusOffset, radius, radius);
                }
            }
        }

        private void DrawLine(Point a, Point b, Color color) => DrawLine(a, b, color, MemoryBitmap);
        private void DrawLine(Point a, Point b, Color color, Bitmap bitmap) {
            Pen pen = new Pen(color);

            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.DrawLine(pen, a, b);
            }
        }
        #endregion

        public void SaveBitmapToFile(string path, System.Drawing.Imaging.ImageFormat format) {
            MemoryBitmap.Save(path, format);
        }
        
        private void RecalculateVerticesCompressionRatio() {
            foreach (Vertex v in Vertices) {
                if (v.compressionRatio == -1) v.compressionRatio = CompressionRatio;
            }
        }

        private void RecalculateVerticesRotation() {
            foreach (Vertex v in Vertices) {
                if (v.rotation == -1) v.rotation = Rotation;
            }
        }
        //If no weight is different than -1 (or 100), it'll assign every vertex a weight of 1. Otherwise, the function ends and nothing is changed.
        //This also calculates totalWeight.
        private void RecalculateVerticesWeight() {
            foreach (Vertex v in Vertices) {
                if (v.weight != -1 && v.weight != 100) goto CalculateTotalWeight;
            }

            //Weight when no vertex has custom weight:
            checkWeight = false;
            foreach (Vertex v in Vertices) v.weight = 1;
            totalWeight = Vertices.Count;
            return;

            //Weight when a vertex has custom weight:
            CalculateTotalWeight:
            checkWeight = true;
            totalWeight = 0;
            foreach (Vertex v in Vertices) {
                totalWeight += v.weight;
            }
        }

        private void CalculateIFSWeight() {
            ifsWeight = 0f;
            foreach(IFSFormula f in IfsFormulas) {
                ifsWeight += f.p;
            }
        }

        private int GetChosenIndex(int randomInt) {
            int accumulatedWeight = 0;
            int chosenIndex = 0;
            foreach (Vertex v in Vertices) {
                accumulatedWeight += v.weight;
                if (accumulatedWeight >= randomInt) return chosenIndex;
                else chosenIndex++;
            }
            return chosenIndex;
        }

        private int GetChosenFormula(float randomFloat) {
            float accumulatedWeight = 0;
            int chosenIndex = 0;
            foreach(IFSFormula f in IfsFormulas) {
                accumulatedWeight += f.p;
                if (accumulatedWeight >= randomFloat) return chosenIndex;
                else chosenIndex++;
            }
            return chosenIndex;
        }

        private void LoadImageFromFile(string filePath) {
            Bitmap loadedImage = new Bitmap(filePath);
            MemoryBitmap = new Bitmap(loadedImage.Width, loadedImage.Height);
            using (Graphics g = Graphics.FromImage(MemoryBitmap)) {
                g.DrawImage(loadedImage, 0, 0, loadedImage.Width, loadedImage.Height);
            }
        }

        //NOT REFACTORED YET:

        /*//TODO: Get rid of this
        public void GenerateFirstPoint() {
            int x = (int)(Vertices[0].X - ((Vertices[0].X - Vertices[1].X) / CompressionRatio));
            int y = (int)(Vertices[0].Y - ((Vertices[0].Y - Vertices[1].Y) / CompressionRatio));
            lastPoint = new Point(x, y);
            DrawPoint(lastPoint, GpSize, Color.Green); //TODO: yeah.
            DrawVertices();
        }*/

        public void GenerateNextPoint2() {
        }
        public bool GetZoomedMap(float zoom, out Bitmap zoomedBitmap) {
            SolidBrush brush = new SolidBrush(Color.Black);
            try {
                Bitmap zoomedMap = new Bitmap((int)(MemoryBitmap.Width * zoom), (int)(MemoryBitmap.Height * zoom));

                using (Graphics g = Graphics.FromImage(zoomedMap)) {
                    g.DrawImage(MemoryBitmap, 0, 0, (int)(MemoryBitmap.Width * zoom), (int)(MemoryBitmap.Height * zoom));
                }
                zoomedBitmap = zoomedMap;
                return true;
            }
            catch (ArgumentException ex) {
                zoomedBitmap = null;
                return false;
            }
        }

        //This method is necessary so GameManager's vertex list and the frame's vertex list don't have the same vertex objects (and thus modifying one modifies the other).
        public List<Vertex> ReplicateList(List<Vertex> originalList) {
            List<Vertex> newList = new List<Vertex>();
            foreach(Vertex v in originalList) {
                Vertex vertexCopy = new Vertex(v.X, v.Y, v.compressionRatio, v.rotation, v.weight);
                newList.Add(vertexCopy);
            }
            return newList;
        }

        public List<IFSFormula> ReplicateList(List<IFSFormula> originalList) {
            List<IFSFormula> newList = new List<IFSFormula>();
            foreach(IFSFormula f in originalList) {
                IFSFormula formulaCopy = new IFSFormula(f.a, f.b, f.c, f.d, f.e, f.f, f.p);
                newList.Add(formulaCopy);
            }
            return newList;
        }
    }

    public class Vertex {
        public int X, Y;
        public float compressionRatio, rotation;
        public int weight;

        //If compressionRate is -1, it'll take the general compressionRate of the game. The same applies to rotation.
        //If weight is -1, the game will treat it as if it was 100.
        public Vertex(int X, int Y, float compressionRatio = -1, float rotation = -1, int weight = -1) {
            this.X = X;
            this.Y = Y;
            this.compressionRatio = compressionRatio;
            this.rotation = rotation;
            this.weight = weight;
        }

        public Point Point {
            get => new Point(X, Y);
        }
    }

    public struct IFSFormula {
        public float a, b, c, d, e, f, p;

        public IFSFormula(float a, float b, float c, float d, float e, float f, float p) {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.p = p;
        }
    }

    //I'm sure this is a terrible implementation.
    public abstract class Rule {
        public string RuleName { get; private set; }

        public virtual int RequiredVertexCache {
            get => 0;
        }

        public Rule(string name) {
            RuleName = name;
        }

        public virtual bool IsVertexValid(int index, int totalVertices, int[] cache) => true;
        public virtual bool IsPointValid(Point point, Bitmap bitmap) => true;
        public virtual Point AlterCenterOfRotation(int index, Point center) => center;
    }

    //Last vertices from [m] (most recent) to [n] (oldest) were the same. And this one is at distance [distance] from that vertex.
    public class Rule_CheckVertices : Rule {
        public readonly int m, n, distance;

        public override int RequiredVertexCache {
            get => n;
        }

        public Rule_CheckVertices(string name, int m, int n, int distance) : base(name) {
            this.m = m;
            this.n = n;
            this.distance = distance;
        }

        public override bool IsVertexValid(int index, int totalVertices, int[] cache) {
            if (cache[n] == -1) return true;
            //Check if last vertices from m to n were the same.
            for (int i = m; i < n; i++) {
                if (cache[i] != cache[i + 1]) return true;
            }
            //Check if current vertex is valid.
            int modifiedIndex = index + distance;

            if (modifiedIndex < 0) modifiedIndex += totalVertices;
            if (modifiedIndex > totalVertices - 1) modifiedIndex -= totalVertices;

            if (modifiedIndex == cache[0]) return false;
            return true;
        }
    }
    //The new point cannot land on a point that is of a specific color in the bitmap.
    public class Rule_BanColor : Rule {
        public readonly Color color;

        public Rule_BanColor(string name, Color color) : base(name) {
            this.color = color;
        }

        public override bool IsPointValid(Point point, Bitmap bitmap) {
            if (bitmap.GetPixel(point.X, point.Y).ToArgb() == color.ToArgb()) {
                return false;
            }
            return true;
        }
    }
    //Add +x, +y to the center of rotation of vertex n.
    public class Rule_AlterRotationCenter : Rule {
        public readonly int x, y, affectedVertex;

        public Rule_AlterRotationCenter(string name, int affectedVertex, int x, int y) : base(name) {
            this.affectedVertex = affectedVertex;
            this.x = x;
            this.y = y;
        }

        public override Point AlterCenterOfRotation(int index, Point center) {
            if (index != affectedVertex) return center;
            return new Point(center.X + x, center.Y + y);
        }
    }
}
