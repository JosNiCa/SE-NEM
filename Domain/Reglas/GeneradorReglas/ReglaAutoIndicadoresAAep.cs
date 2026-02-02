using SE_NEM.Catalogo;
using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;
using SE_NEM.Explanation;

namespace SE_NEM.Domain.Reglas.GeneradorReglas;

public sealed class ReglaAutoIndicadoresAAep : ReglaDifusaBase, IReglaConHechos
{
    private readonly string _aepId;
    private readonly IReadOnlyList<IndicadorDef> _indicadores;

    public ReglaAutoIndicadoresAAep(
        string reglaId,
        string aepId,
        IEnumerable<IndicadorDef> indicadores
    )
        : base(reglaId, $"Inferir {aepId} desde indicadores")
    {
        _aepId = aepId;
        _indicadores = indicadores.ToList().AsReadOnly();
    }

    public override bool EsAplicable(IBaseHechos hechos)
    {
        // Todos los indicadores del AEP deben existir como hechos
        return _indicadores.All(i => hechos.Contiene(i.Id));
    }

    public override IHecho Ejecutar(IBaseHechos hechos)
    {
        var hechosIndicadores = _indicadores
            .Select(i => new
            {
                Def = i,
                Hecho = (HechoIndicador)hechos.ObtenerPorId(i.Id)
            })
            .ToList();

        var nucleares = hechosIndicadores
            .Where(x => x.Def.EsNuclear)
            .Select(x => x.Hecho)
            .ToList();

        var complementarios = hechosIndicadores
            .Where(x => !x.Def.EsNuclear)
            .Select(x => x.Hecho)
            .ToList();

        double valorNuclear;
        double valorComplementario;

        // --- Regla base ---
        if (nucleares.Any())
        {
            valorNuclear = nucleares.Min(h => h.Valor.Valor);
        }
        else
        {
            // Caso raro: AEP sin nucleares
            valorNuclear = hechosIndicadores.Min(h => h.Hecho.Valor.Valor);
        }

        if (complementarios.Any())
        {
            valorComplementario = complementarios.Max(h => h.Valor.Valor);
        }
        else
        {
            valorComplementario = valorNuclear;
        }

        var valorFinal = Math.Min(valorNuclear, valorComplementario);

        return new HechoAEP(
            id: $"AEP-{_aepId}",
            aepId: _aepId,
            indicadoresOrigen: _indicadores.Select(i => i.Id),
            valor: ValorDifuso.DesdeValor(valorFinal)
        );
    }

    public IEnumerable<IHecho> ObtenerHechosUsados(IBaseHechos hechos)
        => _indicadores.Select(i =>hechos.ObtenerPorId(i.Id));
}
