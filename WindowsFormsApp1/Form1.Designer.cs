namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Wii3DS_radio_3DS = new System.Windows.Forms.RadioButton();
            this.Wii3DS_radio_Wii = new System.Windows.Forms.RadioButton();
            this.ds_vf_standard = new System.Windows.Forms.RadioButton();
            this.ds_vf_horihd = new System.Windows.Forms.RadioButton();
            this.ds_vf_3d = new System.Windows.Forms.RadioButton();
            this.ds_3dformat_leftright = new System.Windows.Forms.RadioButton();
            this.ds_3dformat_updown = new System.Windows.Forms.RadioButton();
            this.ds_out_h264 = new System.Windows.Forms.RadioButton();
            this.ds_out_mjpeg = new System.Windows.Forms.RadioButton();
            this.ds_3dformat_swap = new System.Windows.Forms.CheckBox();
            this.ds_out_mpeg = new System.Windows.Forms.RadioButton();
            this.convert_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_ds_vf = new System.Windows.Forms.Panel();
            this.panel_ds_or_wii = new System.Windows.Forms.Panel();
            this.panel_ds_leftright = new System.Windows.Forms.Panel();
            this.panel_ds_outcodec = new System.Windows.Forms.Panel();
            this.panel_scalefilter = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.scale_mix = new System.Windows.Forms.RadioButton();
            this.scale_nearest = new System.Windows.Forms.RadioButton();
            this.scale_linear = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.stretch_full = new System.Windows.Forms.RadioButton();
            this.stretch_10 = new System.Windows.Forms.RadioButton();
            this.surround = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_wii_tv_out = new System.Windows.Forms.Panel();
            this.w480p = new System.Windows.Forms.RadioButton();
            this.w576p = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.wii_output_codec = new System.Windows.Forms.Panel();
            this.wii_xvid = new System.Windows.Forms.RadioButton();
            this.wii_h263 = new System.Windows.Forms.RadioButton();
            this.wii_mjpeg = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_wii_aspect = new System.Windows.Forms.Panel();
            this.wii_169 = new System.Windows.Forms.RadioButton();
            this.wii_43 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.debug_textbox = new System.Windows.Forms.RichTextBox();
            this.panel_stretch = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.stretch_no = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel_wii_fps = new System.Windows.Forms.Panel();
            this.wii_6050 = new System.Windows.Forms.RadioButton();
            this.wii_3025 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.nobframes = new System.Windows.Forms.CheckBox();
            this.nodeblock = new System.Windows.Forms.CheckBox();
            this.dualaudiotracks = new System.Windows.Forms.CheckBox();
            this.version = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.suboffset = new System.Windows.Forms.TextBox();
            this.embeddedsubs = new System.Windows.Forms.CheckBox();
            this.cusresx = new System.Windows.Forms.TextBox();
            this.cusresy = new System.Windows.Forms.TextBox();
            this.panel_ds_vf.SuspendLayout();
            this.panel_ds_or_wii.SuspendLayout();
            this.panel_ds_leftright.SuspendLayout();
            this.panel_ds_outcodec.SuspendLayout();
            this.panel_scalefilter.SuspendLayout();
            this.panel_wii_tv_out.SuspendLayout();
            this.wii_output_codec.SuspendLayout();
            this.panel_wii_aspect.SuspendLayout();
            this.panel_stretch.SuspendLayout();
            this.panel_wii_fps.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wii3DS_radio_3DS
            // 
            this.Wii3DS_radio_3DS.AutoSize = true;
            this.Wii3DS_radio_3DS.Location = new System.Drawing.Point(16, 0);
            this.Wii3DS_radio_3DS.Name = "Wii3DS_radio_3DS";
            this.Wii3DS_radio_3DS.Size = new System.Drawing.Size(76, 17);
            this.Wii3DS_radio_3DS.TabIndex = 0;
            this.Wii3DS_radio_3DS.TabStop = true;
            this.Wii3DS_radio_3DS.Text = "3DS Mode";
            this.Wii3DS_radio_3DS.UseVisualStyleBackColor = true;
            this.Wii3DS_radio_3DS.CheckedChanged += new System.EventHandler(this.test);
            // 
            // Wii3DS_radio_Wii
            // 
            this.Wii3DS_radio_Wii.AutoSize = true;
            this.Wii3DS_radio_Wii.Location = new System.Drawing.Point(176, 0);
            this.Wii3DS_radio_Wii.Name = "Wii3DS_radio_Wii";
            this.Wii3DS_radio_Wii.Size = new System.Drawing.Size(70, 17);
            this.Wii3DS_radio_Wii.TabIndex = 1;
            this.Wii3DS_radio_Wii.TabStop = true;
            this.Wii3DS_radio_Wii.Text = "Wii Mode";
            this.Wii3DS_radio_Wii.UseVisualStyleBackColor = true;
            // 
            // ds_vf_standard
            // 
            this.ds_vf_standard.AutoSize = true;
            this.ds_vf_standard.Location = new System.Drawing.Point(0, 0);
            this.ds_vf_standard.Name = "ds_vf_standard";
            this.ds_vf_standard.Size = new System.Drawing.Size(95, 17);
            this.ds_vf_standard.TabIndex = 2;
            this.ds_vf_standard.TabStop = true;
            this.ds_vf_standard.Text = "Standard 240p";
            this.ds_vf_standard.UseVisualStyleBackColor = true;
            this.ds_vf_standard.CheckedChanged += new System.EventHandler(this.test);
            // 
            // ds_vf_horihd
            // 
            this.ds_vf_horihd.AutoSize = true;
            this.ds_vf_horihd.Location = new System.Drawing.Point(0, 32);
            this.ds_vf_horihd.Name = "ds_vf_horihd";
            this.ds_vf_horihd.Size = new System.Drawing.Size(87, 17);
            this.ds_vf_horihd.TabIndex = 3;
            this.ds_vf_horihd.TabStop = true;
            this.ds_vf_horihd.Text = "HoriHD 240p";
            this.ds_vf_horihd.UseVisualStyleBackColor = true;
            this.ds_vf_horihd.CheckedChanged += new System.EventHandler(this.ds_vf_horihd_CheckedChanged);
            // 
            // ds_vf_3d
            // 
            this.ds_vf_3d.AutoSize = true;
            this.ds_vf_3d.Location = new System.Drawing.Point(0, 64);
            this.ds_vf_3d.Name = "ds_vf_3d";
            this.ds_vf_3d.Size = new System.Drawing.Size(69, 17);
            this.ds_vf_3d.TabIndex = 4;
            this.ds_vf_3d.TabStop = true;
            this.ds_vf_3d.Text = "3D Video";
            this.ds_vf_3d.UseVisualStyleBackColor = true;
            this.ds_vf_3d.CheckedChanged += new System.EventHandler(this.ds_vf_3d_CheckedChanged);
            // 
            // ds_3dformat_leftright
            // 
            this.ds_3dformat_leftright.AutoSize = true;
            this.ds_3dformat_leftright.Enabled = false;
            this.ds_3dformat_leftright.Location = new System.Drawing.Point(0, 0);
            this.ds_3dformat_leftright.Name = "ds_3dformat_leftright";
            this.ds_3dformat_leftright.Size = new System.Drawing.Size(122, 17);
            this.ds_3dformat_leftright.TabIndex = 5;
            this.ds_3dformat_leftright.TabStop = true;
            this.ds_3dformat_leftright.Text = "Left/Right stereo 3D";
            this.ds_3dformat_leftright.UseVisualStyleBackColor = true;
            this.ds_3dformat_leftright.CheckedChanged += new System.EventHandler(this.test);
            // 
            // ds_3dformat_updown
            // 
            this.ds_3dformat_updown.AutoSize = true;
            this.ds_3dformat_updown.Enabled = false;
            this.ds_3dformat_updown.Location = new System.Drawing.Point(0, 32);
            this.ds_3dformat_updown.Name = "ds_3dformat_updown";
            this.ds_3dformat_updown.Size = new System.Drawing.Size(121, 17);
            this.ds_3dformat_updown.TabIndex = 6;
            this.ds_3dformat_updown.TabStop = true;
            this.ds_3dformat_updown.Text = "Up/Down stereo 3D";
            this.ds_3dformat_updown.UseVisualStyleBackColor = true;
            // 
            // ds_out_h264
            // 
            this.ds_out_h264.AutoSize = true;
            this.ds_out_h264.Location = new System.Drawing.Point(0, 0);
            this.ds_out_h264.Name = "ds_out_h264";
            this.ds_out_h264.Size = new System.Drawing.Size(51, 17);
            this.ds_out_h264.TabIndex = 7;
            this.ds_out_h264.TabStop = true;
            this.ds_out_h264.Text = "H264";
            this.ds_out_h264.UseVisualStyleBackColor = true;
            this.ds_out_h264.CheckedChanged += new System.EventHandler(this.test);
            // 
            // ds_out_mjpeg
            // 
            this.ds_out_mjpeg.AutoSize = true;
            this.ds_out_mjpeg.Location = new System.Drawing.Point(0, 64);
            this.ds_out_mjpeg.Name = "ds_out_mjpeg";
            this.ds_out_mjpeg.Size = new System.Drawing.Size(61, 17);
            this.ds_out_mjpeg.TabIndex = 8;
            this.ds_out_mjpeg.TabStop = true;
            this.ds_out_mjpeg.Text = "MJPEG";
            this.ds_out_mjpeg.UseVisualStyleBackColor = true;
            this.ds_out_mjpeg.CheckedChanged += new System.EventHandler(this.test);
            // 
            // ds_3dformat_swap
            // 
            this.ds_3dformat_swap.AutoSize = true;
            this.ds_3dformat_swap.Enabled = false;
            this.ds_3dformat_swap.Location = new System.Drawing.Point(32, 288);
            this.ds_3dformat_swap.Name = "ds_3dformat_swap";
            this.ds_3dformat_swap.Size = new System.Drawing.Size(118, 17);
            this.ds_3dformat_swap.TabIndex = 9;
            this.ds_3dformat_swap.Text = "swap left/right view";
            this.ds_3dformat_swap.UseVisualStyleBackColor = true;
            this.ds_3dformat_swap.CheckedChanged += new System.EventHandler(this.test);
            // 
            // ds_out_mpeg
            // 
            this.ds_out_mpeg.AutoSize = true;
            this.ds_out_mpeg.Location = new System.Drawing.Point(0, 32);
            this.ds_out_mpeg.Name = "ds_out_mpeg";
            this.ds_out_mpeg.Size = new System.Drawing.Size(62, 17);
            this.ds_out_mpeg.TabIndex = 10;
            this.ds_out_mpeg.TabStop = true;
            this.ds_out_mpeg.Text = "MPEG2";
            this.ds_out_mpeg.UseVisualStyleBackColor = true;
            this.ds_out_mpeg.CheckedChanged += new System.EventHandler(this.test);
            // 
            // convert_button
            // 
            this.convert_button.Location = new System.Drawing.Point(16, 464);
            this.convert_button.Name = "convert_button";
            this.convert_button.Size = new System.Drawing.Size(80, 22);
            this.convert_button.TabIndex = 12;
            this.convert_button.Text = "convert";
            this.toolTip1.SetToolTip(this.convert_button, "select file you want to convert");
            this.convert_button.UseVisualStyleBackColor = true;
            this.convert_button.Click += new System.EventHandler(this.woomy);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(32, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Video format:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(32, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Input video 3D format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(32, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Output codec:";
            // 
            // panel_ds_vf
            // 
            this.panel_ds_vf.Controls.Add(this.ds_vf_standard);
            this.panel_ds_vf.Controls.Add(this.ds_vf_horihd);
            this.panel_ds_vf.Controls.Add(this.ds_vf_3d);
            this.panel_ds_vf.Location = new System.Drawing.Point(32, 96);
            this.panel_ds_vf.Name = "panel_ds_vf";
            this.panel_ds_vf.Size = new System.Drawing.Size(128, 80);
            this.panel_ds_vf.TabIndex = 16;
            // 
            // panel_ds_or_wii
            // 
            this.panel_ds_or_wii.Controls.Add(this.Wii3DS_radio_3DS);
            this.panel_ds_or_wii.Controls.Add(this.Wii3DS_radio_Wii);
            this.panel_ds_or_wii.Location = new System.Drawing.Point(16, 48);
            this.panel_ds_or_wii.Name = "panel_ds_or_wii";
            this.panel_ds_or_wii.Size = new System.Drawing.Size(288, 16);
            this.panel_ds_or_wii.TabIndex = 17;
            // 
            // panel_ds_leftright
            // 
            this.panel_ds_leftright.Controls.Add(this.ds_3dformat_leftright);
            this.panel_ds_leftright.Controls.Add(this.ds_3dformat_updown);
            this.panel_ds_leftright.Location = new System.Drawing.Point(32, 224);
            this.panel_ds_leftright.Name = "panel_ds_leftright";
            this.panel_ds_leftright.Size = new System.Drawing.Size(128, 48);
            this.panel_ds_leftright.TabIndex = 18;
            // 
            // panel_ds_outcodec
            // 
            this.panel_ds_outcodec.Controls.Add(this.ds_out_h264);
            this.panel_ds_outcodec.Controls.Add(this.ds_out_mpeg);
            this.panel_ds_outcodec.Controls.Add(this.ds_out_mjpeg);
            this.panel_ds_outcodec.Location = new System.Drawing.Point(32, 352);
            this.panel_ds_outcodec.Name = "panel_ds_outcodec";
            this.panel_ds_outcodec.Size = new System.Drawing.Size(128, 80);
            this.panel_ds_outcodec.TabIndex = 19;
            // 
            // panel_scalefilter
            // 
            this.panel_scalefilter.Controls.Add(this.label5);
            this.panel_scalefilter.Controls.Add(this.scale_mix);
            this.panel_scalefilter.Controls.Add(this.scale_nearest);
            this.panel_scalefilter.Controls.Add(this.scale_linear);
            this.panel_scalefilter.Location = new System.Drawing.Point(112, 464);
            this.panel_scalefilter.Name = "panel_scalefilter";
            this.panel_scalefilter.Size = new System.Drawing.Size(104, 100);
            this.panel_scalefilter.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Scale filter:";
            // 
            // scale_mix
            // 
            this.scale_mix.AutoSize = true;
            this.scale_mix.Location = new System.Drawing.Point(0, 80);
            this.scale_mix.Name = "scale_mix";
            this.scale_mix.Size = new System.Drawing.Size(41, 17);
            this.scale_mix.TabIndex = 2;
            this.scale_mix.TabStop = true;
            this.scale_mix.Text = "Mix";
            this.toolTip1.SetToolTip(this.scale_mix, resources.GetString("scale_mix.ToolTip"));
            this.scale_mix.UseVisualStyleBackColor = true;
            this.scale_mix.CheckedChanged += new System.EventHandler(this.test);
            // 
            // scale_nearest
            // 
            this.scale_nearest.AutoSize = true;
            this.scale_nearest.Location = new System.Drawing.Point(0, 48);
            this.scale_nearest.Name = "scale_nearest";
            this.scale_nearest.Size = new System.Drawing.Size(108, 17);
            this.scale_nearest.TabIndex = 1;
            this.scale_nearest.TabStop = true;
            this.scale_nearest.Text = "Nearest Neighbor";
            this.scale_nearest.UseVisualStyleBackColor = true;
            this.scale_nearest.CheckedChanged += new System.EventHandler(this.test);
            // 
            // scale_linear
            // 
            this.scale_linear.AutoSize = true;
            this.scale_linear.Location = new System.Drawing.Point(0, 16);
            this.scale_linear.Name = "scale_linear";
            this.scale_linear.Size = new System.Drawing.Size(65, 17);
            this.scale_linear.TabIndex = 0;
            this.scale_linear.TabStop = true;
            this.scale_linear.Text = "Lanczos";
            this.scale_linear.UseVisualStyleBackColor = true;
            this.scale_linear.CheckedChanged += new System.EventHandler(this.test);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "Select a input video";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 22);
            this.button1.TabIndex = 22;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stretch_full
            // 
            this.stretch_full.AutoSize = true;
            this.stretch_full.Location = new System.Drawing.Point(0, 80);
            this.stretch_full.Name = "stretch_full";
            this.stretch_full.Size = new System.Drawing.Size(76, 17);
            this.stretch_full.TabIndex = 2;
            this.stretch_full.TabStop = true;
            this.stretch_full.Text = "Full stretch";
            this.toolTip1.SetToolTip(this.stretch_full, "Stretches the video on both dimension so it fully fills the 3DS screen.");
            this.stretch_full.UseVisualStyleBackColor = true;
            this.stretch_full.CheckedChanged += new System.EventHandler(this.test);
            // 
            // stretch_10
            // 
            this.stretch_10.AutoSize = true;
            this.stretch_10.Location = new System.Drawing.Point(0, 48);
            this.stretch_10.Name = "stretch_10";
            this.stretch_10.Size = new System.Drawing.Size(80, 17);
            this.stretch_10.TabIndex = 1;
            this.stretch_10.TabStop = true;
            this.stretch_10.Text = "10% stretch";
            this.toolTip1.SetToolTip(this.stretch_10, "Scales the video vertically by 10%.");
            this.stretch_10.UseVisualStyleBackColor = true;
            this.stretch_10.CheckedChanged += new System.EventHandler(this.test);
            // 
            // surround
            // 
            this.surround.AutoSize = true;
            this.surround.Location = new System.Drawing.Point(16, 512);
            this.surround.Name = "surround";
            this.surround.Size = new System.Drawing.Size(70, 43);
            this.surround.TabIndex = 35;
            this.surround.Text = "downmix \r\nsurround \r\nto stereo";
            this.toolTip1.SetToolTip(this.surround, resources.GetString("surround.ToolTip"));
            this.surround.UseVisualStyleBackColor = true;
            this.surround.CheckedChanged += new System.EventHandler(this.test);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 22);
            this.button2.TabIndex = 42;
            this.button2.Text = "convert folder";
            this.toolTip1.SetToolTip(this.button2, "select any file in the folder you want to convert");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_wii_tv_out
            // 
            this.panel_wii_tv_out.Controls.Add(this.w480p);
            this.panel_wii_tv_out.Controls.Add(this.w576p);
            this.panel_wii_tv_out.Location = new System.Drawing.Point(192, 96);
            this.panel_wii_tv_out.Name = "panel_wii_tv_out";
            this.panel_wii_tv_out.Size = new System.Drawing.Size(128, 48);
            this.panel_wii_tv_out.TabIndex = 29;
            // 
            // w480p
            // 
            this.w480p.AutoSize = true;
            this.w480p.Location = new System.Drawing.Point(0, 0);
            this.w480p.Name = "w480p";
            this.w480p.Size = new System.Drawing.Size(61, 17);
            this.w480p.TabIndex = 2;
            this.w480p.TabStop = true;
            this.w480p.Text = "480p60";
            this.w480p.UseVisualStyleBackColor = true;
            this.w480p.CheckedChanged += new System.EventHandler(this.test);
            // 
            // w576p
            // 
            this.w576p.AutoSize = true;
            this.w576p.Location = new System.Drawing.Point(0, 32);
            this.w576p.Name = "w576p";
            this.w576p.Size = new System.Drawing.Size(57, 17);
            this.w576p.TabIndex = 3;
            this.w576p.TabStop = true;
            this.w576p.Text = "576i50";
            this.w576p.UseVisualStyleBackColor = true;
            this.w576p.CheckedChanged += new System.EventHandler(this.test);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(192, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Wii TV out:";
            // 
            // wii_output_codec
            // 
            this.wii_output_codec.Controls.Add(this.wii_xvid);
            this.wii_output_codec.Controls.Add(this.wii_h263);
            this.wii_output_codec.Controls.Add(this.wii_mjpeg);
            this.wii_output_codec.Location = new System.Drawing.Point(192, 352);
            this.wii_output_codec.Name = "wii_output_codec";
            this.wii_output_codec.Size = new System.Drawing.Size(128, 80);
            this.wii_output_codec.TabIndex = 20;
            // 
            // wii_xvid
            // 
            this.wii_xvid.AutoSize = true;
            this.wii_xvid.Location = new System.Drawing.Point(0, 32);
            this.wii_xvid.Name = "wii_xvid";
            this.wii_xvid.Size = new System.Drawing.Size(50, 17);
            this.wii_xvid.TabIndex = 7;
            this.wii_xvid.TabStop = true;
            this.wii_xvid.Text = "XVID";
            this.wii_xvid.UseVisualStyleBackColor = true;
            this.wii_xvid.CheckedChanged += new System.EventHandler(this.test);
            // 
            // wii_h263
            // 
            this.wii_h263.AutoSize = true;
            this.wii_h263.Location = new System.Drawing.Point(0, 0);
            this.wii_h263.Name = "wii_h263";
            this.wii_h263.Size = new System.Drawing.Size(51, 17);
            this.wii_h263.TabIndex = 10;
            this.wii_h263.TabStop = true;
            this.wii_h263.Text = "H263";
            this.wii_h263.UseVisualStyleBackColor = true;
            this.wii_h263.CheckedChanged += new System.EventHandler(this.test);
            // 
            // wii_mjpeg
            // 
            this.wii_mjpeg.AutoSize = true;
            this.wii_mjpeg.Location = new System.Drawing.Point(0, 64);
            this.wii_mjpeg.Name = "wii_mjpeg";
            this.wii_mjpeg.Size = new System.Drawing.Size(61, 17);
            this.wii_mjpeg.TabIndex = 8;
            this.wii_mjpeg.TabStop = true;
            this.wii_mjpeg.Text = "MJPEG";
            this.wii_mjpeg.UseVisualStyleBackColor = true;
            this.wii_mjpeg.CheckedChanged += new System.EventHandler(this.test);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(192, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Output codec:";
            // 
            // panel_wii_aspect
            // 
            this.panel_wii_aspect.Controls.Add(this.wii_169);
            this.panel_wii_aspect.Controls.Add(this.wii_43);
            this.panel_wii_aspect.Location = new System.Drawing.Point(192, 176);
            this.panel_wii_aspect.Name = "panel_wii_aspect";
            this.panel_wii_aspect.Size = new System.Drawing.Size(128, 48);
            this.panel_wii_aspect.TabIndex = 21;
            // 
            // wii_169
            // 
            this.wii_169.AutoSize = true;
            this.wii_169.Location = new System.Drawing.Point(0, 0);
            this.wii_169.Name = "wii_169";
            this.wii_169.Size = new System.Drawing.Size(46, 17);
            this.wii_169.TabIndex = 7;
            this.wii_169.TabStop = true;
            this.wii_169.Text = "16:9";
            this.wii_169.UseVisualStyleBackColor = true;
            this.wii_169.CheckedChanged += new System.EventHandler(this.test);
            // 
            // wii_43
            // 
            this.wii_43.AutoSize = true;
            this.wii_43.Location = new System.Drawing.Point(0, 32);
            this.wii_43.Name = "wii_43";
            this.wii_43.Size = new System.Drawing.Size(40, 17);
            this.wii_43.TabIndex = 10;
            this.wii_43.TabStop = true;
            this.wii_43.Text = "4:3";
            this.wii_43.UseVisualStyleBackColor = true;
            this.wii_43.CheckedChanged += new System.EventHandler(this.test);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(192, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "TV Aspect ratio";
            // 
            // debug_textbox
            // 
            this.debug_textbox.BackColor = System.Drawing.SystemColors.Menu;
            this.debug_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.debug_textbox.Location = new System.Drawing.Point(0, 688);
            this.debug_textbox.Name = "debug_textbox";
            this.debug_textbox.Size = new System.Drawing.Size(640, 256);
            this.debug_textbox.TabIndex = 33;
            this.debug_textbox.Text = "";
            // 
            // panel_stretch
            // 
            this.panel_stretch.Controls.Add(this.label6);
            this.panel_stretch.Controls.Add(this.stretch_full);
            this.panel_stretch.Controls.Add(this.stretch_10);
            this.panel_stretch.Controls.Add(this.stretch_no);
            this.panel_stretch.Location = new System.Drawing.Point(224, 464);
            this.panel_stretch.Name = "panel_stretch";
            this.panel_stretch.Size = new System.Drawing.Size(104, 100);
            this.panel_stretch.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "V. Stretch:";
            // 
            // stretch_no
            // 
            this.stretch_no.AutoSize = true;
            this.stretch_no.Location = new System.Drawing.Point(0, 16);
            this.stretch_no.Name = "stretch_no";
            this.stretch_no.Size = new System.Drawing.Size(74, 17);
            this.stretch_no.TabIndex = 0;
            this.stretch_no.TabStop = true;
            this.stretch_no.Text = "No stretch";
            this.stretch_no.UseVisualStyleBackColor = true;
            this.stretch_no.CheckedChanged += new System.EventHandler(this.test);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(0, 672);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "debug values";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 608);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 20);
            this.textBox2.TabIndex = 36;
            // 
            // panel_wii_fps
            // 
            this.panel_wii_fps.Controls.Add(this.wii_6050);
            this.panel_wii_fps.Controls.Add(this.wii_3025);
            this.panel_wii_fps.Location = new System.Drawing.Point(192, 272);
            this.panel_wii_fps.Name = "panel_wii_fps";
            this.panel_wii_fps.Size = new System.Drawing.Size(128, 48);
            this.panel_wii_fps.TabIndex = 22;
            // 
            // wii_6050
            // 
            this.wii_6050.AutoSize = true;
            this.wii_6050.Location = new System.Drawing.Point(0, 0);
            this.wii_6050.Name = "wii_6050";
            this.wii_6050.Size = new System.Drawing.Size(82, 17);
            this.wii_6050.TabIndex = 7;
            this.wii_6050.TabStop = true;
            this.wii_6050.Text = "60fps/50fps";
            this.wii_6050.UseVisualStyleBackColor = true;
            // 
            // wii_3025
            // 
            this.wii_3025.AutoSize = true;
            this.wii_3025.Location = new System.Drawing.Point(0, 32);
            this.wii_3025.Name = "wii_3025";
            this.wii_3025.Size = new System.Drawing.Size(82, 17);
            this.wii_3025.TabIndex = 10;
            this.wii_3025.TabStop = true;
            this.wii_3025.Text = "30fps/25fps";
            this.wii_3025.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(192, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Framerate";
            // 
            // nobframes
            // 
            this.nobframes.AutoSize = true;
            this.nobframes.Location = new System.Drawing.Point(0, 576);
            this.nobframes.Name = "nobframes";
            this.nobframes.Size = new System.Drawing.Size(90, 17);
            this.nobframes.TabIndex = 38;
            this.nobframes.Text = "BFrames \"fix\"";
            this.nobframes.UseVisualStyleBackColor = true;
            // 
            // nodeblock
            // 
            this.nodeblock.AutoSize = true;
            this.nodeblock.Location = new System.Drawing.Point(96, 576);
            this.nodeblock.Name = "nodeblock";
            this.nodeblock.Size = new System.Drawing.Size(81, 17);
            this.nodeblock.TabIndex = 39;
            this.nodeblock.Text = "No deblock";
            this.nodeblock.UseVisualStyleBackColor = true;
            // 
            // dualaudiotracks
            // 
            this.dualaudiotracks.AutoSize = true;
            this.dualaudiotracks.Location = new System.Drawing.Point(176, 576);
            this.dualaudiotracks.Name = "dualaudiotracks";
            this.dualaudiotracks.Size = new System.Drawing.Size(97, 17);
            this.dualaudiotracks.TabIndex = 40;
            this.dualaudiotracks.Text = "all audio tracks";
            this.dualaudiotracks.UseVisualStyleBackColor = true;
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.version.Location = new System.Drawing.Point(0, 552);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(34, 13);
            this.version.TabIndex = 41;
            this.version.TabStop = true;
            this.version.Text = "vx.x.x";
            this.version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.version_LinkClicked);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(416, 240);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(256, 394);
            this.listBox1.TabIndex = 43;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(688, 240);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(256, 394);
            this.listBox2.TabIndex = 44;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(416, 16);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(528, 199);
            this.listBox3.TabIndex = 45;
            // 
            // suboffset
            // 
            this.suboffset.Location = new System.Drawing.Point(208, 608);
            this.suboffset.Name = "suboffset";
            this.suboffset.Size = new System.Drawing.Size(192, 20);
            this.suboffset.TabIndex = 46;
            // 
            // embeddedsubs
            // 
            this.embeddedsubs.AutoSize = true;
            this.embeddedsubs.Location = new System.Drawing.Point(272, 570);
            this.embeddedsubs.Name = "embeddedsubs";
            this.embeddedsubs.Size = new System.Drawing.Size(140, 30);
            this.embeddedsubs.TabIndex = 47;
            this.embeddedsubs.Text = "Subtitles are embedded \r\nin video";
            this.embeddedsubs.UseVisualStyleBackColor = true;
            // 
            // cusresx
            // 
            this.cusresx.Location = new System.Drawing.Point(0, 640);
            this.cusresx.Name = "cusresx";
            this.cusresx.Size = new System.Drawing.Size(192, 20);
            this.cusresx.TabIndex = 48;
            // 
            // cusresy
            // 
            this.cusresy.Location = new System.Drawing.Point(208, 640);
            this.cusresy.Name = "cusresy";
            this.cusresy.Size = new System.Drawing.Size(192, 20);
            this.cusresy.TabIndex = 49;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 903);
            this.Controls.Add(this.cusresy);
            this.Controls.Add(this.cusresx);
            this.Controls.Add(this.embeddedsubs);
            this.Controls.Add(this.suboffset);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.version);
            this.Controls.Add(this.dualaudiotracks);
            this.Controls.Add(this.nodeblock);
            this.Controls.Add(this.nobframes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel_wii_fps);
            this.Controls.Add(this.panel_wii_aspect);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.surround);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel_stretch);
            this.Controls.Add(this.debug_textbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.wii_output_codec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_wii_tv_out);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_scalefilter);
            this.Controls.Add(this.panel_ds_outcodec);
            this.Controls.Add(this.panel_ds_leftright);
            this.Controls.Add(this.panel_ds_or_wii);
            this.Controls.Add(this.panel_ds_vf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.convert_button);
            this.Controls.Add(this.ds_3dformat_swap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nintendo Video Convertor";
            this.panel_ds_vf.ResumeLayout(false);
            this.panel_ds_vf.PerformLayout();
            this.panel_ds_or_wii.ResumeLayout(false);
            this.panel_ds_or_wii.PerformLayout();
            this.panel_ds_leftright.ResumeLayout(false);
            this.panel_ds_leftright.PerformLayout();
            this.panel_ds_outcodec.ResumeLayout(false);
            this.panel_ds_outcodec.PerformLayout();
            this.panel_scalefilter.ResumeLayout(false);
            this.panel_scalefilter.PerformLayout();
            this.panel_wii_tv_out.ResumeLayout(false);
            this.panel_wii_tv_out.PerformLayout();
            this.wii_output_codec.ResumeLayout(false);
            this.wii_output_codec.PerformLayout();
            this.panel_wii_aspect.ResumeLayout(false);
            this.panel_wii_aspect.PerformLayout();
            this.panel_stretch.ResumeLayout(false);
            this.panel_stretch.PerformLayout();
            this.panel_wii_fps.ResumeLayout(false);
            this.panel_wii_fps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Wii3DS_radio_3DS;
        private System.Windows.Forms.RadioButton Wii3DS_radio_Wii;
        private System.Windows.Forms.RadioButton ds_vf_standard;
        private System.Windows.Forms.RadioButton ds_vf_horihd;
        private System.Windows.Forms.RadioButton ds_vf_3d;
        private System.Windows.Forms.RadioButton ds_3dformat_leftright;
        private System.Windows.Forms.RadioButton ds_3dformat_updown;
        private System.Windows.Forms.RadioButton ds_out_h264;
        private System.Windows.Forms.RadioButton ds_out_mjpeg;
        private System.Windows.Forms.CheckBox ds_3dformat_swap;
        private System.Windows.Forms.RadioButton ds_out_mpeg;
        private System.Windows.Forms.Button convert_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_ds_vf;
        private System.Windows.Forms.Panel panel_ds_or_wii;
        private System.Windows.Forms.Panel panel_ds_leftright;
        private System.Windows.Forms.Panel panel_ds_outcodec;
        private System.Windows.Forms.Panel panel_scalefilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton scale_mix;
        private System.Windows.Forms.RadioButton scale_nearest;
        private System.Windows.Forms.RadioButton scale_linear;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_wii_tv_out;
        private System.Windows.Forms.RadioButton w480p;
        private System.Windows.Forms.RadioButton w576p;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel wii_output_codec;
        private System.Windows.Forms.RadioButton wii_xvid;
        private System.Windows.Forms.RadioButton wii_h263;
        private System.Windows.Forms.RadioButton wii_mjpeg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel_wii_aspect;
        private System.Windows.Forms.RadioButton wii_169;
        private System.Windows.Forms.RadioButton wii_43;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox debug_textbox;
        private System.Windows.Forms.Panel panel_stretch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton stretch_full;
        private System.Windows.Forms.RadioButton stretch_10;
        private System.Windows.Forms.RadioButton stretch_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox surround;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel_wii_fps;
        private System.Windows.Forms.RadioButton wii_6050;
        private System.Windows.Forms.RadioButton wii_3025;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox nobframes;
        private System.Windows.Forms.CheckBox nodeblock;
        private System.Windows.Forms.CheckBox dualaudiotracks;
        private System.Windows.Forms.LinkLabel version;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.TextBox suboffset;
        public System.Windows.Forms.CheckBox embeddedsubs;
        private System.Windows.Forms.TextBox cusresx;
        private System.Windows.Forms.TextBox cusresy;
    }
}

