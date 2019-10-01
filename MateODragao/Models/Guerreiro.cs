using System;

namespace MateODragao.Models {
    public class Guerreiro {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CidadeNatal { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string FerramentaProtecao { get; set; }
        public string FerramentaAtaque { get; set; }
        /**
         * TODO: Deixar os atributos privados! 
         */
        public int Forca { get; set; }
        public int Destreza { get; set; }
        public int Agilidade { get; set; }
        public int Inteligencia { get; set; }
        public int Vigor { get; set; }
        public int Vida { get; set; }

        /* Construtor mais simples */
        public Guerreiro (string nome, string sobrenome, string cidadeNatal, DateTime dataNascimento,int forca, int destreza, int agilidade, int inteligencia, int vigor) {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CidadeNatal = cidadeNatal;
            this.DataNascimento = dataNascimento;
            this.Forca = forca;
            this.Destreza = destreza;
            this.Agilidade = agilidade;
            this.Inteligencia = inteligencia;
            this.Vigor = vigor;
            this.Vida = this.Vigor * 10;
        }
        /* Construtor completo */
        public Guerreiro (string nome, string sobrenome, string cidadeNatal, DateTime dataNascimento, string ferramentaAtaque, string ferramentaProtecao, int forca, int destreza, int agilidade, int inteligencia, int vigor) {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CidadeNatal = cidadeNatal;
            this.DataNascimento = dataNascimento;
            this.FerramentaAtaque = ferramentaAtaque;
            this.FerramentaProtecao = ferramentaProtecao;
            this.Forca = forca;
            this.Destreza = destreza;
            this.Agilidade = agilidade;
            this.Inteligencia = inteligencia;
            this.Vigor = vigor;
            this.Vida = this.Vigor * 10;
        }

    }
}