using CGNamespaces.ExtraFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPoint = System.Windows.Point;

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
        private Vertex[] lastChosenVertices = null;
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
        public Point Seed { get; private set; }
        public float CompressionRatio { get; private set; } //Todo: change to decimal IF it's not any slower.
        public float Rotation { get; private set; }
        public List<Rule> Rules { get; private set; }

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
            CompressionRatio = 2.0f;
            Rotation = 0.0f;
            Rules = new List<Rule>();
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

        public void AssignRulesVariables(List<Vertex> vertices, float compressionRatio, float rotation, List<Rule> rules) {
            Vertices = ReplicateList(vertices);

            CompressionRatio = compressionRatio;
            Rotation = rotation;
            Rules = rules;
            //Assign the correct compression, rotation and weight to each individual vertex based on their values.
            RecalculateVerticesCompressionRatio();
            RecalculateVerticesRotation();
            RecalculateVerticesWeight();
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
        public Bitmap GetPreviewBitmap(List<Vertex> vertices, float zoom) {
            Bitmap previewBM = (Bitmap)MemoryBitmap.Clone();
            foreach (Vertex v in vertices) {
                DrawPoint(new Point(v.X, v.Y), VertexSize, VertexColor, previewBM);
            }
            return previewBM;
        }

        public Point GetAutomaticSeed() {
            RecalculateVerticesCompressionRatio();
            RecalculateVerticesRotation();
            return GetNextPoint(Vertices[0].Point, Vertices[1]);
        }
        //At this moment, there is no option to highlight the seed, so the method with no parameters is the only one used by the form.
        public void DrawSeed() => DrawSeed(false, Color.Transparent);
        public void DrawSeed(bool highlightGeneration, Color highlightColor) {
            Color color = (highlightGeneration) ? highlightColor : GpColor;
            DrawPoint(Seed, GpSize, GpColor);
            lastPoint = Seed;
        }

        public void DrawNextFrame(int iterations) => DrawNextFrame(iterations, false, Color.Transparent);
        public void DrawNextFrame(int iterations, bool highlightGeneration, Color highlightColor) {
            //TODO: this first redraws the last point to be 'black', then draws n number of points obtained with DoNextIteration(), and finally, the last one, is drawn 'green'
            //and the vertices are redrawn, if necessary.
            //maybe keepverticesontop is not necessary and can be passed here as a parameter.
            if (lastPoint != nullPoint) {
                DrawPoint(lastPoint, GpSize, GpColor);
            }

            Vertex chosenVertex = null;

            for(int i = 0; i < iterations; i++) {
                lastPoint = DoNextIteration(out chosenVertex);
                DrawPoint(lastPoint, GpSize, GpColor);
            }
            
            if (highlightGeneration) DrawPoint(lastPoint, GpSize, highlightColor);
            if (KeepVerticesOnTop) DrawVertices();
            if (highlightGeneration) DrawPoint(chosenVertex.Point, VertexSize, highlightColor); //Warning: bug potential here.
        }
        #endregion

        #region Methods that control the logic of the game
        private Point DoNextIteration(out Vertex chosenVertex) {
            int randomInt = rng.Next(totalWeight);
            //TODO: Apply the rules about vertex selection.

            chosenVertex = null;

            if (checkWeight) chosenVertex = GetWeightedVertex(randomInt);
            else chosenVertex = Vertices[randomInt];

            //If lastChosenVertices has to store values, do so:
            if(lastChosenVertices != null) {
                //First push all values one index deeper.
                for (int i = 0; i < lastChosenVertices.Length; i++) {
                    if (i + 1 >= lastChosenVertices.Length) break;
                    else {
                        lastChosenVertices[i + 1] = lastChosenVertices[i];
                    }
                }
                //And now add the new value.
                lastChosenVertices[0] = chosenVertex;
            }
            
            return GetNextPoint(lastPoint, chosenVertex);
        }
        private Point GetNextPoint(Point currentPoint, Vertex chosenVertex) {
            int x = (int)ExtraMath.MiddleValueByCompression(currentPoint.X, chosenVertex.X, chosenVertex.compressionRatio);
            int y = (int)ExtraMath.MiddleValueByCompression(currentPoint.Y, chosenVertex.Y, chosenVertex.compressionRatio);

            Point nextPoint = new Point(x, y);
            nextPoint = ExtraMath.RotatePointAroundOrigin(nextPoint, chosenVertex.Point, chosenVertex.rotation);

            //Point middlePoint = new Point(350, 225);
            //nextPoint = ExtraMath.RotatePointAroundOrigin(nextPoint, middlePoint, chosenVertex.rotation);

            return nextPoint;
        }
        #endregion

        #region Methods to manage the bitmap
        public void DrawVertices() {
            foreach (Vertex v in Vertices) {
                DrawPoint(v.Point, VertexSize, VertexColor);
            }
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

        /*private void CalculateTotalWeight() {
            if (totalWeight == -2) {
                totalWeight = Vertices.Count;
                checkWeight = false;
            }
            else {
                totalWeight = 0;
                foreach (Vertex v in Vertices) {
                    totalWeight += v.weight;
                }
            }
        }*/

        private Vertex GetWeightedVertex(int randomInt) {
            int accumulatedWeight = 0;
            foreach (Vertex v in Vertices) {
                accumulatedWeight += v.weight;
                if (accumulatedWeight >= randomInt) return v;
            }
            return null;
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
            catch (ArgumentException e) {
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

    public class Rule {

    }
}
