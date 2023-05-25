using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using produtos_mvc.Model;
using produtos_mvc.View;

namespace produtos_mvc.Controller
{
    public class ProdutoController
    {
        // INSTANCIAR OBJETO PRODUTO E PRODUTOVIEW
        Produto produto = new Produto();

        ProdutoView produtoView = new ProdutoView();

        // METODO CONTROLADOR PARA ACESSAR A LISTAGEM DE PRODUTOS
        public void ListarProdutos()
        {
            // LISTA DE PRODUTOS CHAMADA PELA MODEL
            List<Produto> produtos = produto.Ler();

            // CHAMADA DO METODO DE EXIBIÇÃO(VIEW) RECEBENDO COMO ARGUMENTO A LISTA
            produtoView.Listar(produtos);

        }

        public void CadastrarProduto()
            {        
                
                Produto novoProduto = produtoView.Cadastrar();

                produto.Inserir(novoProduto);

            }



    }
}