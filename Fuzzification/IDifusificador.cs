using SE_NEM.domain.difuso;

namespace SE_NEM.Fuzzification;

public interface IDifusificador
{
    ValorDifuso DifusificarAciertos(double proporcionAciertos);
    ValorDifuso DifusificarTiempo(double segundosPorToken);
    ValorDifuso DifusificarIntentos(int intentos);
}