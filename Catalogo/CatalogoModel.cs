namespace SE_NEM.Catalogo;

public sealed record IndicadorDef(
    string Id,
    string Descripcion
);

public sealed record AepDef(
    string Id,
    string Descripcion,
    IReadOnlyList<IndicadorDef> Indicadores
);

public sealed record ContenidoDef(
    string Id,
    string Nombre,
    IReadOnlyList<AepDef> Aeps
);