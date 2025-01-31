namespace Aetherial_Engine
{
    partial class Engine
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Engine));
            this.properties_panel = new System.Windows.Forms.Panel();
            this.brtb_btn = new System.Windows.Forms.Button();
            this.setimage_btn = new System.Windows.Forms.Button();
            this.objimage_label = new System.Windows.Forms.Label();
            this.brtf_btn = new System.Windows.Forms.Button();
            this.objimage_input = new System.Windows.Forms.TextBox();
            this.removescript_button = new System.Windows.Forms.Button();
            this.properties_btn = new System.Windows.Forms.Button();
            this.objheight_label = new System.Windows.Forms.Label();
            this.objheight_input = new System.Windows.Forms.TextBox();
            this.objwidth_label = new System.Windows.Forms.Label();
            this.objwidth_input = new System.Windows.Forms.TextBox();
            this.objname_label = new System.Windows.Forms.Label();
            this.objname_input = new System.Windows.Forms.TextBox();
            this.scriptslist = new System.Windows.Forms.ListBox();
            this.attachscript_button = new System.Windows.Forms.Button();
            this.objy_label = new System.Windows.Forms.Label();
            this.objy_input = new System.Windows.Forms.TextBox();
            this.objx_label = new System.Windows.Forms.Label();
            this.objx_input = new System.Windows.Forms.TextBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.play_button = new System.Windows.Forms.Button();
            this.createobj_btn = new System.Windows.Forms.Button();
            this.deleteobj_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.load_btn = new System.Windows.Forms.Button();
            this.clrconsole_btn = new System.Windows.Forms.Button();
            this.export_btn = new System.Windows.Forms.Button();
            this.exlogs_btn = new System.Windows.Forms.Button();
            this.properties_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // properties_panel
            // 
            this.properties_panel.AllowDrop = true;
            this.properties_panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.properties_panel.Controls.Add(this.brtb_btn);
            this.properties_panel.Controls.Add(this.setimage_btn);
            this.properties_panel.Controls.Add(this.objimage_label);
            this.properties_panel.Controls.Add(this.brtf_btn);
            this.properties_panel.Controls.Add(this.objimage_input);
            this.properties_panel.Controls.Add(this.removescript_button);
            this.properties_panel.Controls.Add(this.properties_btn);
            this.properties_panel.Controls.Add(this.objheight_label);
            this.properties_panel.Controls.Add(this.objheight_input);
            this.properties_panel.Controls.Add(this.objwidth_label);
            this.properties_panel.Controls.Add(this.objwidth_input);
            this.properties_panel.Controls.Add(this.objname_label);
            this.properties_panel.Controls.Add(this.objname_input);
            this.properties_panel.Controls.Add(this.scriptslist);
            this.properties_panel.Controls.Add(this.attachscript_button);
            this.properties_panel.Controls.Add(this.objy_label);
            this.properties_panel.Controls.Add(this.objy_input);
            this.properties_panel.Controls.Add(this.objx_label);
            this.properties_panel.Controls.Add(this.objx_input);
            this.properties_panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.properties_panel.Location = new System.Drawing.Point(628, -6);
            this.properties_panel.Name = "properties_panel";
            this.properties_panel.Size = new System.Drawing.Size(217, 582);
            this.properties_panel.TabIndex = 0;
            // 
            // brtb_btn
            // 
            this.brtb_btn.Enabled = false;
            this.brtb_btn.Location = new System.Drawing.Point(51, 344);
            this.brtb_btn.Name = "brtb_btn";
            this.brtb_btn.Size = new System.Drawing.Size(112, 23);
            this.brtb_btn.TabIndex = 19;
            this.brtb_btn.Text = "Bring to Back";
            this.brtb_btn.UseVisualStyleBackColor = true;
            this.brtb_btn.Click += new System.EventHandler(this.brtb_btn_Click);
            // 
            // setimage_btn
            // 
            this.setimage_btn.Enabled = false;
            this.setimage_btn.Location = new System.Drawing.Point(66, 274);
            this.setimage_btn.Name = "setimage_btn";
            this.setimage_btn.Size = new System.Drawing.Size(75, 23);
            this.setimage_btn.TabIndex = 17;
            this.setimage_btn.Text = "Set Image";
            this.setimage_btn.UseVisualStyleBackColor = true;
            this.setimage_btn.Click += new System.EventHandler(this.setimage_btn_Click);
            // 
            // objimage_label
            // 
            this.objimage_label.AutoSize = true;
            this.objimage_label.Location = new System.Drawing.Point(23, 248);
            this.objimage_label.Name = "objimage_label";
            this.objimage_label.Size = new System.Drawing.Size(81, 15);
            this.objimage_label.TabIndex = 16;
            this.objimage_label.Text = "Object Image:";
            this.objimage_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // brtf_btn
            // 
            this.brtf_btn.Enabled = false;
            this.brtf_btn.Location = new System.Drawing.Point(51, 315);
            this.brtf_btn.Name = "brtf_btn";
            this.brtf_btn.Size = new System.Drawing.Size(112, 23);
            this.brtf_btn.TabIndex = 18;
            this.brtf_btn.Text = "Bring to Front";
            this.brtf_btn.UseVisualStyleBackColor = true;
            this.brtf_btn.Click += new System.EventHandler(this.brtf_btn_Click);
            // 
            // objimage_input
            // 
            this.objimage_input.Enabled = false;
            this.objimage_input.Location = new System.Drawing.Point(109, 245);
            this.objimage_input.Name = "objimage_input";
            this.objimage_input.Size = new System.Drawing.Size(75, 23);
            this.objimage_input.TabIndex = 15;
            // 
            // removescript_button
            // 
            this.removescript_button.Enabled = false;
            this.removescript_button.Location = new System.Drawing.Point(66, 516);
            this.removescript_button.Name = "removescript_button";
            this.removescript_button.Size = new System.Drawing.Size(97, 23);
            this.removescript_button.TabIndex = 14;
            this.removescript_button.Text = "Remove Script";
            this.removescript_button.UseVisualStyleBackColor = true;
            this.removescript_button.Click += new System.EventHandler(this.removescript_button_Click);
            // 
            // properties_btn
            // 
            this.properties_btn.Location = new System.Drawing.Point(66, 18);
            this.properties_btn.Name = "properties_btn";
            this.properties_btn.Size = new System.Drawing.Size(97, 23);
            this.properties_btn.TabIndex = 13;
            this.properties_btn.Text = "Obj Properties";
            this.properties_btn.UseVisualStyleBackColor = true;
            this.properties_btn.Click += new System.EventHandler(this.properties_btn_Click);
            // 
            // objheight_label
            // 
            this.objheight_label.AutoSize = true;
            this.objheight_label.Location = new System.Drawing.Point(23, 219);
            this.objheight_label.Name = "objheight_label";
            this.objheight_label.Size = new System.Drawing.Size(84, 15);
            this.objheight_label.TabIndex = 12;
            this.objheight_label.Text = "Object Height:";
            this.objheight_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objheight_input
            // 
            this.objheight_input.Enabled = false;
            this.objheight_input.Location = new System.Drawing.Point(109, 216);
            this.objheight_input.Name = "objheight_input";
            this.objheight_input.Size = new System.Drawing.Size(75, 23);
            this.objheight_input.TabIndex = 11;
            this.objheight_input.TextChanged += new System.EventHandler(this.objheight_input_TextChanged);
            // 
            // objwidth_label
            // 
            this.objwidth_label.AutoSize = true;
            this.objwidth_label.Location = new System.Drawing.Point(23, 189);
            this.objwidth_label.Name = "objwidth_label";
            this.objwidth_label.Size = new System.Drawing.Size(80, 15);
            this.objwidth_label.TabIndex = 10;
            this.objwidth_label.Text = "Object Width:";
            this.objwidth_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objwidth_input
            // 
            this.objwidth_input.Enabled = false;
            this.objwidth_input.Location = new System.Drawing.Point(109, 186);
            this.objwidth_input.Name = "objwidth_input";
            this.objwidth_input.Size = new System.Drawing.Size(75, 23);
            this.objwidth_input.TabIndex = 9;
            this.objwidth_input.TextChanged += new System.EventHandler(this.objwidth_input_TextChanged);
            // 
            // objname_label
            // 
            this.objname_label.AutoSize = true;
            this.objname_label.Location = new System.Drawing.Point(23, 100);
            this.objname_label.Name = "objname_label";
            this.objname_label.Size = new System.Drawing.Size(80, 15);
            this.objname_label.TabIndex = 8;
            this.objname_label.Text = "Object Name:";
            this.objname_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objname_input
            // 
            this.objname_input.Enabled = false;
            this.objname_input.Location = new System.Drawing.Point(109, 98);
            this.objname_input.Name = "objname_input";
            this.objname_input.Size = new System.Drawing.Size(75, 23);
            this.objname_input.TabIndex = 7;
            // 
            // scriptslist
            // 
            this.scriptslist.Enabled = false;
            this.scriptslist.FormattingEnabled = true;
            this.scriptslist.ItemHeight = 15;
            this.scriptslist.Location = new System.Drawing.Point(51, 416);
            this.scriptslist.Name = "scriptslist";
            this.scriptslist.Size = new System.Drawing.Size(120, 94);
            this.scriptslist.TabIndex = 6;
            // 
            // attachscript_button
            // 
            this.attachscript_button.Enabled = false;
            this.attachscript_button.Location = new System.Drawing.Point(66, 387);
            this.attachscript_button.Name = "attachscript_button";
            this.attachscript_button.Size = new System.Drawing.Size(85, 23);
            this.attachscript_button.TabIndex = 5;
            this.attachscript_button.Text = "Attach Script";
            this.attachscript_button.UseVisualStyleBackColor = true;
            this.attachscript_button.Click += new System.EventHandler(this.attachscript_button_Click);
            // 
            // objy_label
            // 
            this.objy_label.AutoSize = true;
            this.objy_label.Location = new System.Drawing.Point(23, 160);
            this.objy_label.Name = "objy_label";
            this.objy_label.Size = new System.Drawing.Size(55, 15);
            this.objy_label.TabIndex = 4;
            this.objy_label.Text = "Object Y:";
            this.objy_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objy_input
            // 
            this.objy_input.Enabled = false;
            this.objy_input.Location = new System.Drawing.Point(84, 157);
            this.objy_input.Name = "objy_input";
            this.objy_input.Size = new System.Drawing.Size(100, 23);
            this.objy_input.TabIndex = 3;
            this.objy_input.TextChanged += new System.EventHandler(this.objy_input_TextChanged);
            // 
            // objx_label
            // 
            this.objx_label.AutoSize = true;
            this.objx_label.Location = new System.Drawing.Point(23, 130);
            this.objx_label.Name = "objx_label";
            this.objx_label.Size = new System.Drawing.Size(55, 15);
            this.objx_label.TabIndex = 2;
            this.objx_label.Text = "Object X:";
            this.objx_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objx_input
            // 
            this.objx_input.Enabled = false;
            this.objx_input.Location = new System.Drawing.Point(84, 127);
            this.objx_input.Name = "objx_input";
            this.objx_input.Size = new System.Drawing.Size(100, 23);
            this.objx_input.TabIndex = 1;
            this.objx_input.TextChanged += new System.EventHandler(this.objx_input_TextChanged);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.ControlDark;
            this.console.Location = new System.Drawing.Point(0, 574);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(845, 86);
            this.console.TabIndex = 1;
            this.console.Text = "Aetherial started up successfully!\n";
            // 
            // play_button
            // 
            this.play_button.Location = new System.Drawing.Point(12, 12);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(42, 23);
            this.play_button.TabIndex = 2;
            this.play_button.Text = "Play";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // createobj_btn
            // 
            this.createobj_btn.Location = new System.Drawing.Point(440, 12);
            this.createobj_btn.Name = "createobj_btn";
            this.createobj_btn.Size = new System.Drawing.Size(88, 23);
            this.createobj_btn.TabIndex = 4;
            this.createobj_btn.Text = "Create Object";
            this.createobj_btn.UseVisualStyleBackColor = true;
            this.createobj_btn.Click += new System.EventHandler(this.createobj_btn_Click_1);
            // 
            // deleteobj_btn
            // 
            this.deleteobj_btn.Location = new System.Drawing.Point(534, 12);
            this.deleteobj_btn.Name = "deleteobj_btn";
            this.deleteobj_btn.Size = new System.Drawing.Size(88, 23);
            this.deleteobj_btn.TabIndex = 5;
            this.deleteobj_btn.Text = "Delete Object";
            this.deleteobj_btn.UseVisualStyleBackColor = true;
            this.deleteobj_btn.Click += new System.EventHandler(this.removeobj_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(440, 545);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(54, 23);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(500, 545);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(54, 23);
            this.load_btn.TabIndex = 7;
            this.load_btn.Text = "Load";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // clrconsole_btn
            // 
            this.clrconsole_btn.Location = new System.Drawing.Point(12, 545);
            this.clrconsole_btn.Name = "clrconsole_btn";
            this.clrconsole_btn.Size = new System.Drawing.Size(93, 23);
            this.clrconsole_btn.TabIndex = 8;
            this.clrconsole_btn.Text = "Clear Console";
            this.clrconsole_btn.UseVisualStyleBackColor = true;
            this.clrconsole_btn.Click += new System.EventHandler(this.clrconsole_btn_Click);
            // 
            // export_btn
            // 
            this.export_btn.Enabled = false;
            this.export_btn.Location = new System.Drawing.Point(560, 545);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(54, 23);
            this.export_btn.TabIndex = 9;
            this.export_btn.Text = "Export";
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // exlogs_btn
            // 
            this.exlogs_btn.Location = new System.Drawing.Point(111, 545);
            this.exlogs_btn.Name = "exlogs_btn";
            this.exlogs_btn.Size = new System.Drawing.Size(77, 23);
            this.exlogs_btn.TabIndex = 10;
            this.exlogs_btn.Text = "Export Logs";
            this.exlogs_btn.UseVisualStyleBackColor = true;
            this.exlogs_btn.Click += new System.EventHandler(this.exlogs_btn_Click);
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(840, 656);
            this.Controls.Add(this.exlogs_btn);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.clrconsole_btn);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.deleteobj_btn);
            this.Controls.Add(this.createobj_btn);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.console);
            this.Controls.Add(this.properties_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Engine";
            this.Text = "Aetherial Engine";
            this.properties_panel.ResumeLayout(false);
            this.properties_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel properties_panel;
        public RichTextBox console;
        private Button play_button;
        private Label objx_label;
        private TextBox objx_input;
        private Label objy_label;
        private TextBox objy_input;
        private ListBox scriptslist;
        private Button attachscript_button;
        private Label objname_label;
        private Button createobj_btn;
        private Label objheight_label;
        private TextBox objheight_input;
        private Label objwidth_label;
        private TextBox objwidth_input;
        private Button properties_btn;
        private Button deleteobj_btn;
        private TextBox objname_input;
        private Button removescript_button;
        private Button save_btn;
        private Button load_btn;
        private Button setimage_btn;
        private Label objimage_label;
        private TextBox objimage_input;
        private Button clrconsole_btn;
        private Button export_btn;
        private Button exlogs_btn;
        private Button brtf_btn;
        private Button brtb_btn;
    }
}