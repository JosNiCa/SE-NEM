using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;

namespace SE_NEM.Inference;

public interface IMotorInferencia
{
    void Ejecutar(IBaseHechos hechos, IEnumerable<IRegla> reglas);
}