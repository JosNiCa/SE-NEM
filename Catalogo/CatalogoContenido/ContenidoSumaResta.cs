namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoSumaResta()
    {
        return new ContenidoDef(
            Id: "CT-SR",
            Nombre: "Suma y resta",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-SR-6-1",
                    "Suma y resta de decimales y fracciones",
                    new[]
                    {
                        new IndicadorDef("IND-SR-6-1-1", "Realiza suma de decimales con precisión", true),
                        new IndicadorDef("IND-SR-6-1-2", "Realiza resta de decimales con precisión", true),
                        new IndicadorDef("IND-SR-6-1-3", "Realiza suma de fracciones con diferentes denominadores", true),
                        new IndicadorDef("IND-SR-6-1-4", "Realiza resta de fracciones con diferentes denominadores", true),
                        new IndicadorDef("IND-SR-6-1-5", "Aplica en situaciones contextualizadas", true),
                        new IndicadorDef("IND-SR-6-1-6", "Explica la estrategia utilizada", false),
                        new IndicadorDef("IND-SR-6-1-7", "Comprueba la respuesta usando operación inversa", false)
                    }
                ),
                new AepDef(
                    "AEP-SR-6-2",
                    "Cálculo mental con decimales",
                    new[]
                    {
                        new IndicadorDef("IND-SR-6-2-1", "Estima resultados con base 10", true),
                        new IndicadorDef("IND-SR-6-2-2", "Estima resultados con base 100", true),
                        new IndicadorDef("IND-SR-6-2-3", "Usa aproximaciones", true),
                        new IndicadorDef("IND-SR-6-2-4", "Usa redondeo", true),
                        new IndicadorDef("IND-SR-6-2-5", "Explica la estrategia mental", false),
                        new IndicadorDef("IND-SR-6-2-6", "Acierta sin algoritmo escrito", false)
                    }
                )
            }
        );
    }  
}