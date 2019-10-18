namespace MateODragao.Models
{
    public class Dragao
    {
        public string Nome { get; private set; }
        /**
            * TODO: Deixar os atributos privados!
         */
        public int Forca { get; set; }
        public int Destreza { get; set; }
        public int Agilidade { get; set; }
        public int Inteligencia { get; set; }
        public int Vigor { get; set; }
        public int Vida { get; set; }

        public Dragao(string nome, int forca, int destreza, int agilidade, int inteligencia, int vigor)
        {
            this.Nome = nome;
            this.Forca = forca;
            this.Destreza = destreza;
            this.Agilidade = agilidade;
            this.Inteligencia = inteligencia;
            this.Vigor = vigor;
            this.Vida = vigor * 100;
        }

        public int Atacar()
        {
            int dano = this.Forca > this.Inteligencia ? this.Forca + this.Destreza : this.Inteligencia + this.Destreza;
            return dano;
        }

        public bool LevarDano(int dano)
        {
            if (this.Vigor > dano)
            {
                this.Vida -= dano;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}