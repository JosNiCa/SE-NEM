using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public abstract class HechoBase : IHecho
{
    public string Id { get; protected set; }
    public string Tipo { get; protected set; }
    public ValorDifuso Valor { get; protected set; }

    protected HechoBase(string id, string tipo, ValorDifuso valor)
    {
        Id = id;
        Tipo = tipo;
        Valor = valor;
    }
}