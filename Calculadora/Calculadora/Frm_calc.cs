using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public partial class Frm_calc : Form
    {
        // Variável responsável por fazer possível a substituição de dígitos na label_resultado após uma operação.
        bool sub = false;

        // Variável responsável por identificar o tipo de cálculo que será executado.
        string tipoOperacao = "";

        // Variável responsável por identificar se um botão foi pressionado.
        bool press = false;

        // Variável responsável por armazenar o resultado de uma operação (serve principalmente para as operações de Fracão, Raiz e Potência). 
        double valor = 0;

        public Frm_calc()
        {
            InitializeComponent();
        }

        // Botões numéricos.
        private void Btn_zero_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "0";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "0";
            }
        }

        private void Btn_um_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "1";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "1";
            }
        }

        private void Btn_dois_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "2";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "2";
            }
        }

        private void Btn_tres_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "3";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "3";
            }
        }

        private void Btn_quatro_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "4";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "4";
            }
        }

        private void Btn_cinco_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "5";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "5";
            }
        }

        private void Btn_seis_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "6";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "6";
            }
        }

        private void Btn_sete_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "7";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "7";
            }
        }

        private void Btn_oito_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "8";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "8";
            }
        }

        private void Btn_nove_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                Lbl_resultado.Text = "9";
                sub = false;
                press = true;
                Substituir();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += "9";
            }
        }

        // Botão de inversão de sinal dos números digitados.
        private void Btn_inverte_sinal_Click(object sender, EventArgs e)
        {
            double num = GetValor(Lbl_resultado.Text);
            if (num > 0)
            {
                if (Lbl_calculando.Text.Contains(")"))
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        int index = Lbl_calculando.Text.IndexOf(operacao);
                        string substituta = Lbl_calculando.Text.Substring(index + 2);
                        Lbl_calculando.Text = Lbl_calculando.Text.Remove(index + 2);
                        Lbl_calculando.Text += "negative(" + substituta + ")";
                    }
                    else
                    {
                        Lbl_calculando.Text = "negative(" + Lbl_calculando.Text + ")";
                    }
                }
                else
                {
                    press = true;
                }
                Lbl_resultado.Text = "-" + num;
            }
            else
            {
                Lbl_resultado.Text = num.ToString().Replace('-', ' ').Trim();
                press = true;
            }
        }

        // Botão que adiciona uma vírgula (Funciona apenas se o Windows utilizado for da versão Pt-BR ABNT2).
        private void Btn_virgula_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text.Contains(',') == false)
            {
                Lbl_resultado.Text += ",";
            }
        }

        //Botão responsável por limpar todas as informações da calculadora.
        private void Btn_limpar_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
            Lbl_calculando.Text = " ";
            sub = false;
            tipoOperacao = "";
        }

        // Botão responsável por limpar apenas os números que são digitados.
        private void Btn_limpar_resultado_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
        }

        // Botão responsável por apagar os números digitados de maneira unitária.
        private void Btn_limpar_unidade_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text.Length > 1)
            {
                Lbl_resultado.Text = Lbl_resultado.Text.Remove((Lbl_resultado.Text.Length - 1), 1);
            }
            else
            {
                Lbl_resultado.Text = "0";
            }
        }

        // Botão que realiza a operação de adição.
        private void Btn_adicao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.EndsWith("=") == true)
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " + ";
            }
            else if (tipoOperacao == "ADICAO" || tipoOperacao == "")
            {
                if (Lbl_calculando.Text == " ")
                {
                    tipoOperacao = "ADICAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " + ";
                }
                else
                {
                    if (press == true)
                    {
                        double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " + ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (press == false && Lbl_calculando.Text.EndsWith("+ ") == false)
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        OperaCaoPassada("+");
                        tipoOperacao = "ADICAO";  
                    }
                    else
                    {
                        Lbl_calculando.Text += " + ";
                        valor = GetValor(Lbl_resultado.Text);
                    }
                }
                else if (Lbl_calculando.Text.EndsWith("+ ") == true)
                {
                    if (press == true)
                    {
                        tipoOperacao = "ADICAO";
                        double resultado = Calcular(valor.ToString(), Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " + ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    tipoOperacao = "ADICAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " + ";
                }
            }
            else
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " + ";
                    Lbl_resultado.Text = resultado.ToString();
                    tipoOperacao = "ADICAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('-', '+').Replace('x', '+').Replace('÷', '+');
                    tipoOperacao = "ADICAO";
                }
            }
            sub = true;
            press = false;
        }

        //Botão que realiza a operação de subtração.
        private void Btn_subtracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.EndsWith("=") == true)
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " - ";
            }
            else if (tipoOperacao == "SUBTRACAO" || tipoOperacao == "")
            {
                if (Lbl_calculando.Text == " ")
                {
                    tipoOperacao = "SUBTRACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " - ";
                }
                else
                {
                    if (press == true)
                    {
                        double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (press == false && Lbl_calculando.Text.EndsWith("- ") == false)
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        OperaCaoPassada("-");
                        tipoOperacao = "SUBTRACAO";
                    }
                    else
                    {
                        Lbl_calculando.Text += " - ";
                        valor = GetValor(Lbl_resultado.Text);
                    }
                }
                else if (Lbl_calculando.Text.EndsWith("- ") == true)
                {
                    if (press == true)
                    {
                        tipoOperacao = "SUBTRACAO";
                        double resultado = Calcular(valor.ToString(), Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    tipoOperacao = "SUBTRACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " - ";
                }
            }
            else
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " - ";
                    Lbl_resultado.Text = resultado.ToString();
                    tipoOperacao = "SUBTRACAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '-').Replace('x', '-').Replace('÷', '-');
                    tipoOperacao = "SUBTRACAO";
                }
            }
            sub = true;
            press = false;
        }

        //Botão que realiza a operação de multiplicação.
        private void Btn_multiplicacao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.EndsWith("=") == true)
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " x ";
            }
            else if (tipoOperacao == "MULTIPLICACAO" || tipoOperacao == "")
            {
                if (Lbl_calculando.Text == " ")
                {
                    tipoOperacao = "MULTIPLICACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " x ";
                }
                else
                {
                    if (press == true)
                    {
                        double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (press == false && Lbl_calculando.Text.EndsWith("x ") == false)
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        OperaCaoPassada("x");
                        tipoOperacao = "MULTIPLICACAO";
                    }
                    else
                    {
                        Lbl_calculando.Text += " x ";
                        valor = GetValor(Lbl_resultado.Text);
                    }
                }
                else if (Lbl_calculando.Text.EndsWith("x ") == true)
                {
                    if (press == true)
                    {
                        tipoOperacao = "MULTIPLICACAO";
                        double resultado = Calcular(valor.ToString(), Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    tipoOperacao = "MULTIPLICACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " x ";
                }
            }
            else
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " x ";
                    Lbl_resultado.Text = resultado.ToString();
                    tipoOperacao = "MULTIPLICACAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', 'x').Replace('-', 'x').Replace('÷', 'x');
                    tipoOperacao = "MULTIPLICACAO";
                }
            }
            sub = true;
            press = false;
        }

        // Botão que realiza a operação de divisão.
        private void Btn_divisao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.EndsWith("=") == true)
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " ÷ ";
            }
            else if (tipoOperacao == "DIVISAO" || tipoOperacao == "")
            {
                if (Lbl_calculando.Text == " ")
                {
                    tipoOperacao = "DIVISAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " ÷ ";
                }
                else
                {
                    if (press == true)
                    {
                        if (GetValor(Lbl_resultado.Text) == 0)
                        {
                            MessageBox.Show("Não é possível dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Lbl_calculando.Text = " ";
                            Lbl_resultado.Text = "0";
                            tipoOperacao = "";
                        }
                        else
                        {
                            double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                            Lbl_calculando.Text = resultado.ToString() + " ÷ ";
                            Lbl_resultado.Text = resultado.ToString();
                        }
                    }
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (press == false && Lbl_calculando.Text.EndsWith("÷ ") == false)
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        OperaCaoPassada("÷");
                        tipoOperacao = "DIVISAO";
                    }
                    else
                    {
                        Lbl_calculando.Text += " ÷ ";
                        valor = GetValor(Lbl_resultado.Text);
                    }
                }
                else if (Lbl_calculando.Text.EndsWith("÷ ") == true)
                {
                    if (press == true)
                    {
                        tipoOperacao = "DIVISAO";
                        double resultado = Calcular(valor.ToString(), Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " ÷ ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    tipoOperacao = "DIVISAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " ÷ ";
                }
            }
            else
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " ÷ ";
                    Lbl_resultado.Text = resultado.ToString();
                    tipoOperacao = "DIVISAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '÷').Replace('-', '÷').Replace('x', '÷');
                    tipoOperacao = "DIVISAO";
                }
            }
            sub = true;
            press = false;
        }

        // Continuar o desenvolvimento das condicionais de cálculo entre as operações de Radiciação, Fração e Potenciação.
        //
        // Botão que realiza a operação de radiciação.
        private void Btn_raiz_quadrada_Click(object sender, EventArgs e)
        {
            double resultado;
            if (tipoOperacao == "FRACAO" || tipoOperacao == "POTENCIA")
            {

            }
            else
            {
                if(tipoOperacao == "RAIZ" || tipoOperacao == "" || Lbl_calculando.Text == " ")
                {
                    Lbl_calculando.Text = "sqrt(" + Lbl_resultado.Text + ")";
                }
                else
                {
                    Lbl_calculando.Text += "sqrt(" + Lbl_resultado.Text + ")";
                }
                tipoOperacao = "RAIZ";
                resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_resultado.Text = resultado.ToString();
                valor = resultado;
            }
            sub = true;
            press = false;
        }

        //Botão responsável pela operação de potenciação.
        private void Btn_elevar_quadrado_Click(object sender, EventArgs e)
        {
            double resultado;
            if (tipoOperacao == "FRACAO" || tipoOperacao == "RAIZ")
            {

            }
            else
            {
                if (tipoOperacao == "POTENCIA" || tipoOperacao == "" || Lbl_calculando.Text == " ")
                {
                    Lbl_calculando.Text = "sqr(" + Lbl_resultado.Text + ")";
                }
                else
                {
                    Lbl_calculando.Text += "sqr(" + Lbl_resultado.Text + ")";
                }
                tipoOperacao = "POTENCIA";
                resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_resultado.Text = resultado.ToString();
                valor = resultado;
            }
            sub = true;
            press = false;
        }

        // Botão responsável pela operação de fração.
        private void Btn_fracao_Click(object sender, EventArgs e)
        {
            double resultado;
            if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA")
            {

            }
            else
            {
                if (tipoOperacao == "FRACAO" || tipoOperacao == "" || Lbl_calculando.Text == " ")
                {
                    Lbl_calculando.Text = "1/(" + Lbl_resultado.Text + ")";
                }
                else
                {
                    Lbl_calculando.Text += "1/(" + Lbl_resultado.Text + ")";
                }
                if (GetValor(Lbl_resultado.Text) == 0)
                {
                    MessageBox.Show("Não é possível dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lbl_calculando.Text = " ";
                    Lbl_resultado.Text = "0";
                    tipoOperacao = "";
                }
                else
                {
                    tipoOperacao = "FRACAO";
                    resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_resultado.Text = resultado.ToString();
                    valor = resultado;
                }
            }
            sub = true;
            press = false;
        }

        // Botão responsável pela operação de porcentagem.
        private void Btn_porcentagem_Click(object sender, EventArgs e)
        {
            double valor1;
            double valor2;
            double resultado;
            if (Lbl_calculando.Text != " " && tipoOperacao != "FRACAO" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA")
            {
                if (Lbl_calculando.Text.EndsWith("="))
                {
                    valor1 = GetValor(Lbl_resultado.Text);
                    resultado = valor1 * (valor1 / 100);
                    Lbl_calculando.Text = resultado.ToString();
                    Lbl_resultado.Text = resultado.ToString();
                }
                else
                {
                    valor1 = GetValor(Lbl_calculando.Text);
                    valor2 = GetValor(Lbl_resultado.Text);
                    resultado = valor1 * (valor2 / 100);
                    Lbl_resultado.Text = resultado.ToString();
                }
                press = true;
            }
            else
            {
                Lbl_calculando.Text = " ";
                Lbl_resultado.Text = "0";
                tipoOperacao = "";
            }
            sub = true;
        }
        
        // Implementar função para que quanto for pressionado o botão, seja sempre realizado a última operação disponível.
        //
        // Botão que finaliza o cálculo, realizando a última operação disponível.
        private void Btn_resultado_Click(object sender, EventArgs e)
        {
            if(tipoOperacao == "")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " =";
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "FRACAO" || tipoOperacao == "POTENCIA")
            {
                double resultado;
                string operacao = GetSignal(Lbl_calculando.Text);
                switch (operacao)
                {
                    case "+ ":
                        if (Lbl_calculando.Text.EndsWith(")") == true)
                        {
                            Lbl_calculando.Text += " =";
                            string numeroASerAcrescido = Lbl_calculando.Text.Remove(Lbl_calculando.Text.IndexOf("+ "));
                            resultado = Calcular(numeroASerAcrescido, valor.ToString(), "ADICAO");
                        }
                        else
                        {
                            Lbl_calculando.Text += Lbl_resultado.Text + " =";
                            resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "ADICAO");
                        }
                        Lbl_resultado.Text = resultado.ToString();
                        break;
                    case "- ":
                        if (Lbl_calculando.Text.EndsWith(")") == true)
                        {
                            Lbl_calculando.Text += " =";
                            string numeroASerSubtraido = Lbl_calculando.Text.Remove(Lbl_calculando.Text.IndexOf("- "));
                            resultado = Calcular(numeroASerSubtraido, valor.ToString(), "SUBTRACAO");
                        }
                        else
                        {
                            Lbl_calculando.Text += Lbl_resultado.Text + " =";
                            resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "SUBTRACAO");
                        }
                        Lbl_resultado.Text = resultado.ToString();
                        break;
                    case "x ":
                        if (Lbl_calculando.Text.EndsWith(")") == true)
                        {
                            Lbl_calculando.Text += " =";
                            string numeroASerMultiplicado = Lbl_calculando.Text.Remove(Lbl_calculando.Text.IndexOf("x "));
                            resultado = Calcular(numeroASerMultiplicado, valor.ToString(), "MULTIPLICACAO");
                        }
                        else
                        {
                            Lbl_calculando.Text += Lbl_resultado.Text + " =";
                            resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "MULTIPLICACAO");
                        }
                        Lbl_resultado.Text = resultado.ToString();
                        break;
                    case "÷ ":
                        if (Lbl_calculando.Text.EndsWith(")") == true)
                        {
                            Lbl_calculando.Text += " =";
                            string dividendo = Lbl_calculando.Text.Remove(Lbl_calculando.Text.IndexOf("÷ "));
                            resultado = Calcular(dividendo, valor.ToString(), "DIVISAO");
                        }
                        else
                        {
                            Lbl_calculando.Text += Lbl_resultado.Text + " =";
                            resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "DIVISAO");
                        }
                        Lbl_resultado.Text = resultado.ToString();
                        break;
                    default:
                        Lbl_calculando.Text += " =";
                        break;
                }
            }
            else
            {
                double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                if (Lbl_resultado.Text.StartsWith("-") == true)
                {
                    Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-', ' ').Trim() + ") =";
                }
                else
                {
                    Lbl_calculando.Text += Lbl_resultado.Text + " =";
                }
                Lbl_resultado.Text = result.ToString();
            }
            valor = 0;
            sub = true;
            press = false;
            tipoOperacao = "";
        }

        //Função responsável pelos Cálculos.
        public double Calcular(string value1, string value2, string operacao)
        {
            double valor1 = GetValor(value1);
            double valor2 = GetValor(value2);
            double resultado;
            switch (operacao)
            {
                case "ADICAO":             
                    resultado = valor1 + valor2;
                    return resultado;
                case "SUBTRACAO":
                    resultado = valor1 - valor2;
                    return resultado;
                case "MULTIPLICACAO":
                    resultado = valor1 * valor2;
                    return resultado;
                case "DIVISAO":
                    resultado = valor1 / valor2;
                    return resultado;
                case "RAIZ":
                    resultado = Math.Sqrt(valor2);
                    return resultado;
                case "POTENCIA":
                    resultado = Math.Pow(valor2, 2);
                    return resultado;
                case "FRACAO":
                    resultado = 1 / valor2;
                    return resultado;
                default:
                    return -1;
            }
        }

        //Função que faz a limpeza dos valores da label
        public double GetValor(string valorASerLimpo)
        {
            double resultado;
            string pattern = "[0-9,-]{1,16}";
            Match valorlimpo = Regex.Match(valorASerLimpo, pattern);
            resultado = double.Parse(valorlimpo.Value);
            return resultado;
        }

        public string GetSignal(string valor)
        {
            string pattern = "[+x÷-][ ]";
            Match v = Regex.Match(valor, pattern);
            return v.Value;
        }

        public void OperaCaoPassada(string sinalOperacaoAtual)
        {
            string operacao = GetSignal(Lbl_calculando.Text);
            double resultado;
            switch (operacao)
            {
                case "+ ":
                    if (Lbl_calculando.Text.EndsWith(")") == true)
                    {
                        int index = Lbl_calculando.Text.IndexOf("+ ");
                        string numeroASerAcrescido = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerAcrescido, valor.ToString(), "ADICAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "ADICAO");
                    }
                    Lbl_calculando.Text = resultado.ToString() + " " + sinalOperacaoAtual + " ";
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "- ":
                    if (Lbl_calculando.Text.EndsWith(")") == true)
                    {
                        int index = Lbl_calculando.Text.IndexOf("- ");
                        string numeroASerSubtraido = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerSubtraido, valor.ToString(), "SUBTRACAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "SUBTRACAO");
                    }
                    Lbl_calculando.Text = resultado.ToString() + " " + sinalOperacaoAtual + " ";
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "x ":
                    if (Lbl_calculando.Text.EndsWith(")") == true)
                    {
                        int index = Lbl_calculando.Text.IndexOf("x ");
                        string numeroASerMultiplicado = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerMultiplicado, valor.ToString(), "MULTIPLICACAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "MULTIPLICACAO");
                    }
                    Lbl_calculando.Text = resultado.ToString() + " " + sinalOperacaoAtual + " ";
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "÷ ":
                    if (Lbl_calculando.Text.EndsWith(")") == true)
                    {
                        int index = Lbl_calculando.Text.IndexOf("÷ ");
                        string dividendo = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(dividendo, valor.ToString(), "DIVISAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "DIVISAO");
                    }
                    Lbl_calculando.Text = resultado.ToString() + " " + sinalOperacaoAtual + " ";
                    Lbl_resultado.Text = resultado.ToString();
                    break;
            }
        }
        public void Substituir()
        {
            if (Lbl_calculando.Text.EndsWith(")") == true)
            {
                string operacao = GetSignal(Lbl_calculando.Text);
                int index = Lbl_calculando.Text.IndexOf(operacao) + 2;
                Lbl_calculando.Text = Lbl_calculando.Text.Remove(index);
                switch (operacao)
                {
                    case "+ ":
                        tipoOperacao = "ADICAO";
                        break;
                    case "- ":
                        tipoOperacao = "SUBTRACAO";
                        break;
                    case "x ":
                        tipoOperacao = "MULTIPLICACAO";
                        break;
                    case "÷ ":
                        tipoOperacao = "DIVISAO";
                        break;
                }
            }
        }
    }
}