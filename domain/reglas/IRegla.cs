using SE_NEM.domain.hechos;

namespace SE_NEM.domain.reglas;

public interface IRegla
{
    string Id { get; }
    string Descripcion { get; }
    
    bool EsAplicable(IBaseHechos hechos);
    IHecho Ejecutar(IBaseHechos hechos);
}