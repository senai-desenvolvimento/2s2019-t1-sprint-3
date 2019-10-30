using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public abstract class Jaula
    {
        // TODO: Implementar com "out bool" e lançar uma exceção InvalidCast, depois criar uma própria
        abstract public bool ColocarNaJaula(Animal animal);
    }
}