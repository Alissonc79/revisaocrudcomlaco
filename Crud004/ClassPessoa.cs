using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //biblioteca banco de dados

namespace Crud004 //CRUD - Create, Reader, Update, Delete - 
{ //COMEÇAR O FORM POR AQUI (1A PARTE)
    class ClassPessoa
    {
        public int Id { get; set; }//escrever prob e dar dois tab
        public string nome { get; set; }//escrever prob e dar dois tab
        public string idade { get; set; }//escrever prob e dar dois tab

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\source\\repos\\Crud004\\Crud004\\DbPessoa.mdf;Integrated Security=True"); 
        //conectar com o banco de dados (duas \\ ou @ no começo - ir no DbPessoa clicar e pegar o caminho - link)

        public List<ClassPessoa> listapessoas() //metodo public tipo lista, levou o nome de li (Read)
        {
            List<ClassPessoa> li = new List<ClassPessoa>(); 
            string sql = "SELECT * FROM Pessoa"; //string pra selecionar tudo da tabela pessoa
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con); //comando sql com a conexao
            SqlDataReader dr = cmd.ExecuteReader(); //foi colocado dentro de um datareader e chamado de dr
            while (dr.Read()) //laço while, equanto dr for lido...
            {
                ClassPessoa p = new ClassPessoa(); //criada variavel p para buscar a classe pessoa
                p.Id = (int)dr["Id"]; //puxa os dados do construtor la em cima
                p.nome = dr["nome"].ToString(); 
                p.idade = dr["idade"].ToString();
                li.Add(p); //para cada pessoa add sera acrescentada na lista.
            }
            dr.Close(); //fecha data reader
            con.Close(); //fecha conexao
            return li; //mostra a lista
        }
        public void Inserir(string nome, string idade) //busca o que vai inserir (Create)
        {
            string sql = "INSERT INTO Pessoa(nome,idade) VALUES ('" + nome + "', '" + idade + "')"; //concatenar as variaveis usando sinal de +
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery(); //exexutar a Query
            con.Close();
        }
        public void Atualizar(int Id, string nome, string idade)  //puxa um por um para nao atualizar somente Id como igual pra todos(Update)
        {
            string sql = "UPDATE pessoa SET nome='"+nome+"',idade='"+idade+"' WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id) //parametro passado para excluir, no caso apenas Id pq ja exlcui tudo (Delete)
        {
            string sql = "DELETE FROM Pessoa WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Localizar (int Id) // localizar o Id ja basta
        {
            string sql = "SELECT * FROM Pessoa WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader(); //aqui vai no banco e acha o id, se retornar um registro este deve ser guardado em um data reader
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                idade = dr["idade"].ToString();
            }
            dr.Close();
            con.Close();
        }
    }
}
