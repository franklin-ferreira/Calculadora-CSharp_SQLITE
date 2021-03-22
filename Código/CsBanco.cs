using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Management;

namespace Calculadora
{
    static class CsBanco
    {
        #region variaveis
        static private SQLiteConnection conexao = new SQLiteConnection(@"Data Source=banco.db;Version=3;New=False;Compress=true;");
        static private SQLiteCommand comando;
        static private SQLiteDataAdapter adapter;
        static private SQLiteCommandBuilder sqBuilder;
        static private DataSet DS = new DataSet();
        static private DataTable DT = new DataTable();
        #endregion
        #region ExecutarComandoSQL
        static public void ExecutarComandoSQL(string StringSQL)
        {
            try
            {
                conexao.Open();//abrir conexao
                comando = conexao.CreateCommand();//abro a conexao pra passar o comando
                comando.CommandText = StringSQL;//passo a string sql
                comando.ExecuteNonQuery();//executa o comando
                conexao.Close();//fecho a conexao
                //ConfigBanco.Mensagem("Processo concluido", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region carregadr dados
        static public void CarregaDados(string stringSql, DataGridView nomeDataGrid)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(stringSql, conexao);
                da.Fill(dt);
                nomeDataGrid.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
        #endregion
    }
}