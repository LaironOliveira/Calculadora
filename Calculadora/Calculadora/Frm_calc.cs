using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    public partial class Frm_calc : Form
    {
        //
        //Vari�vel respons�vel para que ap�s ocorrer um bot�o de opera��o matem�tica ter o evento click acionado
        //o pr�ximo n�mero digitado sobreescreva o n�mero na label de resultado, para evitar que os n�meros de
        //opera��es anteriores se acumulem
        //
        bool sub = false;
        //
        //Valores que s�o utilizados para os c�lculo
        //
        double valor1 = 0, valor2 = 0;
        //
        //Vari�vel respons�vle pela defini��o do tipo de c�lculo
        //
        string tipoOperacao = "";
        //
        //Vari�vel respons�vel por identificar se existe uma opera��o anterior pendente ao clicar em outra opera��o antes de clicar no bot�o igual(=).
        //
        bool valida=false;
        //
        //Vari�vel respons�vel pela identifica��o de erros
        //
        bool error = false;

        public Frm_calc()
        {
            InitializeComponent();           

        }

        private void Btn_zero_Click(object sender, EventArgs e)
        {
            //
            //Verifica��o se o n�mero na label resultado � igual a zero ou n�o para que o programa
            //possa sobreescrever ou adicionar mais um n�mero a label resultado.
            //Essa verifica��o � feita a todos os n�meros do teclado num�rico.
            //
            if (Lbl_resultado.Text == "0" || sub==true)
            {
                Lbl_resultado.Text = "0";
                sub = false;
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
            }
            else
            {
                Lbl_resultado.Text += "9";
            }
        }
        
        //
        // Fim da verifica��o dos n�meros inseridos
        //

        private void Btn_inverte_sinal_Click(object sender, EventArgs e)
        {
            //
            //Verifica se os n�meros da label resultado s�o positivos, caso sim, adiciona o sinal
            //de negativo. Caso sejam negativos, remove o sinal de negativo.
            //
            double calc = double.Parse(Lbl_resultado.Text);
            if (calc > 0)
            {
                Lbl_resultado.Text = "-" + calc;
            }
            else
            {
                Lbl_resultado.Text = calc.ToString().Replace('-', ' ').Trim();
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
            valor1 = 0; 
            valor2 = 0;
            tipoOperacao = "";
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
                //Recebe o tamanho da sequ�ncia de caracteres menos 1, no caso abaixo � 1
                //
                int apaga = Lbl_resultado.Text.Length - (Lbl_resultado.Text.Length - 1);
                //
                //Remove a posi��o do vetor de caracteres (string) referente ao tamanho capturado na vari�vel apaga. Na fun��o Remove() o primeiro par�metro �
                //a posi��o no vetor do qual ser� iniciado a remo��o e o segundo par�metro � o n�mero de caracteres que ser�o removidos
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
            else if (tipoOperacao != "ADICAO")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim()); 
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = resultado.ToString()+" + ";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = resultado.ToString()+" + ";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if (valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = resultado.ToString() + " + ";
                            sub = true;
                            valida = true;
                        }
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = resultado.ToString()+ " + ";
                        sub = true;
                        valida = true;
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = resultado.ToString()+" + ";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = resultado.ToString()+" + ";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "ADICAO";
                valida = false;
            }
            else if (Lbl_calculando.Text == " ")
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = 0;
                double result = valor1 + valor2;
                Lbl_calculando.Text = result.ToString() + " + ";
                sub = true;
                tipoOperacao = "ADICAO";
            }
            else
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = double.Parse(Lbl_calculando.Text.Replace('+', ' ').Trim());
                double result = valor1 + valor2;
                Lbl_calculando.Text = result.ToString() + " + ";
                sub = true;
                tipoOperacao = "ADICAO";
            }                            
        }
        private void Btn_subtracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "SUBTRACAO")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if (valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = resultado.ToString() + " - ";
                            sub = true;
                            valida = true;
                        }
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        sub = true;
                        valida = true;
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = resultado.ToString() + " - ";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "SUBTRACAO";
                valida = false;
            }
            else if (Lbl_calculando.Text == " ")
            {
                double result;
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = 0;
                result = valor1 - valor2;
                Lbl_calculando.Text = result.ToString() + " - ";
                sub = true;
                tipoOperacao = "SUBTRACAO";
            }
            else
            {
                double result;
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length-2), 2).Trim());
                result = valor2 - valor1;
                Lbl_calculando.Text = result.ToString() + " - ";
                sub = true;
                tipoOperacao = "SUBTRACAO";
            }
        }

        private void Btn_multiplicacao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "MULTIPLICACAO")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        sub = true;
                        valida = true;
                        break;
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if(valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = resultado.ToString() + " x ";
                            sub = true;
                            valida = true;
                        }                   
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        sub = true;
                        valida = true;
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = resultado.ToString() + " x ";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "MULTIPLICACAO";
                valida = false;
            }
            else if (Lbl_calculando.Text == " ")
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = 1;
                double result = valor2 * valor1;
                Lbl_calculando.Text = result.ToString() + " x ";
                sub = true;
                tipoOperacao = "MULTIPLICACAO";
            }
            else
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                valor2 = double.Parse(Lbl_calculando.Text.Replace('x', ' ').Trim());
                double result = valor2 * valor1;
                Lbl_calculando.Text = result.ToString() + " x ";
                sub = true;
                tipoOperacao = "MULTIPLICACAO";
            }
        }

        private void Btn_divisao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "DIVISAO")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = resultado.ToString() + " � ";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "DIVISAO";
                valida = false;
            }
            else if (Lbl_calculando.Text == " ")
            {
                if(Lbl_resultado.Text=="0")
                {
                    MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    valor1 = double.Parse(Lbl_resultado.Text);
                    valor2 = valor1 * valor1;
                    double result = valor2 / valor1;
                    Lbl_calculando.Text = result.ToString() + " � ";
                    sub = true;
                    tipoOperacao = "DIVISAO";
                }
            }
            else
            {
                if(Lbl_calculando.Text == "0 � " || Lbl_resultado.Text == "0")
                {
                    MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    valor1 = double.Parse(Lbl_resultado.Text);
                    valor2 = double.Parse(Lbl_calculando.Text.Replace('�', ' ').Trim());
                    double result = valor2 / valor1;
                    Lbl_calculando.Text = result.ToString() + " � ";
                    sub = true;
                    tipoOperacao = "DIVISAO";
                }
            }          
        }

        private void Btn_raiz_quadrada_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "RAIZ")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if (valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                            sub = true;
                            valida = true;
                        }
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = "sqrt(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "RAIZ";
                valida = false;
            }
            else
            {
                if (double.Parse(Lbl_resultado.Text) < 0)
                {
                    MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lbl_calculando.Text = " ";
                    Lbl_resultado.Text = "0";
                    tipoOperacao = "";
                }
                else
                {
                    valor1 = double.Parse(Lbl_resultado.Text);
                    double result = Math.Round(Math.Sqrt(valor1), 2);
                    Lbl_calculando.Text = "sqrt(" + valor1.ToString() + ")";
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "RAIZ";
                }               
            }
        }

        private void Btn_elevar_quadrado_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "POTENCIA")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if (valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                            sub = true;
                            valida = true;
                        }
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "FRACAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')', ' ').Trim());
                        resultado = 1 / valor1;
                        Lbl_calculando.Text = "sqr(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "POTENCIA";
                valida = false;
            }
            else
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                double result = Math.Round(Math.Pow(valor1, 2), 2);
                Lbl_calculando.Text = "sqr(" + valor1.ToString() + ")";
                Lbl_resultado.Text = result.ToString();
                sub = true;
                tipoOperacao = "POTENCIA";
            }    
        }

        private void Btn_fracao_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (tipoOperacao != "FRACAO")
            {
                double resultado;
                switch (tipoOperacao)
                {
                    case "ADICAO":
                        valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        valor2 = double.Parse(Lbl_resultado.Text);
                        resultado = valor1 + valor2;
                        Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "SUBTRACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 - valor1;
                        Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "MULTIPLICACAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        resultado = valor2 * valor1;
                        Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "DIVISAO":
                        valor1 = double.Parse(Lbl_resultado.Text);
                        valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                        if (valor1 == 0 || valor2 == 0)
                        {
                            MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        else
                        {
                            resultado = valor2 / valor1;
                            Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                            sub = true;
                            valida = true;
                        }
                        break;
                    case "RAIZ":
                        if (double.Parse(Lbl_resultado.Text) < 0)
                        {
                            MessageBox.Show("Resultado indefinido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                        }
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());//16
                        resultado = Math.Round(Math.Sqrt(valor1), 2);
                        Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                    case "POTENCIA":
                        valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim()); //2
                        resultado = Math.Round(Math.Pow(valor1, 2), 2);
                        Lbl_calculando.Text = "1/(" + resultado.ToString() + ")";
                        sub = true;
                        valida = true;
                        break;
                }
            }
            if (error == true)
            {
                Lbl_resultado.Text = "0";
                Lbl_calculando.Text = " ";
                tipoOperacao = "";
                error = false;
            }
            else if (valida == true)
            {
                tipoOperacao = "FRACAO";
                valida = false;
            }
            
            else
            {
                valor1 = double.Parse(Lbl_resultado.Text);
                double result = 1 / valor1;
                Lbl_calculando.Text = "1/(" + valor1.ToString() + ")";
                Lbl_resultado.Text = result.ToString();
                sub = true;
                tipoOperacao = "FRACAO";
            }            
        }

        private void Btn_porcentagem_Click(object sender, EventArgs e)
        {
            if (Lbl_calculando.Text.Substring(Lbl_calculando.Text.Length - 1) == "=")
            {
                Lbl_calculando.Text = " ";
            }
            else if (Lbl_calculando.Text == " "||tipoOperacao=="FRACAO"||tipoOperacao=="RAIZ"||tipoOperacao=="POTENCIA")
            {
                Lbl_calculando.Text = " ";
                Lbl_resultado.Text = "0";
                tipoOperacao = "";
            }
            else
            {
                valor1 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                valor2 = double.Parse(Lbl_resultado.Text);
                double result = valor1 * (valor2 / 100);
                Lbl_resultado.Text = result.ToString();
                sub = true;
            }
        }

        private void Btn_resultado_Click(object sender, EventArgs e)
        {
            double result;
            valor1 = double.Parse(Lbl_resultado.Text);

            switch (tipoOperacao)
            {                
                case "ADICAO":
                    valor2 = double.Parse(Lbl_calculando.Text.Replace('+', ' ').Trim());
                    Lbl_calculando.Text += valor1.ToString() + " =";
                    result = valor1 + valor2;
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break;
                case "SUBTRACAO":
                    valor2 = double.Parse(Lbl_calculando.Text.Remove((Lbl_calculando.Text.Length - 2), 2).Trim());
                    Lbl_calculando.Text += valor1.ToString() + " =";
                    result =  valor2 - valor1;
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break;
                case "MULTIPLICACAO":
                    valor2 = double.Parse(Lbl_calculando.Text.Replace('x', ' ').Trim());
                    Lbl_calculando.Text += valor1.ToString() + " =";
                    result = valor2 * valor1;
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break;
                case "DIVISAO":
                    valor2 = double.Parse(Lbl_calculando.Text.Replace('�', ' ').Trim());
                    if (valor1 == 0 || valor2 == 0)
                    {
                        MessageBox.Show("N�o � poss�vel dividir por Zero", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Lbl_calculando.Text += valor1.ToString() + " =";
                        result = valor2 / valor1;
                        Math.Round(result, 2);
                        Lbl_resultado.Text = result.ToString();
                        sub = true;
                        tipoOperacao = "";
                    }
                    break;
                case "RAIZ":
                    valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('t', ' ').Replace('(', ' ').Replace(')', ' ').Trim());
                    Lbl_calculando.Text = "sqrt(" + valor1.ToString() + ") =";
                    result = Math.Round(Math.Sqrt(valor1), 2);
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break;
                case "POTENCIA":
                    valor1 = double.Parse(Lbl_calculando.Text.Replace('s', ' ').Replace('q', ' ').Replace('r', ' ').Replace('(', ' ').Replace(')', ' ').Trim());
                    Lbl_calculando.Text = "sqr(" + valor1.ToString() + ") =";
                    result = Math.Round(Math.Pow(valor1, 2), 2);
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break;
                case "FRACAO":
                    valor1 = double.Parse(Lbl_calculando.Text.Remove(1, 3).Replace(')',' ').Trim());
                    result = 1 / valor1;
                    Lbl_calculando.Text = "1/(" + valor1.ToString() + ") =";
                    Lbl_resultado.Text = result.ToString();
                    sub = true;
                    tipoOperacao = "";
                    break; 
                default:
                    Lbl_calculando.Text = valor1.ToString() + " =";                    
                    sub = true;
                    tipoOperacao = "";
                    break;
            }
        }
    }
}