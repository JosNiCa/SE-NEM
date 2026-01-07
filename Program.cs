using SE_NEM.domain.hechos;
using SE_NEM.Inference;

var baseHechos = new BaseHechosDifusa();
var motor = new MotorInferenciaForward();

// 1. Insertar hechos IND iniciales
//foreach (var ind in hechosIndicadores)
  //  baseHechos.AgregarOActualizar(ind);

// 2. Ejecutar inferencia
//motor.Ejecutar(baseHechos, reglas);

// 3. Consultar resultado final
var grado = (HechoGrado)baseHechos.ObtenerPorTipo("GRADO").Single();