using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGNamespaces.ExtraFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChaosGame {
    public partial class MainWindow {
        private readonly List<IFSFormula> IFS_FERN = new List<IFSFormula>() {
            new IFSFormula(0, 0, 0, 0.16f, 0, 0, 0.01f),
            new IFSFormula(0.85f, 0.04f, -0.04f, 0.85f, 0, 1.6f, 0.85f),
            new IFSFormula(0.20f, -0.26f, 0.23f, 0.22f, 0, 1.60f, 0.07f),
            new IFSFormula(-0.15f, 0.28f, 0.26f, 0.24f, 0, 0.44f, 0.07f)
        };
        private readonly List<IFSFormula> IFS_FERN_VARIANT = new List<IFSFormula>() {
            new IFSFormula(0, 0, 0, 0.16f, 0, 0, 0.01f),
            new IFSFormula(0.75f, 0.04f, -0.04f, 0.85f, 0, 1.6f, 0.85f),
            new IFSFormula(0.20f, -0.26f, 0.23f, 0.22f, 0, 1.60f, 0.07f),
            new IFSFormula(-0.15f, 0.28f, 0.26f, 0.24f, 0, 0.44f, 0.07f)
        };

        private JsonSerializer json = new JsonSerializer();

        private GameManager gm; //Whenever we start a new game, we create a new GameManager to replace the current one. One is called on MainWindow().
        private string filePath;
        //This List<Vertex> is not the same list as GameManager's Vertices list. It does not contain the same Vertex objects, either.
        //This vertices variable and GameManager's Vertices should NEVER interact with each other, unless they use the method GameManager.ReplicateList()
        //to ensure that both lists remain completely independent of each other.
        private List<Vertex> vertices;
        private List<Vertex> Vertices {
            get => vertices;
            set {
                vertices = value;
                PreviewVertices();
            }
        }

        private List<IFSFormula> ifsFormulas;
        private List<IFSFormula> IfsFormulas {
            get => ifsFormulas;
            set {
                ifsFormulas = value;
                label_formulaCount.Text = "Count: " + ifsFormulas.Count;
            }
        }

        private List<Rule> Rules { get; set; }
        
        private void CreateNewGame() {
            gm = new GameManager();
            EnableVisualControl = true;
            EnableRulesControl = false;
            EnableGenerationControl = false;
            //Asign new game values to controls.
            pictureBox_bitmap.Image = null;
            pictureBox_bitmap.BorderStyle = BorderStyle.None;

            BitmapHeight = gm.Height;
            BitmapWidth = gm.Width;
            BitmapBgColor = gm.MemoryBitmapBGColor;
            ImportBitmap = false;

            VertexSize = gm.VertexSize;
            VertexColor = gm.VertexColor;
            KeepVerticesOnTop = gm.KeepVerticesOnTop;

            GpSize = gm.GpSize;
            GpColor = gm.GpColor;

            if(!gm.UseIfs) {
                Vertices = gm.ReplicateList(gm.Vertices);
                DrawSides = gm.DrawSides;
                SideColor = gm.SideColor;

                checkBox_autoSeed.Checked = true;
                numeric_seedX.Value = Seed.X;
                numeric_seedX.Value = Seed.Y;
                CompressionRatio = gm.CompressionRatio;
                Rotation = gm.Rotation;
                Rules = gm.Rules;
                IterationsToIgnore = gm.IterationsToIgnore;

                IfsFormulas = new List<IFSFormula>();
            }
            else {
                tabControl_rules.SelectTab(1);
                IfsFormulas = gm.ReplicateList(gm.IfsFormulas);
                CenterPoint = gm.CenterPoint;
                IfsMagnificationX = gm.IfsMagnificationX;
                IfsMagnificationY = gm.IfsMagnificationY;
                LinkIfsMagnify = (IfsMagnificationX == IfsMagnificationY) ? true : false;
                DrawAxes = gm.DrawAxes;

                Vertices = new List<Vertex>();
            }
        }

        private void PreviewVertices() {
            label_pointCount.Text = "Count: " + Vertices.Count.ToString();

            button_ApplyRulesOptions.Enabled = (Vertices.Count < 2) ? false : true;

            if (pictureBox_bitmap.Image == null) return;
            else {
                pictureBox_bitmap.Image = gm.GetPreviewBitmap(Vertices, Zoom, DrawSides, SideColor);
            }
        }

        private void PreviewAxes() {
            if (pictureBox_bitmap.Image == null) return;
            else {
                if(DrawAxes) {
                    pictureBox_bitmap.Image = gm.GetPreviewIFSBitmap(CenterPoint, Zoom);
                }
                else {
                    UpdateBitmap();
                }
            }
        }

        private System.Drawing.Size BitmapSize {
            get => new System.Drawing.Size((int)numeric_imgWidth.Value, (int)numeric_imgHeight.Value);
            set {
                numeric_imgWidth.Value = Size.Width;
                numeric_imgHeight.Value = Size.Height;
                UpdatePictureBoxSize();
            }
        }

        private int BitmapHeight {
            get => (int)numeric_imgHeight.Value;
            set {
                numeric_imgHeight.Value = value;
                UpdatePictureBoxSize();
            }
        }

        private int BitmapWidth {
            get => (int)numeric_imgWidth.Value;
            set {
                numeric_imgWidth.Value = value;
                UpdatePictureBoxSize();
            }
        }

        private System.Drawing.Color BitmapBgColor {
            get => pictureBox_bgColor.BackColor;
            set {
                pictureBox_bgColor.BackColor = value;
                label_bgColorVal.Text = value.HexValue();
            }
        }

        private int VertexSize {
            get => (int)numeric_vertexSize.Value;
            set => numeric_vertexSize.Value = value;
        }

        private System.Drawing.Color VertexColor {
            get => pictureBox_vertexColor.BackColor;
            set {
                pictureBox_vertexColor.BackColor = value;
                label_vertexColorVal.Text = value.HexValue();
            }
        }

        private bool KeepVerticesOnTop {
            get => checkBox_ipOnTop.Checked;
            set => checkBox_ipOnTop.Checked = value;
        }

        private int GpSize {
            get => (int)numeric_gpSize.Value;
            set => numeric_gpSize.Value = value;
        }

        private System.Drawing.Color GpColor {
            get => pictureBox_gpColor.BackColor;
            set {
                pictureBox_gpColor.BackColor = value;
                label_gpColorVal.Text = value.HexValue();
            }
        }

        private float Zoom {
            get => (float)numeric_zoom.Value;
            set => numeric_zoom.Value = (decimal)value;
        }

        private int Iterations {
            get => (int)numeric_iterations.Value;
            set => numeric_iterations.Value = value;
        }

        private int Time {
            get => (int)numeric_time.Value;
            set => numeric_time.Value = value;
        }

        private float CompressionRatio {
            get => (float)numeric_compressionRatio.Value;
            set => numeric_compressionRatio.Value = (decimal)value;
        }

        private float Rotation {
            get => (float)numeric_rotation.Value;
            set => numeric_rotation.Value = (decimal)value;
        }

        private int Rule2Val {
            get => (int)numeric_rule2Val.Value;
            set => numeric_rule2Val.Value = value;
        }

        private void LoadBitmap() {
            pictureBox_bitmap.BorderStyle = BorderStyle.FixedSingle;
            UpdateBitmap();
            UpdatePictureBoxSize();
        }

        private bool UpdateBitmap(bool updatePictureBoxSize = false) {
            if (gm.GetZoomedMap(Zoom, out System.Drawing.Bitmap b)) {
                pictureBox_bitmap.Image = b;
                if (updatePictureBoxSize) UpdatePictureBoxSize();
                return true;
            }
            else {
                MessageBox.Show("There was an error applying the zoom. Maybe it's too big for your computer to handle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdatePictureBoxSize() {
            pictureBox_bitmap.Size = new System.Drawing.Size((int)(BitmapWidth * Zoom), (int)(BitmapHeight * Zoom));
            UpdatePictureBoxPosition();
        }

        private void UpdatePictureBoxPosition() {
            int picHeight = pictureBox_bitmap.Size.Height, picWidth = pictureBox_bitmap.Size.Width;
            int panelHeight = panel_bitmap.Size.Height, panelWidth = panel_bitmap.Size.Width;
            int x = 0, y = 0;

            if (picWidth <= panelWidth) {
                x = (int)((panelWidth - picWidth) / 2f);
            }
            if (picHeight <= panelHeight) {
                y = (int)((panelHeight - picHeight) / 2f);
            }
            pictureBox_bitmap.Location = new System.Drawing.Point(x, y);
        }

        private bool AddVertexOnClick {
            get => checkBox_addVertexOnClick.Checked;
            set => checkBox_addVertexOnClick.Checked = value;
        }

        /*private void UpdateBitmap() {
            if(pictureBox_bitmap.InvokeRequired) {
                UpdateBitmapDelegate deg = new UpdateBitmapDelegate(UpdateBitmap);
                pictureBox_bitmap.Invoke(deg);
            }
            else {
                pictureBox_bitmap.Image = gm.bitmap;
            }
        }*/

        //This is called when the automatic generation is started or stopped.
        private void EnableGenerationControls(bool disable) {
            button_new.Enabled = disable;
            button_clear.Enabled = disable;
            button_restart.Enabled = disable;

            label_iterations.Enabled = disable;
            numeric_iterations.Enabled = disable;
            label_time.Enabled = disable;
            numeric_time.Enabled = disable;
            button_startGen.Enabled = disable;
            button_stopGen.Enabled = !disable;
            button_nextIteration.Enabled = disable;
            button_nextFrame.Enabled = disable;
            button_saveBitmap.Enabled = disable;
        }

        private void AutoResizePictureBox(int width, int height) {
            BitmapWidth = width;
            BitmapHeight = height;
        }

        private bool HighlightGeneration {
            get => checkBox_highlightSel.Checked;
            set => checkBox_highlightSel.Checked = value;
        }

        private System.Drawing.Color HighlightColor {
            get => pictureBox_highlightColor.BackColor;
            set {
                pictureBox_highlightColor.BackColor = value;
                label_highlightVal.Text = value.HexValue();
            }
        }

        private void NextFrame(int iterations) {
            if (HighlightGeneration) gm.DrawNextFrame(iterations, true, HighlightColor);
            else gm.DrawNextFrame(iterations);
            UpdateBitmap();
        }

        private System.Drawing.Point Seed {
            get {
                return new System.Drawing.Point((int)numeric_seedX.Value, (int)numeric_seedY.Value);
            }
            set {
                numeric_seedX.Value = value.X;
                numeric_seedY.Value = value.Y;
            }
        }

        private bool UseAutomaticSeed {
            get => checkBox_autoSeed.Checked;
            set => checkBox_autoSeed.Checked = value;
        }

        private int IterationsToIgnore {
            get {
                if (!UseIfs) return (int)numeric_ignoreIterationsVal.Value;
                else return (int)numeric_ifs_ignoreIterationsVal.Value;
            }
            set {
                if (!UseIfs) numeric_ignoreIterationsVal.Value = value;
                else numeric_ifs_ignoreIterationsVal.Value = value;
            }
        }

        private bool DrawSides {
            get => checkBox_drawSides.Checked;
            set => checkBox_drawSides.Checked = value;
        }

        private System.Drawing.Color SideColor {
            get => pictureBox_sideColor.BackColor;
            set {
                pictureBox_sideColor.BackColor = value;
                label_sideColorVal.Text = value.HexValue();
            }
        }

        private bool UseIfs {
            get {
                if (tabControl_rules.SelectedIndex == 1) return true;
                return false;
            }
            set {
                if (value) tabControl_rules.SelectTab(1);
                else tabControl_rules.SelectTab(0);
            }
        }

        private float IfsMagnificationX {
            get => (float)numeric_ifsMagnifyX.Value;
            set => numeric_ifsMagnifyX.Value = (decimal)value;
        }

        private float IfsMagnificationY {
            get => (float)numeric_ifsMagnifyY.Value;
            set => numeric_ifsMagnifyY.Value = (decimal)value;
        }

        private System.Drawing.Point CenterPoint {
            get {
                int x = (int)numeric_cpX.Value;
                int y = (int)numeric_cpY.Value;
                return new System.Drawing.Point(x, y);
            }
            set {
                numeric_cpX.Value = value.X;
                numeric_cpY.Value = value.Y;
            }
        }

        private bool DrawAxes {
            get => checkBox_drawAxes.Checked;
            set => checkBox_drawAxes.Checked = value;
        }

        private bool ImportBitmap {
            get => checkBox_import.Checked;
            set {
                checkBox_import.Checked = value;

                groupBox_imgDim.Enabled = !ImportBitmap;
                label_imgBgColor.Enabled = !ImportBitmap;
                label_bgColorVal.Enabled = !ImportBitmap;
                pictureBox_bgColor.Enabled = !ImportBitmap;
                
                button_import.Enabled = ImportBitmap;
            }
        }

        private bool LinkIfsMagnify {
            get => checkBox_linkIfsMagnify.Checked;
            set => checkBox_linkIfsMagnify.Checked = value;
        }

        private bool EnableVisualControl {
            get => groupBox_visualOptions.Enabled;
            set => groupBox_visualOptions.Enabled = value;
        }

        private bool EnableRulesControl {
            get => tabControl_rules.Enabled;
            set {
                tabControl_rules.Enabled = value;
                button_loadPreset.Enabled = value;
                button_savePreset.Enabled = value;
            }
        }

        private bool EnableGenerationControl {
            get => groupBox_generation.Enabled;
            set => groupBox_generation.Enabled = value;
        }

        private void ImportJsonPreset(string path) {
            JObject preset = JObject.Parse(File.ReadAllText(path));

            if ((string)preset["type"] == "chaos") {
                //Parse data.
                JArray presetVertices = (JArray)preset["vertexList"];
                JArray presetRules = (JArray)preset["ruleList"];

                List<Vertex> vertexList = new List<Vertex>();
                for(int i = 0; i < presetVertices.Count; i++) {
                    int x = int.Parse((string)presetVertices[i]["x"]);
                    int y = int.Parse((string)presetVertices[i]["y"]);
                    float vComp = int.Parse((string)presetVertices[i]["compression"]);
                    float vRot = int.Parse((string)presetVertices[i]["rotation"]);
                    int vWeight = int.Parse((string)presetVertices[i]["weight"]);
                    Vertex newVertex = new Vertex(x, y, vComp, vRot, vWeight);
                    vertexList.Add(newVertex);
                }

                bool autoSeed = (bool)preset["autoSeed"];
                int seedX = 0, seedY = 0;

                if(!autoSeed) {
                    seedX = (int)preset["seedX"];
                    seedY = (int)preset["seedY"];
                }
                float compression = (float)preset["compression"];
                float rotation = (float)preset["rotation"];

                List<Rule> ruleList = new List<Rule>();
                for(int i = 0; i < presetRules.Count; i++) {
                    string ruleName = (string)presetRules[i]["ruleName"];
                    int ruleType = (int)presetRules[i]["ruleType"];
                    if (ruleType == 0) {
                        int m = (int)presetRules[i]["m"];
                        int n = (int)presetRules[i]["n"];
                        int o = (int)presetRules[i]["o"];
                        ruleList.Add(new Rule_CheckVertices(ruleName, m, n, o));
                    }
                    else if (ruleType == 1) {
                        int r = (int)presetRules[i]["r"];
                        int g = (int)presetRules[i]["g"];
                        int b = (int)presetRules[i]["b"];
                        int a = (int)presetRules[i]["a"];
                        ruleList.Add(new Rule_BanColor(ruleName, System.Drawing.Color.FromArgb(a, r, g, b)));
                    }
                    else if (ruleType == 2) {
                        int vIndex = (int)presetRules[i]["i"];
                        int x = (int)presetRules[i]["x"];
                        int y = (int)presetRules[i]["y"];
                        ruleList.Add(new Rule_AlterRotationCenter(ruleName, vIndex, x, y));
                    }
                }
                //Apply data
                UseIfs = false;
                Vertices = vertexList;
                UseAutomaticSeed = autoSeed;
                if (!autoSeed) {
                    Seed = new System.Drawing.Point(seedX, seedY);
                }
                CompressionRatio = compression;
                Rotation = rotation;
                Rules = ruleList;
            }
            else if((string)preset["type"] == "ifs") {
                //Parse data
                JArray presetFormulas = (JArray)preset["formula"];
                List<IFSFormula> formulaList = new List<IFSFormula>();

                for(int i = 0; i < presetFormulas.Count; i++) {
                    float a = (float)presetFormulas[i]["a"];
                    float b = (float)presetFormulas[i]["b"];
                    float c = (float)presetFormulas[i]["c"];
                    float d = (float)presetFormulas[i]["d"];
                    float e = (float)presetFormulas[i]["e"];
                    float f = (float)presetFormulas[i]["f"];
                    float p = (float)presetFormulas[i]["p"];
                    formulaList.Add(new IFSFormula(a, b, c, d, e, f, p));
                }

                int centerPointX = (int)preset["centerPointX"];
                int centerPointY = (int)preset["centerPointY"];
                float magnifyX = (float)preset["magnifyX"];
                float magnifyY = (float)preset["magnifyY"];

                //Apply data
                UseIfs = true;
                IfsFormulas = formulaList;
                CenterPoint = new System.Drawing.Point(centerPointX, centerPointY);
                IfsMagnificationX = magnifyX;
                IfsMagnificationY = magnifyY;
            }
        }

        private void CreateJsonPreset(string name) {
            List<string> jsonLines = new List<string>();
            jsonLines.Add("{");
            jsonLines.Add("	\"name\": \"" + name + "\",");
            if(!UseIfs) {
                jsonLines.Add("	\"type\": \"chaos\",");
                jsonLines.Add("	\"vertexList\": [");
                foreach(Vertex v in Vertices) {
                    jsonLines.Add("		{");
                    jsonLines.Add("		    \"x\": " + v.X + ",");
                    jsonLines.Add("		    \"y\": " + v.Y + ",");
                    jsonLines.Add("		    \"compression\": " + v.compressionRatio + ",");
                    jsonLines.Add("		    \"rotation\": " + v.rotation + ",");
                    jsonLines.Add("		    \"weight\": " + v.weight);
                    jsonLines.Add("		},");
                }
                jsonLines.Add("	],");
                if (UseAutomaticSeed) {
                    jsonLines.Add("	\"autoSeed\": true,");
                }
                else {
                    jsonLines.Add("		\"autoSeed\": false,");
                    jsonLines.Add("		\"seedX\": " + Seed.X + ",");
                    jsonLines.Add("		\"seedX\": " + Seed.Y + ",");
                }
                jsonLines.Add("	\"compression\": \"" + CompressionRatio + "\",");
                jsonLines.Add("	\"rotation\": \"" + Rotation + "\",");
                jsonLines.Add("	\"ruleList\": [");
                foreach (Rule r in Rules) {
                    if(r is Rule_CheckVertices casted0) {
                        jsonLines.Add("		{");
                        jsonLines.Add("		    \"ruleType\": 0, ");
                        jsonLines.Add("		    \"ruleName\": " + casted0.RuleName + ",");
                        jsonLines.Add("		    \"m\": " + casted0.m + ",");
                        jsonLines.Add("		    \"n\": " + casted0.n + ",");
                        jsonLines.Add("		    \"o\": " + casted0.distance);
                        jsonLines.Add("		},");
                    }
                    else if (r is Rule_BanColor casted1) {
                        jsonLines.Add("		{");
                        jsonLines.Add("		    \"ruleType\": 1, ");
                        jsonLines.Add("		    \"ruleName\": " + casted1.RuleName + ",");
                        jsonLines.Add("		    \"r\": " + casted1.color.R + ",");
                        jsonLines.Add("		    \"g\": " + casted1.color.G + ",");
                        jsonLines.Add("		    \"b\": " + casted1.color.B + ",");
                        jsonLines.Add("		    \"a\": " + casted1.color.A);
                        jsonLines.Add("		},");
                    }
                    else if (r is Rule_AlterRotationCenter casted2) {
                        jsonLines.Add("		{");
                        jsonLines.Add("		    \"ruleType\": 2, ");
                        jsonLines.Add("		    \"ruleName\": " + casted2.RuleName + ",");
                        jsonLines.Add("		    \"i\": " + casted2.affectedVertex + ",");
                        jsonLines.Add("		    \"x\": " + casted2.x + ",");
                        jsonLines.Add("		    \"y\": " + casted2.y);
                        jsonLines.Add("		},");
                    }
                }
                jsonLines.Add("	],");
            }
            else if (UseIfs) {
                jsonLines.Add("	\"type\": \"ifs\",");
                jsonLines.Add("	\"formula\": [");
                foreach (IFSFormula f in IfsFormulas) {
                    jsonLines.Add("		{");
                    jsonLines.Add("		    \"a\": " + f.a + ",");
                    jsonLines.Add("		    \"b\": " + f.b + ",");
                    jsonLines.Add("		    \"c\": " + f.c + ",");
                    jsonLines.Add("		    \"d\": " + f.d + ",");
                    jsonLines.Add("		    \"e\": " + f.e + ",");
                    jsonLines.Add("		    \"f\": " + f.f + ",");
                    jsonLines.Add("		    \"p\": " + f.p + ",");
                    jsonLines.Add("		},");
                }
                jsonLines.Add("	],");
                jsonLines.Add("	\"centerPointX\": \"" + CenterPoint.X + "\",");
                jsonLines.Add("	\"centerPointY\": \"" + CenterPoint.Y + "\",");
                jsonLines.Add("	\"magnifyX\": \"" + IfsMagnificationX + "\",");
                jsonLines.Add("	\"magnifyY\": \"" + IfsMagnificationY + "\"");
            }
            jsonLines.Add("}");

            //Removing invalid filename characters as listed here: https://gist.github.com/doctaphred/d01d05291546186941e1b7ddc02034d3
            string path = name.Replace(' ', '_').Replace("<", "").Replace(">", "").Replace(":", "").Replace("\"", "").Replace("/", "");
            path = path.Replace("\\", "").Replace("|", "").Replace("?", "").Replace("*", "");

            path = @".\res\presets\" + path.ToLower();

            int index = 0;

            if (File.Exists(path + ".cgpreset")) {
                do {
                    index++;
                }
                while (Directory.Exists(path + "_" + index + ".cgpreset"));

                path = path + "_" + index.ToString();
            }

            path = path + ".cgpreset";

            using (StreamWriter outputFile = new StreamWriter(path)) {
                foreach(string line in jsonLines) {
                    outputFile.WriteLine(line);
                }
            }
        }
    }
}
