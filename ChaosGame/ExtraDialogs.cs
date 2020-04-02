using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sdr = System.Drawing;
using HSVColor = System.Tuple<double, double, double>;
using ChaosGame;

namespace System.Windows.Forms.ExtraDialogs {
    public class VertexEditor {
        #region Components of the dialog
        private Form dialog = new Form() {
            ClientSize = new Drawing.Size(360, 403),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "List of points",
            StartPosition = FormStartPosition.CenterScreen,
            MaximizeBox = false,
            MinimizeBox = false,
            //HelpButton = true
        };

        private Label label_vertices = new Label() {
            Left = 10,
            Top = 10,
            AutoSize = true,
            Text = "Current points:"
        };

        private DataGridView table_vertices = new DataGridView() {
            Left = 10,
            Top = 30,
            Width = 340,
            Height = 244,
            ColumnCount = 5
        };

        private CheckBox checkBox_showAdvancedFields = new CheckBox() {
            Appearance = Appearance.Button,
            AutoSize = false,
            Left = 10,
            Top = 285,
            Width = 150,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "Show advanced properties"
        };

        private Button button_up = new Button() {
            Left = 296,
            Top = 285,
            Width = 25,
            Text = "+"
        };

        private Button button_down = new Button() {
            Left = 326,
            Top = 285,
            Width = 25,
            Text = "-"
        };

        private Button button_generatePolygon = new Button() {
            Left = 10,
            Top = 313,
            Width = 150,
            Text = "Generate regular polygon"
        };

        private Button button_generateSquare = new Button() {
            Left = 165,
            Top = 313,
            Width = 113,
            Text = "Generate rectangle"
        };

        private NumericUpDown numeric_increaseCoords = new NumericUpDown() {
            Left = 10,
            Top = 342,
            Width = 80,
            Minimum = -10000,
            Maximum = 10000,
            DecimalPlaces = 3,
            Increment = 10,
            ThousandsSeparator = true,
            Value = 10
        };

        private Button button_increaseCoords = new Button() {
            Left = 105,
            Top = 341,
            Width = 175,
            Text = "Add n to selected coordinates"
        };

        private Button button_ok = new Button() {
            Left = 276,
            Top = 369,
            Width = 75,
            Text = "OK",
            DialogResult = DialogResult.OK
        };
        #endregion

        private List<Vertex> CurrentPointList {
            get {
                List<Vertex> list = new List<Vertex>();
                foreach (DataGridViewRow row in table_vertices.Rows) {
                    if (row.IsNewRow == true) continue;

                    int x, y;
                    float compressionRate, rotation;
                    int weight;

                    //note: a "" string is not the same as null, it will be TryParse'd and will fail.
                    if (row.Cells[0].Value == null) continue;
                    else if (!int.TryParse(row.Cells[0].Value.ToString(), out int i)) continue;
                    else x = i;

                    if (row.Cells[1].Value == null) continue;
                    else if (!int.TryParse(row.Cells[1].Value.ToString(), out int i)) continue;
                    else y = i;

                    if (row.Cells[2].Value == null) compressionRate = -1;
                    else if (!float.TryParse(row.Cells[2].Value.ToString(), out float f)) continue;
                    else compressionRate = f;

                    if (row.Cells[3].Value == null) rotation = -1;
                    else if (!float.TryParse(row.Cells[3].Value.ToString(), out float f)) continue;
                    else rotation = f;

                    if (row.Cells[4].Value == null) weight = -1;
                    else if (!int.TryParse(row.Cells[4].Value.ToString(), out int i)) continue;
                    else weight = i;

                    list.Add(new Vertex(x, y, compressionRate, rotation, weight));
                }

                return list;
            }
        }

        public List<Vertex> ShowDialog(List<Vertex> vertexList, sdr::Size dimensions) {
            table_vertices.Columns[0].Name = "x";
            table_vertices.Columns[0].Width = 75;
            table_vertices.Columns[1].Name = "y";
            table_vertices.Columns[1].Width = 75;
            table_vertices.Columns[2].Name = "Compression";
            table_vertices.Columns[2].Width = 75;
            table_vertices.Columns[3].Name = "Rotation";
            table_vertices.Columns[3].Width = 75;
            table_vertices.Columns[4].Name = "Weight";
            table_vertices.Columns[4].Width = 50;

            table_vertices.Columns[2].Visible = false;
            table_vertices.Columns[3].Visible = false;
            table_vertices.Columns[4].Visible = false;

            //Whenever we input a new value in a row, we check if all values in that row are correct.
            table_vertices.CellValueChanged += (sender, e) => {
                AnalyzeRow(e.RowIndex);
            };
            //Adds the functionality of pressing the 'delete' button to delete selected cells' values.
            table_vertices.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Delete) {
                    foreach (DataGridViewCell selectedCell in table_vertices.SelectedCells) {
                        selectedCell.Value = null;
                    }
                }
            };

            foreach (Vertex v in vertexList) {
                table_vertices.Rows.Add(
                    v.X.ToString(),
                    v.Y.ToString(),
                    (v.compressionRatio == -1) ? null : v.compressionRatio.ToString(),
                    (v.rotation == -1) ? null : v.rotation.ToString(),
                    (v.weight == -1) ? null : v.weight.ToString()
                    );
            }

            checkBox_showAdvancedFields.CheckedChanged += (sender, e) => {
                if(checkBox_showAdvancedFields.Checked) {
                    table_vertices.Columns[0].Width = 40;
                    table_vertices.Columns[1].Width = 40;
                    table_vertices.Columns[2].Visible = true;
                    table_vertices.Columns[3].Visible = true;
                    table_vertices.Columns[4].Visible = true;
                }
                else {
                    table_vertices.Columns[0].Width = 65;
                    table_vertices.Columns[1].Width = 65;
                    table_vertices.Columns[2].Visible = false;
                    table_vertices.Columns[3].Visible = false;
                    table_vertices.Columns[4].Visible = false;
                }
            };

            //WARNING: This implementation treats any unselected rows between the selected ones as if they were selected.
            button_up.Click += (sender, e) => {
                int firstIndex = table_vertices.SelectedCells[0].RowIndex;
                foreach (DataGridViewCell cell in table_vertices.SelectedCells) {
                    if (table_vertices.Rows[cell.RowIndex].IsNewRow) return;
                    if (cell.RowIndex < firstIndex) {
                        firstIndex = cell.RowIndex;
                    }
                }

                int lastIndex = table_vertices.SelectedCells[0].RowIndex;
                foreach (DataGridViewCell cell in table_vertices.SelectedCells) {
                    if (cell.RowIndex > lastIndex) {
                        lastIndex = cell.RowIndex;
                    }
                }

                if (firstIndex == 0) return;

                DataGridViewRow rowToBeDescended = table_vertices.Rows[firstIndex - 1];
                table_vertices.Rows.Insert(lastIndex + 1,
                    rowToBeDescended.Cells[0].Value,
                    rowToBeDescended.Cells[1].Value,
                    rowToBeDescended.Cells[2].Value,
                    rowToBeDescended.Cells[3].Value,
                    rowToBeDescended.Cells[4].Value
                    );
                AnalyzeRow(lastIndex + 1);
                table_vertices.Rows.RemoveAt(firstIndex - 1);
            };
            button_down.Click += (sender, e) => {
                int firstIndex = table_vertices.SelectedCells[0].RowIndex;
                foreach (DataGridViewCell cell in table_vertices.SelectedCells) {
                    if (table_vertices.Rows[cell.RowIndex].IsNewRow) return;
                    if (cell.RowIndex < firstIndex) {
                        firstIndex = cell.RowIndex;
                    }
                }

                int lastIndex = table_vertices.SelectedCells[0].RowIndex;
                foreach (DataGridViewCell cell in table_vertices.SelectedCells) {
                    if (cell.RowIndex > lastIndex) {
                        lastIndex = cell.RowIndex;
                    }
                }

                if (lastIndex > table_vertices.Rows.Count - 3) return;

                DataGridViewRow rowToBeAscended = table_vertices.Rows[lastIndex + 1];
                table_vertices.Rows.Insert(firstIndex,
                    rowToBeAscended.Cells[0].Value,
                    rowToBeAscended.Cells[1].Value,
                    rowToBeAscended.Cells[2].Value,
                    rowToBeAscended.Cells[3].Value,
                    rowToBeAscended.Cells[4].Value
                    );
                AnalyzeRow(firstIndex);
                table_vertices.Rows.RemoveAt(lastIndex + 2);
            };

            button_generatePolygon.Click += (sender, e) => {
                PolygonSettings inputSettings;
                if(table_vertices.Rows.Count <= 1) inputSettings = PolygonBox.ShowDialog(false, 3, 30, false);
                else inputSettings = PolygonBox.ShowDialog(false, 3, 30, true);

                if (inputSettings.vertices == 0) return;

                if (inputSettings.overridePreviousVertices) {
                    table_vertices.Rows.Clear();
                }

                int centerX = (int)(dimensions.Width / 2f);
                int centerY = (int)(dimensions.Height / 2f);

                int radiusX = (int)((dimensions.Width / 2f) - inputSettings.margin);
                int radiusY = (int)((dimensions.Height / 2f) - inputSettings.margin);

                if (!inputSettings.traceOnEllipse) {
                    if (radiusX <= radiusY) radiusY = radiusX;
                    else radiusX = radiusY;
                }

                int vertices = inputSettings.vertices;
                for (int i = 0; i < vertices; i++) {
                    int x = centerX + (int)(radiusX * Math.Cos((2 * Math.PI * (i / (double)vertices)) + (0.5f * Math.PI)));
                    int y = centerY - (int)(radiusY * Math.Sin((2 * Math.PI * (i / (double)vertices)) + (0.5f * Math.PI)));
                    table_vertices.Rows.Add(x, y, null, null, null);
                };
            };
            
            button_generateSquare.Click += (sender, e) => {
                PolygonSettings inputSettings;
                if (table_vertices.Rows.Count <= 1) inputSettings = PolygonBox.ShowDialog(true, 4, 30, false);
                else inputSettings = PolygonBox.ShowDialog(true, 4, 30, true);

                if (inputSettings.vertices == 0) return;

                if (inputSettings.overridePreviousVertices) {
                    table_vertices.Rows.Clear();
                }

                int x1, y1, x2, y2, x3, y3, x4, y4;
                //Some of these x and y coords are equal, but it's easier to visualize the algorithm by calculating every single integer.
                if(inputSettings.traceOnEllipse) {
                    int margin = inputSettings.margin;
                    x1 = margin;
                    y1 = margin;

                    x2 = margin;
                    y2 = dimensions.Height - margin;

                    x3 = dimensions.Width - margin;
                    y3 = dimensions.Height - margin;

                    x4 = dimensions.Width - margin;
                    y4 = margin;
                }
                else {
                    int margin = inputSettings.margin;
                    int squareLength = ((dimensions.Width <= dimensions.Height) ? dimensions.Width : dimensions.Height) - (margin * 2);
                    x1 = (int)((dimensions.Width - squareLength) / 2f);
                    y1 = (int)((dimensions.Height - squareLength) / 2f);

                    x2 = x1;
                    y2 = y1 + squareLength;

                    x3 = x1 + squareLength;
                    y3 = y1 + squareLength;

                    x4 = x1 + squareLength;
                    y4 = y1;
                }
                
                table_vertices.Rows.Add(x1, y1, null, null, null);
                table_vertices.Rows.Add(x2, y2, null, null, null);
                table_vertices.Rows.Add(x3, y3, null, null, null);
                table_vertices.Rows.Add(x4, y4, null, null, null);
            };

            button_increaseCoords.Click += (sender, e) => {
                foreach (DataGridViewCell cell in table_vertices.SelectedCells) {
                    if (cell.ColumnIndex == 0 || cell.ColumnIndex == 1 || cell.ColumnIndex == 4) {
                        if (!int.TryParse(cell.Value.ToString(), out int i)) continue;
                        else cell.Value = (i + (int)numeric_increaseCoords.Value).ToString();
                    }
                    else {
                        if (!float.TryParse(cell.Value.ToString(), out float f)) continue;
                        else cell.Value = (f + (float)numeric_increaseCoords.Value).ToString();
                    }
                };
            };

            dialog.Controls.Add(label_vertices);
            dialog.Controls.Add(table_vertices);
            dialog.Controls.Add(checkBox_showAdvancedFields);
            dialog.Controls.Add(button_up);
            dialog.Controls.Add(button_down);
            dialog.Controls.Add(button_generatePolygon);
            dialog.Controls.Add(button_generateSquare);
            dialog.Controls.Add(numeric_increaseCoords);
            dialog.Controls.Add(button_increaseCoords);
            dialog.Controls.Add(button_ok);

            return dialog.ShowDialog() == DialogResult.OK ? CurrentPointList : null;
        }

        private void AnalyzeRow(int rowIndex) {
            DataGridViewRow row = table_vertices.Rows[rowIndex];

            foreach (DataGridViewCell cell in row.Cells) {
                //The x and y columns
                if (cell.ColumnIndex <= 1) {
                    if (!int.TryParse(cell.FormattedValue.ToString(), out int i)) {
                        row.ErrorText = "One of the values in this row is invalid. This row will not be saved.";
                        return;
                    }
                }
                //The compression rate, rotation and weight columns.
                else if (cell.FormattedValue.ToString() != "" && !float.TryParse(cell.FormattedValue.ToString(), out float f)) {
                    row.ErrorText = "One of the values in this row is invalid. This row will not be saved.";
                    return;
                }
            }

            row.ErrorText = "";
        }
    }

    public static class InputBox {
        public static string ShowDialog(string caption, string text, string defaultValue = "", string cancelValue = "") {
            Form dialog = new Form() {
                ClientSize = new Drawing.Size(200, 101),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label textLabel = new Label() {
                Left = 20,
                Top = 20,
                AutoSize = true,
                Text = text
            };
            TextBox textBox = new TextBox() {
                Left = 20,
                Top = 40,
                Width = 160,
                Text = defaultValue
            };
            Button confirmation = new Button() {
                Left = 105,
                Top = 68,
                Width = 75,
                Text = "OK",
                DialogResult = DialogResult.OK
            };
            //confirmation.Click += (sender, e) => dialog.Close();
            dialog.Controls.Add(textBox);
            dialog.Controls.Add(confirmation);
            dialog.Controls.Add(textLabel);
            //dialog.AcceptButton = confirmation;

            return dialog.ShowDialog() == DialogResult.OK ? textBox.Text : cancelValue;
        }
    }

    public static class PolygonBox {
        public static PolygonSettings ShowDialog(bool isSquare, int defaultVertices, int defaultMargin, bool askForOverride, bool traceOnEllipse = false, bool overrideVertices = true) {
            Form dialog = new Form() {
                ClientSize = new Drawing.Size(245, 130),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Generate regular polygon",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label label_vertices = new Label() {
                Left = 30,
                Top = 20,
                AutoSize = true,
                Text = "Vertices:"
            };

            TextBox textBox_vertices = new TextBox() {
                Left = 85,
                Top = 18,
                Width = 35,
                Text = defaultVertices.ToString(),
                TabIndex = 0
            };

            if(isSquare) {
                label_vertices.Enabled = false;
                textBox_vertices.Enabled = false;
            }

            Label label_margin = new Label() {
                Left = 130,
                Top = 20,
                AutoSize = true,
                Text = "Margin:"
            };

            TextBox textBox_margin = new TextBox() {
                Left = 180,
                Top = 18,
                Width = 35,
                Text = defaultMargin.ToString(),
                TabIndex = 1
            };
            CheckBox checkBox_traceOnEllipse = new CheckBox() {
                Left = 30,
                Top = 45,
                AutoSize = true,
                Text = "Trace polygon on a ellipse.",
                Checked = traceOnEllipse,
                TabIndex = 2
            };
            CheckBox checkBox_overrideVertices = new CheckBox() {
                Left = 30,
                Top = 65,
                AutoSize = true,
                Text = "Delete previous vertices.",
                Checked = overrideVertices,
                TabIndex = 3
            };

            Button button_ok = new Button() {
                Left = 141,
                Top = 90,
                Width = 75,
                Text = "OK",
                DialogResult = DialogResult.OK,
                TabIndex = 4
            };

            textBox_vertices.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_vertices.Text, out int i) == false) {
                    MessageBox.Show("Invalid number format for vertices.", "Invalid number format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_vertices.Text = defaultVertices.ToString();
                }
            };
            textBox_margin.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_margin.Text, out int i) == false) {
                    MessageBox.Show("Invalid number format for margin.", "Invalid number format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_margin.Text = defaultMargin.ToString();
                }
            };

            dialog.Controls.Add(label_vertices);
            dialog.Controls.Add(textBox_vertices);
            dialog.Controls.Add(label_margin);
            dialog.Controls.Add(textBox_margin);
            dialog.Controls.Add(checkBox_traceOnEllipse);
            dialog.Controls.Add(checkBox_overrideVertices);
            dialog.Controls.Add(button_ok);

            DialogResult result = dialog.ShowDialog();
            
            if (result == DialogResult.OK) {
                if(checkBox_overrideVertices.Checked == true && askForOverride == true) {
                    DialogResult replaceVertices = MessageBox.Show("Creating this polygon will remove the current vertices. Do you wish to continue?",
                        "Clear vertices",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );

                    if (replaceVertices == DialogResult.No) {
                        return ShowDialog(isSquare, int.Parse(textBox_vertices.Text), int.Parse(textBox_margin.Text), true, checkBox_traceOnEllipse.Checked);
                    }
                }
                return new PolygonSettings(int.Parse(textBox_vertices.Text), int.Parse(textBox_margin.Text), checkBox_traceOnEllipse.Checked, checkBox_overrideVertices.Checked);
            }
            else {
                return new PolygonSettings(0, 0, false, false);
            }
        }
    }

    public struct PolygonSettings {
        public int vertices;
        public int margin;
        public bool traceOnEllipse;
        public bool overridePreviousVertices;

        public PolygonSettings(int vertices, int margin, bool traceOnEllipse, bool overridePreviousVertices) {
            this.vertices = vertices;
            this.margin = margin;
            this.traceOnEllipse = traceOnEllipse;
            this.overridePreviousVertices = overridePreviousVertices;
        }
    }

    public class ColorPicker {
        private sdr::Color initialColor = sdr::Color.White;
        public sdr::Color InitialColor {
            get => initialColor;
            set {
                initialColor = value;
                CurrentColor = value;
                CurrentH = ColorToHSV(initialColor).Item1;
                CurrentAlpha = initialColor.A;
            }
        }

        private sdr::Color currentColor = sdr::Color.White;

        private sdr::Color CurrentColor {
            get => currentColor;
            set {
                currentColor = value;
                pbNewColor.BackColor = currentColor;
                HSVColor hsv = ColorToHSV(currentColor);
                textBox_HSV_H.Text = ((int)Math.Round(currentH)).ToString();
                textBox_HSV_s.Text = ((int)(hsv.Item2 * 100)).ToString();
                textBox_HSV_v.Text = ((int)(hsv.Item3 * 100)).ToString();
                textBox_RGB_R.Text = currentColor.R.ToString();
                textBox_RGB_G.Text = currentColor.G.ToString();
                textBox_RGB_B.Text = currentColor.B.ToString();
                textBox_Alpha.Text = currentColor.A.ToString();
            }
        }

        private double currentH;
        private double CurrentH {
            get => currentH;
            set {
                currentH = value;
                HSVColor hsv = ColorToHSV(CurrentColor);
                CurrentColor = ColorFromHSV(currentH, hsv.Item2, hsv.Item3);
                squarePalette.Image = GetSPBitmap();
            }
        }

        private int currentAlpha;
        private int CurrentAlpha {
            get => currentAlpha;
            set {
                currentAlpha = value;
                CurrentColor = sdr::Color.FromArgb(currentAlpha, CurrentColor.R, CurrentColor.G, CurrentColor.B);
                squarePalette.Image = GetSPBitmap();
            }
        }

        public ColorPicker() {
            CurrentH = ColorToHSV(initialColor).Item1;
            CurrentAlpha = initialColor.A;
            pbNewColor.BackColor = CurrentColor;
            pbOldColor.BackColor = InitialColor;
        }

        Label labelNewColor = new Label() {
            Left = 336,
            Top = 10,
            Width = 60,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "new"
        };

        Label labelOldColor = new Label() {
            Left = 336,
            Top = 94,
            Width = 60,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "current"
        };


        PictureBox pbNewColorBack = new PictureBox() {
            Left = 336,
            Top = 30,
            Width = 60,
            Height = 35,
            BackColor = sdr::Color.White //TODO: this does not work
        };
        PictureBox pbOldColorBack = new PictureBox() {
            Left = 336,
            Top = 64,
            Width = 60,
            Height = 35,
            BackColor = sdr::Color.White //TODO: this does not work
        };

        PictureBox pbNewColor = new PictureBox() {
            Left = 336,
            Top = 30,
            Width = 60,
            Height = 35,
            BorderStyle = BorderStyle.FixedSingle
        };
        PictureBox pbOldColor = new PictureBox() {
            Left = 336,
            Top = 64,
            Width = 60,
            Height = 35,
            BorderStyle = BorderStyle.FixedSingle
        };

        PictureBox squarePalette = new PictureBox() {
            Left = 20,
            Top = 20,
            Width = 256,
            Height = 256,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = sdr::Color.White
        };

        PictureBox huePalette = new PictureBox() {
            Left = 296,
            Top = 20,
            Width = 20,
            Height = 256,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = sdr::Color.White
        };

        PictureBox alphaPalette = new PictureBox() {
            Left = 20,
            Top = 296,
            Width = 256,
            Height = 20,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = sdr::Color.White
        };

        #region Textbox showing the color value.
        Label labelHSV_H = new Label() {
            Left = 336,
            Top = 120,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "H:"
        };
        Label labelHSV_s = new Label() {
            Left = 336,
            Top = 145,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "s:"
        };
        Label labelHSV_v = new Label() {
            Left = 336,
            Top = 170,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "v:"
        };
        TextBox textBox_HSV_H = new TextBox() {
            Left = 356,
            Top = 123,
            Width = 30,
            Text = "55"
        };
        TextBox textBox_HSV_s = new TextBox() {
            Left = 356,
            Top = 148,
            Width = 30,
            Text = "55"
        };
        TextBox textBox_HSV_v = new TextBox() {
            Left = 356,
            Top = 173,
            Width = 30,
            Text = "55"
        };

        Label labelRGB_R = new Label() {
            Left = 336,
            Top = 203,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "R:"
        };
        Label labelRGB_G = new Label() {
            Left = 336,
            Top = 228,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "G:"
        };
        Label labelRGB_B = new Label() {
            Left = 336,
            Top = 253,
            Width = 20,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "B:"
        };
        TextBox textBox_RGB_R = new TextBox() {
            Left = 356,
            Top = 206,
            Width = 30,
            Text = "55"
        };
        TextBox textBox_RGB_G = new TextBox() {
            Left = 356,
            Top = 231,
            Width = 30,
            Text = "55"
        };
        TextBox textBox_RGB_B = new TextBox() {
            Left = 356,
            Top = 256,
            Width = 30,
            Text = "55"
        };
        Label label_Alpha = new Label() {
            Left = 316,
            Top = 293,
            Width = 40,
            TextAlign = sdr::ContentAlignment.MiddleCenter,
            Text = "Alpha:"
        };
        TextBox textBox_Alpha = new TextBox() {
            Left = 356,
            Top = 296,
            Width = 30,
            Text = "55"
        };
        #endregion

        public sdr::Color ShowDialog(string text = "Color picker") {
            Form dialog = new Form() {
                ClientSize = new Drawing.Size(520, 350),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = text,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Timer SPTimer = new Timer() {
                Interval = 10,
                Enabled = false
            };

            SPTimer.Tick += (sender, e) => {
                sdr::Point cursorPos = squarePalette.PointToClient(Cursor.Position);
                if (cursorPos.X < 0) cursorPos.X = 0;
                if (cursorPos.X > 255) cursorPos.X = 255;
                if (cursorPos.Y < 0) cursorPos.Y = 0;
                if (cursorPos.Y > 255) cursorPos.Y = 255;
                CurrentColor = ColorFromHSV(CurrentH, cursorPos.X / 255d, 1 - (cursorPos.Y / 255d));
                pbNewColor.BackColor = CurrentColor;
            };

            squarePalette.MouseDown += (sender, e) => SPTimer.Enabled = true;
            squarePalette.MouseUp += (sender, e) => SPTimer.Enabled = false;

            squarePalette.Image = GetSPBitmap();

            Timer HPTimer = new Timer() {
                Interval = 10,
                Enabled = false
            };

            HPTimer.Tick += (sender, e) => {
                sdr::Point cursorPos = squarePalette.PointToClient(Cursor.Position);
                if (cursorPos.Y < 0) cursorPos.Y = 0;
                if (cursorPos.Y > 255) cursorPos.Y = 255;
                CurrentH = 360 - (cursorPos.Y * 360 / 255d);
                squarePalette.Image = GetSPBitmap();
                pbNewColor.BackColor = CurrentColor;
            };

            huePalette.MouseDown += (sender, e) => HPTimer.Enabled = true;
            huePalette.MouseUp += (sender, e) => HPTimer.Enabled = false;

            huePalette.Image = GetHueBitmap();

            Timer alphaTimer = new Timer() {
                Interval = 1,
                Enabled = false
            };

            alphaTimer.Tick += (sender, e) => {
                sdr::Point cursorPos = alphaPalette.PointToClient(Cursor.Position);
                if (cursorPos.X < 0) cursorPos.X = 0;
                if (cursorPos.X > 255) cursorPos.X = 255;
                CurrentAlpha = cursorPos.X;
                squarePalette.Image = GetSPBitmap();
                huePalette.Image = GetHueBitmap();
                pbNewColor.BackColor = CurrentColor;
            };

            alphaPalette.MouseDown += (sender, e) => alphaTimer.Enabled = true;
            alphaPalette.MouseUp += (sender, e) => alphaTimer.Enabled = false;

            alphaPalette.Image = GetHueBitmap();

            alphaPalette.Image = GetAlphaBitmap();

            Button button_ok = new Button() {
                Left = 430, //last control at 396
                Top = 20,
                Width = 75,
                Text = "OK",
                DialogResult = DialogResult.OK
            };

            Button button_cancel = new Button() {
                Left = 430, //last control at 396
                Top = 50,
                Width = 75,
                Text = "Cancel",
                DialogResult = DialogResult.Cancel
            };

            #region Add events to Hsv, RGB:
            textBox_HSV_H.LostFocus += (sender, e) => {
                if (double.TryParse(textBox_HSV_H.Text, out double newH)) {
                    if(newH > 360 || newH < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        CurrentH = newH;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_HSV_s.LostFocus += (sender, e) => {
                if (double.TryParse(textBox_HSV_s.Text, out double news)) {
                    news /= 100d;
                    if (news > 1 || news < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        HSVColor currentHSV = ColorToHSV(CurrentColor);
                        //If we call CurrentColor instead of currentColor, we'll update this box instantly and the new number may not be the same as the old one.
                        currentColor = ColorFromHSV(currentHSV.Item1, news, currentHSV.Item3);
                        pbNewColor.BackColor = currentColor;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_HSV_v.LostFocus += (sender, e) => {
                if (double.TryParse(textBox_HSV_v.Text, out double newv)) {
                    newv /= 100d;
                    if (newv > 1 || newv < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        HSVColor currentHSV = ColorToHSV(CurrentColor);
                        //If we call CurrentColor instead of currentColor, we'll update this box instantly and the new number may not be the same as the old one.
                        currentColor = ColorFromHSV(currentHSV.Item1, currentHSV.Item2, newv);
                        pbNewColor.BackColor = currentColor;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_RGB_R.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_RGB_R.Text, out int newR)) {
                    if (newR > 255 || newR < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        CurrentColor = sdr::Color.FromArgb(CurrentAlpha, newR, CurrentColor.G, CurrentColor.B);
                        CurrentH = ColorToHSV(CurrentColor).Item1;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_RGB_G.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_RGB_G.Text, out int newG)) {
                    if (newG > 255 || newG < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        CurrentColor = sdr::Color.FromArgb(CurrentAlpha, CurrentColor.R, newG, CurrentColor.B);
                        CurrentH = ColorToHSV(CurrentColor).Item1;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_RGB_B.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_RGB_B.Text, out int newB)) {
                    if (newB > 255 || newB < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        CurrentColor = sdr::Color.FromArgb(CurrentAlpha, CurrentColor.R, CurrentColor.G, newB);
                        CurrentH = ColorToHSV(CurrentColor).Item1;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            textBox_Alpha.LostFocus += (sender, e) => {
                if (int.TryParse(textBox_Alpha.Text, out int newAlpha)) {
                    if (newAlpha > 255 || newAlpha < 0) {
                        CurrentColor = CurrentColor;
                    }
                    else {
                        CurrentAlpha = newAlpha;
                    }
                }
                else {
                    CurrentColor = CurrentColor;
                }
            };
            #endregion

            #region 'Common colors' group.
            GroupBox commonColorsGB = new GroupBox() {
                Left = 402,
                Top = 117,
                Width = 102,
                Height = 200,
                Text = "Common colors"
            };

            sdr::Color[] commonColors = new sdr::Color[21] {
                sdr::Color.Red,
                sdr::Color.Blue,
                sdr::Color.Lime,

                sdr::Color.FromArgb(192, 0, 0),
                sdr::Color.Navy,
                sdr::Color.Green,

                sdr::Color.FromArgb(128, 64, 0),
                sdr::Color.FromArgb(0, 128, 255),
                sdr::Color.FromArgb(0, 64, 0),

                sdr::Color.FromArgb(255, 128, 0),
                sdr::Color.Aqua,
                sdr::Color.Magenta,

                sdr::Color.FromArgb(255, 192, 0),
                sdr::Color.FromArgb(64, 0, 128),
                sdr::Color.FromArgb(128, 0, 255),

                sdr::Color.Yellow,
                sdr::Color.Olive,
                sdr::Color.Silver,
                
                sdr::Color.Black,
                sdr::Color.Gray,
                sdr::Color.White,
            };

            //the 'area' to be filled in, with a margin of 5 from each side, starts at (6, 16) and has width 90 and height 177.

            int commonColorsCount = 0;
            for(int row = 0; row < 7; row++) {
                for (int column = 0; column < 3; column++) {
                    PictureBox commonColorPB = new PictureBox() {
                        Left = 8 + (31 * column),
                        Top = 17 + (26 * row),
                        Width = 24,
                        Height = 19,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = commonColors[commonColorsCount++]
                    };

                    //If this color dialog wasn't full of hardcoding, changing CurrentColor would update CurrentH and CurrentAlpha. But it doesn't.
                    commonColorPB.Click += (sender, e) => {
                        CurrentColor = commonColorPB.BackColor;
                        CurrentH = ColorToHSV(CurrentColor).Item1;
                        CurrentAlpha = 255;
                    };

                    commonColorsGB.Controls.Add(commonColorPB);
                }
            }

            PictureBox newColorTest = new PictureBox() {
                Left = 6,
                Top = 16,
                Width = 90,
                Height = 177,
                BorderStyle = BorderStyle.FixedSingle
            };

            dialog.Controls.Add(commonColorsGB);
            //commonColorsGB.Controls.Add(newColorTest);
            #endregion

            dialog.Controls.Add(pbNewColor);
            dialog.Controls.Add(pbOldColor);
            dialog.Controls.Add(pbNewColorBack);
            dialog.Controls.Add(pbOldColorBack);
            dialog.Controls.Add(labelNewColor);
            dialog.Controls.Add(labelOldColor);
            dialog.Controls.Add(squarePalette);
            dialog.Controls.Add(huePalette);
            dialog.Controls.Add(alphaPalette);
            //Textboxes
            dialog.Controls.Add(labelHSV_H);
            dialog.Controls.Add(labelHSV_s);
            dialog.Controls.Add(labelHSV_v);
            dialog.Controls.Add(textBox_HSV_H);
            dialog.Controls.Add(textBox_HSV_s);
            dialog.Controls.Add(textBox_HSV_v);

            dialog.Controls.Add(labelRGB_R);
            dialog.Controls.Add(labelRGB_G);
            dialog.Controls.Add(labelRGB_B);
            dialog.Controls.Add(textBox_RGB_R);
            dialog.Controls.Add(textBox_RGB_G);
            dialog.Controls.Add(textBox_RGB_B);
            dialog.Controls.Add(label_Alpha);
            dialog.Controls.Add(textBox_Alpha);

            dialog.Controls.Add(button_ok);
            dialog.Controls.Add(button_cancel);

            return dialog.ShowDialog() == DialogResult.OK ? CurrentColor : InitialColor;
        }

        private sdr::Bitmap GetSPBitmap() {
            sdr::Bitmap bitmap_sp = new sdr::Bitmap(256, 256);
            for (int x = 0; x < 256; x++) {
                for (int y = 0; y < 256; y++) {
                    bitmap_sp.SetPixel(x, y, ColorFromHSV(CurrentH, x / 255d, 1 - (y / 255d)));
                }
            }
            return bitmap_sp;
        }

        private sdr::Bitmap GetHueBitmap() {
            sdr::Bitmap bitmap_sp = new sdr::Bitmap(20, 256);
            for (int x = 0; x < 20; x++) {
                for (int y = 0; y < 256; y++) {
                    bitmap_sp.SetPixel(x, y, ColorFromHSV(360 - (y * 360 / 255d), 1, 1));
                }
            }
            return bitmap_sp;
        }

        private sdr::Bitmap GetAlphaBitmap() {
            sdr::Bitmap bitmap_sp = new sdr::Bitmap(256, 20);
            for (int x = 0; x < 256; x++) {
                for (int y = 0; y < 20; y++) {
                    bitmap_sp.SetPixel(x, y, sdr::Color.FromArgb(x, 0, 0, 0));
                }
            }
            return bitmap_sp;
        }

        private sdr::Color ColorFromHSV(double hue, double saturation, double value) {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return sdr::Color.FromArgb(currentAlpha, v, t, p);
            else if (hi == 1)
                return sdr::Color.FromArgb(currentAlpha, q, v, p);
            else if (hi == 2)
                return sdr::Color.FromArgb(currentAlpha, p, v, t);
            else if (hi == 3)
                return sdr::Color.FromArgb(currentAlpha, p, q, v);
            else if (hi == 4)
                return sdr::Color.FromArgb(currentAlpha, t, p, v);
            else
                return sdr::Color.FromArgb(currentAlpha, v, p, q);
        }

        private HSVColor ColorToHSV(sdr::Color color) {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            double hue = color.GetHue();
            double saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            double value = max / 255d;

            return new HSVColor(hue, saturation, value);
        }
    }

}
