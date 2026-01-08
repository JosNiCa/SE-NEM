namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoProporcionalidad() 
    { 
        return new ContenidoDef(
            Id: "CT-PROP", 
            Nombre: "Relaciones de proporcionalidad", 
            Aeps: new[] 
            {
                new AepDef(
                    "AEP-Prop-6-1",
                    "Comparación de razones con números naturales",
                    new[]
                    {
                        new IndicadorDef("IND-PROP-6-1-1", "Identifica razón como comparación multiplicativa", true),
                        new IndicadorDef("IND-PROP-6-1-2", "Compara razones en forma a:b", true),
                        new IndicadorDef("IND-PROP-6-1-3", "Aplica conceptos en problemas", true)
                    }
                ),
                new AepDef(
                    "AEP-Prop-6-2",
                    "Determinación de valores faltantes",
                    new[]
                    {
                        new IndicadorDef("IND-PROP-6-2-1", "Identifica proporción en tablas o pares de valores", true),
                        new IndicadorDef("IND-PROP-6-2-2", "Calcula valor unitario cuando es posible", true),
                        new IndicadorDef("IND-PROP-6-2-3", "Resuelve proporciones sin valor unitario explícito", true),
                        new IndicadorDef("IND-PROP-6-2-4", "Acierta en problemas", true)
                    }
                ),
                new AepDef(
                    "AEP-Prop-6-3",
                    "Comparación de razones naturales y fracciones",
                    new[]
                    {
                        new IndicadorDef("IND-PROP-6-3-1", "Convierte fracción a forma razón", true),
                        new IndicadorDef("IND-PROP-6-3-2", "Compara a:b con c:d", true),
                        new IndicadorDef("IND-PROP-6-3-3", "Explica la estrategia comparativa", false),
                        new IndicadorDef("IND-PROP-6-3-4", "Usa equivalencias o productos cruzados", true)
                    }
                ),
                new AepDef(
                    "AEP-Prop-6-4",
                    "Cálculo mental de porcentajes",
                    new[]
                    {
                        new IndicadorDef("IND-PROP-6-4-1", "Usa mitades para 50%", true),
                        new IndicadorDef("IND-PROP-6-4-2", "Usa cuarta parte para 25%", true),
                        new IndicadorDef("IND-PROP-6-4-3", "Usa décima parte para 10%", true),
                        new IndicadorDef("IND-PROP-6-4-4", "Usa centésima parte para 1%", true),
                        new IndicadorDef("IND-PROP-6-4-5", "Aplica combinaciones de porcentajes", true)
                    }
                ),
                new AepDef(
                    "AEP-Prop-6-5",
                    "Tanto por ciento de una cantidad",
                    new[]
                    {
                        new IndicadorDef("IND-PROP-6-5-1", "Identifica base, porcentaje y resultado", true),
                        new IndicadorDef("IND-PROP-6-5-2", "Resuelve p% de N", true),
                        new IndicadorDef("IND-PROP-6-5-3", "Calcula qué porcentaje representa A de B", true),
                        new IndicadorDef("IND-PROP-6-5-4", "Interpreta el resultado en contexto", true)
                    }
                ) 
            }
            ); 
    }
}