namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoProbabilidad()
    {
        return new ContenidoDef(
            Id: "CT-PROB",
            Nombre: "Probabilidad",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-Prob-6-1",
                    "Clasificación de eventos",
                    new[]
                    {
                        new IndicadorDef("IND-PROB-6-1-1", "Clasifica eventos como seguro, probable o imposible", true),
                        new IndicadorDef("IND-PROB-6-1-2", "Justifica clasificación", false),
                        new IndicadorDef("IND-PROB-6-1-3", "Aplica a situaciones reales", true)
                    }
                ),
                new AepDef(
                    "AEP-Prob-6-2",
                    "Resultados posibles, tablas y árboles",
                    new[]
                    {
                        new IndicadorDef("IND-PROB-6-2-1", "Determina resultados posibles", true),
                        new IndicadorDef("IND-PROB-6-2-2", "Construye tabla de doble entrada", true),
                        new IndicadorDef("IND-PROB-6-2-3", "Construye diagrama de árbol", true),
                        new IndicadorDef("IND-PROB-6-2-4", "Interpreta la representación", true)
                    }
                )
            }
        );
    }

}