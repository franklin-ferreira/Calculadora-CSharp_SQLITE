using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#region Sobre ----------------------~
/*
 *
 * Franklin Ferreira Santos
 * Banco de dados SQLIte.
 * Historico dos ultimos 12 registros.
 **/

#endregion
namespace Calculadora
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            carregarBanco();
            limpar();
            aux = "";
           
            

        }

        #region Calculo
        float n1 = 0;
        float n2 = 0;
        int i = 1;
        float resul = 0;
        string operacao = "";
        public float calc (float num1,float num2,string tipo)
        {
            txtCampoCalculo.Text = "";
            
            if (tipo =="+")
            {
                resul = num1 + num2;
            }
            if(tipo == "-")
            {
                resul = num1 - num2;
            }
            if(tipo == "x")
            {
                resul = num1 * num2;
            }
            if(tipo == "÷")
            {
                resul = num1 / num2;
            }
            
            return resul;
        }

        #endregion     
        #region Botoes de numeracao
        private void btn7_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn7.Text;
            lblText.Text += btn7.Text;
           
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn8.Text;
            lblText.Text += btn8.Text;
            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn9.Text;
            lblText.Text += btn9.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn4.Text;
            lblText.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn5.Text;
            lblText.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn6.Text;
            lblText.Text += btn6.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn1.Text;
            lblText.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn2.Text;
            lblText.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn3.Text;
            lblText.Text += btn3.Text;   
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += btn0.Text;
            lblText.Text += btn0.Text;
        }
        private void btnPonto_Click(object sender, EventArgs e)
        {
            txtCampoCalculo.Text += ",";
            lblText.Text += btnPonto.Text;
        }
        #endregion
        #region operacoes
        String aux = "";
        public void AC()
        {
            txtCampoCalculo.Text = "";
            lblText.Text = aux;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AC();
        }
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            try
            {


                n1 = float.Parse(txtCampoCalculo.Text);
                lblText.Text += " " + btnAdicao.Text + " ";

                operacao = btnAdicao.Text;
                aux = lblText.Text;
                txtCampoCalculo.Focus();
                txtCampoCalculo.Text = "";
                
            }catch(Exception ex)
            {

            }

        }
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = float.Parse(txtCampoCalculo.Text);
                lblText.Text += " " + btnSubtracao.Text + " ";
                operacao = btnSubtracao.Text;
                aux = lblText.Text;
                txtCampoCalculo.Focus();
                txtCampoCalculo.Text = "";
                
            }
            catch(Exception ex)
            {

            }
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = float.Parse(txtCampoCalculo.Text);
                lblText.Text += " " + btnMultiplicacao.Text + " ";
                operacao = btnMultiplicacao.Text;
                aux = lblText.Text;
                txtCampoCalculo.Focus();
                txtCampoCalculo.Text = "";
                
            }catch(Exception ex)
            {

            }
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            try
            {


                n1 = float.Parse(txtCampoCalculo.Text);
                lblText.Text += " " + btnDivisao.Text + " ";
                operacao = btnDivisao.Text;
                aux = lblText.Text;
                txtCampoCalculo.Focus();
                txtCampoCalculo.Text = "";
                
            }catch(Exception ex)
            {

            }
        }
        public void igual()
        {
            try
            {
                n2 = float.Parse(txtCampoCalculo.Text);
                lblText.Text += " = " + calc(n1, n2, operacao);
                CsBanco.ExecutarComandoSQL("insert into tbcalculos(calculo) values ('" + lblText.Text + "');");
                carregarBanco();
                n1 = 0; n2 = 0;
                txtCampoCalculo.Text = "";
                txtCampoCalculo.Focus();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                aux = "";
            }
        }
        private void btnIgual_Click(object sender, EventArgs e)
        {
            igual();
            

        }

        #endregion
        #region detalhes
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Clique no limpar para iniciar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLimpar.PerformClick();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                CsBanco.ExecutarComandoSQL("DELETE from tbcalculos;");
                carregarBanco();
            }
            catch (Exception ex)
            {
                carregarBanco();
            }
        }
        public void carregarBanco()
        {
            try
            {
                CsBanco.CarregaDados("select calculo as 'Historico' from tbcalculos ORDER by id  desc limit 12;", dataGridView1);
            }
            catch (Exception ex)
            {

            }
        }
        private void txtCampoCalculo_TextChanged(object sender, EventArgs e)
        {
            
            if(txtCampoCalculo.Text.Length >= 11)
            {
                MessageBox.Show("Voce chegou no limite permitido de 12 digitos por calculo", "Maximo de 12 digitos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public void limpar()
        {

            txtCampoCalculo.Text = "";
            lblText.Text = "";
            aux = "";
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {

            limpar();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Width = 556;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Width = 290;
        }
        #endregion
        #region KeyDown
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0) // 0
                {
                    btn0.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);

                }
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) // 1
                {
                    btn1.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);

                }
                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) // 2
                {
                    btn2.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) // 3
                {
                    btn3.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) // 4
                {
                    btn4.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) // 5
                {
                    btn5.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6) // 6
                {
                    btn6.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7) // 7
                {
                    btn7.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)  // 8
                {
                    btn8.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9) // 9
                {
                    btn9.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.Decimal) // ,
                {
                    btnPonto.PerformClick();
                    txtCampoCalculo.Select(txtCampoCalculo.Text.Length - 1, txtCampoCalculo.Text.Length);
                }
                if (e.KeyCode == Keys.Add) // +
                {
                    btnAdicao.PerformClick();
                }
                if (e.KeyCode == Keys.Multiply) // x
                {
                    btnMultiplicacao.PerformClick();
                }
                if (e.KeyCode == Keys.Subtract) // -
                {
                    btnSubtracao.PerformClick();
                }
                if (e.KeyCode == Keys.Divide) // /
                {
                    btnDivisao.PerformClick();
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus) // = ou enter
                {


                    igual();
                    txtCampoCalculo.Text = "";


                }
                if (e.KeyCode == Keys.Back)
                {
                    btnLimpar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erro");

            }
        }


        #endregion

        
    }
}
