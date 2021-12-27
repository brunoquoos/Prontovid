using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class Pessoa
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Usuario { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_ATIVO = "Ativo";
        public const string COLUNA_CPF = "Cpf";
        public const string COLUNA_DATA_CADASTRO = "DataCadastro";
        public const string COLUNA_DATA_NASCIMENTO = "DataNascimento";
        public const string COLUNA_EMAIL = "Email";
        public const string COLUNA_ENDERECO = "Endereco";
        public const string COLUNA_NOME = "Nome";
        public const string COLUNA_SEXO = "Sexo";
        public const string COLUNA_TELEFONE = "Telefone";
        public const string COLUNA_SENHA = "Senha";
        public const string COLUNA_USUARIO = "Usuario";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<Pessoa> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<Pessoa> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<Pessoa>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "Ativo," + Texto.QuebraLinha;
                sql += "Cpf," + Texto.QuebraLinha;
                sql += "DataCadastro," + Texto.QuebraLinha;
                sql += "DataNascimento," + Texto.QuebraLinha;
                sql += "Email," + Texto.QuebraLinha;
                sql += "Endereco," + Texto.QuebraLinha;
                sql += "Nome," + Texto.QuebraLinha;
                sql += "Sexo," + Texto.QuebraLinha;
                sql += "Telefone," + Texto.QuebraLinha;
                sql += "Senha," + Texto.QuebraLinha;
                sql += "Usuario" + Texto.QuebraLinha;
                sql += " From Pessoa" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var pessoa = ConverterDataReader(banco, dr);
                    lista.Add(pessoa);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static Pessoa ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var pessoa = new Pessoa();

                    pessoa.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    pessoa.Ativo = banco.RecuperarBooelan(dr["Ativo"].ToString());
                    pessoa.Cpf = dr["Cpf"].ToString();
                    pessoa.DataCadastro = Convert.ToDateTime(dr["DataCadastro"].ToString());
                    pessoa.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
                    pessoa.Email = dr["Email"].ToString();
                    pessoa.Endereco = dr["Endereco"].ToString();
                    pessoa.Nome = dr["Nome"].ToString();
                    pessoa.Sexo = dr["Sexo"].ToString();
                    pessoa.Telefone = dr["Telefone"].ToString();
                    pessoa.Senha = banco.ConverterTextoNull(dr["Senha"].ToString());
                    pessoa.Usuario = banco.ConverterTextoNull(dr["Usuario"].ToString());

			
			return pessoa;
		}
		
		public static Pessoa ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, Pessoa pessoa)
        {            
		return InserirSQL(banco, pessoa,false);

        }
		
		private static bool InserirSQL(IBanco banco, Pessoa pessoa,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, pessoa))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(pessoa.Codigo) + ",";

                }
                campos += "Ativo, ";
                valores += banco.ObterVerdadeiroFalso(pessoa.Ativo) + ",";

                campos += "Cpf, ";
                valores += banco.ObterTexto(pessoa.Cpf, 14) + ",";

                campos += "DataCadastro, ";
                valores += banco.ObterDataHora(pessoa.DataCadastro) + ",";

                campos += "DataNascimento, ";
                valores += banco.ObterDataHora(pessoa.DataNascimento) + ",";

                campos += "Email, ";
                valores += banco.ObterTexto(pessoa.Email, 64) + ",";

                campos += "Endereco, ";
                valores += banco.ObterTexto(pessoa.Endereco, 256) + ",";

                campos += "Nome, ";
                valores += banco.ObterTexto(pessoa.Nome, 128) + ",";

                campos += "Sexo, ";
                valores += banco.ObterTexto(pessoa.Sexo, 1) + ",";

                campos += "Telefone, ";
                valores += banco.ObterTexto(pessoa.Telefone, 32) + ",";

                campos += "Senha, ";
                valores += banco.ObterTexto(pessoa.Senha, 256) + ",";

                campos += "Usuario ";
                valores += banco.ObterTexto(pessoa.Usuario, 32);

                var sql = "Insert into Pessoa(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  Pessoa";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    pessoa.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, Pessoa pessoa)
        {            
			if (!TestarCampos(banco, pessoa))
				return false;
					
			var sql = "Update Pessoa Set ";
			sql += "Ativo = " + banco.ObterVerdadeiroFalso(pessoa.Ativo);
			sql += ", Cpf = " + banco.ObterTexto(pessoa.Cpf, 14);
			sql += ", DataCadastro = " + banco.ObterDataHora(pessoa.DataCadastro);
			sql += ", DataNascimento = " + banco.ObterDataHora(pessoa.DataNascimento);
			sql += ", Email = " + banco.ObterTexto(pessoa.Email, 64);
			sql += ", Endereco = " + banco.ObterTexto(pessoa.Endereco, 256);
			sql += ", Nome = " + banco.ObterTexto(pessoa.Nome, 128);
			sql += ", Sexo = " + banco.ObterTexto(pessoa.Sexo, 1);
			sql += ", Telefone = " + banco.ObterTexto(pessoa.Telefone, 32);
			sql += ", Senha = " + banco.ObterTexto(pessoa.Senha, 256);
			sql += ", Usuario = " + banco.ObterTexto(pessoa.Usuario, 32);
			sql += " Where Codigo = " + banco.ObterDuplo(pessoa.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, Pessoa pessoa)
		{
			var sql = "Delete From Pessoa ";
			sql += " Where Codigo = " + banco.ObterDuplo(pessoa.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, Pessoa pessoa)
        {
            return AlterarSQL(banco, pessoa) || InserirSQL(banco, pessoa);
        }
		 
		#endregion
		 
    }
}
