using SE_NEM.domain.hechos;
using SE_NEM.domain.difuso;
using SE_NEM.domain.reglas;
using SE_NEM.Domain.Reglas.GeneradorReglas;
using SE_NEM.Inference;
using SE_NEM.Explanation;
using SE_NEM.Fuzzification;
using SE_NEM.Catalogo;

// =======================================================
// FUNCION AUXILIAR: crear HechoIndicador simulado
// =======================================================
static HechoIndicador CrearIndicadorSimulado(
    DifusificadorUnesco dif,
    string indId,
    string aepId,
    int correctos,
    int total,
    int intentos,
    double tiempoPromedio
)
{
    var vAciertos = dif.DifusificarAciertos(correctos / (double)total);
    var vTiempo   = dif.DifusificarTiempo(tiempoPromedio);
    var vIntentos = dif.DifusificarIntentos(intentos);

    double valorFinal =
          0.6  * vAciertos.Valor
        + 0.25 * vTiempo.Valor
        + 0.15 * vIntentos.Valor;

    return new HechoIndicador(
        id: indId,
        indicatorId: indId,
        aepId: aepId,
        totalReactivos: total,
        reactivosCorrectos: correctos,
        intentosUsados: intentos,
        tiempoTotalSegundos: tiempoPromedio * total,
        aciertos: vAciertos,
        tiempo: vTiempo,
        intentos: vIntentos,
        valorFinal: ValorDifuso.DesdeValor(valorFinal)
    );
}

// =======================================================
// 1. INFRAESTRUCTURA
// =======================================================
var baseHechos     = new BaseHechosDifusa();
var difusificador  = new DifusificadorUnesco();
var explicador     = new ExplicadorDifuso();
var motor          = new MotorInferenciaForward(explicador);

// =======================================================
// 2. REGLAS (desde el catálogo)
// =======================================================
IRuleFactory ruleFactory = new RuleFactorySextoGrado();
var reglas = ruleFactory.CrearReglas().ToList();

Console.WriteLine($"Reglas cargadas: {reglas.Count}");

// =======================================================
// 3. CARGA DE DATOS SIMULADOS (TODOS LOS IND)
// =======================================================
var contenidos = new[]
{
    ContenidosCatalogo.ContenidoSumaResta(),
    ContenidosCatalogo.ContenidoDatos(),
    ContenidosCatalogo.ContenidoGeometriaCuerpos(),
    ContenidosCatalogo.ContenidoGeometriaFiguras(),
    ContenidosCatalogo.ContenidoMedicion(),
    ContenidosCatalogo.ContenidoMultDiv(),
    ContenidosCatalogo.ContenidoNumeros(),
    ContenidosCatalogo.ContenidoPerimetroAreaVolumen(),
    ContenidosCatalogo.ContenidoProbabilidad(),
    ContenidosCatalogo.ContenidoProporcionalidad(),
    ContenidosCatalogo.ContenidoUbicacion()
};


foreach (var contenido in contenidos)
{
    foreach (var aep in contenido.Aeps)
    {
        foreach (var ind in aep.Indicadores)
        {
            // Simulación controlada:
            // nucleares → M
            // complementarios → P/M
            int total      = 10;
            int correctos  = ind.EsNuclear ? 7 : 6;
            int intentos   = ind.EsNuclear ? 1 : 2;
            double tiempo  = ind.EsNuclear ? 48 : 60;

            var hechoInd = CrearIndicadorSimulado(
                difusificador,
                ind.Id,
                aep.Id,
                correctos,
                total,
                intentos,
                tiempo
            );

            baseHechos.AgregarOActualizar(hechoInd);
        }
    }
}

Console.WriteLine($"Hechos IND cargados: {baseHechos.ObtenerPorTipo("IND").Count()}");

// =======================================================
// 4. EJECUTAR MOTOR DE INFERENCIA
// =======================================================
motor.Ejecutar(baseHechos, reglas);

// =======================================================
// 5. MOSTRAR RESULTADOS
// =======================================================

Console.WriteLine("\n===== RESULTADOS AEP =====");
foreach (var h in baseHechos.ObtenerPorTipo("AEP").OrderBy(h => h.Id))
{
    Console.WriteLine($"{h.Id} → {h.Valor.Nivel} ({h.Valor.Valor:F2})");
}

Console.WriteLine("\n===== RESULTADOS CONTENIDOS =====");
foreach (var h in baseHechos.ObtenerPorTipo("CONT").OrderBy(h => h.Id))
{
    Console.WriteLine($"{h.Id} → {h.Valor.Nivel} ({h.Valor.Valor:F2})");
}

Console.WriteLine("\n===== RESULTADO FINAL =====");
var grado = baseHechos.ObtenerPorTipo("GRADO").SingleOrDefault();

if (grado is HechoGrado g)
{
    Console.WriteLine($"GRADO {g.GradoId} → {g.Valor.Nivel} ({g.Valor.Valor:F2})");
}
else
{
    Console.WriteLine("❌ No se pudo inferir el grado.");
}

// =======================================================
// 6. (OPCIONAL) EXPLICACIONES
// =======================================================
Console.WriteLine("\n===== EXPLICACIONES (primeras 5) =====");
foreach (var exp in explicador.Todas().Take(5))
{
    Console.WriteLine(
        $"{exp.HechoGeneradoId} ← {exp.ReglaId} " +
        $"({exp.Resultado.Nivel} {exp.Resultado.Valor:F2})"
    );
}
