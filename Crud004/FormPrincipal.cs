using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud004 //2a parte
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ClassPessoa pessoa = new ClassPessoa(); //instaciada com todos os metodos da classe
            List<ClassPessoa> pessoas = pessoa.listapessoas(); // metodo tipo lista com nome de pessoas, que esta com a lista
            dgvPessoa.DataSource = pessoas; //mostra no datagread a variavel pessoas criada na lista acima
        }
        //chegando aqui ir ate o form principal design e dar dois clicks no botao Inserir
        private void btnInserir_Click(object sender, EventArgs e)
        {
            ClassPessoa pessoa = new ClassPessoa();
            pessoa.Inserir(txtNome.Text, txtIdade.Text); //chamando o metodo inserir e passando os parametros que eu quero
            MessageBox.Show("Biluxa inserida com sucesso!"); //mensagem q deu certo
            List<ClassPessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtIdade.Text = ""; //*********testar se esta inserindo(F5)*******
        }

        private void btnEditar_Click(object sender, EventArgs e) //dois clicks em editar
        {
            int Id = Convert.ToInt32(txtId.Text.Trim()); //convertendo a variavel pois o Id q ta buscando esta em int, convertendo entao para texto
            ClassPessoa pessoa = new ClassPessoa();
            pessoa.Atualizar(Id, txtNome.Text, txtIdade.Text);
            MessageBox.Show("Viada! Voce arraza na edição"); //copiar essa parte do Inserir e trocar cadastrada para atualizada
            List<ClassPessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtId.Text = ""; //acrescentar o Id aqui
            txtNome.Text = "";
            txtIdade.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim()); //copiar do Editar e fazer alteraçoes necessarias
            ClassPessoa pessoa = new ClassPessoa();
            pessoa.Excluir(Id);
            MessageBox.Show("Biluxa excluída com sucesso!"); 
            List<ClassPessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtId.Text = ""; 
            txtNome.Text = "";
            txtIdade.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            ClassPessoa pessoa = new ClassPessoa();
            pessoa.Localizar(Id);
            txtNome.Text = pessoa.nome;
            txtIdade.Text = pessoa.idade;
        }
        //ir no dgv do design, clicar uma vez, ir ao lado, no raio, e dar 2 clicks em CellClick 
        private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e) //ja criou a varial "e"
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex]; // qdo clicar em qualquer lugar do dgv, selecione a linha toda
                txtId.Text = row.Cells[0].Value.ToString(); //denominando posicoes, no caso aqui é a de numero 0
                txtNome.Text = row.Cells[1].Value.ToString();
                txtIdade.Text = row.Cells[2].Value.ToString();
            } //testar *****F5*****
        }
    }
}
