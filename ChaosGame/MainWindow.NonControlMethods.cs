using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGNamespaces.ExtraFunctions;

namespace ChaosGame {
    public partial class MainWindow {
        GameManager gm; //Whenever we start a new game, we create a new GameManager to replace the current one. One is called on MainWindow().
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
        private List<Rule> Rules { get; set; }
        
        private void CreateNewGame() {
            gm = new GameManager();
            groupBox_visualOptions.Enabled = true;
            groupBox_rules.Enabled = false;
            groupBox_generation.Enabled = false;
            //Asign new game values to controls.
            pictureBox_bitmap.Image = null;
            pictureBox_bitmap.BorderStyle = BorderStyle.None;

            BitmapHeight = gm.Height;
            BitmapWidth = gm.Width;
            BitmapBgColor = gm.MemoryBitmapBGColor;

            VertexSize = gm.VertexSize;
            VertexColor = gm.VertexColor;
            KeepVerticesOnTop = gm.KeepVerticesOnTop;

            GpSize = gm.GpSize;
            GpColor = gm.GpColor;

            Vertices = gm.ReplicateList(gm.Vertices);
            checkBox_autoSeed.Checked = true;
            numeric_seedX.Value = Seed.X;
            numeric_seedX.Value = Seed.Y;
            CompressionRatio = gm.CompressionRatio;
            Rotation = gm.Rotation;
            Rules = gm.Rules;
            IterationsToIgnore = gm.IterationsToIgnore;

            //Seed = gm.GetAutomaticSeed();
        }

        private void PreviewVertices() {
            label_pointCount.Text = "Count: " + Vertices.Count.ToString();
            if (pictureBox_bitmap.Image == null) return;
            else {
                pictureBox_bitmap.Image = gm.GetPreviewBitmap(Vertices, Zoom);
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
            get => (int)numeric_ipSize.Value;
            set => numeric_ipSize.Value = value;
        }

        private System.Drawing.Color VertexColor {
            get => pictureBox_ipColor.BackColor;
            set {
                pictureBox_ipColor.BackColor = value;
                label_ipColorVal.Text = value.HexValue();
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
            get => (int)numeric_ignoreIterationsVal.Value;
            set => numeric_ignoreIterationsVal.Value = value;
        }
    }
}
