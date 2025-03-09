using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class Form1: Form
    {
        public decimal resultado { get; set; }
        List<string> numeros = new List<string>();
        public Form1()
        {
            
            //acessando a struct size
            //Size tamanho = new Size()
            //tamanho.Width = 400;
            //tamanho.Height = 200;


            InitializeComponent();
            //this.Text = "Lucas Gomes";
            //this.Size = new Size(400, 200);
            //this.ControlBox = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtResultado.Focus();


            txtResultado.ReadOnly = true;

        }

        private void Form1_Click(object sender, EventArgs e)
        {
          
           
         
        }



        private void botao0_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
            
       
        }

        private void botao1_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
            
        }

        private void botao2_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
            
        }

        private void botao3_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
           
        }

        private void botao4_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
            
        }

        private void botao5_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
           
        }

        private void botao6_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
           
        }

        private void botao7_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
            
        }

        private void botao8_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
            
        }

        private void botao9_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
           
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            
            numeros.Add(txtResultado.Text);
            txtOperadores.Text = txtResultado.Text + " + ";
            txtResultado.Text = " ";
            
        }
        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            numeros.Add(txtResultado.Text);
            txtOperadores.Text = txtResultado.Text + " - ";
            txtResultado.Text = " ";
        }

        private void btnMutiplicar_Click(object sender, EventArgs e)
        {
            numeros.Add(txtResultado.Text);
            txtOperadores.Text = txtResultado.Text + " x ";
            txtResultado.Text = " ";

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOperadores.Text.Contains("+"))
                {
                    // Adiciona o valor atual do resultado à lista de números
                    numeros.Add(txtResultado.Text);

                    // Inicializa o resultado com o primeiro número
                    resultado = decimal.Parse(numeros[0]);

                    // Realiza a soma com os valores subsequentes
                    for (int i = 1; i < numeros.Count; i++)
                    {
                        resultado += decimal.Parse(numeros[i]);
                    }
                }

                if (txtOperadores.Text.Contains("-"))
                {

                    numeros.Add(txtResultado.Text);

                    resultado = decimal.Parse(numeros[0]);

                    for (int i = 1; i < numeros.Count; i++)
                    {
                        resultado -= decimal.Parse(numeros[i]);
                    }
                }
                if (txtOperadores.Text.Contains("x"))
                {

                    numeros.Add(txtResultado.Text);

                    resultado = decimal.Parse(numeros[0]);

                    for (int i = 1; i < numeros.Count; i++)
                    {
                        resultado *= decimal.Parse(numeros[i]);
                    }


                }
                if (txtOperadores.Text.Contains("÷"))
                {

                    numeros.Add(txtResultado.Text);

                    resultado = decimal.Parse(numeros[0]);
                    if(txtResultado.Text == "0")
                    {
                        txtResultado.Text = "Error: Attempted to divide by zero";
                        return;
                    }
                    for (int i = 1; i < numeros.Count; i++)
                    {
                        resultado /= decimal.Parse(numeros[i]);
                    }


                }

                if (txtOperadores.Text.Contains("^"))
                {
                    numeros.Add(txtResultado.Text);

                    if (txtResultado.Text == "0")
                    {
                        resultado = 1;
                        return;
                    }
                    else
                    
                    {
                        int expoente = int.Parse(txtResultado.Text);
                        resultado = 1;
                        for(int elemento = 0; elemento < expoente; elemento++)
                        {
                            resultado *= Convert.ToDecimal(numeros[0]);
                           
                        }
                    
                    
                    }
                   

                }

                txtResultado.Text = resultado.ToString();
                txtOperadores.Text = " ";
                numeros.Clear();
            }
            catch(Exception ex)
            {
                txtResultado.Text = "Error: Press C";
                MessageBox.Show("Error: " + ex);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = true;
                }
            }
            txtResultado.Text = "";
            txtOperadores.Text = "";
        }

        private void btnBinario_Click(object sender, EventArgs e)
        {
            try
            {
                txtOperadores.Text = " ";
                txtOperadores.Text += txtResultado.Text + " BIN";
                if (txtResultado.Text == "1")
                {
                    txtResultado.Text = "";
                    txtResultado.Text += "1";
                }
                else if (txtResultado.Text == "0")
                {
                    txtResultado.Text = "";
                    txtResultado.Text += "0";
                }




                else
                {
                    int variavel = int.Parse(txtResultado.Text);
                    string resultado = "";
                    do
                    {
                        int resto = variavel % 2;
                        resultado = resto.ToString() + resultado;
                        variavel = variavel / 2;


                    } while (variavel > 0);
                    txtResultado.Text = resultado;

                }
            }
            catch(Exception ex)
            {
              
                txtResultado.Text = "Error: Press C";
                MessageBox.Show("Erro: " + ex.Message);
                DesabilitarBotoes();
            }
        }
        private void DesabilitarBotoes()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn && btn.Name != "button3") 
                {
                    btn.Enabled = false;
                }
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            numeros.Clear();
            numeros.Add(txtResultado.Text);
            txtOperadores.Text += txtResultado.Text + " ^";
            txtResultado.Text = " ";

          


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                numeros.Clear();
                double numero = Convert.ToDouble(txtResultado.Text);
                double resultado = Math.Sqrt(numero);
                txtResultado.Text = resultado.ToString();
            }
            catch(Exception ex)
            {
                txtResultado.Text = "Error: Press C";
                MessageBox.Show("Erro: " + ex.Message);
                DesabilitarBotoes();
            }
            
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            
            numeros.Add(txtResultado.Text);
            txtOperadores.Text += txtResultado.Text + " ÷";
            txtResultado.Text = " ";

        }

        private void txtOperadores_TextChanged(object sender, EventArgs e)
        {
            txtOperadores.TabStop = false;
        }

        private void txtOperadores_MouseEnter(object sender, EventArgs e)
        {
            txtOperadores.TabStop = false;
            txtOperadores.Enabled = false;
        }
        
    }
}   
