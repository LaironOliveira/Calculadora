using System;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public partial class Frm_calc : Form
    {
        // Vari�vel respons�vel por fazer poss�vel a substitui��o de d�gitos na label_resultado ap�s uma opera��o.
        bool sub = false;

        // Vari�vel respons�vel por identificar o tipo de c�lculo que ser� executado.
        string tipoOperacao = "";
        string ultimaOperacao = "";

        // Vari�vel respons�vel por identificar se um bot�o foi pressionado.
        bool press = false;

        // Vari�vel respons�vel por armazenar o resultado de uma opera��o. 
        double valor = 0;
        double percent = 0;
        double operationResult = 0;

        public Frm_calc()
        {
            InitializeComponent();
        }

        // Bot�es num�ricos.
        private void Btn_zero_Click(object sender, EventArgs e)
        {
            Number(0);
        }

        private void Btn_um_Click(object sender, EventArgs e)
        {
            Number(1);
        }

        private void Btn_dois_Click(object sender, EventArgs e)
        {
            Number(2);
        }

        private void Btn_tres_Click(object sender, EventArgs e)
        {
            Number(3);
        }

        private void Btn_quatro_Click(object sender, EventArgs e)
        {
            Number(4);
        }

        private void Btn_cinco_Click(object sender, EventArgs e)
        {
            Number(5);
        }

        private void Btn_seis_Click(object sender, EventArgs e)
        {
            Number(6);
        }

        private void Btn_sete_Click(object sender, EventArgs e)
        {
            Number(7);
        }

        private void Btn_oito_Click(object sender, EventArgs e)
        {
            Number(8);
        }

        private void Btn_nove_Click(object sender, EventArgs e)
        {
            Number(9);
        }

        // Bot�o de invers�o de sinal dos n�meros digitados.
        private void Btn_inverte_sinal_Click(object sender, EventArgs e)
        {
            string signal = GetSignal(Lbl_calculando.Text);
            string substring1 = GetFirstHalf(Lbl_calculando.Text, signal);
            string substring2 = GetSecondHalf(Lbl_calculando.Text, signal);
            double num = GetValue(Lbl_resultado.Text);
            if (num != 0)
            {
                if (Lbl_calculando.Text.EndsWith('='))
                {
                    Lbl_calculando.Text = " ";
                    num *= (-1);
                    Lbl_resultado.Text = num.ToString();
                }
                else if (substring1.Contains("negative") ==false || substring2.Contains("negative") == false)
                {
                    if (Lbl_calculando.Text.Contains(signal) == false && substring1.EndsWith(')'))
                    {
                        Lbl_calculando.Text = "negative(" + Lbl_calculando.Text + ")";
                        valor *= (-1);
                    }
                    else if (Lbl_calculando.Text.Contains(signal) && substring2.EndsWith(')'))
                    {
                        if (substring1.EndsWith(')') == false)
                        {
                            valor *= (-1);
                        }
                        Lbl_calculando.Text = substring1 + " " + signal + "negative(" + substring2 + ")";
                    }
                    else if (Lbl_calculando.Text.Contains(signal) && press == false)
                    {
                        if (num > 0)
                        {
                            Lbl_calculando.Text = substring1 + " " + signal + "negative(" + Lbl_resultado.Text + ")";
                        }
                        else
                        {
                            Lbl_calculando.Text = substring1 + " "  + signal;
                        }
                    }
                }
                else if (Lbl_calculando.Text.Contains("negative"))
                {
                    if (Lbl_calculando.Text.Contains(signal) == false)
                    {
                        Lbl_calculando.Text = RemoveNegative(substring1);
                        valor *= (-1);
                    }
                    else if (substring2.Contains("negative"))
                    {
                        substring2 = RemoveNegative(substring2);
                        Lbl_calculando.Text = substring1 + " " + signal + substring2;
                        if (substring1.EndsWith(')') == false && substring2.EndsWith(')'))
                        {
                            valor *= (-1);
                        }
                    }
                }
                else
                {
                    press = true;
                }
                num *= (-1);
                Lbl_resultado.Text = num.ToString();
            }
        }

        // Bot�o que adiciona uma v�rgula (Funciona apenas se o Windows utilizado for da vers�o Pt-BR ABNT2).
        private void Btn_virgula_Click(object sender, EventArgs e)
        {
            if (Lbl_resultado.Text.Contains(',') == false)
            {
                Lbl_resultado.Text += ",";
            }
        }

        //Bot�o respons�vel por limpar todas as informa��es da calculadora.
        private void Btn_limpar_Click(object sender, EventArgs e)
        {
            Lbl_resultado.Text = "0";
            Lbl_calculando.Text = " ";
            tipoOperacao = "";
        }

        // Bot�o respons�vel por limpar apenas os n�meros que s�o digitados.
        private void Btn_limpar_resultado_Click(object sender, EventArgs e)
        {
            string signal = GetSignal(Lbl_calculando.Text);
            Lbl_resultado.Text = "0";
            if (Lbl_calculando.Text.EndsWith("="))
            {
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
            }
            else if (Lbl_calculando.Text.EndsWith(')') && signal != "!")
            {
                int index = Lbl_calculando.Text.IndexOf(signal);
                Lbl_calculando.Text = Lbl_calculando.Text.Remove(index + 2);
            }
        }

        // Bot�o respons�vel por apagar os n�meros digitados de maneira unit�ria.
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

        // Bot�o respons�vel pela opera��o de porcentagem.
        private void Btn_porcentagem_Click(object sender, EventArgs e)
        {
            double valor1 = GetValue(Lbl_calculando.Text);
            double valor2 = GetValue(Lbl_resultado.Text);
            double resultado;
            string signal = GetSignal(Lbl_calculando.Text);
            if (Lbl_calculando.Text != " " && signal != "!" || tipoOperacao == "" && Lbl_calculando.Text != " ")
            {
                if (Lbl_calculando.Text == Lbl_resultado.Text)
                {
                    resultado = percent * (valor2 / 100);
                    Lbl_calculando.Text = resultado.ToString();
                    Lbl_resultado.Text = resultado.ToString();
                }
                else if (Lbl_calculando.Text.EndsWith("="))
                {
                    percent = valor2;
                    resultado = valor2 * (valor2 / 100);
                    Lbl_calculando.Text = resultado.ToString();
                    Lbl_resultado.Text = resultado.ToString();
                    ultimaOperacao = ChangeToOperation(signal);
                    if (resultado == 0)
                    {
                        Lbl_calculando.Text = " ";
                    }
                }
                else
                {
                    string substring = GetFirstHalf(Lbl_calculando.Text, signal);
                    if (substring.EndsWith(')'))
                    {
                        valor1 = valor;
                    }
                    resultado = valor1 * (valor2 / 100);
                    Lbl_resultado.Text = resultado.ToString();
                    press = true;
                }
            }
            else
            {
                Lbl_calculando.Text = " ";
                Lbl_resultado.Text = "0";
                tipoOperacao = "";
                ultimaOperacao = "";
            }
            sub = true;
        }

        // Bot�o que realiza a opera��o de adi��o.
        private void Btn_adicao_Click(object sender, EventArgs e)
        {
            BasicOperation("ADICAO", '+');
        }

        //Bot�o que realiza a opera��o de subtra��o.
        private void Btn_subtracao_Click(object sender, EventArgs e)
        {
            BasicOperation("SUBTRACAO", '-');
        }

        //Bot�o que realiza a opera��o de multiplica��o.
        private void Btn_multiplicacao_Click(object sender, EventArgs e)
        {
            BasicOperation("MULTIPLICACAO", 'x');
        }

        // Bot�o que realiza a opera��o de divis�o.
        private void Btn_divisao_Click(object sender, EventArgs e)
        {
            BasicOperation("DIVISAO", '�');
        }

        // Bot�o que realiza a opera��o de radicia��o.
        private void Btn_raiz_quadrada_Click(object sender, EventArgs e)
        {
            string signal = GetSignal(Lbl_calculando.Text);
            double resultado;
            if(tipoOperacao == "RAIZ" && signal == "!" || tipoOperacao == "" || Lbl_calculando.Text == " ")
            {
                Lbl_calculando.Text = "sqrt(" + Lbl_resultado.Text + ")";
            }
            else if ((tipoOperacao == "FRACAO" || tipoOperacao == "POTENCIA") && signal == "!")
            {
                Lbl_calculando.Text = "sqrt(" + Lbl_calculando.Text + ")";
            }
            else
            {
                Lbl_calculando.Text += "sqrt(" + Lbl_resultado.Text + ")";
            }
            tipoOperacao = "RAIZ";
            resultado = Calcular(Lbl_resultado.Text, tipoOperacao);
            Lbl_resultado.Text = resultado.ToString();
            string substring = GetSecondHalf(Lbl_calculando.Text, signal);
            if (substring.Contains("negative"))
            {
                substring = RemoveNegative(substring);
            }
            if (substring == "" || substring.EndsWith(')') == false)
            {
                valor = resultado;
            }
            sub = true;
            press = false;
            ultimaOperacao = "";
        }

        //Bot�o respons�vel pela opera��o de potencia��o.
        private void Btn_elevar_quadrado_Click(object sender, EventArgs e)
        {
            string signal = GetSignal(Lbl_calculando.Text);
            double resultado;
            if (tipoOperacao == "POTENCIA" && signal == "!" || tipoOperacao == "" || Lbl_calculando.Text == " ")
            {
                Lbl_calculando.Text = "sqr(" + Lbl_resultado.Text + ")";
            }
            else if ((tipoOperacao == "RAIZ" || tipoOperacao == "FRACAO") && signal == "!")
            {
                Lbl_calculando.Text = "sqr(" + Lbl_calculando.Text + ")";
            }
            else
            {
                Lbl_calculando.Text += "sqr(" + Lbl_resultado.Text + ")";
            }
            tipoOperacao = "POTENCIA";
            resultado = Calcular(Lbl_resultado.Text, tipoOperacao);
            Lbl_resultado.Text = resultado.ToString();
            string substring = GetSecondHalf(Lbl_calculando.Text, signal);
            if (substring.Contains("negative"))
            {
                substring = RemoveNegative(substring);
            }
            if (substring == "" || substring.EndsWith(')') == false)
            {
                valor = resultado;
            }
            sub = true;
            press = false;
            ultimaOperacao = "";
        }

        // Bot�o respons�vel pela opera��o de fra��o.
        private void Btn_fracao_Click(object sender, EventArgs e)
        {
            string signal = GetSignal(Lbl_calculando.Text);
            double resultado;
            if (tipoOperacao == "FRACAO" && signal == "!" || tipoOperacao == "" || Lbl_calculando.Text == " ")
            {
                Lbl_calculando.Text = "1/(" + Lbl_resultado.Text + ")";
            }
            else if ((tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA") && signal == "!")
            {
                Lbl_calculando.Text = "1/(" + Lbl_calculando.Text + ")";
            }
            else
            {
                Lbl_calculando.Text += "1/(" + Lbl_resultado.Text + ")";
            }
            if (GetValue(Lbl_resultado.Text) == 0)
            {
                MessageBox.Show("N�o � poss�vel dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Lbl_calculando.Text = " ";
                Lbl_resultado.Text = "0";
                tipoOperacao = "";
            }
            else
            {
                tipoOperacao = "FRACAO";
                resultado = Calcular(Lbl_resultado.Text, tipoOperacao);
                Lbl_resultado.Text = resultado.ToString();
                string substring = GetSecondHalf(Lbl_calculando.Text, signal);
                if (substring.Contains("negative"))
                {
                    substring = RemoveNegative(substring);
                }
                if (substring == "" || substring.EndsWith(')') == false)
                {
                    valor = resultado;
                }
            }
            sub = true;
            press = false;
            ultimaOperacao = "";
        }
        
        // Bot�o que finaliza o c�lculo, realizando a �ltima opera��o dispon�vel.
        private void Btn_resultado_Click(object sender, EventArgs e)
        {
            double resultado;
            string signal = GetSignal(Lbl_calculando.Text);
            string substring;

            // Continuar o desenvolvimento - OBS: Esta � a a��o que permitir� que a �ltima opera��o seja executada ao pressionar o bot�o.
            // �ltima altera��o necess�ria para que a calculadora seja finalizada.
            if (Lbl_calculando.Text.EndsWith('=') && signal != "!" || ultimaOperacao != "")
            {
                if (ultimaOperacao == "")
                {
                    ultimaOperacao = ChangeToOperation(signal);
                }
                else
                {
                    signal = ChangeToSignal(ultimaOperacao);
                }
                resultado = Calcular(Lbl_resultado.Text, operationResult.ToString(), ultimaOperacao);
                if (operationResult < 0)
                {
                    Lbl_calculando.Text = Lbl_resultado.Text + " " + signal + "negative(" + operationResult * (-1) + ") =";
                }
                else
                {
                    Lbl_calculando.Text = Lbl_resultado.Text + " " + signal + operationResult + " =";
                }
                Lbl_resultado.Text = resultado.ToString();
            }
            else if (tipoOperacao == "")
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " =";
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "FRACAO" || tipoOperacao == "POTENCIA")
            {
                operationResult = GetValue(Lbl_resultado.Text);
                SolveOperationAndTurn('=');
            }
            else
            {
                substring = GetSecondHalf(Lbl_calculando.Text, signal);
                if (Lbl_resultado.Text.StartsWith("-") && substring.Contains("negative") == false)
                {
                    Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-', ' ').Trim() + ") =";
                }
                else
                {
                    if (substring.Contains("negative") || substring != "")
                    {
                        Lbl_calculando.Text += " =";
                    }
                    else
                    {
                            Lbl_calculando.Text += Lbl_resultado.Text + " =";
                    }
                }
                operationResult = GetValue(Lbl_resultado.Text);
                resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                Lbl_resultado.Text = resultado.ToString();
            }
            sub = true;
            press = false;
            tipoOperacao = "";
        }

        // Fun��o respons�vel por criar os bot�es de opera��es b�sicas.
        public void BasicOperation(string operation, char signal) 
        {
            if (Lbl_calculando.Text.EndsWith('='))
            {
                Lbl_calculando.Text = Lbl_resultado.Text + " " + signal + " ";
            }
            else if (tipoOperacao == "RAIZ" || tipoOperacao == "POTENCIA" || tipoOperacao == "FRACAO")
            {
                if (Lbl_calculando.Text.EndsWith(signal + " ") == false)
                {
                    string operacao = GetSignal(Lbl_calculando.Text);
                    if (Lbl_calculando.Text.Contains(operacao))
                    {
                        if (press == true || Lbl_calculando.Text.EndsWith(')'))
                        {
                            SolveOperationAndTurn(signal);
                            tipoOperacao = operation;
                        }
                        else
                        {
                            ChangeOperationTo(signal);
                        }
                    }
                    else
                    {
                        Lbl_calculando.Text += " " + signal + " ";
                        valor = GetValue(Lbl_resultado.Text);
                    }
                }
                else if (Lbl_calculando.Text.EndsWith(signal + " ") && press == true)
                {
                    if (operation == "DIVISAO" && GetValue(Lbl_resultado.Text) == 0)
                    {
                        MessageBox.Show("N�o � poss�vel dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lbl_calculando.Text = " ";
                        Lbl_resultado.Text = "0";
                    }
                    else
                    {
                        tipoOperacao = operation;
                        double resultado = Calcular(valor.ToString(), Lbl_resultado.Text, tipoOperacao);
                        Lbl_calculando.Text = resultado.ToString() + " " + signal + " ";
                        Lbl_resultado.Text = resultado.ToString();
                    }
                }
            }
            else
            {
                if (Lbl_calculando.Text == " ")
                {
                    tipoOperacao = operation;
                    Lbl_calculando.Text = Lbl_resultado.Text + " " + signal + " ";
                }
                else
                {
                    if (press == true || Lbl_calculando.Text.Contains("negative"))
                    {
                        if (operation == "DIVISAO" && GetValue(Lbl_resultado.Text) == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por 0", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Lbl_calculando.Text = " ";
                            Lbl_resultado.Text = "0";
                        }
                        else
                        {
                            double resultado = Calcular(Lbl_calculando.Text, Lbl_resultado.Text, tipoOperacao);
                            Lbl_calculando.Text = resultado.ToString() + " " + signal + " ";
                            Lbl_resultado.Text = resultado.ToString();
                            tipoOperacao = operation;
                        }
                    }
                    else
                    {
                        ChangeOperationTo(signal);
                        tipoOperacao = operation;
                    }
                }
            }
            sub = true;
            press = false;
            ultimaOperacao = "";
        }

        //Fun��o respons�vel pelos C�lculos.
        public double Calcular(string value1, string value2, string operacao)
        {
            double valor1;
            double valor2 = GetValue(value2);
            double resultado;
            if (value1.Contains("negative"))
            {
                string sinal = GetSignal(Lbl_calculando.Text);
                string substring = Lbl_calculando.Text.Remove(Lbl_calculando.Text.IndexOf(sinal));
                valor1 = GetValue(substring);
            }
            else
            {
                valor1 = GetValue(value1);
            }
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
                
                default:
                    return -1;
            }
        }

        public double Calcular(string value, string operacao)
        {
            double valor = GetValue(value);
            double resultado;
            switch (operacao)
            {
                case "RAIZ":
                    resultado = Math.Sqrt(valor);
                    return resultado;
                case "POTENCIA":
                    resultado = Math.Pow(valor, 2);
                    return resultado;
                case "FRACAO":
                    resultado = 1 / valor;
                    return resultado;
                default:
                    return -1;
            }
        }

        // Fun��o respons�vel por realizar a �ltima opera��o pendente.
        // Utilizado quando tratamos das opera��es de Radicia��o, Potencia��o e Fra��o, pois necessitam de um tratamento particular.
        public void SolveOperationAndTurn(char operation)
        {
            int index;
            double resultado;
            string substring1;
            string substring2;
            string lastOperation = GetSignal(Lbl_calculando.Text);
            switch (lastOperation)
            {
                case "+ ":
                    substring1 = GetFirstHalf(Lbl_calculando.Text, lastOperation);
                    substring2 = GetSecondHalf(Lbl_calculando.Text, lastOperation);
                    if (substring2.Contains("negative"))
                    {
                        substring2 = RemoveNegative(substring2);
                    }
                    if (substring1.EndsWith(')') == false && substring2.EndsWith(')'))
                    {
                        index = Lbl_calculando.Text.IndexOf("+ ");
                        string numeroASerAcrescido = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerAcrescido, valor.ToString(), "ADICAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "ADICAO");
                    }
                    if (operation == '=')
                    {
                        if (substring2.EndsWith(')') || GetValue(Lbl_resultado.Text) < 0){
                            if (press == true && GetValue(Lbl_resultado.Text) < 0)
                            {
                                Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-',' ').Trim() + ")";
                            }
                            Lbl_calculando.Text += " " + operation;
                        }
                        else
                        {
                            Lbl_calculando.Text += Lbl_resultado.Text + " " + operation;
                        }
                    }
                    else
                    {
                        Lbl_calculando.Text = resultado.ToString() + " " + operation + " ";
                    }
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "- ":
                    substring1 = GetFirstHalf(Lbl_calculando.Text, lastOperation);
                    substring2 = GetSecondHalf(Lbl_calculando.Text, lastOperation);
                    if (substring2.Contains("negative"))
                    {
                        substring2 = RemoveNegative(substring2);
                    }
                    if (substring1.EndsWith(')') == false && substring2.EndsWith(')') == true)
                    {
                        index = Lbl_calculando.Text.IndexOf("- ");
                        string numeroASerSubtraido = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerSubtraido, valor.ToString(), "SUBTRACAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "SUBTRACAO");
                    }
                    if (operation == '=')
                    {
                        if (substring2.EndsWith(')') || GetValue(Lbl_resultado.Text) < 0)
                        {
                            if (press == true && GetValue(Lbl_resultado.Text) < 0)
                            {
                                Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-', ' ').Trim() + ")";
                            }
                            Lbl_calculando.Text += " " + operation;
                        }
                        else
                        {
                            Lbl_calculando.Text = Lbl_resultado.Text + " " + operation;
                        }
                    }
                    else
                    {
                        Lbl_calculando.Text = resultado.ToString() + " " + operation + " ";
                    }
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "x ":
                    substring1 = GetFirstHalf(Lbl_calculando.Text, lastOperation);
                    substring2 = GetSecondHalf(Lbl_calculando.Text, lastOperation);
                    if (substring2.Contains("negative"))
                    {
                        substring2 = RemoveNegative(substring2);
                    }
                    if (substring1.EndsWith(')') == false && substring2.EndsWith(')') == true)
                    {
                        index = Lbl_calculando.Text.IndexOf("x ");
                        string numeroASerMultiplicado = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(numeroASerMultiplicado, valor.ToString(), "MULTIPLICACAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "MULTIPLICACAO");
                    }
                    if (operation == '=')
                    {
                        if (substring2.EndsWith(')') || GetValue(Lbl_resultado.Text) < 0)
                        {
                            if (press == true && GetValue(Lbl_resultado.Text) < 0)
                            {
                                Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-', ' ').Trim() + ")";
                            }
                            Lbl_calculando.Text += " " + operation;
                        }
                        else
                        {
                            Lbl_calculando.Text = Lbl_resultado.Text + " " + operation;
                        }
                    }
                    else
                    {
                        Lbl_calculando.Text = resultado.ToString() + " " + operation + " ";
                    }
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                case "� ":
                    substring1 = GetFirstHalf(Lbl_calculando.Text, lastOperation);
                    substring2 = GetSecondHalf(Lbl_calculando.Text, lastOperation);
                    if (substring2.Contains("negative"))
                    {
                        substring2 = RemoveNegative(substring2);
                    }
                    if (substring1.EndsWith(')') == false && substring2.EndsWith(')') == true)
                    {
                        index = Lbl_calculando.Text.IndexOf("� ");
                        string dividendo = Lbl_calculando.Text.Remove(index);
                        resultado = Calcular(dividendo, valor.ToString(), "DIVISAO");
                    }
                    else
                    {
                        resultado = Calcular(valor.ToString(), Lbl_resultado.Text, "DIVISAO");
                    }
                    if (operation == '=')
                    {
                        if (substring2.EndsWith(')') || GetValue(Lbl_resultado.Text) < 0)
                        {
                            if (press == true && GetValue(Lbl_resultado.Text) < 0)
                            {
                                Lbl_calculando.Text += "negative(" + Lbl_resultado.Text.Replace('-', ' ').Trim() + ")";
                            }
                            Lbl_calculando.Text += " " + operation;
                        }
                        else
                        {
                            Lbl_calculando.Text = Lbl_resultado.Text + " " + operation;
                        }
                    }
                    else
                    {
                        Lbl_calculando.Text = resultado.ToString() + " " + operation + " ";
                    }
                    Lbl_resultado.Text = resultado.ToString();
                    break;
                default:
                    if (operation == '=')
                    {
                        Lbl_calculando.Text += " " + operation;
                    }
                    break;
            }
        }

        // Fun��o respons�vel por alterar o sinal da opera��o.
        public void ChangeOperationTo(char operation) 
        {
            Lbl_calculando.Text = Lbl_calculando.Text.Replace('-', operation).Replace('x', operation).Replace('�', operation).Replace('+', operation);
        }

        public string ChangeToOperation(string operation)
        {
            switch (operation)
            {
                case "+ ":
                    return "ADICAO";
                    
                case "- ":
                    return "SUBTRACAO";
                    
                case "x ":
                    return "MULTIPLICACAO";
                case "� ":
                    return "DIVISAO";
                default:
                    return "";
            }
        }
        
        public string ChangeToSignal(string operation)
        {
            switch (operation)
            {
                case "ADICAO":
                    return "+ ";
                case "SUBTRACAO":
                    return "- ";
                case "MULTIPLICACAO":
                    return "x ";
                case "DIVISAO":
                    return "� ";
                default:
                    return "!";
            }
        }

        //Fun��o que faz a limpeza dos valores da label.
        public double GetValue(string valorASerLimpo)
        {
            double resultado;
            string pattern = "[0-9,-]{1,16}";
            Match valorlimpo = Regex.Match(valorASerLimpo, pattern);
            resultado = double.Parse(valorlimpo.Value);
            return resultado;
        }

        public string RemoveNegative(string text)
        {
            string resultado;
            resultado = text.Substring(9);
            resultado = resultado.Remove(resultado.Length - 1);
            return resultado;
        }

        public string GetFirstHalf(string text, string signal) 
        {
            int index = text.Length;
            string resultado;
            if (signal != "!")
            {
                index = text.IndexOf(signal) - 1;
            }
            resultado = text.Remove(index);
            return resultado;
        }

        public string GetSecondHalf(string text, string signal)
        {
            if (signal != "!")
            {
                int index = text.IndexOf(signal) + 2;
                string resultado = text.Substring(index);
                return resultado;
            }
            else
            {
                return "";
            }
        }

        // Fun��o respons�vel por captar o s�mbolo da opera��o.
        public string GetSignal(string valor)
        {
            string pattern = "[+x�-][ ]";
            Match v = Regex.Match(valor, pattern);
            string resultado = v.Value;
            if (resultado == "")
            {
                resultado = "!";
            }
            return resultado;
        }

        // Fun��o respons�vel por remover as opera��es de Radicia��o, Pot�ncia��o e Fra��o, caso seu resultado seja alterado.
        public void Substitute()
        {
            if (Lbl_calculando.Text.EndsWith(")") == true)
            {
                string operacao = GetSignal(Lbl_calculando.Text);
                if (Lbl_calculando.Text.Contains(operacao))
                {
                    int index = Lbl_calculando.Text.IndexOf(operacao) + 2;
                    Lbl_calculando.Text = Lbl_calculando.Text.Remove(index);
                }
                else
                {
                    Lbl_calculando.Text = " ";
                }
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
                    case "� ":
                        tipoOperacao = "DIVISAO";
                        break;
                    default:
                        tipoOperacao = "";
                        break;
                }
            }
        }

        // Fun��o respons�vel por exibir os n�meros quando seu respectivo bot�o � pressionado.
        public void Number(int num)
        {
            if (Lbl_resultado.Text == "0" || sub == true)
            {
                if (Lbl_calculando.Text.EndsWith("="))
                {
                    Lbl_calculando.Text = " ";
                }
                Lbl_resultado.Text = num.ToString();
                sub = false;
                press = true;
                Substitute();
            }
            else if (Lbl_resultado.Text.Length < 14)
            {
                Lbl_resultado.Text += num.ToString();
            }
        }
    }
}