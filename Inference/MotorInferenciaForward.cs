using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;

namespace SE_NEM.Inference;

public sealed class MotorInferenciaForward : IMotorInferencia
{
    private const int MaxIteraciones = 100;

    public void Ejecutar(IBaseHechos hechos, IEnumerable<IRegla> reglas)
    {
        bool huboCambios;
        int iteracion = 0;

        do
        {
            huboCambios = false;
            iteracion++;

            if (iteracion > MaxIteraciones)
                throw new InvalidOperationException(
                    "Posible ciclo infinito detectado en el motor de inferencia.");

            foreach (var regla in reglas)
            {
                if (!regla.EsAplicable(hechos))
                    continue;

                var nuevoHecho = regla.Ejecutar(hechos);

                if (nuevoHecho == null)
                    continue;

                // Snapshot antes de insertar
                var antes = hechos.Contiene(nuevoHecho.Id)
                    ? hechos.ObtenerPorId(nuevoHecho.Id)
                    : null;

                hechos.AgregarOActualizar(nuevoHecho);

                // Snapshot después
                var despues = hechos.ObtenerPorId(nuevoHecho.Id);

                if (antes == null ||
                    despues.Valor.Valor > antes.Valor.Valor)
                {
                    huboCambios = true;
                }
            }

        } while (huboCambios);
    }
}
