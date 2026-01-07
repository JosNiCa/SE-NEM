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
                        new IndicadorDef("IND-MD-6-1-1", "Posiciona correctamente el punto decimal"),
                        new IndicadorDef("IND-MD-6-1-2", "Resuelve divisiones decimales"),
                        new IndicadorDef("IND-MD-6-1-3", "Interpreta el resultado en contexto"),
                        new IndicadorDef("IND-MD-6-1-4", "Puede verificar por multiplicación inversa")
                    }
                ),
                new AepDef(
                    "AEP-MD-6-2",
                    "División de fracciones entre naturales",
                    new[]
                    {
                        new IndicadorDef("IND-MD-6-2-1", "Representa la división fraccionaria como fracción ÷ natural"),
                        new IndicadorDef("IND-MD-6-2-2", "Aplica transformación equivalente"),
                        new IndicadorDef("IND-MD-6-2-3", "Resuelve ejercicios"),
                        new IndicadorDef("IND-MD-6-2-4", "Aplica en problemas reales")
                    }
                )
            }
        );
    }
}