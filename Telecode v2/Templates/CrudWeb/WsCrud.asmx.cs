using System;
using System.Web.Script.Services;
using System.Web.Services;
using Telecon.Genericos.Classes.BancoDeDados;
using [Namespace];
using [NamespaceSemBiblioteca].Classes;
using [NamespaceSemBiblioteca].biblioteca;

namespace [NamespaceSemBiblioteca].WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class Ws[NomeClasse] : WebService
    {

        [WebMethod(EnableSession = true)]
        public RetornoWebService ConsultarChave(string codigo)
        {
            var resultado = new RetornoWebService();

            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();

                var usuario = (Usuario)Session[SessaoUtil.USUARIO];
                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                var item = [NomeClasse].ConsultarChave(banco, [ConvertPK](codigo));

                resultado.Dado = item;
                resultado.Sucesso = true;
                return resultado;
            }
            catch (Exception erro)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = erro.Message;
                return resultado;
            }
            finally
            {
                if (banco != null) banco.FecharConexao();
            }
        }


        [WebMethod(EnableSession = true)]
        public RetornoWebService Gravar([ParametrosGravarWebService])
        {
            var resultado = new RetornoWebService();

            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();

                var usuario = (Usuario)Session[SessaoUtil.USUARIO];
                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                [NomeClasse] item;
                if ([VariavelCodigo].Equals("0"))
                {
                    item = new [NomeClasse]();
                    item.[CampoPK] = [NomeClasse].ObterProximoCodigo(banco);
                }
                else
                    item = [NomeClasse].ConsultarChave(banco, [ConvertPK]([VariavelCodigo]));

                [AtribuicoesGravarWebService]

                [NomeClasse].Gravar(banco, item);

                resultado.Sucesso = true;
                return resultado;
            }
            catch (Exception erro)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = erro is FormatException ? "Conteúdo inválido." : erro.Message;
                return resultado;
            }
            finally
            {
                if (banco != null) banco.FecharConexao();
            }
        }


        [WebMethod(EnableSession = true)]
        public RetornoWebService Excluir(string codigo)
        {
            var resultado = new RetornoWebService();

            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();

                var usuario = (Usuario)Session[SessaoUtil.USUARIO];
                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                var item = [NomeClasse].ConsultarChave(banco, [ConvertPK](codigo));

                [NomeClasse].Excluir(banco, item);

                resultado.Sucesso = true;
                return resultado;
            }
            catch (Exception erro)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = erro.Message;
                return resultado;
            }
            finally
            {
                if (banco != null) banco.FecharConexao();
            }
        }
        
        [WebMethod(EnableSession = true)]
        public RetornoWebService Consultar(string pesquisa)
        {
            var resultado = new RetornoWebService();
            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();

                var usuario = (Usuario)Session[SessaoUtil.USUARIO];
                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                resultado.Dado = [NomeClasse].Consultar(banco, usuario, pesquisa);
                resultado.Sucesso = true;

                return resultado;
            }
            catch (Exception erro)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = erro.Message;
                return resultado;
            }
            finally
            {
                if (banco != null) banco.FecharConexao();
            }
        }
        
    }
}
