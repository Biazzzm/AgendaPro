namespace AgendaProTela
{
    partial class Form1
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
            btnDeletar = new Button();
            btnCancelarPost = new Button();
            btnSalvarPost = new Button();
            teltextBox3 = new TextBox();
            label3 = new Label();
            emailtextbox = new TextBox();
            label2 = new Label();
            NameTextBox = new TextBox();
            label1 = new Label();
            idTextBox = new TextBox();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDeletar
            // 
            btnDeletar.Location = new Point(323, 41);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(79, 26);
            btnDeletar.TabIndex = 3;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // btnCancelarPost
            // 
            btnCancelarPost.BackColor = SystemColors.ButtonFace;
            btnCancelarPost.Location = new Point(55, 250);
            btnCancelarPost.Name = "btnCancelarPost";
            btnCancelarPost.Size = new Size(84, 31);
            btnCancelarPost.TabIndex = 7;
            btnCancelarPost.Text = "Cancelar";
            btnCancelarPost.UseVisualStyleBackColor = false;
            btnCancelarPost.Click += btnCancelarPost_Click;
            // 
            // btnSalvarPost
            // 
            btnSalvarPost.BackColor = SystemColors.MenuHighlight;
            btnSalvarPost.Location = new Point(201, 250);
            btnSalvarPost.Name = "btnSalvarPost";
            btnSalvarPost.Size = new Size(84, 31);
            btnSalvarPost.TabIndex = 6;
            btnSalvarPost.Text = "Salvar";
            btnSalvarPost.UseVisualStyleBackColor = false;
            btnSalvarPost.Click += btnSalvarPost_Click;
            // 
            // teltextBox3
            // 
            teltextBox3.Location = new Point(55, 204);
            teltextBox3.Name = "teltextBox3";
            teltextBox3.Size = new Size(230, 23);
            teltextBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 207);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 4;
            label3.Text = "Tel";
            // 
            // emailtextbox
            // 
            emailtextbox.Location = new Point(55, 149);
            emailtextbox.Name = "emailtextbox";
            emailtextbox.Size = new Size(230, 23);
            emailtextbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 152);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "E-mail";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(55, 98);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(230, 23);
            NameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 101);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(729, 44);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(57, 23);
            idTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(706, 47);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 4;
            label4.Text = "Id";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(323, 98);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(673, 429);
            dataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 44);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 9;
            label5.Text = "Cadastro Contato";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 613);
            Controls.Add(label5);
            Controls.Add(idTextBox);
            Controls.Add(label4);
            Controls.Add(btnCancelarPost);
            Controls.Add(btnDeletar);
            Controls.Add(dataGridView1);
            Controls.Add(btnSalvarPost);
            Controls.Add(teltextBox3);
            Controls.Add(label3);
            Controls.Add(emailtextbox);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "AgendaPro";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button btnListar;
        private Button btnDeletar;
        private Panel panelcriar;
        private TextBox emailtextbox;
        private Label label2;
        private TextBox NameTextBox;
        private Label label1;
        private TextBox teltextBox3;
        private Label label3;
        private Button btnCancelarPost;
        private Button btnSalvarPost;
        private Panel panelListar;
        private TextBox idTextBox;
        private Label label4;
        private DataGridView dataGridView1;
        private Panel panelalterar;
        private Button btnCancelarPut;
        private Button btnSalvarPut;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private Button btnMenu;
        private Button btnAlterar;
    }
}
