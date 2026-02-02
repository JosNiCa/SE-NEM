using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;
using SE_NEM.Explanation;

namespace SE_NEM.Domain.Reglas.GeneradorReglas;

public sealed class ReglaAutoContenidosAGrado : ReglaDifusaBase, IReglaConHechos
{
    private readonly string _gradoId;
    private readonly IReadOnlyList<string> _contenidosIds;

    public ReglaAutoContenidosAGrado(
        string reglaId,
        string gradoId,
        IEnumerable<string> contenidosIds
    )
        : base(reglaId, $"Inferir grado {gradoId}")
    {
        _gradoId = gradoId;
        _contenidosIds = contenidosIds.ToList().AsReadOnly();
    }

    public override bool EsAplicable(IBaseHechos hechos)
        => _contenidosIds.All(hechos.Contiene);

    public override IHecho Ejecutar(IBaseHechos hechos)
    {
        var contenidos = _contenidosIds.Select(hechos.ObtenerPorId).ToList();

        var valorDifuso = contenidos.Min(h => h.Valor.Valor);

        return new HechoGrado(
            id: $"GRADO-{_gradoId}",
            gradoId: _gradoId,
            contenidosOrigen: _contenidosIds,
            valor: ValorDifuso.DesdeValor(valorDifuso)
        );
    }

    public IEnumerable<IHecho> ObtenerHechosUsados(IBaseHechos hechos)
        => _contenidosIds.Select(hechos.ObtenerPorId);
}
