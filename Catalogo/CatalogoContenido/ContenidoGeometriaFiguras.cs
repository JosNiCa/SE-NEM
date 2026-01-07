namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoGeometriaFiguras()
    {
        return new ContenidoDef(
            Id: "CT-GEO-F",
            Nombre: "Figuras geométricas",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-GeoF-6-1",
                    "Construcción de polígonos regulares",
                    new[]
                    {
                        new IndicadorDef("IND-GEOF-6-1-1", "Construye polígonos regulares"),
                        new IndicadorDef("IND-GEOF-6-1-2", "Mantiene igualdad de lados y ángulos"),
                        new IndicadorDef("IND-GEOF-6-1-3", "Explica procedimiento")
                    }
                )
            }
        );
    }
}