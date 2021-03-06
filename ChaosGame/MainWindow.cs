﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ExtraDialogs;
using System.Windows.Threading;
using SWPoint = System.Windows.Point;

// Vertices are called 'initial points' or 'ip' in the code.
// The seed is called 'first generated point' or 'gpFirst' in the code.
// Anything related with the compression ratio should be referred 'compression' or 'compressionRatio'. It is possible that something is referred as 'genPos'.

namespace ChaosGame {
    // Any variable or method not directly related to a control in the form is defined in the file MainWindow.NonControlMethods.cs
    // The contents of the controls (text, numeric values) should always be accessed using the getters/setters defined in the auxiliary NonControlMethods file.
    // - this simplifies the code, makes it more readable, and prevents unexpected interactions between the forms and the values in the GameManager.
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            CreateNewGame();
        }

        #region Main controls
        private void button_new_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to restore the default values. " +
                "This will create a new game, and the current settings and progress will be lost.",
                "Restore default values",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes) {
                CreateNewGame();
            }
        }

        private void button_clear_Click(object sender, EventArgs e) {
            gm.ClearBitmap();
            UpdateBitmap();
        }

        private void button_restart_Click(object sender, EventArgs e) {
            EnableVisualControl = true;
            EnableRulesControl = false;
            EnableGenerationControl = false;
            gm.ClearBitmap();
            UpdateBitmap();
        }
        #endregion

        #region Visual options controls
        private void button_applyVisualOptions_Click(object sender, EventArgs e) {
            if(!ImportBitmap) {
                gm.AssignVisualVariables(BitmapWidth, BitmapHeight, BitmapBgColor, VertexSize, VertexColor, KeepVerticesOnTop, GpSize, GpColor);
            }
            else {
                gm.AssignVisualVariablesAndLoadImage(filePath, VertexSize, VertexColor, KeepVerticesOnTop, GpSize, GpColor);
            }

            EnableVisualControl = false;
            EnableRulesControl = true;
            EnableGenerationControl = false;

            LoadBitmap();
            /*New maps are generated with 3 vertices forming a triangle.
             * This makes the program display those vertices right away when clicking on "ok",
             * so the user knows there are 3 vertices already generated. */
            if (tabControl_rules.SelectedIndex == 0) PreviewVertices();
            else if (tabControl_rules.SelectedIndex == 1) PreviewAxes();
        }

        private void UpdatePictureBoxEvent(object sender, EventArgs e) {
            UpdatePictureBoxSize();
        }

        private void button_dimSquare_Click(object sender, EventArgs e) {
            int side = (panel_bitmap.Height <= panel_bitmap.Width) ? panel_bitmap.Height - 4 : panel_bitmap.Width - 4;
            AutoResizePictureBox(side, side);
        }

        private void button_dimRectangle_Click(object sender, EventArgs e) {
            int height = panel_bitmap.Height - 4;
            int width = panel_bitmap.Width - 4;
            AutoResizePictureBox(width, height);
        }

        private void pictureBox_bgColor_DoubleClick(object sender, EventArgs e) {
            ColorPicker c = new ColorPicker();
            c.InitialColor = BitmapBgColor;
            BitmapBgColor = c.ShowDialog();
        }
        
        private void checkBox_import_CheckedChanged(object sender, EventArgs e) {
            ImportBitmap = ImportBitmap;
        }

        private void button_import_Click(object sender, EventArgs e) {
            OpenFileDialog o = new OpenFileDialog();

            if(o.ShowDialog() == DialogResult.OK && o.FileName != "") {
                filePath = o.FileName;
                Bitmap chosenImage = new Bitmap(filePath);
                BitmapWidth = chosenImage.Width;
                BitmapHeight = chosenImage.Height;
            }
        }

        private void pictureBox_vertexColor_DoubleClick(object sender, EventArgs e) {
            ColorPicker c = new ColorPicker();
            c.InitialColor = VertexColor;
            VertexColor = c.ShowDialog();
        }

        private void checkBox_ipOnTop_CheckedChanged(object sender, EventArgs e) {
            if(KeepVerticesOnTop == false) {
                HighlightGeneration = false;
                checkBox_highlightSel.Enabled = false;
                label_highlightSel.Enabled = false;
                label_highlightVal.Enabled = false;
                pictureBox_highlightColor.Enabled = false;
            }
            else {
                HighlightGeneration = true;
                checkBox_highlightSel.Enabled = true;
                label_highlightSel.Enabled = true;
                label_highlightVal.Enabled = true;
                pictureBox_highlightColor.Enabled = true;
            }
        }

        private void pictureBox_gpColor_DoubleClick(object sender, EventArgs e) {
            ColorPicker c = new ColorPicker();
            c.InitialColor = GpColor;
            GpColor = c.ShowDialog();
        }
        #endregion

        #region Rules options controls
        private void button_loadPreset_Click(object sender, EventArgs e) {
            LoadPreset p = new LoadPreset();
            string path = p.ShowDialog();
            if (path != "") {
                ImportJsonPreset(path);
            }
        }

        private void button_savePreset_Click(object sender, EventArgs e) {
            string presetName = InputBox.ShowDialog("Save preset", "Name your preset:", "New preset");
            if(presetName != "") {
                CreateJsonPreset(presetName);
            }
        }

        private void tabControl_rules_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl_rules.SelectedIndex == 0) {
                PreviewVertices();
            }
            else {
                UpdateBitmap();
            }
        }

        private void button_ApplyRulesOptions_Click(object sender, EventArgs e) {
            gm.AssignRulesVariables(Vertices, DrawSides, SideColor, CompressionRatio, Rotation, Rules, IterationsToIgnore);
            if (UseAutomaticSeed) gm.AssignSeed(gm.GetAutomaticSeed());
            else gm.AssignSeed(Seed);

            EnableVisualControl = false;
            EnableRulesControl = false;
            EnableGenerationControl = true;

            gm.DrawVertices();
            gm.DrawSeed();
            UpdateBitmap();
        }

        private void button_pointList_Click(object sender, EventArgs e) {
            VertexEditor v = new VertexEditor();
            List<Vertex> newVertices = v.ShowDialog(Vertices, BitmapSize);
            if (newVertices != null) {
                Vertices = newVertices; //uncomment
                PreviewVertices();
            }
        }

        private void button_clearVertices_Click(object sender, EventArgs e) {
            Vertices.Clear();
            PreviewVertices();
        }

        private void checkBox_drawSides_CheckedChanged(object sender, EventArgs e) {
            PreviewVertices();
        }

        private void pictureBox_sideColor_DoubleClick(object sender, EventArgs e) {
            ColorPicker c = new ColorPicker();
            c.InitialColor = SideColor;
            SideColor = c.ShowDialog();
        }
        //This is only active when "Add vertices by clicking..." is checked.
        private void pictureBox_bitmap_MouseClick(object sender, MouseEventArgs e) {
            if (AddVertexOnClick) {
                Vertex newVertex = new Vertex((int)(e.Location.X / Zoom), (int)(e.Location.Y / Zoom));
                Vertices.Add(newVertex);
                PreviewVertices();
            }
        }
        //This makes sure the 'Add vertices by clicking on the bitmap' checkbox is toggled off when we stop editing the rules.
        private void groupBox_rules_EnabledChanged(object sender, EventArgs e) {
            AddVertexOnClick = false;
        }

        private void checkBox_autoSeed_CheckedChanged(object sender, EventArgs e) {
            if(checkBox_autoSeed.Checked == true) {
                numeric_seedX.Enabled = false;
                numeric_seedY.Enabled = false;
            }
            else {
                numeric_seedX.Enabled = true;
                numeric_seedY.Enabled = true;
            }
        }
        //Update the 'dist' label, which reflects with % (where 1 is 100%) of the line the point will travel.
        private void numeric_compressionRatio_ValueChanged(object sender, EventArgs e) {
            label_dist.Text = string.Format("Dist: {0:0.####}", 1 / CompressionRatio);
        }

        //Use IFS
        private void button_ApplyIFS_Click(object sender, EventArgs e) {
            gm.AssignIFSVariables(IfsFormulas, CenterPoint, IfsMagnificationX, IfsMagnificationY, DrawAxes, IterationsToIgnore);
            groupBox_visualOptions.Enabled = false;
            tabControl_rules.Enabled = false;
            groupBox_generation.Enabled = true;
        }

        private void rules_ifs_openTable_Click(object sender, EventArgs e) {
            IFSEditor f = new IFSEditor();
            List<IFSFormula> newFormulas = f.ShowDialog(IfsFormulas);
            if(newFormulas != null) {
                IfsFormulas = newFormulas;
            }
        }

        private void checkBox_drawAxes_CheckedChanged(object sender, EventArgs e) {
            PreviewAxes();
        }

        private void UpdateCenterPointEvent(object sender, EventArgs e) {
            PreviewAxes();
        }
        #endregion

        #region Generation controls
        private void button_nextIteration_Click(object sender, EventArgs e) {
            NextFrame(1);
        }

        private void button_nextFrame_Click(object sender, EventArgs e) {
            NextFrame(Iterations);
        }

        private void button_startGen_Click(object sender, EventArgs e) {
            timer_gpGeneration.Enabled = true;
            timer_gpGeneration.Interval = Time;

            EnableGenerationControls(false);
        }

        private void button_stopGen_Click(object sender, EventArgs e) {
            timer_gpGeneration.Enabled = false;

            EnableGenerationControls(true);
        }

        private void pictureBox_highlightColor_DoubleClick(object sender, EventArgs e) {
            ColorPicker c = new ColorPicker();
            c.InitialColor = HighlightColor;
            HighlightColor = c.ShowDialog();
        }
        #endregion

        #region Other controls
        private void timer_gpGeneration_Tick(object sender, EventArgs e) {
            NextFrame(Iterations);
        }
        #endregion

        #region Controls not yet refactored
        private void button_saveBitmap_Click(object sender, EventArgs e) {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|JPG (*.jpg)|*.jpg|GIF (*.gif)|*.gif|TIFF (*.tiff)|*.tiff";
            s.Title = "Save bitmap";
            if (s.ShowDialog(this) == DialogResult.OK || s.FileName != "") {
                switch (Path.GetExtension(s.FileName)) {
                    case ".png":
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".bmp":
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".jpg":
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case ".tiff":
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    default:
                        gm.SaveBitmapToFile(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
            }
        }
        #endregion

        private void panel_bitmap_SizeChanged(object sender, EventArgs e) {
            UpdatePictureBoxPosition();
        }

        private void numeric_zoom_ValueChanged(object sender, EventArgs e) {
            if (!UpdateBitmap(true)) {
                numeric_zoom.Value = 1.00m;
            }
        }

        private void button_ruleList_Click(object sender, EventArgs e) {
            RuleEditor r = new RuleEditor();
            r.ShowDialog(Rules);
        }

        private void numeric_ifsMagnifyX_ValueChanged(object sender, EventArgs e) {
            if (LinkIfsMagnify) numeric_ifsMagnifyY.Value = numeric_ifsMagnifyX.Value;
        }

        private void numeric_ifsMagnifyY_ValueChanged(object sender, EventArgs e) {
            if (LinkIfsMagnify) numeric_ifsMagnifyX.Value = numeric_ifsMagnifyY.Value;
        }
    }
}
