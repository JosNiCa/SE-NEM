// Domain/Reglas/GeneradorReglas/ReglaAutoIndicadoresAAep.cs
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
        _aepId = NormalizarAepId(aepId);
        _indicadores = indicadores.ToList().AsReadOnly();
    }

    public override bool EsAplicable(IBaseHechos hechos)
        => _indicadores.All(i => hechos.Contiene(i.Id));

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

        double valorNuclear = nucleares.Any()
            ? nucleares.Min(h => h.Valor.Valor)
            : hechosIndicadores.Min(h => h.Hecho.Valor.Valor);

        double valorComplementario = complementarios.Any()
            ? complementarios.Max(h => h.Valor.Valor)
            : valorNuclear;

        var valorFinal = Math.Min(valorNuclear, valorComplementario);

        return new HechoAEP(
            id: _aepId,                 // <<-- antes: $"AEP-{_aepId}"
            aepId: _aepId,              // <<-- consistente
            indicadoresOrigen: _indicadores.Select(i => i.Id).ToList(),
            valor: ValorDifuso.DesdeValor(valorFinal)
        );
    }

    public IEnumerable<IHecho> ObtenerHechosUsados(IBaseHechos hechos)
        => _indicadores.Select(i => hechos.ObtenerPorId(i.Id));

    private static string NormalizarAepId(string aepId)
    {
        if (string.IsNullOrWhiteSpace(aepId))
            return aepId;

        const string prefijo = "AEP-";

        // colapsa repeticiones: AEP-AEP-SR-6-1 -> AEP-SR-6-1
        while (aepId.StartsWith(prefijo + prefijo, StringComparison.OrdinalIgnoreCase))
            aepId = prefijo + aepId[(prefijo + prefijo).Length..];

        // asegura 1 prefijo
        if (!aepId.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
            aepId = prefijo + aepId;

        return aepId;
    }
}
