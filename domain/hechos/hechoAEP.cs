using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoAEP :HechoBase
{
    public string AepId { get; }
    public IReadOnlyList<string> IndicadoresOrigen { get; }

    public HechoAEP(
        string id,
        string aepId,
        IEnumerable<string> indicadoresOrigen,
        ValorDifuso valor
    )
        : base(id, "AEP", valor)
    {
        AepId = aepId;
        IndicadoresOrigen = indicadoresOrigen.ToList().AsReadOnly();
    }
}