using SE_NEM.domain.difuso;

namespace SE_NEM.Fuzzification;

public sealed class DifusificadorUnesco : IDifusificador
{
    // ---------- ACIERTOS ----------
    private readonly IFuncionPertenencia _aciertosI =
        new FuncionTrapezoidal(0.0, 0.0, 0.20, 0.35);

    private readonly IFuncionPertenencia _aciertosP =
        new FuncionTrapezoidal(0.20, 0.35, 0.55, 0.70);

    private readonly IFuncionPertenencia _aciertosM =
        new FuncionTrapezoidal(0.50, 0.65, 0.80, 0.95);

    private readonly IFuncionPertenencia _aciertosE =
        new FuncionTrapezoidal(0.75, 0.90, 1.0, 1.0);

    // ---------- TIEMPO (segundos por token) ----------
    private readonly IFuncionPertenencia _tiempoE =
        new FuncionTrapezoidal(0, 0, 40, 48);

    private readonly IFuncionPertenencia _tiempoM =
        new FuncionTrapezoidal(40, 48, 65, 80);

    private readonly IFuncionPertenencia _tiempoP =
        new FuncionTrapezoidal(65, 80, 94, 120);

    private readonly IFuncionPertenencia _tiempoI =
        new FuncionTrapezoidal(94, 120, double.MaxValue, double.MaxValue);

    // ---------- INTENTOS ----------
    public ValorDifuso DifusificarIntentos(int intentos)
    {
        return intentos switch
        {
            1 => ValorDifuso.DesdeValor(0.9),
            2 => ValorDifuso.DesdeValor(0.66),
            3 => ValorDifuso.DesdeValor(0.45),
            _ => throw new ArgumentOutOfRangeException(nameof(intentos))
        };
    }

    // ---------- ACIERTOS ----------
    public ValorDifuso DifusificarAciertos(double proporcionAciertos)
    {
        return DifusificarConjunto(
            proporcionAciertos,
            _aciertosI,
            _aciertosP,
            _aciertosM,
            _aciertosE
        );
    }

    // ---------- TIEMPO ----------
    public ValorDifuso DifusificarTiempo(double segundosPorToken)
    {
        return DifusificarConjunto(
            segundosPorToken,
            _tiempoI,
            _tiempoP,
            _tiempoM,
            _tiempoE
        );
    }

    // ---------- Helper ----------
    private static ValorDifuso DifusificarConjunto(
        double x,
        IFuncionPertenencia fI,
        IFuncionPertenencia fP,
        IFuncionPertenencia fM,
        IFuncionPertenencia fE)
    {
        var valores = new Dictionary<NivelCompetencia, double>
        {
            { NivelCompetencia.I, fI.Evaluar(x) },
            { NivelCompetencia.P, fP.Evaluar(x) },
            { NivelCompetencia.M, fM.Evaluar(x) },
            { NivelCompetencia.E, fE.Evaluar(x) }
        };

        var max = valores.MaxBy(v => v.Value);

        return ValorDifuso.DesdeValor(max.Value switch
        {
            _ when max.Key == NivelCompetencia.I => 0.2,
            _ when max.Key == NivelCompetencia.P => 0.45,
            _ when max.Key == NivelCompetencia.M => 0.70,
            _ => 0.95
        });
    }
}