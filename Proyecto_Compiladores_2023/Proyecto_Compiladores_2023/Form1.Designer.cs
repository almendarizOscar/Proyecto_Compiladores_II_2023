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
			this.BotonConvertirPosfija = new System.Windows.Forms.Button();
			this.txtPostfija = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ExpresionRegular = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.LimeGreen;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(134, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(578, 39);
			this.label5.TabIndex = 6;
			this.label5.Text = "Oscar Almendariz Rodríguez\r\nJosé Ivan Linares Camacho\r\n";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.LimeGreen;
			this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label4.Location = new System.Drawing.Point(202, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(428, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Fundamentos de compiladores - Equipo Hopper";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LimeGreen;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(-216, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1177, 72);
			this.label1.TabIndex = 4;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BotonConvertirPosfija
			// 
			this.BotonConvertirPosfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BotonConvertirPosfija.Location = new System.Drawing.Point(131, 130);
			this.BotonConvertirPosfija.Name = "BotonConvertirPosfija";
			this.BotonConvertirPosfija.Size = new System.Drawing.Size(140, 21);
			this.BotonConvertirPosfija.TabIndex = 11;
			this.BotonConvertirPosfija.Text = "Convertir a postfija";
			this.BotonConvertirPosfija.UseVisualStyleBackColor = true;
			this.BotonConvertirPosfija.Click += new System.EventHandler(this.btnRegularPostija_Click);
			// 
			// txtPostfija
			// 
			this.txtPostfija.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPostfija.Location = new System.Drawing.Point(15, 155);
			this.txtPostfija.Name = "txtPostfija";
			this.txtPostfija.Size = new System.Drawing.Size(256, 19);
			this.txtPostfija.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 141);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Postfija";
			// 
			// ExpresionRegular
			// 
			this.ExpresionRegular.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExpresionRegular.Location = new System.Drawing.Point(15, 106);
			this.ExpresionRegular.Name = "ExpresionRegular";
			this.ExpresionRegular.Size = new System.Drawing.Size(256, 19);
			this.ExpresionRegular.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Expresión Regular";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 415);
			this.Controls.Add(this.BotonConvertirPosfija);
			this.Controls.Add(this.txtPostfija);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ExpresionRegular);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BotonConvertirPosfija;
		private System.Windows.Forms.TextBox txtPostfija;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ExpresionRegular;
		private System.Windows.Forms.Label label2;
	}
}

