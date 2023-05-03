namespace Proyecto_Compiladores_2023
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btnIdentificarTokens = new System.Windows.Forms.Button();
			this.TextBox_Numero = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.TextBox_Programa = new System.Windows.Forms.TextBox();
			this.TextBox_Identificador = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.DataGredView_Tokens = new System.Windows.Forms.DataGridView();
			this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label10 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEdosAFD = new System.Windows.Forms.TextBox();
			this.tablaAFD = new System.Windows.Forms.DataGridView();
			this.button4 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button3 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGredView_Tokens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tablaAFD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.LimeGreen;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(236, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(578, 39);
			this.label5.TabIndex = 6;
			this.label5.Text = "Oscar Almendariz Rodríguez\r\nJosé Ivan Linares Camacho\r\n";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.LimeGreen;
			this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label4.Location = new System.Drawing.Point(304, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(444, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Fundamentos de compiladores - Equipo Lovelace";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LimeGreen;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(-216, -13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1356, 72);
			this.label1.TabIndex = 4;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Button1
			// 
			this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Button1.Location = new System.Drawing.Point(96, 60);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(109, 21);
			this.Button1.TabIndex = 11;
			this.Button1.Text = "Convertir a postfija";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button1.Click += new System.EventHandler(this.btnRegularPostija_Click);
			// 
			// TextBox2
			// 
			this.TextBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox2.Location = new System.Drawing.Point(9, 87);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.ReadOnly = true;
			this.TextBox2.Size = new System.Drawing.Size(256, 23);
			this.TextBox2.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(6, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Postfija";
			// 
			// TextBox1
			// 
			this.TextBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox1.Location = new System.Drawing.Point(9, 33);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(256, 23);
			this.TextBox1.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Expresión Regular";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(211, 60);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(54, 21);
			this.button2.TabIndex = 12;
			this.button2.Text = "Limpiar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.btnIdentificarTokens);
			this.groupBox1.Controls.Add(this.TextBox_Numero);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.TextBox_Programa);
			this.groupBox1.Controls.Add(this.TextBox_Identificador);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.DataGredView_Tokens);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtEdosAFD);
			this.groupBox1.Controls.Add(this.tablaAFD);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.TextBox1);
			this.groupBox1.Controls.Add(this.Button1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TextBox2);
			this.groupBox1.Location = new System.Drawing.Point(5, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1037, 497);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Análisis Léxico";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(773, 60);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(134, 13);
			this.label14.TabIndex = 35;
			this.label14.Text = "Programa en lenguaje TINY";
			// 
			// btnIdentificarTokens
			// 
			this.btnIdentificarTokens.Location = new System.Drawing.Point(924, 202);
			this.btnIdentificarTokens.Name = "btnIdentificarTokens";
			this.btnIdentificarTokens.Size = new System.Drawing.Size(111, 23);
			this.btnIdentificarTokens.TabIndex = 34;
			this.btnIdentificarTokens.Text = "Clasifica Tokens";
			this.btnIdentificarTokens.UseVisualStyleBackColor = true;
			this.btnIdentificarTokens.Click += new System.EventHandler(this.btnIdentificarTokens_Click);
			// 
			// TextBox_Numero
			// 
			this.TextBox_Numero.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox_Numero.Location = new System.Drawing.Point(912, 29);
			this.TextBox_Numero.Name = "TextBox_Numero";
			this.TextBox_Numero.Size = new System.Drawing.Size(107, 24);
			this.TextBox_Numero.TabIndex = 33;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(909, 13);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(45, 13);
			this.label13.TabIndex = 32;
			this.label13.Text = "Número";
			// 
			// TextBox_Programa
			// 
			this.TextBox_Programa.AcceptsTab = true;
			this.TextBox_Programa.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox_Programa.Location = new System.Drawing.Point(776, 76);
			this.TextBox_Programa.Multiline = true;
			this.TextBox_Programa.Name = "TextBox_Programa";
			this.TextBox_Programa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox_Programa.Size = new System.Drawing.Size(255, 123);
			this.TextBox_Programa.TabIndex = 30;
			// 
			// TextBox_Identificador
			// 
			this.TextBox_Identificador.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox_Identificador.Location = new System.Drawing.Point(776, 29);
			this.TextBox_Identificador.Name = "TextBox_Identificador";
			this.TextBox_Identificador.Size = new System.Drawing.Size(131, 24);
			this.TextBox_Identificador.TabIndex = 31;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(773, 13);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(67, 13);
			this.label12.TabIndex = 29;
			this.label12.Text = "Identificador";
			// 
			// DataGredView_Tokens
			// 
			this.DataGredView_Tokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DataGredView_Tokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGredView_Tokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Lexema});
			this.DataGredView_Tokens.Location = new System.Drawing.Point(776, 231);
			this.DataGredView_Tokens.Name = "DataGredView_Tokens";
			this.DataGredView_Tokens.RowHeadersVisible = false;
			this.DataGredView_Tokens.RowHeadersWidth = 20;
			this.DataGredView_Tokens.Size = new System.Drawing.Size(259, 238);
			this.DataGredView_Tokens.TabIndex = 28;
			// 
			// Nombre
			// 
			this.Nombre.HeaderText = "Nombre";
			this.Nombre.Name = "Nombre";
			// 
			// Lexema
			// 
			this.Lexema.HeaderText = "Lexema";
			this.Lexema.Name = "Lexema";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.ForestGreen;
			this.label10.Location = new System.Drawing.Point(415, 90);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(334, 14);
			this.label10.TabIndex = 26;
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(638, 62);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(111, 23);
			this.button5.TabIndex = 22;
			this.button5.Text = "Validar";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox6
			// 
			this.textBox6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox6.Location = new System.Drawing.Point(415, 32);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(334, 24);
			this.textBox6.TabIndex = 23;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(412, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(45, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "Lexema:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(535, 159);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(125, 14);
			this.label11.TabIndex = 25;
			this.label11.Text = "Estados de aceptación:";
			// 
			// textBox5
			// 
			this.textBox5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox5.Location = new System.Drawing.Point(666, 153);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(83, 24);
			this.textBox5.TabIndex = 24;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(548, 130);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 14);
			this.label9.TabIndex = 23;
			this.label9.Text = "Número de estados:";
			// 
			// txtEdosAFD
			// 
			this.txtEdosAFD.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEdosAFD.Location = new System.Drawing.Point(686, 124);
			this.txtEdosAFD.Name = "txtEdosAFD";
			this.txtEdosAFD.ReadOnly = true;
			this.txtEdosAFD.Size = new System.Drawing.Size(63, 24);
			this.txtEdosAFD.TabIndex = 22;
			// 
			// tablaAFD
			// 
			this.tablaAFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tablaAFD.Location = new System.Drawing.Point(415, 183);
			this.tablaAFD.Name = "tablaAFD";
			this.tablaAFD.RowHeadersWidth = 20;
			this.tablaAFD.Size = new System.Drawing.Size(334, 292);
			this.tablaAFD.TabIndex = 21;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(418, 154);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(111, 23);
			this.button4.TabIndex = 20;
			this.button4.Text = "Construir AFD";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(163, 157);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(144, 14);
			this.label7.TabIndex = 19;
			this.label7.Text = "Número de transiciones ε:";
			// 
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(313, 153);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(96, 24);
			this.textBox3.TabIndex = 18;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(195, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 14);
			this.label6.TabIndex = 17;
			this.label6.Text = "Número de estados:";
			// 
			// textBox4
			// 
			this.textBox4.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox4.Location = new System.Drawing.Point(313, 127);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(96, 24);
			this.textBox4.TabIndex = 16;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(9, 183);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 20;
			this.dataGridView1.Size = new System.Drawing.Size(400, 292);
			this.dataGridView1.TabIndex = 15;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 149);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "AFN";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 60);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1059, 516);
			this.tabControl1.TabIndex = 36;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1051, 491);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Análisis Léxico";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox7);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.button6);
			this.tabPage2.Controls.Add(this.dataGridView2);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1051, 491);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Análisis Sintáctico";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox7
			// 
			this.textBox7.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox7.Location = new System.Drawing.Point(4, 258);
			this.textBox7.Multiline = true;
			this.textBox7.Name = "textBox7";
			this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox7.Size = new System.Drawing.Size(716, 218);
			this.textBox7.TabIndex = 29;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(6, 239);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(110, 16);
			this.label15.TabIndex = 30;
			this.label15.Text = "Lista de conjuntos:";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(7, 10);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(255, 23);
			this.button6.TabIndex = 31;
			this.button6.Text = "Construir colección LR(0) Canónica";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// dataGridView2
			// 
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(7, 39);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersWidth = 20;
			this.dataGridView2.Size = new System.Drawing.Size(713, 187);
			this.dataGridView2.TabIndex = 32;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(1059, 588);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Proyecto Compiladores";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGredView_Tokens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tablaAFD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Button1;
		private System.Windows.Forms.TextBox TextBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtEdosAFD;
		private System.Windows.Forms.DataGridView tablaAFD;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnIdentificarTokens;
		private System.Windows.Forms.TextBox TextBox_Numero;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox TextBox_Programa;
		private System.Windows.Forms.TextBox TextBox_Identificador;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DataGridView DataGredView_Tokens;
		private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.DataGridView dataGridView2;
	}
}

