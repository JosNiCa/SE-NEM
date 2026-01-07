using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;

namespace SE_NEM.Explanation;

public interface IExplicador
{
    void RegistrarDisparo(IRegla regla, IEnumerable<IHecho> usados, IHecho generado);

    Explicacion ObtenerExplicacion(string hechoId);

    IReadOnlyCollection<Explicacion> Todas();
}
