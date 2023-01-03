using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    public partial class Frm_calc : Form
    {
        bool sub = false;
        //Vari�vel respons�vel para que ap�s ocorrer um bot�o de opera��o matem�tica ter o evento click acionado
        //o pr�ximo n�mero digitado sobreescreva o n�mero na label de resultado, para evitar que os n�meros de
        //opera��es anteriores se acumulem.

        string tipoOperacao = "";
        string operacaoPassada = "";
        //Vari�vel respons�vle pela identifica��o dos ipos de c�lculos

        bool press = false;
        bool notpress = true;
        //Vari�veis respons�veis por identificar se aldum bot�o num�rico foi pressionado.

        double valor=0;
        //Vari�vel respons�vel por armazenar o valor da opera��o

        public Frm_calc()
        {
            InitializeComponent();
        }

        // Bot�es num�ricos
        private void Btn_zero_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub==true)
            {
                Lbl_resultado.Text = "0";
                sub = false;
                press = true;
                notpress= false;
            }
            else
            {
                Lbl_resultado.Text += "0";
            }
        }

        private void Btn_um_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "1";
                sub = false;
                press = true;
                notpress= false;
            }
            else
            {
                Lbl_resultado.Text += "1";
            }
        }

        private void Btn_dois_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "2";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "2";
            }
        }

        private void Btn_tres_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "3";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "3";
            }
        }

        private void Btn_quatro_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "4";
                sub  = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "4";
            }
        }

        private void Btn_cinco_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "5";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "5";
            }
        }

        private void Btn_seis_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "6";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "6";
            }
        }

        private void Btn_sete_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "7";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "7";
            }
        }

        private void Btn_oito_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "8";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "8";
            }
        }

        private void Btn_nove_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text == "0" || sub ==true)
            {
                Lbl_resultado.Text = "9";
                sub = false;
                press = true;
                notpress = false;
            }
            else
            {
                Lbl_resultado.Text += "9";
            }
        }

        // Bot�o de invers�o de sinal dos n�meros digitados
        private void Btn_inverte_sinal_Click(object sender, EventArgs e)
        {
            double num = double.Parse(Lbl_resultado.Text);
            if (num > 0)
            {
                Lbl_resultado.Text = "-" + num;
                press = true;
            }
            else
            {
                Lbl_resultado.Text = num.ToString().Replace('-', ' ').Trim();
                press = true;
            }
        }

        // Bot�o que adiciona uma v�rgula (Funciona apenas se o windows utilizado for da vers�o Pt-BR ABNT2)
        private void Btn_virgula_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text += ",";
        }

        //Bot�o respons�vel por limpar todas as informa��es da calculadora
        private void Btn_limpar_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
            Lbl_calculando.Text = " ";
            sub = false;
            tipoOperacao = "";
            operacaoPassada = "";
            Lbl_operacao_passada.Text = " ";
        }

        // Bot�o respons�vel por limpar apenas os n�meros que s�o digitados
        private void Btn_limpar_resultado_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
        }

        // Bot�o respons�vel por apagar os n�meros digitados de maneira unit�ria
        private void Btn_limpar_unidade_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text.Length > 1)
            {
                int apaga = Lbl_resultado.Text.Length - (Lbl_resultado.Text.Length - 1);
                Lbl_resultado.Text = Lbl_resultado.Text.Remove((Lbl_resultado.Text.Length - 1), apaga);
            }
            else
            {
                Lbl_resultado.Text = "0";
            }
        }

        // Bot�o que realiza a opera��o de adi��o
        private void Btn_adicao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " + ";
            }
            else if (tipoOperacao != "ADICAO" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA" && tipoOperacao != "FRACAO")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " + ";
                    tipoOperacao = "ADICAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('-', '+').Replace('x', '+').Replace('�', '+');
                    tipoOperacao = "ADICAO";
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = valor.ToString("N2") + " + ";
                    tipoOperacao = "ADICAO";
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "ADICAO";
                    Lbl_calculando.Text = "0 + ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " + ";
                }
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "ADICAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " + ";
                }
            }
            else
            {
                if (press == true)
                {
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = "";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " + ";
                }
            }
            sub = true;
            press = false;
            notpress = true;
        }

        //Bot�o que realiza a opera��o de subtra��o
        private void Btn_subtracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " - ";
            }
            else if (tipoOperacao != "SUBTRACAO" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA" && tipoOperacao != "FRACAO")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " - ";
                    tipoOperacao = "SUBTRACAO";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '-').Replace('x', '-').Replace('�', '-');
                    tipoOperacao = "SUBTRACAO";
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = valor.ToString("N2") + " - ";
                    tipoOperacao = "SUBTRACAO";
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "SUBTRACAO";
                    Lbl_calculando.Text = "0";
                    double valor1 = double.Parse(Lbl_calculando.Text);
                    double valor2 = double.Parse(Lbl_resultado.Text);
                    double result = valor2 - valor1;
                    Lbl_calculando.Text = result.ToString() + " - ";
                }
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "SUBTRACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " - ";
                }
            }
            else
            {
                if (press == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " - ";
                }
            }
            sub = true;
            press = false;
            notpress = true;
        }

        //Bot�o que realiza a opera��o de multiplica��o
        private void Btn_multiplicacao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " x ";
            }
            else if (tipoOperacao != "MULTIPLICACAO" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA" && tipoOperacao != "FRACAO")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = resultado.ToString() + " x ";
                    tipoOperacao = "MULTIPLICACAO";
                } 
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', 'x').Replace('-', 'x').Replace('�', 'x');
                    tipoOperacao = "MULTIPLICACAO";
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = valor.ToString("N2") + " x ";
                    tipoOperacao = "MULTIPLICACAO";
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "MULTIPLICACAO";
                    Lbl_calculando.Text = "1 x ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " x ";
                }
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "MULTIPLICACAO";
                    Lbl_calculando.Text = Lbl_resultado.Text + " x ";
                }
            }
            else
            {
                if (press == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " x ";
                }
            }
            sub = true;
            press = false;
            notpress = true;
        }

        // Bot�o que realiza a opera��o de divis�o
        private void Btn_divisao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                tipoOperacao = "DIVISAO";
                Lbl_calculando.Text = Lbl_resultado.Text + " � ";
            }
            else if (tipoOperacao != "DIVISAO" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA" && tipoOperacao != "FRACAO")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    if (resultado != 0)
                    {
                        Lbl_calculando.Text = resultado.ToString("N2") + " � ";
                        tipoOperacao = "DIVISAO";
                    }
                    else
                    {
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        tipoOperacao = "";
                    }
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '�').Replace('-', '�').Replace('x', '�');
                    tipoOperacao = "DIVISAO";
                }
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = valor.ToString("N2") + " � ";
                    tipoOperacao = "DIVISAO";
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    if (Lbl_resultado.Text != "0")
                    {
                        tipoOperacao = "DIVISAO";
                        Lbl_calculando.Text = "1";
                        double valor1 = double.Parse(Lbl_calculando.Text);
                        double valor2 = double.Parse(Lbl_resultado.Text);
                        double result = valor2 / valor1;
                        Lbl_calculando.Text = result.ToString() + " � ";
                    }
                    else
                    {
                        MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        sub = true;
                        tipoOperacao = "";
                    }
                }
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    if (Lbl_resultado.Text != "0")
                    {
                        tipoOperacao = "DIVISAO";
                        Lbl_calculando.Text = "1";
                        double valor1 = double.Parse(Lbl_calculando.Text);
                        double valor2 = double.Parse(Lbl_resultado.Text);
                        double result = valor2 / valor1;
                        Lbl_calculando.Text = result.ToString() + " � ";
                    }
                    else
                    {
                        MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        tipoOperacao = "";
                    }
                }
            }
            else
            {
                if (press == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "DIVISAO";
                    if (Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim() != "0" && Lbl_resultado.Text != "0")
                    {
                        double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                        Lbl_resultado.Text = resultado.ToString("N2");
                        Lbl_calculando.Text = Lbl_resultado.Text + " � ";
                    }
                    else
                    {
                        MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        tipoOperacao = "";
                    }
                }
            }
            sub = true;
            press = false;
            notpress = true;
        }

        // Bot�o que realiza a opera��o de raiz quadrada
        private void Btn_raiz_quadrada_Click(object sender, EventArgs e)
        {
            if (tipoOperacao != "RAIZ" && tipoOperacao != "" && tipoOperacao != "POTENCIA" && tipoOperacao != "FRACAO")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                tipoOperacao = "RAIZ";
                double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_calculando.Text = "sqrt(" + Lbl_resultado.Text + ")";
                Lbl_resultado.Text = resultado.ToString("N2");
                valor = resultado;
            }
            else if (tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = "sqrt(" + valor.ToString("N2") + ")";
                    tipoOperacao = "RAIZ";
                    double resultado = Calcular(Lbl_calculando.Text, valor.ToString(), tipoOperacao);
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "RAIZ";
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = "sqrt(" + Lbl_resultado.Text + ")";
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
            }
            else
            {
                tipoOperacao = "RAIZ";
                double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_calculando.Text = "sqrt(" + Lbl_resultado.Text + ")";
                Lbl_resultado.Text = resultado.ToString("N2");
                valor = resultado;
            }
            sub = true;
            notpress = true;
        }

        //Bot�o respons�vel pela opera��o de elevar um n�mero a segunda pot�ncia
        private void Btn_elevar_quadrado_Click(object sender, EventArgs e)
        {
            if (tipoOperacao != "POTENCIA" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "FRACAO")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                tipoOperacao = "POTENCIA";
                double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_calculando.Text = "sqr(" + Lbl_resultado.Text + ")";
                Lbl_resultado.Text = resultado.ToString("N2");
                valor = resultado;
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "FRACAO")
            {
                if(notpress == true)
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    Lbl_calculando.Text = "sqr(" + valor.ToString("N2") + ")";
                    tipoOperacao = "POTENCIA";
                    double resultado = Calcular(Lbl_calculando.Text, valor.ToString(), tipoOperacao);
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
                else
                {
                    operacaoPassada = "";
                    Lbl_operacao_passada.Text = " ";
                    tipoOperacao = "POTENCIA";
                    Lbl_calculando.Text = "sqr(" + Lbl_resultado.Text + ")";
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
            }
            else
            {
                tipoOperacao = "POTENCIA";
                Lbl_calculando.Text = "sqr(" + Lbl_resultado.Text + ")";
                double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_resultado.Text = resultado.ToString("N2");
                valor = resultado;
            }
            sub = true;
            notpress = true;
        }

        // Bot�o respons�vel pela opera��o de fracionar um n�mero digitado
        private void Btn_fracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else
            {
                if (tipoOperacao != "FRACAO" && tipoOperacao != "" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA" && Lbl_resultado.Text != "0")
                {
                    operacaoPassada = tipoOperacao;
                    Lbl_operacao_passada.Text = Lbl_calculando.Text;
                    tipoOperacao = "FRACAO";
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = "1/(" + Lbl_resultado.Text + ")";
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
                else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" && Lbl_resultado.Text != "0")
                {
                    if (notpress == true)
                    {
                        operacaoPassada = "";
                        Lbl_operacao_passada.Text = " ";
                        operacaoPassada = tipoOperacao;
                        Lbl_operacao_passada.Text = Lbl_calculando.Text;
                        Lbl_calculando.Text = "1/(" + valor.ToString("N2") + ")";
                        tipoOperacao = "FRACAO";
                        double resultado = Calcular(Lbl_calculando.Text, valor.ToString(), tipoOperacao);
                        Lbl_resultado.Text = resultado.ToString("N2");
                        valor = resultado;
                    }
                    else
                    {
                        operacaoPassada = "";
                        Lbl_operacao_passada.Text = " ";
                        tipoOperacao = "FRACAO";
                        Lbl_calculando.Text = "1/(" + Lbl_resultado.Text + ")";
                        double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                        Lbl_resultado.Text = resultado.ToString("N2");
                        valor = resultado;
                    }
                }
                else if (tipoOperacao == "FRACAO" && Lbl_resultado.Text != "0")
                {
                    tipoOperacao = "FRACAO";
                    Lbl_calculando.Text = "1/(" + Lbl_resultado.Text + ")";
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_resultado.Text = resultado.ToString("N2");
                    valor = resultado;
                }
                else
                {
                    Lbl_calculando.Text = " ";
                    Lbl_resultado.Text = "0";
                    tipoOperacao = "";
                    Lbl_operacao_passada.Text = " ";
                    operacaoPassada = "";
                    MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            sub = true;
            notpress = true;
        }

        // Bot�o respons�vel pela opera��o de porcentagem.
        // De maneira resumida: No momento de realiza��o de uma opera��o ele ir� fazer a
        // c�lculo da porcentagem em rela��o ao primeiro n�mero da opera��o, e realocar o valor referente a sua porcentagem
        // Exemplo: 50 + 50% -> output: 50 + 25
        private void Btn_porcentagem_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (Lbl_calculando.Text != " " && tipoOperacao != "FRACAO" && tipoOperacao != "RAIZ" && tipoOperacao != "POTENCIA")
            {
                double valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                double valor2 = double.Parse(Lbl_resultado.Text);
                double result = valor1 * (valor2 / 100);
                Lbl_resultado.Text = result.ToString();
                sub = true;               
            }
            else
            {
                Lbl_calculando.Text = " ";
                Lbl_resultado.Text = "0";
                tipoOperacao = "";
                Lbl_operacao_passada.Text = " ";
                operacaoPassada = "";
            }
        }

        // Bot�o que realiza a opera��o previamente exposta
        private void Btn_resultado_Click(object sender, EventArgs e)
        {
            if(tipoOperacao == "")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " =";
                Lbl_operacao_passada.Text = " ";
            }
            else if(tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (notpress == true)
                {
                    double calc;
                    switch (operacaoPassada)
                    {
                        case "ADICAO":
                            calc = double.Parse(Lbl_operacao_passada.Text.Replace('+', ' ').Trim()) + valor;
                            Lbl_calculando.Text += " =";
                            Lbl_resultado.Text = calc.ToString();
                            break;
                        case "SUBTRACAO":
                            calc = double.Parse(Lbl_operacao_passada.Text.Replace('-', ' ').Trim()) - valor;
                            Lbl_calculando.Text += " =";
                            Lbl_resultado.Text = calc.ToString();
                            break;
                        case "MULTIPLICACAO":
                            calc = double.Parse(Lbl_operacao_passada.Text.Replace('x', ' ').Trim()) * valor;
                            Lbl_calculando.Text += " =";
                            Lbl_resultado.Text = calc.ToString();
                            break;
                        case "DIVISAO":
                            calc = double.Parse(Lbl_operacao_passada.Text.Replace('�', ' ').Trim()) / valor;
                            Lbl_calculando.Text += " =";
                            Lbl_resultado.Text = calc.ToString();
                            break;
                        default:
                            Lbl_calculando.Text += " =";
                            break;
                    }
                }
                else
                {
                    Lbl_operacao_passada.Text = " ";
                    Lbl_calculando.Text = Lbl_resultado.Text + " =";
                }
            }
            else if (tipoOperacao == "DIVISAO")
            {
                if (Lbl_resultado.Text != "0")
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text += Lbl_resultado.Text + " =";
                    Lbl_resultado.Text = resultado.ToString("N2");
                    Lbl_operacao_passada.Text = " ";
                }
                else
                {
                    MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lbl_calculando.Text = " ";
                    Lbl_resultado.Text = "0";
                    Lbl_operacao_passada.Text = " ";
                }
            }
            else
            {
                double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_calculando.Text += Lbl_resultado.Text + " =";
                Lbl_resultado.Text = result.ToString();
                Lbl_operacao_passada.Text = " ";
            }
            sub = true;
            press = false;
            notpress = true;
            tipoOperacao = "";
            operacaoPassada = "";
        }

        //Fun��o respons�vel pelos C�lculos.
        public static double Calcular(string Lbl_calculando, string Lbl_resultado, string operacao)
        {
            double valor1;
            double valor2;
            double resultado;
            switch (operacao)
            {
                case "ADICAO":
                    valor1 = double.Parse(Lbl_calculando.Remove((Lbl_calculando.Length - 2), 2).Trim());
                    valor2 = double.Parse(Lbl_resultado);
                    resultado = valor1 + valor2;
                    return resultado;
                case "SUBTRACAO":
                    valor1 = double.Parse(Lbl_resultado);
                    valor2 = double.Parse(Lbl_calculando.Remove((Lbl_calculando.Length - 2), 2).Trim());
                    resultado = valor2 - valor1;
                    return resultado;
                case "MULTIPLICACAO":
                    valor1 = double.Parse(Lbl_resultado);
                    valor2 = double.Parse(Lbl_calculando.Remove((Lbl_calculando.Length - 2), 2).Trim());
                    resultado = valor2 * valor1;
                    return resultado;
                case "DIVISAO":
                    valor1 = double.Parse(Lbl_resultado);
                    valor2 = double.Parse(Lbl_calculando.Remove((Lbl_calculando.Length - 2), 2).Trim());
                    resultado = valor2 / valor1;
                    return resultado;
                case "RAIZ":
                    resultado = Math.Sqrt(double.Parse(Lbl_resultado));
                    return resultado;
                case "POTENCIA":
                    valor1 = double.Parse(Lbl_resultado);
                    resultado = Math.Pow(valor1, 2);
                    return resultado;
                case "FRACAO":
                    valor1 = double.Parse(Lbl_resultado);
                    resultado = 1 / valor1;
                    return resultado;
                default:
                    MessageBox.Show("Insira uma opera��o v�lida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
            }
        }
    }
}