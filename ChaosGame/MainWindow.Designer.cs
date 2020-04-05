namespace ChaosGame {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.layout_table = new System.Windows.Forms.TableLayoutPanel();
            this.layout_optionPanels = new System.Windows.Forms.Panel();
            this.groupBox_visualOptions = new System.Windows.Forms.GroupBox();
            this.button_applyVisualOptions = new System.Windows.Forms.Button();
            this.groupBox_gp = new System.Windows.Forms.GroupBox();
            this.label_gpSize = new System.Windows.Forms.Label();
            this.label_gpColor = new System.Windows.Forms.Label();
            this.pictureBox_gpColor = new System.Windows.Forms.PictureBox();
            this.numeric_gpSize = new System.Windows.Forms.NumericUpDown();
            this.label_gpColorVal = new System.Windows.Forms.Label();
            this.groupBox_imgDim = new System.Windows.Forms.GroupBox();
            this.button_dimRectangle = new System.Windows.Forms.Button();
            this.button_dimSquare = new System.Windows.Forms.Button();
            this.label_imgHeight = new System.Windows.Forms.Label();
            this.numeric_imgHeight = new System.Windows.Forms.NumericUpDown();
            this.label_imgWidth = new System.Windows.Forms.Label();
            this.numeric_imgWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox_vertex = new System.Windows.Forms.GroupBox();
            this.checkBox_ipOnTop = new System.Windows.Forms.CheckBox();
            this.label_vertexSize = new System.Windows.Forms.Label();
            this.label_vertexColor = new System.Windows.Forms.Label();
            this.pictureBox_vertexColor = new System.Windows.Forms.PictureBox();
            this.numeric_vertexSize = new System.Windows.Forms.NumericUpDown();
            this.label_vertexColorVal = new System.Windows.Forms.Label();
            this.pictureBox_bgColor = new System.Windows.Forms.PictureBox();
            this.label_bgColorVal = new System.Windows.Forms.Label();
            this.label_imgBgColor = new System.Windows.Forms.Label();
            this.numeric_ignoreIterationsVal = new System.Windows.Forms.NumericUpDown();
            this.label_ignoreIterations = new System.Windows.Forms.Label();
            this.button_clearRules = new System.Windows.Forms.Button();
            this.button_clearVertices = new System.Windows.Forms.Button();
            this.checkBox_addVertexOnClick = new System.Windows.Forms.CheckBox();
            this.button_ApplyRulesOptions = new System.Windows.Forms.Button();
            this.button_ruleList = new System.Windows.Forms.Button();
            this.label_gpFirstY = new System.Windows.Forms.Label();
            this.numeric_rotation = new System.Windows.Forms.NumericUpDown();
            this.numeric_compressionRatio = new System.Windows.Forms.NumericUpDown();
            this.label_rotation = new System.Windows.Forms.Label();
            this.button_pointList = new System.Windows.Forms.Button();
            this.label_dist = new System.Windows.Forms.Label();
            this.label_compression = new System.Windows.Forms.Label();
            this.label_gpFirstX = new System.Windows.Forms.Label();
            this.label_rulesCount = new System.Windows.Forms.Label();
            this.label_pointCount = new System.Windows.Forms.Label();
            this.numeric_seedY = new System.Windows.Forms.NumericUpDown();
            this.label_gpFirstPos = new System.Windows.Forms.Label();
            this.numeric_seedX = new System.Windows.Forms.NumericUpDown();
            this.checkBox_autoSeed = new System.Windows.Forms.CheckBox();
            this.groupBox_generation = new System.Windows.Forms.GroupBox();
            this.checkBox_highlightSel = new System.Windows.Forms.CheckBox();
            this.button_stopGen = new System.Windows.Forms.Button();
            this.button_startGen = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.pictureBox_highlightColor = new System.Windows.Forms.PictureBox();
            this.label_highlightVal = new System.Windows.Forms.Label();
            this.label_iterations = new System.Windows.Forms.Label();
            this.label_highlightSel = new System.Windows.Forms.Label();
            this.button_nextFrame = new System.Windows.Forms.Button();
            this.button_nextIteration = new System.Windows.Forms.Button();
            this.numeric_time = new System.Windows.Forms.NumericUpDown();
            this.numeric_iterations = new System.Windows.Forms.NumericUpDown();
            this.groupBox_rules2 = new System.Windows.Forms.GroupBox();
            this.button_saveBitmap = new System.Windows.Forms.Button();
            this.groupBox_restrictions = new System.Windows.Forms.GroupBox();
            this.checkBox_rule3 = new System.Windows.Forms.CheckBox();
            this.checkBox_rule2 = new System.Windows.Forms.CheckBox();
            this.checkBox_rule1 = new System.Windows.Forms.CheckBox();
            this.numeric_rule2Val = new System.Windows.Forms.NumericUpDown();
            this.numeric_zoom = new System.Windows.Forms.NumericUpDown();
            this.button_restart = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_new = new System.Windows.Forms.Button();
            this.panel_bitmap = new System.Windows.Forms.Panel();
            this.pictureBox_bitmap = new System.Windows.Forms.PictureBox();
            this.timer_gpGeneration = new System.Windows.Forms.Timer(this.components);
            this.checkBox_drawSides = new System.Windows.Forms.CheckBox();
            this.label_sideColorVal = new System.Windows.Forms.Label();
            this.pictureBox_sideColor = new System.Windows.Forms.PictureBox();
            this.label_sideColor = new System.Windows.Forms.Label();
            this.tabControl_rules = new System.Windows.Forms.TabControl();
            this.tab_vertices = new System.Windows.Forms.TabPage();
            this.tab_IFS = new System.Windows.Forms.TabPage();
            this.rules_ifs_openTable = new System.Windows.Forms.Button();
            this.label_formulaCount = new System.Windows.Forms.Label();
            this.button_ApplyIFS = new System.Windows.Forms.Button();
            this.label_ifsMagnifyX = new System.Windows.Forms.Label();
            this.numeric_ifsMagnifyX = new System.Windows.Forms.NumericUpDown();
            this.groupBox_centerPoint = new System.Windows.Forms.GroupBox();
            this.label_cpX = new System.Windows.Forms.Label();
            this.numeric_cpX = new System.Windows.Forms.NumericUpDown();
            this.label_cpY = new System.Windows.Forms.Label();
            this.numeric_cpY = new System.Windows.Forms.NumericUpDown();
            this.checkBox_drawAxes = new System.Windows.Forms.CheckBox();
            this.checkBox_import = new System.Windows.Forms.CheckBox();
            this.button_import = new System.Windows.Forms.Button();
            this.numeric_ifsMagnifyY = new System.Windows.Forms.NumericUpDown();
            this.label_ifsMagnifyY = new System.Windows.Forms.Label();
            this.checkBox_linkIfsMagnify = new System.Windows.Forms.CheckBox();
            this.numeric_ifs_ignoreIterationsVal = new System.Windows.Forms.NumericUpDown();
            this.label_ifs_ignoreIterations = new System.Windows.Forms.Label();
            this.button_loadPreset = new System.Windows.Forms.Button();
            this.button_savePreset = new System.Windows.Forms.Button();
            this.layout_table.SuspendLayout();
            this.layout_optionPanels.SuspendLayout();
            this.groupBox_visualOptions.SuspendLayout();
            this.groupBox_gp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gpColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gpSize)).BeginInit();
            this.groupBox_imgDim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_imgHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_imgWidth)).BeginInit();
            this.groupBox_vertex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vertexColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_vertexSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bgColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ignoreIterationsVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_rotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_compressionRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seedX)).BeginInit();
            this.groupBox_generation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_highlightColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_iterations)).BeginInit();
            this.groupBox_rules2.SuspendLayout();
            this.groupBox_restrictions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_rule2Val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_zoom)).BeginInit();
            this.panel_bitmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bitmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sideColor)).BeginInit();
            this.tabControl_rules.SuspendLayout();
            this.tab_vertices.SuspendLayout();
            this.tab_IFS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifsMagnifyX)).BeginInit();
            this.groupBox_centerPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cpX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cpY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifsMagnifyY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifs_ignoreIterationsVal)).BeginInit();
            this.SuspendLayout();
            // 
            // layout_table
            // 
            this.layout_table.ColumnCount = 2;
            this.layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.layout_table.Controls.Add(this.layout_optionPanels, 1, 0);
            this.layout_table.Controls.Add(this.panel_bitmap, 0, 0);
            this.layout_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_table.Location = new System.Drawing.Point(0, 0);
            this.layout_table.Name = "layout_table";
            this.layout_table.RowCount = 1;
            this.layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_table.Size = new System.Drawing.Size(1008, 729);
            this.layout_table.TabIndex = 0;
            // 
            // layout_optionPanels
            // 
            this.layout_optionPanels.AutoScroll = true;
            this.layout_optionPanels.Controls.Add(this.button_savePreset);
            this.layout_optionPanels.Controls.Add(this.button_loadPreset);
            this.layout_optionPanels.Controls.Add(this.tabControl_rules);
            this.layout_optionPanels.Controls.Add(this.groupBox_visualOptions);
            this.layout_optionPanels.Controls.Add(this.groupBox_generation);
            this.layout_optionPanels.Controls.Add(this.groupBox_rules2);
            this.layout_optionPanels.Controls.Add(this.button_restart);
            this.layout_optionPanels.Controls.Add(this.button_clear);
            this.layout_optionPanels.Controls.Add(this.button_new);
            this.layout_optionPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_optionPanels.Location = new System.Drawing.Point(723, 0);
            this.layout_optionPanels.Margin = new System.Windows.Forms.Padding(0);
            this.layout_optionPanels.Name = "layout_optionPanels";
            this.layout_optionPanels.Size = new System.Drawing.Size(285, 729);
            this.layout_optionPanels.TabIndex = 0;
            // 
            // groupBox_visualOptions
            // 
            this.groupBox_visualOptions.Controls.Add(this.button_import);
            this.groupBox_visualOptions.Controls.Add(this.button_applyVisualOptions);
            this.groupBox_visualOptions.Controls.Add(this.checkBox_import);
            this.groupBox_visualOptions.Controls.Add(this.groupBox_gp);
            this.groupBox_visualOptions.Controls.Add(this.groupBox_imgDim);
            this.groupBox_visualOptions.Controls.Add(this.groupBox_vertex);
            this.groupBox_visualOptions.Controls.Add(this.pictureBox_bgColor);
            this.groupBox_visualOptions.Controls.Add(this.label_bgColorVal);
            this.groupBox_visualOptions.Controls.Add(this.label_imgBgColor);
            this.groupBox_visualOptions.Location = new System.Drawing.Point(13, 42);
            this.groupBox_visualOptions.Name = "groupBox_visualOptions";
            this.groupBox_visualOptions.Size = new System.Drawing.Size(250, 286);
            this.groupBox_visualOptions.TabIndex = 0;
            this.groupBox_visualOptions.TabStop = false;
            this.groupBox_visualOptions.Text = "Visual options";
            // 
            // button_applyVisualOptions
            // 
            this.button_applyVisualOptions.Location = new System.Drawing.Point(170, 255);
            this.button_applyVisualOptions.Name = "button_applyVisualOptions";
            this.button_applyVisualOptions.Size = new System.Drawing.Size(75, 23);
            this.button_applyVisualOptions.TabIndex = 105;
            this.button_applyVisualOptions.Text = "Apply";
            this.button_applyVisualOptions.UseVisualStyleBackColor = true;
            this.button_applyVisualOptions.Click += new System.EventHandler(this.button_applyVisualOptions_Click);
            // 
            // groupBox_gp
            // 
            this.groupBox_gp.Controls.Add(this.label_gpSize);
            this.groupBox_gp.Controls.Add(this.label_gpColor);
            this.groupBox_gp.Controls.Add(this.pictureBox_gpColor);
            this.groupBox_gp.Controls.Add(this.numeric_gpSize);
            this.groupBox_gp.Controls.Add(this.label_gpColorVal);
            this.groupBox_gp.Location = new System.Drawing.Point(6, 206);
            this.groupBox_gp.Name = "groupBox_gp";
            this.groupBox_gp.Size = new System.Drawing.Size(237, 43);
            this.groupBox_gp.TabIndex = 104;
            this.groupBox_gp.TabStop = false;
            this.groupBox_gp.Text = "Generated points";
            // 
            // label_gpSize
            // 
            this.label_gpSize.AutoSize = true;
            this.label_gpSize.Location = new System.Drawing.Point(6, 16);
            this.label_gpSize.Name = "label_gpSize";
            this.label_gpSize.Size = new System.Drawing.Size(30, 13);
            this.label_gpSize.TabIndex = 10;
            this.label_gpSize.Text = "Size:";
            // 
            // label_gpColor
            // 
            this.label_gpColor.AutoSize = true;
            this.label_gpColor.Location = new System.Drawing.Point(103, 16);
            this.label_gpColor.Name = "label_gpColor";
            this.label_gpColor.Size = new System.Drawing.Size(34, 13);
            this.label_gpColor.TabIndex = 10;
            this.label_gpColor.Text = "Color:";
            // 
            // pictureBox_gpColor
            // 
            this.pictureBox_gpColor.BackColor = System.Drawing.Color.Black;
            this.pictureBox_gpColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_gpColor.Location = new System.Drawing.Point(200, 14);
            this.pictureBox_gpColor.Name = "pictureBox_gpColor";
            this.pictureBox_gpColor.Size = new System.Drawing.Size(31, 20);
            this.pictureBox_gpColor.TabIndex = 8;
            this.pictureBox_gpColor.TabStop = false;
            this.pictureBox_gpColor.DoubleClick += new System.EventHandler(this.pictureBox_gpColor_DoubleClick);
            // 
            // numeric_gpSize
            // 
            this.numeric_gpSize.Location = new System.Drawing.Point(42, 14);
            this.numeric_gpSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gpSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gpSize.Name = "numeric_gpSize";
            this.numeric_gpSize.Size = new System.Drawing.Size(55, 20);
            this.numeric_gpSize.TabIndex = 108;
            this.numeric_gpSize.ThousandsSeparator = true;
            this.numeric_gpSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label_gpColorVal
            // 
            this.label_gpColorVal.AutoSize = true;
            this.label_gpColorVal.Location = new System.Drawing.Point(134, 16);
            this.label_gpColorVal.Name = "label_gpColorVal";
            this.label_gpColorVal.Size = new System.Drawing.Size(62, 13);
            this.label_gpColorVal.TabIndex = 6;
            this.label_gpColorVal.Text = "#000000FF";
            // 
            // groupBox_imgDim
            // 
            this.groupBox_imgDim.Controls.Add(this.button_dimRectangle);
            this.groupBox_imgDim.Controls.Add(this.button_dimSquare);
            this.groupBox_imgDim.Controls.Add(this.label_imgHeight);
            this.groupBox_imgDim.Controls.Add(this.numeric_imgHeight);
            this.groupBox_imgDim.Controls.Add(this.label_imgWidth);
            this.groupBox_imgDim.Controls.Add(this.numeric_imgWidth);
            this.groupBox_imgDim.Location = new System.Drawing.Point(6, 16);
            this.groupBox_imgDim.Name = "groupBox_imgDim";
            this.groupBox_imgDim.Size = new System.Drawing.Size(236, 68);
            this.groupBox_imgDim.TabIndex = 103;
            this.groupBox_imgDim.TabStop = false;
            this.groupBox_imgDim.Text = "Bitmap dimensions:";
            // 
            // button_dimRectangle
            // 
            this.button_dimRectangle.Location = new System.Drawing.Point(121, 40);
            this.button_dimRectangle.Name = "button_dimRectangle";
            this.button_dimRectangle.Size = new System.Drawing.Size(109, 23);
            this.button_dimRectangle.TabIndex = 105;
            this.button_dimRectangle.Text = "Generate rectangle";
            this.button_dimRectangle.UseVisualStyleBackColor = true;
            this.button_dimRectangle.Click += new System.EventHandler(this.button_dimRectangle_Click);
            // 
            // button_dimSquare
            // 
            this.button_dimSquare.Location = new System.Drawing.Point(6, 40);
            this.button_dimSquare.Name = "button_dimSquare";
            this.button_dimSquare.Size = new System.Drawing.Size(109, 23);
            this.button_dimSquare.TabIndex = 105;
            this.button_dimSquare.Text = "Generate square";
            this.button_dimSquare.UseVisualStyleBackColor = true;
            this.button_dimSquare.Click += new System.EventHandler(this.button_dimSquare_Click);
            // 
            // label_imgHeight
            // 
            this.label_imgHeight.AutoSize = true;
            this.label_imgHeight.Location = new System.Drawing.Point(6, 16);
            this.label_imgHeight.Name = "label_imgHeight";
            this.label_imgHeight.Size = new System.Drawing.Size(41, 13);
            this.label_imgHeight.TabIndex = 0;
            this.label_imgHeight.Text = "Height:";
            // 
            // numeric_imgHeight
            // 
            this.numeric_imgHeight.Location = new System.Drawing.Point(50, 14);
            this.numeric_imgHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_imgHeight.Name = "numeric_imgHeight";
            this.numeric_imgHeight.Size = new System.Drawing.Size(65, 20);
            this.numeric_imgHeight.TabIndex = 103;
            this.numeric_imgHeight.ThousandsSeparator = true;
            this.numeric_imgHeight.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.numeric_imgHeight.ValueChanged += new System.EventHandler(this.UpdatePictureBoxEvent);
            // 
            // label_imgWidth
            // 
            this.label_imgWidth.AutoSize = true;
            this.label_imgWidth.Location = new System.Drawing.Point(124, 16);
            this.label_imgWidth.Name = "label_imgWidth";
            this.label_imgWidth.Size = new System.Drawing.Size(38, 13);
            this.label_imgWidth.TabIndex = 0;
            this.label_imgWidth.Text = "Width:";
            // 
            // numeric_imgWidth
            // 
            this.numeric_imgWidth.Location = new System.Drawing.Point(165, 14);
            this.numeric_imgWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_imgWidth.Name = "numeric_imgWidth";
            this.numeric_imgWidth.Size = new System.Drawing.Size(65, 20);
            this.numeric_imgWidth.TabIndex = 104;
            this.numeric_imgWidth.ThousandsSeparator = true;
            this.numeric_imgWidth.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.numeric_imgWidth.ValueChanged += new System.EventHandler(this.UpdatePictureBoxEvent);
            // 
            // groupBox_vertex
            // 
            this.groupBox_vertex.Controls.Add(this.checkBox_ipOnTop);
            this.groupBox_vertex.Controls.Add(this.label_vertexSize);
            this.groupBox_vertex.Controls.Add(this.label_vertexColor);
            this.groupBox_vertex.Controls.Add(this.pictureBox_vertexColor);
            this.groupBox_vertex.Controls.Add(this.numeric_vertexSize);
            this.groupBox_vertex.Controls.Add(this.label_vertexColorVal);
            this.groupBox_vertex.Location = new System.Drawing.Point(6, 138);
            this.groupBox_vertex.Name = "groupBox_vertex";
            this.groupBox_vertex.Size = new System.Drawing.Size(237, 62);
            this.groupBox_vertex.TabIndex = 11;
            this.groupBox_vertex.TabStop = false;
            this.groupBox_vertex.Text = "Vertices";
            // 
            // checkBox_ipOnTop
            // 
            this.checkBox_ipOnTop.AutoSize = true;
            this.checkBox_ipOnTop.Checked = true;
            this.checkBox_ipOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ipOnTop.Location = new System.Drawing.Point(6, 39);
            this.checkBox_ipOnTop.Name = "checkBox_ipOnTop";
            this.checkBox_ipOnTop.Size = new System.Drawing.Size(176, 17);
            this.checkBox_ipOnTop.TabIndex = 107;
            this.checkBox_ipOnTop.Text = "Keep initial points always on top";
            this.checkBox_ipOnTop.UseVisualStyleBackColor = true;
            this.checkBox_ipOnTop.CheckedChanged += new System.EventHandler(this.checkBox_ipOnTop_CheckedChanged);
            // 
            // label_vertexSize
            // 
            this.label_vertexSize.AutoSize = true;
            this.label_vertexSize.Location = new System.Drawing.Point(6, 16);
            this.label_vertexSize.Name = "label_vertexSize";
            this.label_vertexSize.Size = new System.Drawing.Size(30, 13);
            this.label_vertexSize.TabIndex = 10;
            this.label_vertexSize.Text = "Size:";
            // 
            // label_vertexColor
            // 
            this.label_vertexColor.AutoSize = true;
            this.label_vertexColor.Location = new System.Drawing.Point(103, 16);
            this.label_vertexColor.Name = "label_vertexColor";
            this.label_vertexColor.Size = new System.Drawing.Size(34, 13);
            this.label_vertexColor.TabIndex = 10;
            this.label_vertexColor.Text = "Color:";
            // 
            // pictureBox_vertexColor
            // 
            this.pictureBox_vertexColor.BackColor = System.Drawing.Color.Red;
            this.pictureBox_vertexColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_vertexColor.Location = new System.Drawing.Point(200, 14);
            this.pictureBox_vertexColor.Name = "pictureBox_vertexColor";
            this.pictureBox_vertexColor.Size = new System.Drawing.Size(31, 20);
            this.pictureBox_vertexColor.TabIndex = 8;
            this.pictureBox_vertexColor.TabStop = false;
            this.pictureBox_vertexColor.DoubleClick += new System.EventHandler(this.pictureBox_vertexColor_DoubleClick);
            // 
            // numeric_vertexSize
            // 
            this.numeric_vertexSize.Location = new System.Drawing.Point(42, 14);
            this.numeric_vertexSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_vertexSize.Name = "numeric_vertexSize";
            this.numeric_vertexSize.Size = new System.Drawing.Size(55, 20);
            this.numeric_vertexSize.TabIndex = 106;
            this.numeric_vertexSize.ThousandsSeparator = true;
            this.numeric_vertexSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label_vertexColorVal
            // 
            this.label_vertexColorVal.AutoSize = true;
            this.label_vertexColorVal.Location = new System.Drawing.Point(134, 16);
            this.label_vertexColorVal.Name = "label_vertexColorVal";
            this.label_vertexColorVal.Size = new System.Drawing.Size(62, 13);
            this.label_vertexColorVal.TabIndex = 6;
            this.label_vertexColorVal.Text = "#FF0000FF";
            // 
            // pictureBox_bgColor
            // 
            this.pictureBox_bgColor.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_bgColor.Location = new System.Drawing.Point(161, 85);
            this.pictureBox_bgColor.Name = "pictureBox_bgColor";
            this.pictureBox_bgColor.Size = new System.Drawing.Size(79, 20);
            this.pictureBox_bgColor.TabIndex = 8;
            this.pictureBox_bgColor.TabStop = false;
            this.pictureBox_bgColor.DoubleClick += new System.EventHandler(this.pictureBox_bgColor_DoubleClick);
            // 
            // label_bgColorVal
            // 
            this.label_bgColorVal.AutoSize = true;
            this.label_bgColorVal.Location = new System.Drawing.Point(80, 87);
            this.label_bgColorVal.Name = "label_bgColorVal";
            this.label_bgColorVal.Size = new System.Drawing.Size(62, 13);
            this.label_bgColorVal.TabIndex = 6;
            this.label_bgColorVal.Text = "#FFFFFF00";
            // 
            // label_imgBgColor
            // 
            this.label_imgBgColor.AutoSize = true;
            this.label_imgBgColor.Location = new System.Drawing.Point(6, 87);
            this.label_imgBgColor.Name = "label_imgBgColor";
            this.label_imgBgColor.Size = new System.Drawing.Size(68, 13);
            this.label_imgBgColor.TabIndex = 5;
            this.label_imgBgColor.Text = "Background:";
            // 
            // numeric_ignoreIterationsVal
            // 
            this.numeric_ignoreIterationsVal.Location = new System.Drawing.Point(81, 219);
            this.numeric_ignoreIterationsVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_ignoreIterationsVal.Name = "numeric_ignoreIterationsVal";
            this.numeric_ignoreIterationsVal.Size = new System.Drawing.Size(55, 20);
            this.numeric_ignoreIterationsVal.TabIndex = 108;
            this.numeric_ignoreIterationsVal.ThousandsSeparator = true;
            // 
            // label_ignoreIterations
            // 
            this.label_ignoreIterations.AutoSize = true;
            this.label_ignoreIterations.Location = new System.Drawing.Point(6, 220);
            this.label_ignoreIterations.Name = "label_ignoreIterations";
            this.label_ignoreIterations.Size = new System.Drawing.Size(185, 13);
            this.label_ignoreIterations.TabIndex = 109;
            this.label_ignoreIterations.Text = "Ignore the first                      iterations.";
            // 
            // button_clearRules
            // 
            this.button_clearRules.Location = new System.Drawing.Point(178, 190);
            this.button_clearRules.Name = "button_clearRules";
            this.button_clearRules.Size = new System.Drawing.Size(60, 23);
            this.button_clearRules.TabIndex = 108;
            this.button_clearRules.Text = "Clear";
            this.button_clearRules.UseVisualStyleBackColor = true;
            // 
            // button_clearVertices
            // 
            this.button_clearVertices.Location = new System.Drawing.Point(178, 6);
            this.button_clearVertices.Name = "button_clearVertices";
            this.button_clearVertices.Size = new System.Drawing.Size(60, 23);
            this.button_clearVertices.TabIndex = 108;
            this.button_clearVertices.Text = "Clear";
            this.button_clearVertices.UseVisualStyleBackColor = true;
            this.button_clearVertices.Click += new System.EventHandler(this.button_clearVertices_Click);
            // 
            // checkBox_addVertexOnClick
            // 
            this.checkBox_addVertexOnClick.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_addVertexOnClick.AutoEllipsis = true;
            this.checkBox_addVertexOnClick.Location = new System.Drawing.Point(6, 35);
            this.checkBox_addVertexOnClick.Name = "checkBox_addVertexOnClick";
            this.checkBox_addVertexOnClick.Size = new System.Drawing.Size(232, 24);
            this.checkBox_addVertexOnClick.TabIndex = 1;
            this.checkBox_addVertexOnClick.Text = "Add vertices by clicking on the bitmap";
            this.checkBox_addVertexOnClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_addVertexOnClick.UseVisualStyleBackColor = true;
            // 
            // button_ApplyRulesOptions
            // 
            this.button_ApplyRulesOptions.Location = new System.Drawing.Point(163, 245);
            this.button_ApplyRulesOptions.Name = "button_ApplyRulesOptions";
            this.button_ApplyRulesOptions.Size = new System.Drawing.Size(75, 23);
            this.button_ApplyRulesOptions.TabIndex = 107;
            this.button_ApplyRulesOptions.Text = "Apply";
            this.button_ApplyRulesOptions.UseVisualStyleBackColor = true;
            this.button_ApplyRulesOptions.Click += new System.EventHandler(this.button_ApplyRulesOptions_Click);
            // 
            // button_ruleList
            // 
            this.button_ruleList.Location = new System.Drawing.Point(6, 190);
            this.button_ruleList.Name = "button_ruleList";
            this.button_ruleList.Size = new System.Drawing.Size(101, 23);
            this.button_ruleList.TabIndex = 106;
            this.button_ruleList.Text = "List of rules";
            this.button_ruleList.UseVisualStyleBackColor = true;
            this.button_ruleList.Click += new System.EventHandler(this.button_ruleList_Click);
            // 
            // label_gpFirstY
            // 
            this.label_gpFirstY.AutoSize = true;
            this.label_gpFirstY.Enabled = false;
            this.label_gpFirstY.Location = new System.Drawing.Point(128, 114);
            this.label_gpFirstY.Name = "label_gpFirstY";
            this.label_gpFirstY.Size = new System.Drawing.Size(15, 13);
            this.label_gpFirstY.TabIndex = 105;
            this.label_gpFirstY.Text = "y:";
            // 
            // numeric_rotation
            // 
            this.numeric_rotation.DecimalPlaces = 3;
            this.numeric_rotation.Location = new System.Drawing.Point(105, 164);
            this.numeric_rotation.Maximum = new decimal(new int[] {
            359999,
            0,
            0,
            196608});
            this.numeric_rotation.Name = "numeric_rotation";
            this.numeric_rotation.Size = new System.Drawing.Size(72, 20);
            this.numeric_rotation.TabIndex = 102;
            // 
            // numeric_compressionRatio
            // 
            this.numeric_compressionRatio.DecimalPlaces = 3;
            this.numeric_compressionRatio.Location = new System.Drawing.Point(105, 138);
            this.numeric_compressionRatio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            196608});
            this.numeric_compressionRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numeric_compressionRatio.Name = "numeric_compressionRatio";
            this.numeric_compressionRatio.Size = new System.Drawing.Size(72, 20);
            this.numeric_compressionRatio.TabIndex = 102;
            this.numeric_compressionRatio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            196608});
            this.numeric_compressionRatio.ValueChanged += new System.EventHandler(this.numeric_compressionRatio_ValueChanged);
            // 
            // label_rotation
            // 
            this.label_rotation.AutoSize = true;
            this.label_rotation.Location = new System.Drawing.Point(6, 166);
            this.label_rotation.Name = "label_rotation";
            this.label_rotation.Size = new System.Drawing.Size(50, 13);
            this.label_rotation.TabIndex = 3;
            this.label_rotation.Text = "Rotation:";
            // 
            // button_pointList
            // 
            this.button_pointList.Location = new System.Drawing.Point(6, 6);
            this.button_pointList.Name = "button_pointList";
            this.button_pointList.Size = new System.Drawing.Size(101, 23);
            this.button_pointList.TabIndex = 100;
            this.button_pointList.Text = "List of vertices";
            this.button_pointList.UseVisualStyleBackColor = true;
            this.button_pointList.Click += new System.EventHandler(this.button_pointList_Click);
            // 
            // label_dist
            // 
            this.label_dist.AutoSize = true;
            this.label_dist.Location = new System.Drawing.Point(183, 140);
            this.label_dist.Name = "label_dist";
            this.label_dist.Size = new System.Drawing.Size(46, 13);
            this.label_dist.TabIndex = 3;
            this.label_dist.Text = "Dist: 0.5";
            // 
            // label_compression
            // 
            this.label_compression.AutoSize = true;
            this.label_compression.Location = new System.Drawing.Point(6, 140);
            this.label_compression.Name = "label_compression";
            this.label_compression.Size = new System.Drawing.Size(93, 13);
            this.label_compression.TabIndex = 3;
            this.label_compression.Text = "Compression ratio:";
            // 
            // label_gpFirstX
            // 
            this.label_gpFirstX.AutoSize = true;
            this.label_gpFirstX.Enabled = false;
            this.label_gpFirstX.Location = new System.Drawing.Point(6, 114);
            this.label_gpFirstX.Name = "label_gpFirstX";
            this.label_gpFirstX.Size = new System.Drawing.Size(15, 13);
            this.label_gpFirstX.TabIndex = 105;
            this.label_gpFirstX.Text = "x:";
            // 
            // label_rulesCount
            // 
            this.label_rulesCount.AutoSize = true;
            this.label_rulesCount.Location = new System.Drawing.Point(112, 195);
            this.label_rulesCount.Name = "label_rulesCount";
            this.label_rulesCount.Size = new System.Drawing.Size(47, 13);
            this.label_rulesCount.TabIndex = 1;
            this.label_rulesCount.Text = "Count: 0";
            // 
            // label_pointCount
            // 
            this.label_pointCount.AutoSize = true;
            this.label_pointCount.Location = new System.Drawing.Point(112, 11);
            this.label_pointCount.Name = "label_pointCount";
            this.label_pointCount.Size = new System.Drawing.Size(47, 13);
            this.label_pointCount.TabIndex = 1;
            this.label_pointCount.Text = "Count: 3";
            // 
            // numeric_seedY
            // 
            this.numeric_seedY.Enabled = false;
            this.numeric_seedY.Location = new System.Drawing.Point(149, 112);
            this.numeric_seedY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_seedY.Name = "numeric_seedY";
            this.numeric_seedY.Size = new System.Drawing.Size(65, 20);
            this.numeric_seedY.TabIndex = 103;
            this.numeric_seedY.ThousandsSeparator = true;
            this.numeric_seedY.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // label_gpFirstPos
            // 
            this.label_gpFirstPos.AutoSize = true;
            this.label_gpFirstPos.Location = new System.Drawing.Point(6, 90);
            this.label_gpFirstPos.Name = "label_gpFirstPos";
            this.label_gpFirstPos.Size = new System.Drawing.Size(35, 13);
            this.label_gpFirstPos.TabIndex = 103;
            this.label_gpFirstPos.Text = "Seed:";
            // 
            // numeric_seedX
            // 
            this.numeric_seedX.Enabled = false;
            this.numeric_seedX.Location = new System.Drawing.Point(27, 112);
            this.numeric_seedX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_seedX.Name = "numeric_seedX";
            this.numeric_seedX.Size = new System.Drawing.Size(65, 20);
            this.numeric_seedX.TabIndex = 103;
            this.numeric_seedX.ThousandsSeparator = true;
            this.numeric_seedX.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // checkBox_autoSeed
            // 
            this.checkBox_autoSeed.AutoSize = true;
            this.checkBox_autoSeed.Checked = true;
            this.checkBox_autoSeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoSeed.Location = new System.Drawing.Point(47, 89);
            this.checkBox_autoSeed.Name = "checkBox_autoSeed";
            this.checkBox_autoSeed.Size = new System.Drawing.Size(160, 17);
            this.checkBox_autoSeed.TabIndex = 104;
            this.checkBox_autoSeed.Text = "Generate seed automatically";
            this.checkBox_autoSeed.UseVisualStyleBackColor = true;
            this.checkBox_autoSeed.CheckedChanged += new System.EventHandler(this.checkBox_autoSeed_CheckedChanged);
            // 
            // groupBox_generation
            // 
            this.groupBox_generation.Controls.Add(this.checkBox_highlightSel);
            this.groupBox_generation.Controls.Add(this.button_stopGen);
            this.groupBox_generation.Controls.Add(this.button_startGen);
            this.groupBox_generation.Controls.Add(this.label_time);
            this.groupBox_generation.Controls.Add(this.pictureBox_highlightColor);
            this.groupBox_generation.Controls.Add(this.label_highlightVal);
            this.groupBox_generation.Controls.Add(this.label_iterations);
            this.groupBox_generation.Controls.Add(this.label_highlightSel);
            this.groupBox_generation.Controls.Add(this.button_nextFrame);
            this.groupBox_generation.Controls.Add(this.button_nextIteration);
            this.groupBox_generation.Controls.Add(this.numeric_time);
            this.groupBox_generation.Controls.Add(this.numeric_iterations);
            this.groupBox_generation.Location = new System.Drawing.Point(13, 669);
            this.groupBox_generation.Name = "groupBox_generation";
            this.groupBox_generation.Size = new System.Drawing.Size(250, 178);
            this.groupBox_generation.TabIndex = 4;
            this.groupBox_generation.TabStop = false;
            this.groupBox_generation.Text = "Generation";
            // 
            // checkBox_highlightSel
            // 
            this.checkBox_highlightSel.AutoSize = true;
            this.checkBox_highlightSel.Checked = true;
            this.checkBox_highlightSel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_highlightSel.Location = new System.Drawing.Point(6, 129);
            this.checkBox_highlightSel.Name = "checkBox_highlightSel";
            this.checkBox_highlightSel.Size = new System.Drawing.Size(141, 17);
            this.checkBox_highlightSel.TabIndex = 107;
            this.checkBox_highlightSel.Text = "Highlight selected points";
            this.checkBox_highlightSel.UseVisualStyleBackColor = true;
            // 
            // button_stopGen
            // 
            this.button_stopGen.Enabled = false;
            this.button_stopGen.Location = new System.Drawing.Point(113, 100);
            this.button_stopGen.Name = "button_stopGen";
            this.button_stopGen.Size = new System.Drawing.Size(75, 23);
            this.button_stopGen.TabIndex = 104;
            this.button_stopGen.Text = "Stop";
            this.button_stopGen.UseVisualStyleBackColor = true;
            this.button_stopGen.Click += new System.EventHandler(this.button_stopGen_Click);
            // 
            // button_startGen
            // 
            this.button_startGen.Location = new System.Drawing.Point(7, 100);
            this.button_startGen.Name = "button_startGen";
            this.button_startGen.Size = new System.Drawing.Size(100, 23);
            this.button_startGen.TabIndex = 103;
            this.button_startGen.Text = "Start generation";
            this.button_startGen.UseVisualStyleBackColor = true;
            this.button_startGen.Click += new System.EventHandler(this.button_startGen_Click);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(7, 76);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(102, 13);
            this.label_time.TabIndex = 1;
            this.label_time.Text = "Time (ms) per frame:";
            // 
            // pictureBox_highlightColor
            // 
            this.pictureBox_highlightColor.BackColor = System.Drawing.Color.Green;
            this.pictureBox_highlightColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_highlightColor.Location = new System.Drawing.Point(161, 150);
            this.pictureBox_highlightColor.Name = "pictureBox_highlightColor";
            this.pictureBox_highlightColor.Size = new System.Drawing.Size(79, 20);
            this.pictureBox_highlightColor.TabIndex = 8;
            this.pictureBox_highlightColor.TabStop = false;
            this.pictureBox_highlightColor.DoubleClick += new System.EventHandler(this.pictureBox_highlightColor_DoubleClick);
            // 
            // label_highlightVal
            // 
            this.label_highlightVal.AutoSize = true;
            this.label_highlightVal.Location = new System.Drawing.Point(89, 152);
            this.label_highlightVal.Name = "label_highlightVal";
            this.label_highlightVal.Size = new System.Drawing.Size(62, 13);
            this.label_highlightVal.TabIndex = 6;
            this.label_highlightVal.Text = "#008000FF";
            // 
            // label_iterations
            // 
            this.label_iterations.AutoSize = true;
            this.label_iterations.Location = new System.Drawing.Point(7, 50);
            this.label_iterations.Name = "label_iterations";
            this.label_iterations.Size = new System.Drawing.Size(100, 13);
            this.label_iterations.TabIndex = 1;
            this.label_iterations.Text = "Iterations per frame:";
            // 
            // label_highlightSel
            // 
            this.label_highlightSel.AutoSize = true;
            this.label_highlightSel.Location = new System.Drawing.Point(6, 152);
            this.label_highlightSel.Name = "label_highlightSel";
            this.label_highlightSel.Size = new System.Drawing.Size(77, 13);
            this.label_highlightSel.TabIndex = 5;
            this.label_highlightSel.Text = "Highlight color:";
            // 
            // button_nextFrame
            // 
            this.button_nextFrame.Location = new System.Drawing.Point(93, 20);
            this.button_nextFrame.Name = "button_nextFrame";
            this.button_nextFrame.Size = new System.Drawing.Size(70, 23);
            this.button_nextFrame.TabIndex = 100;
            this.button_nextFrame.Text = "Next Frame";
            this.button_nextFrame.UseVisualStyleBackColor = true;
            this.button_nextFrame.Click += new System.EventHandler(this.button_nextFrame_Click);
            // 
            // button_nextIteration
            // 
            this.button_nextIteration.Location = new System.Drawing.Point(7, 20);
            this.button_nextIteration.Name = "button_nextIteration";
            this.button_nextIteration.Size = new System.Drawing.Size(80, 23);
            this.button_nextIteration.TabIndex = 100;
            this.button_nextIteration.Text = "Next Iteration";
            this.button_nextIteration.UseVisualStyleBackColor = true;
            this.button_nextIteration.Click += new System.EventHandler(this.button_nextIteration_Click);
            // 
            // numeric_time
            // 
            this.numeric_time.Location = new System.Drawing.Point(113, 74);
            this.numeric_time.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_time.Name = "numeric_time";
            this.numeric_time.Size = new System.Drawing.Size(65, 20);
            this.numeric_time.TabIndex = 102;
            this.numeric_time.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numeric_iterations
            // 
            this.numeric_iterations.Location = new System.Drawing.Point(113, 48);
            this.numeric_iterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_iterations.Name = "numeric_iterations";
            this.numeric_iterations.Size = new System.Drawing.Size(65, 20);
            this.numeric_iterations.TabIndex = 101;
            this.numeric_iterations.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBox_rules2
            // 
            this.groupBox_rules2.Controls.Add(this.button_saveBitmap);
            this.groupBox_rules2.Controls.Add(this.groupBox_restrictions);
            this.groupBox_rules2.Location = new System.Drawing.Point(13, 853);
            this.groupBox_rules2.Name = "groupBox_rules2";
            this.groupBox_rules2.Size = new System.Drawing.Size(250, 204);
            this.groupBox_rules2.TabIndex = 5;
            this.groupBox_rules2.TabStop = false;
            this.groupBox_rules2.Text = "Panel with leftovers that will be removed";
            // 
            // button_saveBitmap
            // 
            this.button_saveBitmap.Location = new System.Drawing.Point(6, 19);
            this.button_saveBitmap.Name = "button_saveBitmap";
            this.button_saveBitmap.Size = new System.Drawing.Size(75, 23);
            this.button_saveBitmap.TabIndex = 105;
            this.button_saveBitmap.Text = "Save bitmap";
            this.button_saveBitmap.UseVisualStyleBackColor = true;
            this.button_saveBitmap.Click += new System.EventHandler(this.button_saveBitmap_Click);
            // 
            // groupBox_restrictions
            // 
            this.groupBox_restrictions.Controls.Add(this.checkBox_rule3);
            this.groupBox_restrictions.Controls.Add(this.checkBox_rule2);
            this.groupBox_restrictions.Controls.Add(this.checkBox_rule1);
            this.groupBox_restrictions.Controls.Add(this.numeric_rule2Val);
            this.groupBox_restrictions.Controls.Add(this.numeric_zoom);
            this.groupBox_restrictions.Location = new System.Drawing.Point(6, 48);
            this.groupBox_restrictions.Name = "groupBox_restrictions";
            this.groupBox_restrictions.Size = new System.Drawing.Size(237, 169);
            this.groupBox_restrictions.TabIndex = 5;
            this.groupBox_restrictions.TabStop = false;
            this.groupBox_restrictions.Text = "Restrictions";
            // 
            // checkBox_rule3
            // 
            this.checkBox_rule3.AutoSize = true;
            this.checkBox_rule3.Location = new System.Drawing.Point(6, 91);
            this.checkBox_rule3.Name = "checkBox_rule3";
            this.checkBox_rule3.Size = new System.Drawing.Size(384, 17);
            this.checkBox_rule3.TabIndex = 101;
            this.checkBox_rule3.Text = "Vertex can\'t be -1 position from last vertex if last two vertices were the same.";
            this.checkBox_rule3.UseVisualStyleBackColor = true;
            // 
            // checkBox_rule2
            // 
            this.checkBox_rule2.AutoSize = true;
            this.checkBox_rule2.Location = new System.Drawing.Point(6, 42);
            this.checkBox_rule2.Name = "checkBox_rule2";
            this.checkBox_rule2.Size = new System.Drawing.Size(222, 17);
            this.checkBox_rule2.TabIndex = 101;
            this.checkBox_rule2.Text = "Vertex can\'t be n position from last vertex.";
            this.checkBox_rule2.UseVisualStyleBackColor = true;
            // 
            // checkBox_rule1
            // 
            this.checkBox_rule1.AutoSize = true;
            this.checkBox_rule1.Location = new System.Drawing.Point(6, 19);
            this.checkBox_rule1.Name = "checkBox_rule1";
            this.checkBox_rule1.Size = new System.Drawing.Size(206, 17);
            this.checkBox_rule1.TabIndex = 100;
            this.checkBox_rule1.Text = "Vertex can\'t be chosen twice in a row.";
            this.checkBox_rule1.UseVisualStyleBackColor = true;
            // 
            // numeric_rule2Val
            // 
            this.numeric_rule2Val.Location = new System.Drawing.Point(166, 65);
            this.numeric_rule2Val.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_rule2Val.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numeric_rule2Val.Name = "numeric_rule2Val";
            this.numeric_rule2Val.Size = new System.Drawing.Size(65, 20);
            this.numeric_rule2Val.TabIndex = 102;
            this.numeric_rule2Val.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numeric_zoom
            // 
            this.numeric_zoom.DecimalPlaces = 2;
            this.numeric_zoom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numeric_zoom.Location = new System.Drawing.Point(6, 114);
            this.numeric_zoom.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numeric_zoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numeric_zoom.Name = "numeric_zoom";
            this.numeric_zoom.Size = new System.Drawing.Size(67, 20);
            this.numeric_zoom.TabIndex = 102;
            this.numeric_zoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_zoom.ValueChanged += new System.EventHandler(this.numeric_zoom_ValueChanged);
            // 
            // button_restart
            // 
            this.button_restart.AutoEllipsis = true;
            this.button_restart.Location = new System.Drawing.Point(187, 14);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(77, 23);
            this.button_restart.TabIndex = 102;
            this.button_restart.Text = "Restart";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // button_clear
            // 
            this.button_clear.AutoEllipsis = true;
            this.button_clear.Location = new System.Drawing.Point(96, 14);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(85, 23);
            this.button_clear.TabIndex = 101;
            this.button_clear.Text = "Clear bitmap";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_new
            // 
            this.button_new.AutoEllipsis = true;
            this.button_new.Location = new System.Drawing.Point(13, 14);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(77, 23);
            this.button_new.TabIndex = 100;
            this.button_new.Text = "New";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // panel_bitmap
            // 
            this.panel_bitmap.AutoScroll = true;
            this.panel_bitmap.Controls.Add(this.pictureBox_bitmap);
            this.panel_bitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bitmap.Location = new System.Drawing.Point(3, 3);
            this.panel_bitmap.Name = "panel_bitmap";
            this.panel_bitmap.Size = new System.Drawing.Size(717, 723);
            this.panel_bitmap.TabIndex = 1;
            this.panel_bitmap.SizeChanged += new System.EventHandler(this.panel_bitmap_SizeChanged);
            // 
            // pictureBox_bitmap
            // 
            this.pictureBox_bitmap.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bitmap.Location = new System.Drawing.Point(13, 11);
            this.pictureBox_bitmap.Name = "pictureBox_bitmap";
            this.pictureBox_bitmap.Size = new System.Drawing.Size(700, 700);
            this.pictureBox_bitmap.TabIndex = 0;
            this.pictureBox_bitmap.TabStop = false;
            this.pictureBox_bitmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_bitmap_MouseClick);
            // 
            // timer_gpGeneration
            // 
            this.timer_gpGeneration.Interval = 2;
            this.timer_gpGeneration.Tick += new System.EventHandler(this.timer_gpGeneration_Tick);
            // 
            // checkBox_drawSides
            // 
            this.checkBox_drawSides.AutoSize = true;
            this.checkBox_drawSides.Checked = true;
            this.checkBox_drawSides.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_drawSides.Location = new System.Drawing.Point(7, 67);
            this.checkBox_drawSides.Name = "checkBox_drawSides";
            this.checkBox_drawSides.Size = new System.Drawing.Size(78, 17);
            this.checkBox_drawSides.TabIndex = 110;
            this.checkBox_drawSides.Text = "Draw sides";
            this.checkBox_drawSides.UseVisualStyleBackColor = true;
            this.checkBox_drawSides.CheckedChanged += new System.EventHandler(this.checkBox_drawSides_CheckedChanged);
            // 
            // label_sideColorVal
            // 
            this.label_sideColorVal.AutoSize = true;
            this.label_sideColorVal.Location = new System.Drawing.Point(141, 68);
            this.label_sideColorVal.Name = "label_sideColorVal";
            this.label_sideColorVal.Size = new System.Drawing.Size(62, 13);
            this.label_sideColorVal.TabIndex = 6;
            this.label_sideColorVal.Text = "#FFFF00FF";
            // 
            // pictureBox_sideColor
            // 
            this.pictureBox_sideColor.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox_sideColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_sideColor.Location = new System.Drawing.Point(207, 65);
            this.pictureBox_sideColor.Name = "pictureBox_sideColor";
            this.pictureBox_sideColor.Size = new System.Drawing.Size(31, 20);
            this.pictureBox_sideColor.TabIndex = 8;
            this.pictureBox_sideColor.TabStop = false;
            this.pictureBox_sideColor.DoubleClick += new System.EventHandler(this.pictureBox_sideColor_DoubleClick);
            // 
            // label_sideColor
            // 
            this.label_sideColor.AutoSize = true;
            this.label_sideColor.Location = new System.Drawing.Point(110, 68);
            this.label_sideColor.Name = "label_sideColor";
            this.label_sideColor.Size = new System.Drawing.Size(34, 13);
            this.label_sideColor.TabIndex = 10;
            this.label_sideColor.Text = "Color:";
            // 
            // tabControl_rules
            // 
            this.tabControl_rules.Controls.Add(this.tab_vertices);
            this.tabControl_rules.Controls.Add(this.tab_IFS);
            this.tabControl_rules.Location = new System.Drawing.Point(13, 363);
            this.tabControl_rules.Name = "tabControl_rules";
            this.tabControl_rules.SelectedIndex = 0;
            this.tabControl_rules.Size = new System.Drawing.Size(252, 300);
            this.tabControl_rules.TabIndex = 104;
            this.tabControl_rules.SelectedIndexChanged += new System.EventHandler(this.tabControl_rules_SelectedIndexChanged);
            // 
            // tab_vertices
            // 
            this.tab_vertices.BackColor = System.Drawing.SystemColors.Control;
            this.tab_vertices.Controls.Add(this.button_ApplyRulesOptions);
            this.tab_vertices.Controls.Add(this.numeric_ignoreIterationsVal);
            this.tab_vertices.Controls.Add(this.checkBox_drawSides);
            this.tab_vertices.Controls.Add(this.label_ignoreIterations);
            this.tab_vertices.Controls.Add(this.label_sideColor);
            this.tab_vertices.Controls.Add(this.button_clearRules);
            this.tab_vertices.Controls.Add(this.button_pointList);
            this.tab_vertices.Controls.Add(this.button_clearVertices);
            this.tab_vertices.Controls.Add(this.label_rulesCount);
            this.tab_vertices.Controls.Add(this.button_ruleList);
            this.tab_vertices.Controls.Add(this.pictureBox_sideColor);
            this.tab_vertices.Controls.Add(this.numeric_rotation);
            this.tab_vertices.Controls.Add(this.label_gpFirstY);
            this.tab_vertices.Controls.Add(this.numeric_compressionRatio);
            this.tab_vertices.Controls.Add(this.label_rotation);
            this.tab_vertices.Controls.Add(this.label_sideColorVal);
            this.tab_vertices.Controls.Add(this.label_dist);
            this.tab_vertices.Controls.Add(this.label_pointCount);
            this.tab_vertices.Controls.Add(this.label_compression);
            this.tab_vertices.Controls.Add(this.checkBox_addVertexOnClick);
            this.tab_vertices.Controls.Add(this.label_gpFirstPos);
            this.tab_vertices.Controls.Add(this.checkBox_autoSeed);
            this.tab_vertices.Controls.Add(this.numeric_seedX);
            this.tab_vertices.Controls.Add(this.label_gpFirstX);
            this.tab_vertices.Controls.Add(this.numeric_seedY);
            this.tab_vertices.Location = new System.Drawing.Point(4, 22);
            this.tab_vertices.Name = "tab_vertices";
            this.tab_vertices.Padding = new System.Windows.Forms.Padding(3);
            this.tab_vertices.Size = new System.Drawing.Size(244, 274);
            this.tab_vertices.TabIndex = 0;
            this.tab_vertices.Text = "Vertices";
            // 
            // tab_IFS
            // 
            this.tab_IFS.BackColor = System.Drawing.SystemColors.Control;
            this.tab_IFS.Controls.Add(this.numeric_ifs_ignoreIterationsVal);
            this.tab_IFS.Controls.Add(this.checkBox_linkIfsMagnify);
            this.tab_IFS.Controls.Add(this.label_ifs_ignoreIterations);
            this.tab_IFS.Controls.Add(this.checkBox_drawAxes);
            this.tab_IFS.Controls.Add(this.label_ifsMagnifyY);
            this.tab_IFS.Controls.Add(this.label_ifsMagnifyX);
            this.tab_IFS.Controls.Add(this.button_ApplyIFS);
            this.tab_IFS.Controls.Add(this.groupBox_centerPoint);
            this.tab_IFS.Controls.Add(this.label_formulaCount);
            this.tab_IFS.Controls.Add(this.rules_ifs_openTable);
            this.tab_IFS.Controls.Add(this.numeric_ifsMagnifyY);
            this.tab_IFS.Controls.Add(this.numeric_ifsMagnifyX);
            this.tab_IFS.Location = new System.Drawing.Point(4, 22);
            this.tab_IFS.Name = "tab_IFS";
            this.tab_IFS.Padding = new System.Windows.Forms.Padding(3);
            this.tab_IFS.Size = new System.Drawing.Size(244, 274);
            this.tab_IFS.TabIndex = 1;
            this.tab_IFS.Text = "IFS";
            // 
            // rules_ifs_openTable
            // 
            this.rules_ifs_openTable.Location = new System.Drawing.Point(6, 7);
            this.rules_ifs_openTable.Name = "rules_ifs_openTable";
            this.rules_ifs_openTable.Size = new System.Drawing.Size(132, 23);
            this.rules_ifs_openTable.TabIndex = 0;
            this.rules_ifs_openTable.Text = "Open formula table";
            this.rules_ifs_openTable.UseVisualStyleBackColor = true;
            this.rules_ifs_openTable.Click += new System.EventHandler(this.rules_ifs_openTable_Click);
            // 
            // label_formulaCount
            // 
            this.label_formulaCount.AutoSize = true;
            this.label_formulaCount.Location = new System.Drawing.Point(144, 12);
            this.label_formulaCount.Name = "label_formulaCount";
            this.label_formulaCount.Size = new System.Drawing.Size(47, 13);
            this.label_formulaCount.TabIndex = 1;
            this.label_formulaCount.Text = "Count: 4";
            // 
            // button_ApplyIFS
            // 
            this.button_ApplyIFS.Location = new System.Drawing.Point(163, 245);
            this.button_ApplyIFS.Name = "button_ApplyIFS";
            this.button_ApplyIFS.Size = new System.Drawing.Size(75, 23);
            this.button_ApplyIFS.TabIndex = 108;
            this.button_ApplyIFS.Text = "Apply";
            this.button_ApplyIFS.UseVisualStyleBackColor = true;
            this.button_ApplyIFS.Click += new System.EventHandler(this.button_ApplyIFS_Click);
            // 
            // label_ifsMagnifyX
            // 
            this.label_ifsMagnifyX.AutoSize = true;
            this.label_ifsMagnifyX.Location = new System.Drawing.Point(3, 83);
            this.label_ifsMagnifyX.Name = "label_ifsMagnifyX";
            this.label_ifsMagnifyX.Size = new System.Drawing.Size(55, 13);
            this.label_ifsMagnifyX.TabIndex = 109;
            this.label_ifsMagnifyX.Text = "Magnify x:";
            // 
            // numeric_ifsMagnifyX
            // 
            this.numeric_ifsMagnifyX.DecimalPlaces = 3;
            this.numeric_ifsMagnifyX.Location = new System.Drawing.Point(64, 81);
            this.numeric_ifsMagnifyX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_ifsMagnifyX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numeric_ifsMagnifyX.Name = "numeric_ifsMagnifyX";
            this.numeric_ifsMagnifyX.Size = new System.Drawing.Size(74, 20);
            this.numeric_ifsMagnifyX.TabIndex = 106;
            this.numeric_ifsMagnifyX.ThousandsSeparator = true;
            this.numeric_ifsMagnifyX.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numeric_ifsMagnifyX.ValueChanged += new System.EventHandler(this.numeric_ifsMagnifyX_ValueChanged);
            // 
            // groupBox_centerPoint
            // 
            this.groupBox_centerPoint.Controls.Add(this.label_cpX);
            this.groupBox_centerPoint.Controls.Add(this.numeric_cpX);
            this.groupBox_centerPoint.Controls.Add(this.label_cpY);
            this.groupBox_centerPoint.Controls.Add(this.numeric_cpY);
            this.groupBox_centerPoint.Location = new System.Drawing.Point(2, 36);
            this.groupBox_centerPoint.Name = "groupBox_centerPoint";
            this.groupBox_centerPoint.Size = new System.Drawing.Size(236, 41);
            this.groupBox_centerPoint.TabIndex = 103;
            this.groupBox_centerPoint.TabStop = false;
            this.groupBox_centerPoint.Text = "Center point:";
            // 
            // label_cpX
            // 
            this.label_cpX.AutoSize = true;
            this.label_cpX.Location = new System.Drawing.Point(6, 16);
            this.label_cpX.Name = "label_cpX";
            this.label_cpX.Size = new System.Drawing.Size(15, 13);
            this.label_cpX.TabIndex = 0;
            this.label_cpX.Text = "x:";
            // 
            // numeric_cpX
            // 
            this.numeric_cpX.Location = new System.Drawing.Point(27, 14);
            this.numeric_cpX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_cpX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numeric_cpX.Name = "numeric_cpX";
            this.numeric_cpX.Size = new System.Drawing.Size(65, 20);
            this.numeric_cpX.TabIndex = 103;
            this.numeric_cpX.ThousandsSeparator = true;
            this.numeric_cpX.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numeric_cpX.ValueChanged += new System.EventHandler(this.UpdateCenterPointEvent);
            // 
            // label_cpY
            // 
            this.label_cpY.AutoSize = true;
            this.label_cpY.Location = new System.Drawing.Point(124, 16);
            this.label_cpY.Name = "label_cpY";
            this.label_cpY.Size = new System.Drawing.Size(15, 13);
            this.label_cpY.TabIndex = 0;
            this.label_cpY.Text = "y:";
            // 
            // numeric_cpY
            // 
            this.numeric_cpY.Location = new System.Drawing.Point(145, 14);
            this.numeric_cpY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_cpY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numeric_cpY.Name = "numeric_cpY";
            this.numeric_cpY.Size = new System.Drawing.Size(65, 20);
            this.numeric_cpY.TabIndex = 104;
            this.numeric_cpY.ThousandsSeparator = true;
            this.numeric_cpY.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.numeric_cpY.ValueChanged += new System.EventHandler(this.UpdateCenterPointEvent);
            // 
            // checkBox_drawAxes
            // 
            this.checkBox_drawAxes.AutoSize = true;
            this.checkBox_drawAxes.Location = new System.Drawing.Point(7, 137);
            this.checkBox_drawAxes.Name = "checkBox_drawAxes";
            this.checkBox_drawAxes.Size = new System.Drawing.Size(129, 17);
            this.checkBox_drawAxes.TabIndex = 110;
            this.checkBox_drawAxes.Text = "Draw coordinate axes";
            this.checkBox_drawAxes.UseVisualStyleBackColor = true;
            this.checkBox_drawAxes.CheckedChanged += new System.EventHandler(this.checkBox_drawAxes_CheckedChanged);
            // 
            // checkBox_import
            // 
            this.checkBox_import.AutoSize = true;
            this.checkBox_import.Location = new System.Drawing.Point(6, 115);
            this.checkBox_import.Name = "checkBox_import";
            this.checkBox_import.Size = new System.Drawing.Size(128, 17);
            this.checkBox_import.TabIndex = 106;
            this.checkBox_import.Text = "Import bitmap from file";
            this.checkBox_import.UseVisualStyleBackColor = true;
            this.checkBox_import.CheckedChanged += new System.EventHandler(this.checkBox_import_CheckedChanged);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(165, 111);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 107;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // numeric_ifsMagnifyY
            // 
            this.numeric_ifsMagnifyY.DecimalPlaces = 3;
            this.numeric_ifsMagnifyY.Location = new System.Drawing.Point(64, 107);
            this.numeric_ifsMagnifyY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_ifsMagnifyY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numeric_ifsMagnifyY.Name = "numeric_ifsMagnifyY";
            this.numeric_ifsMagnifyY.Size = new System.Drawing.Size(74, 20);
            this.numeric_ifsMagnifyY.TabIndex = 106;
            this.numeric_ifsMagnifyY.ThousandsSeparator = true;
            this.numeric_ifsMagnifyY.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numeric_ifsMagnifyY.ValueChanged += new System.EventHandler(this.numeric_ifsMagnifyY_ValueChanged);
            // 
            // label_ifsMagnifyY
            // 
            this.label_ifsMagnifyY.AutoSize = true;
            this.label_ifsMagnifyY.Location = new System.Drawing.Point(3, 109);
            this.label_ifsMagnifyY.Name = "label_ifsMagnifyY";
            this.label_ifsMagnifyY.Size = new System.Drawing.Size(55, 13);
            this.label_ifsMagnifyY.TabIndex = 109;
            this.label_ifsMagnifyY.Text = "Magnify y:";
            // 
            // checkBox_linkIfsMagnify
            // 
            this.checkBox_linkIfsMagnify.AutoSize = true;
            this.checkBox_linkIfsMagnify.Checked = true;
            this.checkBox_linkIfsMagnify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_linkIfsMagnify.Location = new System.Drawing.Point(144, 97);
            this.checkBox_linkIfsMagnify.Name = "checkBox_linkIfsMagnify";
            this.checkBox_linkIfsMagnify.Size = new System.Drawing.Size(46, 17);
            this.checkBox_linkIfsMagnify.TabIndex = 110;
            this.checkBox_linkIfsMagnify.Text = "Link";
            this.checkBox_linkIfsMagnify.UseVisualStyleBackColor = true;
            this.checkBox_linkIfsMagnify.CheckedChanged += new System.EventHandler(this.checkBox_drawAxes_CheckedChanged);
            // 
            // numeric_ifs_ignoreIterationsVal
            // 
            this.numeric_ifs_ignoreIterationsVal.Location = new System.Drawing.Point(81, 156);
            this.numeric_ifs_ignoreIterationsVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_ifs_ignoreIterationsVal.Name = "numeric_ifs_ignoreIterationsVal";
            this.numeric_ifs_ignoreIterationsVal.Size = new System.Drawing.Size(55, 20);
            this.numeric_ifs_ignoreIterationsVal.TabIndex = 110;
            this.numeric_ifs_ignoreIterationsVal.ThousandsSeparator = true;
            // 
            // label_ifs_ignoreIterations
            // 
            this.label_ifs_ignoreIterations.AutoSize = true;
            this.label_ifs_ignoreIterations.Location = new System.Drawing.Point(6, 157);
            this.label_ifs_ignoreIterations.Name = "label_ifs_ignoreIterations";
            this.label_ifs_ignoreIterations.Size = new System.Drawing.Size(185, 13);
            this.label_ifs_ignoreIterations.TabIndex = 111;
            this.label_ifs_ignoreIterations.Text = "Ignore the first                      iterations.";
            // 
            // button_loadPreset
            // 
            this.button_loadPreset.Location = new System.Drawing.Point(13, 334);
            this.button_loadPreset.Name = "button_loadPreset";
            this.button_loadPreset.Size = new System.Drawing.Size(75, 23);
            this.button_loadPreset.TabIndex = 2;
            this.button_loadPreset.Text = "Load preset";
            this.button_loadPreset.UseVisualStyleBackColor = true;
            this.button_loadPreset.Click += new System.EventHandler(this.button_loadPreset_Click);
            // 
            // button_savePreset
            // 
            this.button_savePreset.Location = new System.Drawing.Point(94, 334);
            this.button_savePreset.Name = "button_savePreset";
            this.button_savePreset.Size = new System.Drawing.Size(75, 23);
            this.button_savePreset.TabIndex = 2;
            this.button_savePreset.Text = "Save preset";
            this.button_savePreset.UseVisualStyleBackColor = true;
            this.button_savePreset.Click += new System.EventHandler(this.button_savePreset_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.layout_table);
            this.Name = "MainWindow";
            this.Text = "The Chaos Game";
            this.layout_table.ResumeLayout(false);
            this.layout_optionPanels.ResumeLayout(false);
            this.groupBox_visualOptions.ResumeLayout(false);
            this.groupBox_visualOptions.PerformLayout();
            this.groupBox_gp.ResumeLayout(false);
            this.groupBox_gp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gpColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gpSize)).EndInit();
            this.groupBox_imgDim.ResumeLayout(false);
            this.groupBox_imgDim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_imgHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_imgWidth)).EndInit();
            this.groupBox_vertex.ResumeLayout(false);
            this.groupBox_vertex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vertexColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_vertexSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bgColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ignoreIterationsVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_rotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_compressionRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seedX)).EndInit();
            this.groupBox_generation.ResumeLayout(false);
            this.groupBox_generation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_highlightColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_iterations)).EndInit();
            this.groupBox_rules2.ResumeLayout(false);
            this.groupBox_restrictions.ResumeLayout(false);
            this.groupBox_restrictions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_rule2Val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_zoom)).EndInit();
            this.panel_bitmap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bitmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sideColor)).EndInit();
            this.tabControl_rules.ResumeLayout(false);
            this.tab_vertices.ResumeLayout(false);
            this.tab_vertices.PerformLayout();
            this.tab_IFS.ResumeLayout(false);
            this.tab_IFS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifsMagnifyX)).EndInit();
            this.groupBox_centerPoint.ResumeLayout(false);
            this.groupBox_centerPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cpX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cpY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifsMagnifyY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ifs_ignoreIterationsVal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout_table;
        private System.Windows.Forms.Panel layout_optionPanels;
        private System.Windows.Forms.Panel panel_bitmap;
        private System.Windows.Forms.PictureBox pictureBox_bitmap;
        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.GroupBox groupBox_rules2;
        private System.Windows.Forms.GroupBox groupBox_generation;
        private System.Windows.Forms.Button button_stopGen;
        private System.Windows.Forms.Button button_startGen;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_iterations;
        private System.Windows.Forms.Button button_nextIteration;
        private System.Windows.Forms.NumericUpDown numeric_time;
        private System.Windows.Forms.NumericUpDown numeric_iterations;
        private System.Windows.Forms.Label label_pointCount;
        private System.Windows.Forms.Button button_pointList;
        private System.Windows.Forms.NumericUpDown numeric_compressionRatio;
        private System.Windows.Forms.Label label_compression;
        private System.Windows.Forms.GroupBox groupBox_restrictions;
        private System.Windows.Forms.CheckBox checkBox_rule2;
        private System.Windows.Forms.CheckBox checkBox_rule1;
        private System.Windows.Forms.NumericUpDown numeric_rule2Val;
        private System.Windows.Forms.CheckBox checkBox_rule3;
        private System.Windows.Forms.Label label_gpFirstY;
        private System.Windows.Forms.Label label_gpFirstX;
        private System.Windows.Forms.NumericUpDown numeric_seedY;
        private System.Windows.Forms.NumericUpDown numeric_seedX;
        private System.Windows.Forms.CheckBox checkBox_autoSeed;
        private System.Windows.Forms.Label label_gpFirstPos;
        private System.Windows.Forms.Button button_saveBitmap;
        private System.Windows.Forms.Timer timer_gpGeneration;
        private System.Windows.Forms.NumericUpDown numeric_zoom;
        private System.Windows.Forms.Button button_nextFrame;
        private System.Windows.Forms.Button button_ApplyRulesOptions;
        private System.Windows.Forms.Button button_ruleList;
        private System.Windows.Forms.NumericUpDown numeric_rotation;
        private System.Windows.Forms.Label label_rotation;
        private System.Windows.Forms.Label label_rulesCount;
        private System.Windows.Forms.CheckBox checkBox_addVertexOnClick;
        private System.Windows.Forms.Label label_dist;
        private System.Windows.Forms.GroupBox groupBox_visualOptions;
        private System.Windows.Forms.Button button_applyVisualOptions;
        private System.Windows.Forms.GroupBox groupBox_gp;
        private System.Windows.Forms.Label label_gpSize;
        private System.Windows.Forms.Label label_gpColor;
        private System.Windows.Forms.PictureBox pictureBox_gpColor;
        private System.Windows.Forms.NumericUpDown numeric_gpSize;
        private System.Windows.Forms.Label label_gpColorVal;
        private System.Windows.Forms.GroupBox groupBox_imgDim;
        private System.Windows.Forms.Button button_dimRectangle;
        private System.Windows.Forms.Button button_dimSquare;
        private System.Windows.Forms.Label label_imgHeight;
        private System.Windows.Forms.NumericUpDown numeric_imgHeight;
        private System.Windows.Forms.Label label_imgWidth;
        private System.Windows.Forms.NumericUpDown numeric_imgWidth;
        private System.Windows.Forms.GroupBox groupBox_vertex;
        private System.Windows.Forms.CheckBox checkBox_ipOnTop;
        private System.Windows.Forms.Label label_vertexSize;
        private System.Windows.Forms.Label label_vertexColor;
        private System.Windows.Forms.PictureBox pictureBox_vertexColor;
        private System.Windows.Forms.NumericUpDown numeric_vertexSize;
        private System.Windows.Forms.Label label_vertexColorVal;
        private System.Windows.Forms.PictureBox pictureBox_bgColor;
        private System.Windows.Forms.Label label_bgColorVal;
        private System.Windows.Forms.Label label_imgBgColor;
        private System.Windows.Forms.CheckBox checkBox_highlightSel;
        private System.Windows.Forms.PictureBox pictureBox_highlightColor;
        private System.Windows.Forms.Label label_highlightVal;
        private System.Windows.Forms.Label label_highlightSel;
        private System.Windows.Forms.Button button_clearRules;
        private System.Windows.Forms.Button button_clearVertices;
        private System.Windows.Forms.NumericUpDown numeric_ignoreIterationsVal;
        private System.Windows.Forms.Label label_ignoreIterations;
        private System.Windows.Forms.CheckBox checkBox_drawSides;
        private System.Windows.Forms.Label label_sideColor;
        private System.Windows.Forms.PictureBox pictureBox_sideColor;
        private System.Windows.Forms.Label label_sideColorVal;
        private System.Windows.Forms.TabControl tabControl_rules;
        private System.Windows.Forms.TabPage tab_vertices;
        private System.Windows.Forms.TabPage tab_IFS;
        private System.Windows.Forms.Button button_ApplyIFS;
        private System.Windows.Forms.Label label_formulaCount;
        private System.Windows.Forms.Button rules_ifs_openTable;
        private System.Windows.Forms.Label label_ifsMagnifyX;
        private System.Windows.Forms.NumericUpDown numeric_ifsMagnifyX;
        private System.Windows.Forms.GroupBox groupBox_centerPoint;
        private System.Windows.Forms.Label label_cpX;
        private System.Windows.Forms.NumericUpDown numeric_cpX;
        private System.Windows.Forms.Label label_cpY;
        private System.Windows.Forms.NumericUpDown numeric_cpY;
        private System.Windows.Forms.CheckBox checkBox_drawAxes;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.CheckBox checkBox_import;
        private System.Windows.Forms.Label label_ifsMagnifyY;
        private System.Windows.Forms.NumericUpDown numeric_ifsMagnifyY;
        private System.Windows.Forms.CheckBox checkBox_linkIfsMagnify;
        private System.Windows.Forms.NumericUpDown numeric_ifs_ignoreIterationsVal;
        private System.Windows.Forms.Label label_ifs_ignoreIterations;
        private System.Windows.Forms.Button button_savePreset;
        private System.Windows.Forms.Button button_loadPreset;
    }
}

