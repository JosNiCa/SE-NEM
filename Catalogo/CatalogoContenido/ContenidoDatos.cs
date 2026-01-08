namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoDatos()
    {
        return new ContenidoDef(
            Id: "CT-DATOS",
            Nombre: "Organización e interpretación de datos",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-Datos-6-1",
                    "Tablas, gráficas de barras y circulares",
                    new[]
                    {
                        new IndicadorDef("IND-DAT-6-1-1", "Lee tablas", true),
                        new IndicadorDef("IND-DAT-6-1-2", "Interpreta barras", true),
                        new IndicadorDef("IND-DAT-6-1-3", "Interpreta gráficas circulares", true),
                        new IndicadorDef("IND-DAT-6-1-4", "Construye gráficas de barras", true),
                        new IndicadorDef("IND-DAT-6-1-5", "Responde preguntas sobre datos", true)
                    }
                ),
                new AepDef(
                    "AEP-Datos-6-2",
                    "Moda, media y rango",
                    new[]
                    {
                        new IndicadorDef("IND-DAT-6-2-1", "Obtiene moda", true),
                        new IndicadorDef("IND-DAT-6-2-2", "Calcula media aritmética", true),
                        new IndicadorDef("IND-DAT-6-2-3", "Calcula rango", true),
                        new IndicadorDef("IND-DAT-6-2-4", "Aplica medidas en problemas", true)
                    }
                )
            }
        );
    }
}