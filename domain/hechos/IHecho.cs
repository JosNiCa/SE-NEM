using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public interface IHecho
{
    string Id { get; }
    ValorDifuso Valor { get; }
    string Tipo { get; } // IND, AEP, CONT, GRADO
}