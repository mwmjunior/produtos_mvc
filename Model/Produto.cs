using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produtos_mvc.Model
{
    public class Produto
    {
        // PROPRIEDADES
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
       
        // CAMINHO DA PASTA E DO ARQUIVO DEFINIDO
        private const string PATH = "Database/Produto.csv"; // PATH = CAMINHO

        // CRIAR UM CONSTRUTOR
        public Produto()
        {
            // OBTER CAMINHO DA PASTA
            string pasta = PATH.Split("/")[0];   // [0] = Database

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public List<Produto> Ler ()
        {
            // INSTANCIAR UMA LISTA DE PRODUTO
            List<Produto> produto = new List<Produto>();

            // ARRAY DE STRING QUE RECEBE CADA LINHA DO CSV
            string[] linhas = File.ReadAllLines(PATH);

            // PARA A LEITURA DE LINHAS
            foreach (string item in linhas)
            {
                // ANTES DO SPLIT 
                // 001; Coquinha; 8

                string [] atributos = item.Split(";");

                // APOS O SPLIT
                // ATRIBUTO [0] - "001"
                // ATRIBUTO [1] - "Coquinha"
                // ATRIBUTO [2] - "8"

                // INSTANCIA O OBJETO PRODUTO
                Produto p = new Produto();

                p.Codigo = int.Parse(atributos[0]);  // ATRIBUTO [0] - "001"
                p.Nome = atributos[1];               // ATRIBUTO [1] - "Coquinha"
                p.Preco = float.Parse(atributos[2]); // ATRIBUTO [2] - "8"

                // ADICIONAR OS PRODUTOS DENTRO DA LISTA
                produto.Add(p);
            }
            return produto;
        }
        


        public string PrerpararLinhasCSV (Produto p)
        {
            return  $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        public void Inserir (Produto p)
        {

            string [] linhas = {PrerpararLinhasCSV (p) };

            File.AppendAllLines(PATH, linhas);

        }




    }
}