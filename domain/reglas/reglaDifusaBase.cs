using SE_NEM.domain.hechos;

namespace SE_NEM.domain.reglas;

public abstract class ReglaDifusaBase : IRegla
{
    public string Id { get; }
    public string Descripcion { get; }

    protected ReglaDifusaBase(string id, string descripcion)
    {
        Id = id;
        Descripcion = descripcion;
    }

    public abstract bool EsAplicable(IBaseHechos hechos);
    public abstract IHecho Ejecutar(IBaseHechos hechos);
}