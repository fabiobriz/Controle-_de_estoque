using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    class Produto
    {
        private int _id;
        private string _nome;
        private int _quantidade;

        public Produto(int id, string nome, int quantidade)
        {
            _id = id;
            _nome = nome;
            _quantidade = quantidade;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }
        public string GetNome()
        {
            return _nome;
        }
        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public int GetQuantidade()
        {
            return _quantidade;
        }
        public void AdicionarProduto(int quantidade)
        {
            _quantidade += quantidade;
        }
        public void RemoverProduto(int quantidade)
        {
            _quantidade -= quantidade; 
        }
    }
}
