using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;

namespace SE_NEM.Explanation;

public sealed class ExplicadorDifuso : IExplicador
{
    private readonly List<Explicacion> _explicaciones = new();

    public void RegistrarDisparo(
        IRegla regla,
        IEnumerable<IHecho> usados,
        IHecho generado)
    {
        var explicacion = new Explicacion(
            hechoGeneradoId: generado.Id,
            tipoHecho: generado.Tipo,
            reglaId: regla.Id,
            reglaDescripcion: regla.Descripcion,
            hechosUsados: usados.Select(h => new HechoResumen(h)),
            resultado: generado.Valor
        );

        _explicaciones.Add(explicacion);
    }

    public Explicacion ObtenerExplicacion(string hechoId)
    {
        return _explicaciones
            .Where(e => e.HechoGeneradoId == hechoId)
            .OrderByDescending(e => e.Resultado.Valor)
            .FirstOrDefault();
    }

    public IReadOnlyCollection<Explicacion> Todas()
        => _explicaciones.AsReadOnly();
}
