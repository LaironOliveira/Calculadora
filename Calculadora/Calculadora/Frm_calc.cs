using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    public partial class Frm_calc : Form
    {
        bool sub = false;
        //Variável responsável para que após ocorrer um botão de operação matemática ter o evento click acionado
        //o próximo número digitado sobreescreva o número na label de resultado, para evitar que os números de
        //operações anteriores se acumulem.

        string tipoOperacao = "";
        string operacaoPassada = "";
        //Variável responsávle pela definição do tipo de cálculo.

        bool press = false;
        //Variáveis responsáveis por identificar quais botões foram pressionados.
        
        Raiz r = new Raiz();
        // Instanciando Objeto da classe raiz quadrada

        public Frm_calc()
        {
            InitializeComponent();
        }

        private void Btn_zero_Click(object sender, EventArgs e)
        {
            //
            //Verificação se o número na label resultado é igual a zero ou não para que o programa
            //possa sobreescrever ou adicionar mais um número a label resultado.
            //Essa verificação é feita a todos os números do teclado numérico.
            //
            if (Lbl_resultado.Text == "0" || sub==true)
            {
                Lbl_resultado.Text = "0";
                sub = false;
                press = true;
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
            }
            else
            {
                Lbl_resultado.Text += "9";
            }
        }
        
        //
        // Fim da verificação dos números inseridos
        //

        private void Btn_inverte_sinal_Click(object sender, EventArgs e)
        {
            //
            //Verifica se os números da label resultado são positivos, caso sim, adiciona o sinal
            //de negativo. Caso sejam negativos, remove o sinal de negativo.
            //
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

        private void Btn_virgula_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text += ",";
        }

        private void Btn_limpar_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
            Lbl_calculando.Text = " ";
            sub = false;
            tipoOperacao = "";
            operacaoPassada = "";
            Lbl_operacao_passada.Text = " ";
        }

        private void Btn_limpar_resultado_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
        }

        private void Btn_limpar_unidade_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text.Length > 1)
            {
                //
                //Recebe o tamanho da sequência de caracteres menos 1, no caso abaixo é 1
                //
                int apaga = Lbl_resultado.Text.Length - (Lbl_resultado.Text.Length - 1);
                //
                //Remove a posição do vetor de caracteres (string) referente ao tamanho capturado na variável apaga. Na função Remove() o primeiro parâmetro é
                //a posição no vetor do qual será iniciado a remoção e o segundo parâmetro é o número de caracteres que serão removidos
                //
                Lbl_resultado.Text = Lbl_resultado.Text.Remove((Lbl_resultado.Text.Length - 1), apaga);
            }
            else
            {
                Lbl_resultado.Text = "0";
            }
        }

        private void Btn_adicao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "ADICAO" && tipoOperacao != "" && tipoOperacao != "RAIZ")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = Lbl_resultado.Text + " + ";
                    Lbl_resultado.Text = resultado.ToString();
                    sub = true;
                    tipoOperacao = "ADICAO";
                    press = false;
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('-', '+').Replace('x', '+').Replace('÷', '+');
                    sub = true;
                    tipoOperacao = "ADICAO";
                }
            }
            else if (tipoOperacao == "RAIZ")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                Lbl_calculando.Text = Math.Round(double.Parse(Lbl_resultado.Text)).ToString() + " + ";
                sub = true;
                press = false;
                tipoOperacao = "ADICAO";
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "ADICAO";
                    Lbl_calculando.Text = "0 + ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " + ";
                    sub = true;
                    press = false;
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
                    sub = true;
                    press = false;
                }
            }                            
        }
        private void Btn_subtracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "SUBTRACAO" && tipoOperacao != "" && tipoOperacao != "RAIZ")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = Lbl_resultado.Text + " - ";
                    Lbl_resultado.Text = resultado.ToString();
                    sub = true;
                    tipoOperacao = "SUBTRACAO";
                    press = false;
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '-').Replace('x', '-').Replace('÷', '-');
                    sub = true;
                    tipoOperacao = "SUBTRACAO";
                }
            }
            else if (tipoOperacao == "RAIZ")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                Lbl_calculando.Text = Math.Round(double.Parse(Lbl_resultado.Text)).ToString() + " - ";
                sub = true;
                press = false;
                tipoOperacao = "SUBTRACAO";
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "SUBTRACAO";
                    Lbl_calculando.Text = "0";
                    double valor1 = double.Parse(Lbl_calculando.Text);
                    double valor2 = double.Parse(Lbl_resultado.Text);
                    double result = valor2 - valor1;
                    Lbl_calculando.Text = result.ToString() + " - ";
                    sub = true;
                    press = false;
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
                    sub = true;
                    press = false;
                }
            }
        }

        private void Btn_multiplicacao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "MULTIPLICACAO"  && tipoOperacao != "" && tipoOperacao != "RAIZ")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = Lbl_resultado.Text + " - ";
                    Lbl_resultado.Text = resultado.ToString();
                    sub = true;
                    tipoOperacao = "MULTIPLICACAO";
                    press = false;
                } 
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', 'x').Replace('-', 'x').Replace('÷', 'x');
                    sub = true;
                    tipoOperacao = "MULTIPLICACAO";
                }
            }
            else if (tipoOperacao == "RAIZ")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                Lbl_calculando.Text = Math.Round(double.Parse(Lbl_resultado.Text)).ToString() + " x ";
                sub = true;
                press = false;
                tipoOperacao = "MULTIPLICACAO";
            }
            else if (Lbl_calculando.Text == " ")
            {
                if (press == true)
                {
                    tipoOperacao = "MULTIPLICACAO";
                    Lbl_calculando.Text = "1 x ";
                    double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text = result.ToString() + " x ";
                    sub = true;
                    press = false;
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
                    sub = true;
                    press = false;
                }
            }
        }

        private void Btn_divisao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "DIVISAO" && tipoOperacao != "" && tipoOperacao != "RAIZ")
            {
                if (press == true)
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    if (resultado != 0)
                    {
                        Lbl_calculando.Text = Lbl_resultado.Text + " ÷ ";
                        Lbl_resultado.Text = resultado.ToString();
                        sub = true;
                        tipoOperacao = "DIVISAO";
                    }
                    else
                    {
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        sub = true;
                        tipoOperacao = "";
                    }
                }
                else
                {
                    Lbl_calculando.Text = Lbl_calculando.Text.Replace('+', '÷').Replace('-', '÷').Replace('x', '÷');
                    sub = true;
                    tipoOperacao = "DIVISAO";
                }
            }
            else if (tipoOperacao == "RAIZ")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                Lbl_calculando.Text = Math.Round(double.Parse(Lbl_resultado.Text)).ToString() + " ÷ ";
                sub = true;
                press = false;
                tipoOperacao = "DIVISAO";
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
                        Lbl_calculando.Text = result.ToString() + " ÷ ";
                        sub = true;
                        press = false;
                    }
                    else
                    {
                        MessageBox.Show("Não é possível dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        sub = true;
                        tipoOperacao = "";
                        press = false;
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
                        Lbl_resultado.Text = resultado.ToString();
                        Lbl_calculando.Text = Lbl_resultado.Text + " ÷ ";
                        sub = true;
                        press = false;
                    }
                    else
                    {
                        MessageBox.Show("Não é possível dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                        sub = true;
                        tipoOperacao = "";
                        press = false;
                    }
                }
            }          
        }

        // continuar o desenvolvimento
        private void Btn_raiz_quadrada_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "RAIZ" && tipoOperacao != "")
            {
                operacaoPassada = tipoOperacao;
                Lbl_operacao_passada.Text = Lbl_calculando.Text;
                r.Calc(tipoOperacao, Lbl_resultado.Text, Lbl_calculando.Text);
                Lbl_calculando.Text = r.getLabel2();
                Lbl_resultado.Text = r.getLabel1();
                sub = true;
                tipoOperacao = "RAIZ";
            }
            else if (Lbl_calculando.Text == " ")
            {
                tipoOperacao = "RAIZ";
                r.Calc(tipoOperacao, Lbl_resultado.Text, Lbl_calculando.Text);
                Lbl_calculando.Text = r.getLabel2();
                Lbl_resultado.Text = r.getLabel1();
                press = false;
                sub = true;
            }
            else
            {
                r.Calc(tipoOperacao, Lbl_resultado.Text, Lbl_calculando.Text);
                Lbl_calculando.Text = r.getLabel2();
                Lbl_resultado.Text = r.getLabel1();
                press = false;
                sub = true;
            }
        }

        private void Btn_elevar_quadrado_Click(object sender, EventArgs e)
        {
            //if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            //{
            //    Lbl_calculando.Text = " ";
            //}
            //else
            //{

            //}
        }

        private void Btn_fracao_Click(object sender, EventArgs e)
        {
            //if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            //{
            //    Lbl_calculando.Text = " ";
            //}
            //else
            //{

            //}
        }

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

        private void Btn_resultado_Click(object sender, EventArgs e)
        {
            if(tipoOperacao == "")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " =";
                Lbl_operacao_passada.Text = " ";
                sub = true;
                press = false;
            }
            else if(tipoOperacao == "RAIZ")
            {
                double calc;
                switch (operacaoPassada)
                {
                    case "ADICAO":
                        calc = double.Parse(Lbl_operacao_passada.Text.Replace('+', ' ').Trim()) + double.Parse(r.getLabel1());
                        Lbl_calculando.Text += " =";
                        Lbl_resultado.Text = calc.ToString();
                        break;
                    case "SUBTRACAO":
                        calc = double.Parse(Lbl_operacao_passada.Text.Replace('-', ' ').Trim()) - double.Parse(r.getLabel1());
                        Lbl_calculando.Text += " =";
                        Lbl_resultado.Text = calc.ToString();
                        break;
                    case "MULTIPLICACAO":
                        calc = double.Parse(Lbl_operacao_passada.Text.Replace('x', ' ').Trim()) * double.Parse(r.getLabel1());
                        Lbl_calculando.Text += " =";
                        Lbl_resultado.Text = calc.ToString();
                        break;
                    case "DIVISAO":
                        calc = double.Parse(Lbl_operacao_passada.Text.Replace('÷', ' ').Trim()) / double.Parse(r.getLabel1());
                        Lbl_calculando.Text += " =";
                        Lbl_resultado.Text = calc.ToString();
                        break;
                    default:
                        Lbl_calculando.Text += " =";
                        Lbl_resultado.Text = Math.Round(double.Parse(Lbl_resultado.Text)).ToString();
                        break;
                }
                tipoOperacao = "";
                operacaoPassada = "";
                sub = true;
                press = false;
            }
            else if(tipoOperacao == "FRACAO" || tipoOperacao == "POTENCIA")
            {
                Lbl_calculando.Text += " =";
                Lbl_operacao_passada.Text = " ";
                sub = true;
                tipoOperacao = "";
                operacaoPassada = "";
                press = false;
            }
            else if (tipoOperacao == "DIVISAO")
            {
                if (Lbl_resultado.Text != "0")
                {
                    double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                    Lbl_calculando.Text += Lbl_resultado.Text + " =";
                    Lbl_resultado.Text = resultado.ToString();
                    sub = true;
                    tipoOperacao = "";
                    operacaoPassada = "";
                    press = false;
                    Lbl_operacao_passada.Text = " ";
                }
                else
                {
                    MessageBox.Show("Não é possível dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lbl_calculando.Text = " ";
                    Lbl_resultado.Text = "0";
                    sub = true;
                    tipoOperacao = "";
                    operacaoPassada = "";
                    press = false;
                    Lbl_operacao_passada.Text = " ";
                }
            }
            else
            {
                double result = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_calculando.Text += Lbl_resultado.Text + " =";
                Lbl_resultado.Text = result.ToString();
                sub = true;
                tipoOperacao = "";
                press = false;
                Lbl_operacao_passada.Text = " ";
                operacaoPassada = "";
            }
        }
        //Função de Cálculo
        public double Calcular(string Lbl_calculando, string Lbl_resultado, string operacao)
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
                    resultado = Math.Round((valor2 / valor1), 2);
                    return resultado;
                case "POTENCIA":
                    valor1 = double.Parse(Lbl_calculando.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim());
                    resultado = Math.Round(Math.Pow(valor1, 2), 2);
                    return resultado;
                case "FRACAO":
                    valor1 = double.Parse(Lbl_calculando.Remove(1, 3).Replace(')', ' ').Trim());
                    resultado = 1 / valor1;
                    return resultado;
                default:
                    MessageBox.Show("Insira uma operação válida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
            }
        }
    }
}