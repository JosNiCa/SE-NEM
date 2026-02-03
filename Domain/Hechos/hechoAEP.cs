// Domain/Hechos/HechoAEP.cs
using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoAEP : IHecho
{
    public string Id { get; }
    public string Tipo => "AEP";

    public string AepId { get; }
    public string? ContenidoId { get; } // si lo usas en tu ctor actual
    public IReadOnlyList<string>? IndicadoresOrigen { get; } // si lo usas en tu ctor actual

    public ValorDifuso Valor { get; }

    public HechoAEP(
        string id,
        string aepId,
        IReadOnlyList<string> indicadoresOrigen,
        ValorDifuso valor)
    {
        var norm = NormalizarAepId(id);
        Id = norm;
        AepId = NormalizarAepId(aepId);
        IndicadoresOrigen = indicadoresOrigen;
        Valor = valor;
    }

    public HechoAEP(
        string id,
        string aepId,
        string contenidoId,
        ValorDifuso valor)
    {
        var norm = NormalizarAepId(id);
        Id = norm;
        AepId = NormalizarAepId(aepId);
        ContenidoId = contenidoId;
        Valor = valor;
    }

    private static string NormalizarAepId(string aepId)
    {
        if (string.IsNullOrWhiteSpace(aepId))
            return aepId;

        const string prefijo = "AEP-";
        while (aepId.StartsWith(prefijo + prefijo, StringComparison.OrdinalIgnoreCase))
            aepId = prefijo + aepId.Substring((prefijo + prefijo).Length);

        return aepId;
    }
}