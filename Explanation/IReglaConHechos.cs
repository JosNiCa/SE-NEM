using SE_NEM.domain.hechos;

namespace SE_NEM.Explanation;

public interface IReglaConHechos
{
    IEnumerable<IHecho> ObtenerHechosUsados(IBaseHechos hechos);
}
