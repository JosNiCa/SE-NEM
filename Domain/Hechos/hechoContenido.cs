using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoContenido : HechoBase
{
    public string ContenidoId { get; }
    public IReadOnlyList<string> AepsOrigen { get; }
    
    public HechoContenido(
        string id,
        string contenidoId,
        IEnumerable<string> aepsOrigen,
        ValorDifuso valor
    )
        : base(id, "CONT", valor)
    {
        ContenidoId = contenidoId;
        AepsOrigen = aepsOrigen.ToList().AsReadOnly();
    }
}