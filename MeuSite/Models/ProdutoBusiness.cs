using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuSite.Models
{
    /// <summary>
    /// Lista todos os produtos.
    /// </summary>
     public class ProdutoBusiness
    {
        public List<Produto> Listar()
        {
            using (BancoDataContext banco = new BancoDataContext())
            {
                return banco.Produtos.OrderBy(o => o.Nome).ToList();
            }

        }

       /// <summary>
       /// Retorna apenas um registro, mediante ao ID informado.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Produto Buscar(int id)
        {
            using (BancoDataContext banco = new BancoDataContext())
            {
                return banco.Produtos.SingleOrDefault(w => w.ID == id);
            }

        }

        /// <summary>
        /// Método para deletar alum registro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Deletar(int id)
        {
            using (BancoDataContext banco = new BancoDataContext())
            {
                var produto = banco.Produtos.SingleOrDefault(w => w.ID == id);
                banco.Produtos.DeleteOnSubmit(produto);
                banco.SubmitChanges();
            }

        }

        /// <summary>
        /// Método para atualizar algum reistro.
        /// </summary>
        /// <param name="id"></param>
        public void Alterar(Produto produto)
        {
            using (BancoDataContext banco = new BancoDataContext())
            {
                var produtoVelho = banco.Produtos.SingleOrDefault(w => w.ID == produto.ID);
                produtoVelho.Nome = produto.Nome.Trim();
                produtoVelho.Descricao = produto.Descricao.Trim();
                produtoVelho.Quantidade = produto.Quantidade;
                produtoVelho.ValorUnitario = produto.ValorUnitario;
                banco.SubmitChanges();
            }
        }

        /// <summary>
        /// Inserção
        /// </summary>
        /// <param name="produto"></param>
        public int Inserir(Produto produto)
        {
            using (BancoDataContext banco = new BancoDataContext())
            {
                banco.Produtos.InsertOnSubmit(produto);
                banco.SubmitChanges();
                return produto.ID;
            }

        }
    }
}