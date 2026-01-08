namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoMultDiv()
    {
        return new ContenidoDef(
            Id: "CT-MD",
            Nombre: "Multiplicación y división",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-MD-6-1",
                    "División de decimales entre naturales",
                    new[]
                    {
                        new IndicadorDef("IND-MD-6-1-1", "Posiciona correctamente el punto decimal", true),
                        new IndicadorDef("IND-MD-6-1-2", "Resuelve divisiones decimales", true),
                        new IndicadorDef("IND-MD-6-1-3", "Interpreta el resultado en contexto", true),
                        new IndicadorDef("IND-MD-6-1-4", "Puede verificar por multiplicación inversa", false)
                    }
                ),
                new AepDef(
                    "AEP-MD-6-2",
                    "División de fracciones entre naturales",
                    new[]
                    {
                        new IndicadorDef("IND-MD-6-2-1", "Representa la división fraccionaria como fracción ÷ natural", true),
                        new IndicadorDef("IND-MD-6-2-2", "Aplica transformación equivalente", true),
                        new IndicadorDef("IND-MD-6-2-3", "Resuelve ejercicios", true),
                        new IndicadorDef("IND-MD-6-2-4", "Aplica en problemas reales", true)
                    }
                )
            }
        );
    }
}