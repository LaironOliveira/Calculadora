namespace Calculadora
{
    partial class Frm_calc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_calc));
            this.Lbl_resultado = new System.Windows.Forms.Label();
            this.Btn_porcentagem = new System.Windows.Forms.Button();
            this.Btn_limpar_resultado = new System.Windows.Forms.Button();
            this.Btn_limpar = new System.Windows.Forms.Button();
            this.Btn_limpar_unidade = new System.Windows.Forms.Button();
            this.Lbl_calculando = new System.Windows.Forms.Label();
            this.Btn_fracao = new System.Windows.Forms.Button();
            this.Btn_elevar_quadrado = new System.Windows.Forms.Button();
            this.Btn_raiz_quadrada = new System.Windows.Forms.Button();
            this.Btn_divisao = new System.Windows.Forms.Button();
            this.Btn_multiplicacao = new System.Windows.Forms.Button();
            this.Btn_subtracao = new System.Windows.Forms.Button();
            this.Btn_adicao = new System.Windows.Forms.Button();
            this.Btn_resultado = new System.Windows.Forms.Button();
            this.Btn_sete = new System.Windows.Forms.Button();
            this.Btn_oito = new System.Windows.Forms.Button();
            this.Btn_nove = new System.Windows.Forms.Button();
            this.Btn_seis = new System.Windows.Forms.Button();
            this.Btn_cinco = new System.Windows.Forms.Button();
            this.Btn_quatro = new System.Windows.Forms.Button();
            this.Btn_tres = new System.Windows.Forms.Button();
            this.Btn_dois = new System.Windows.Forms.Button();
            this.Btn_um = new System.Windows.Forms.Button();
            this.Btn_virgula = new System.Windows.Forms.Button();
            this.Btn_zero = new System.Windows.Forms.Button();
            this.Btn_inverte_sinal = new System.Windows.Forms.Button();
            this.Lbl_operacao_passada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_resultado
            // 
            this.Lbl_resultado.AutoSize = true;
            this.Lbl_resultado.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Lbl_resultado.Location = new System.Drawing.Point(11, 75);
            this.Lbl_resultado.Name = "Lbl_resultado";
            this.Lbl_resultado.Size = new System.Drawing.Size(42, 50);
            this.Lbl_resultado.TabIndex = 0;
            this.Lbl_resultado.Text = "0";
            // 
            // Btn_porcentagem
            // 
            this.Btn_porcentagem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_porcentagem.Location = new System.Drawing.Point(11, 139);
            this.Btn_porcentagem.Name = "Btn_porcentagem";
            this.Btn_porcentagem.Size = new System.Drawing.Size(72, 44);
            this.Btn_porcentagem.TabIndex = 21;
            this.Btn_porcentagem.Text = "%";
            this.Btn_porcentagem.UseVisualStyleBackColor = true;
            this.Btn_porcentagem.Click += new System.EventHandler(this.Btn_porcentagem_Click);
            // 
            // Btn_limpar_resultado
            // 
            this.Btn_limpar_resultado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_limpar_resultado.Location = new System.Drawing.Point(89, 139);
            this.Btn_limpar_resultado.Name = "Btn_limpar_resultado";
            this.Btn_limpar_resultado.Size = new System.Drawing.Size(72, 44);
            this.Btn_limpar_resultado.TabIndex = 3;
            this.Btn_limpar_resultado.Text = "CE";
            this.Btn_limpar_resultado.UseVisualStyleBackColor = true;
            this.Btn_limpar_resultado.Click += new System.EventHandler(this.Btn_limpar_resultado_Click);
            // 
            // Btn_limpar
            // 
            this.Btn_limpar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_limpar.Location = new System.Drawing.Point(167, 139);
            this.Btn_limpar.Name = "Btn_limpar";
            this.Btn_limpar.Size = new System.Drawing.Size(72, 44);
            this.Btn_limpar.TabIndex = 2;
            this.Btn_limpar.Text = "C";
            this.Btn_limpar.UseVisualStyleBackColor = true;
            this.Btn_limpar.Click += new System.EventHandler(this.Btn_limpar_Click);
            // 
            // Btn_limpar_unidade
            // 
            this.Btn_limpar_unidade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_limpar_unidade.BackgroundImage")));
            this.Btn_limpar_unidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_limpar_unidade.Location = new System.Drawing.Point(245, 139);
            this.Btn_limpar_unidade.Name = "Btn_limpar_unidade";
            this.Btn_limpar_unidade.Size = new System.Drawing.Size(72, 44);
            this.Btn_limpar_unidade.TabIndex = 1;
            this.Btn_limpar_unidade.UseVisualStyleBackColor = true;
            this.Btn_limpar_unidade.Click += new System.EventHandler(this.Btn_limpar_unidade_Click);
            // 
            // Lbl_calculando
            // 
            this.Lbl_calculando.AutoSize = true;
            this.Lbl_calculando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Lbl_calculando.Location = new System.Drawing.Point(11, 46);
            this.Lbl_calculando.Name = "Lbl_calculando";
            this.Lbl_calculando.Size = new System.Drawing.Size(12, 17);
            this.Lbl_calculando.TabIndex = 0;
            this.Lbl_calculando.Text = " ";
            // 
            // Btn_fracao
            // 
            this.Btn_fracao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_fracao.Location = new System.Drawing.Point(11, 189);
            this.Btn_fracao.Name = "Btn_fracao";
            this.Btn_fracao.Size = new System.Drawing.Size(72, 44);
            this.Btn_fracao.TabIndex = 20;
            this.Btn_fracao.Text = " ⅟ x";
            this.Btn_fracao.UseVisualStyleBackColor = true;
            this.Btn_fracao.Click += new System.EventHandler(this.Btn_fracao_Click);
            // 
            // Btn_elevar_quadrado
            // 
            this.Btn_elevar_quadrado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_elevar_quadrado.Location = new System.Drawing.Point(89, 189);
            this.Btn_elevar_quadrado.Name = "Btn_elevar_quadrado";
            this.Btn_elevar_quadrado.Size = new System.Drawing.Size(72, 44);
            this.Btn_elevar_quadrado.TabIndex = 19;
            this.Btn_elevar_quadrado.Text = "X²";
            this.Btn_elevar_quadrado.UseVisualStyleBackColor = true;
            this.Btn_elevar_quadrado.Click += new System.EventHandler(this.Btn_elevar_quadrado_Click);
            // 
            // Btn_raiz_quadrada
            // 
            this.Btn_raiz_quadrada.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_raiz_quadrada.Location = new System.Drawing.Point(167, 189);
            this.Btn_raiz_quadrada.Name = "Btn_raiz_quadrada";
            this.Btn_raiz_quadrada.Size = new System.Drawing.Size(72, 44);
            this.Btn_raiz_quadrada.TabIndex = 18;
            this.Btn_raiz_quadrada.Text = "²√x";
            this.Btn_raiz_quadrada.UseVisualStyleBackColor = true;
            this.Btn_raiz_quadrada.Click += new System.EventHandler(this.Btn_raiz_quadrada_Click);
            // 
            // Btn_divisao
            // 
            this.Btn_divisao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_divisao.Location = new System.Drawing.Point(245, 189);
            this.Btn_divisao.Name = "Btn_divisao";
            this.Btn_divisao.Size = new System.Drawing.Size(72, 44);
            this.Btn_divisao.TabIndex = 17;
            this.Btn_divisao.Text = "÷";
            this.Btn_divisao.UseVisualStyleBackColor = true;
            this.Btn_divisao.Click += new System.EventHandler(this.Btn_divisao_Click);
            // 
            // Btn_multiplicacao
            // 
            this.Btn_multiplicacao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_multiplicacao.Location = new System.Drawing.Point(245, 239);
            this.Btn_multiplicacao.Name = "Btn_multiplicacao";
            this.Btn_multiplicacao.Size = new System.Drawing.Size(72, 44);
            this.Btn_multiplicacao.TabIndex = 16;
            this.Btn_multiplicacao.Text = "x";
            this.Btn_multiplicacao.UseVisualStyleBackColor = true;
            this.Btn_multiplicacao.Click += new System.EventHandler(this.Btn_multiplicacao_Click);
            // 
            // Btn_subtracao
            // 
            this.Btn_subtracao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_subtracao.Location = new System.Drawing.Point(245, 289);
            this.Btn_subtracao.Name = "Btn_subtracao";
            this.Btn_subtracao.Size = new System.Drawing.Size(72, 44);
            this.Btn_subtracao.TabIndex = 15;
            this.Btn_subtracao.Text = "-";
            this.Btn_subtracao.UseVisualStyleBackColor = true;
            this.Btn_subtracao.Click += new System.EventHandler(this.Btn_subtracao_Click);
            // 
            // Btn_adicao
            // 
            this.Btn_adicao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_adicao.Location = new System.Drawing.Point(245, 339);
            this.Btn_adicao.Name = "Btn_adicao";
            this.Btn_adicao.Size = new System.Drawing.Size(72, 44);
            this.Btn_adicao.TabIndex = 14;
            this.Btn_adicao.Text = "+";
            this.Btn_adicao.UseVisualStyleBackColor = true;
            this.Btn_adicao.Click += new System.EventHandler(this.Btn_adicao_Click);
            // 
            // Btn_resultado
            // 
            this.Btn_resultado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_resultado.Location = new System.Drawing.Point(245, 389);
            this.Btn_resultado.Name = "Btn_resultado";
            this.Btn_resultado.Size = new System.Drawing.Size(72, 44);
            this.Btn_resultado.TabIndex = 0;
            this.Btn_resultado.Text = "=";
            this.Btn_resultado.UseVisualStyleBackColor = true;
            this.Btn_resultado.Click += new System.EventHandler(this.Btn_resultado_Click);
            // 
            // Btn_sete
            // 
            this.Btn_sete.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_sete.Location = new System.Drawing.Point(12, 239);
            this.Btn_sete.Name = "Btn_sete";
            this.Btn_sete.Size = new System.Drawing.Size(72, 44);
            this.Btn_sete.TabIndex = 11;
            this.Btn_sete.Text = "7";
            this.Btn_sete.UseVisualStyleBackColor = true;
            this.Btn_sete.Click += new System.EventHandler(this.Btn_sete_Click);
            // 
            // Btn_oito
            // 
            this.Btn_oito.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_oito.Location = new System.Drawing.Point(90, 239);
            this.Btn_oito.Name = "Btn_oito";
            this.Btn_oito.Size = new System.Drawing.Size(72, 44);
            this.Btn_oito.TabIndex = 12;
            this.Btn_oito.Text = "8";
            this.Btn_oito.UseVisualStyleBackColor = true;
            this.Btn_oito.Click += new System.EventHandler(this.Btn_oito_Click);
            // 
            // Btn_nove
            // 
            this.Btn_nove.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_nove.Location = new System.Drawing.Point(167, 239);
            this.Btn_nove.Name = "Btn_nove";
            this.Btn_nove.Size = new System.Drawing.Size(72, 44);
            this.Btn_nove.TabIndex = 13;
            this.Btn_nove.Text = "9";
            this.Btn_nove.UseVisualStyleBackColor = true;
            this.Btn_nove.Click += new System.EventHandler(this.Btn_nove_Click);
            // 
            // Btn_seis
            // 
            this.Btn_seis.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_seis.Location = new System.Drawing.Point(167, 289);
            this.Btn_seis.Name = "Btn_seis";
            this.Btn_seis.Size = new System.Drawing.Size(72, 44);
            this.Btn_seis.TabIndex = 10;
            this.Btn_seis.Text = "6";
            this.Btn_seis.UseVisualStyleBackColor = true;
            this.Btn_seis.Click += new System.EventHandler(this.Btn_seis_Click);
            // 
            // Btn_cinco
            // 
            this.Btn_cinco.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_cinco.Location = new System.Drawing.Point(90, 289);
            this.Btn_cinco.Name = "Btn_cinco";
            this.Btn_cinco.Size = new System.Drawing.Size(72, 44);
            this.Btn_cinco.TabIndex = 9;
            this.Btn_cinco.Text = "5";
            this.Btn_cinco.UseVisualStyleBackColor = true;
            this.Btn_cinco.Click += new System.EventHandler(this.Btn_cinco_Click);
            // 
            // Btn_quatro
            // 
            this.Btn_quatro.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_quatro.Location = new System.Drawing.Point(12, 289);
            this.Btn_quatro.Name = "Btn_quatro";
            this.Btn_quatro.Size = new System.Drawing.Size(72, 44);
            this.Btn_quatro.TabIndex = 8;
            this.Btn_quatro.Text = "4";
            this.Btn_quatro.UseVisualStyleBackColor = true;
            this.Btn_quatro.Click += new System.EventHandler(this.Btn_quatro_Click);
            // 
            // Btn_tres
            // 
            this.Btn_tres.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_tres.Location = new System.Drawing.Point(167, 339);
            this.Btn_tres.Name = "Btn_tres";
            this.Btn_tres.Size = new System.Drawing.Size(72, 44);
            this.Btn_tres.TabIndex = 7;
            this.Btn_tres.Text = "3";
            this.Btn_tres.UseVisualStyleBackColor = true;
            this.Btn_tres.Click += new System.EventHandler(this.Btn_tres_Click);
            // 
            // Btn_dois
            // 
            this.Btn_dois.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_dois.Location = new System.Drawing.Point(90, 339);
            this.Btn_dois.Name = "Btn_dois";
            this.Btn_dois.Size = new System.Drawing.Size(72, 44);
            this.Btn_dois.TabIndex = 6;
            this.Btn_dois.Text = "2";
            this.Btn_dois.UseVisualStyleBackColor = true;
            this.Btn_dois.Click += new System.EventHandler(this.Btn_dois_Click);
            // 
            // Btn_um
            // 
            this.Btn_um.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_um.Location = new System.Drawing.Point(12, 339);
            this.Btn_um.Name = "Btn_um";
            this.Btn_um.Size = new System.Drawing.Size(72, 44);
            this.Btn_um.TabIndex = 5;
            this.Btn_um.Text = "1";
            this.Btn_um.UseVisualStyleBackColor = true;
            this.Btn_um.Click += new System.EventHandler(this.Btn_um_Click);
            // 
            // Btn_virgula
            // 
            this.Btn_virgula.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_virgula.Location = new System.Drawing.Point(167, 389);
            this.Btn_virgula.Name = "Btn_virgula";
            this.Btn_virgula.Size = new System.Drawing.Size(72, 44);
            this.Btn_virgula.TabIndex = 23;
            this.Btn_virgula.Text = ",";
            this.Btn_virgula.UseVisualStyleBackColor = true;
            this.Btn_virgula.Click += new System.EventHandler(this.Btn_virgula_Click);
            // 
            // Btn_zero
            // 
            this.Btn_zero.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_zero.Location = new System.Drawing.Point(90, 389);
            this.Btn_zero.Name = "Btn_zero";
            this.Btn_zero.Size = new System.Drawing.Size(72, 44);
            this.Btn_zero.TabIndex = 4;
            this.Btn_zero.Text = "0";
            this.Btn_zero.UseVisualStyleBackColor = true;
            this.Btn_zero.Click += new System.EventHandler(this.Btn_zero_Click);
            // 
            // Btn_inverte_sinal
            // 
            this.Btn_inverte_sinal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_inverte_sinal.Location = new System.Drawing.Point(12, 389);
            this.Btn_inverte_sinal.Name = "Btn_inverte_sinal";
            this.Btn_inverte_sinal.Size = new System.Drawing.Size(72, 44);
            this.Btn_inverte_sinal.TabIndex = 22;
            this.Btn_inverte_sinal.Text = "+/-";
            this.Btn_inverte_sinal.UseVisualStyleBackColor = true;
            this.Btn_inverte_sinal.Click += new System.EventHandler(this.Btn_inverte_sinal_Click);
            // 
            // Lbl_operacao_passada
            // 
            this.Lbl_operacao_passada.AutoSize = true;
            this.Lbl_operacao_passada.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Lbl_operacao_passada.Location = new System.Drawing.Point(12, 18);
            this.Lbl_operacao_passada.Name = "Lbl_operacao_passada";
            this.Lbl_operacao_passada.Size = new System.Drawing.Size(12, 17);
            this.Lbl_operacao_passada.TabIndex = 0;
            this.Lbl_operacao_passada.Text = " ";
            // 
            // Frm_calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 445);
            this.Controls.Add(this.Lbl_operacao_passada);
            this.Controls.Add(this.Btn_virgula);
            this.Controls.Add(this.Btn_zero);
            this.Controls.Add(this.Btn_inverte_sinal);
            this.Controls.Add(this.Btn_tres);
            this.Controls.Add(this.Btn_dois);
            this.Controls.Add(this.Btn_um);
            this.Controls.Add(this.Btn_seis);
            this.Controls.Add(this.Btn_cinco);
            this.Controls.Add(this.Btn_quatro);
            this.Controls.Add(this.Btn_nove);
            this.Controls.Add(this.Btn_oito);
            this.Controls.Add(this.Btn_sete);
            this.Controls.Add(this.Btn_resultado);
            this.Controls.Add(this.Btn_adicao);
            this.Controls.Add(this.Btn_subtracao);
            this.Controls.Add(this.Btn_multiplicacao);
            this.Controls.Add(this.Btn_divisao);
            this.Controls.Add(this.Btn_raiz_quadrada);
            this.Controls.Add(this.Btn_elevar_quadrado);
            this.Controls.Add(this.Btn_fracao);
            this.Controls.Add(this.Lbl_calculando);
            this.Controls.Add(this.Btn_limpar_unidade);
            this.Controls.Add(this.Btn_limpar);
            this.Controls.Add(this.Btn_limpar_resultado);
            this.Controls.Add(this.Btn_porcentagem);
            this.Controls.Add(this.Lbl_resultado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_calc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Lbl_resultado;
        private Button Btn_porcentagem;
        private Button Btn_limpar_resultado;
        private Button Btn_limpar;
        private Button Btn_limpar_unidade;
        private Label Lbl_calculando;
        private Button Btn_fracao;
        private Button Btn_elevar_quadrado;
        private Button Btn_raiz_quadrada;
        private Button Btn_divisao;
        private Button Btn_multiplicacao;
        private Button Btn_subtracao;
        private Button Btn_adicao;
        private Button Btn_resultado;
        private Button Btn_sete;
        private Button Btn_oito;
        private Button Btn_nove;
        private Button Btn_seis;
        private Button Btn_cinco;
        private Button Btn_quatro;
        private Button Btn_tres;
        private Button Btn_dois;
        private Button Btn_um;
        private Button Btn_virgula;
        private Button Btn_zero;
        private Button Btn_inverte_sinal;
        private Label Lbl_operacao_passada;
    }
}