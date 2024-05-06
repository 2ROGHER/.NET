using AsyncStream;
using System.Diagnostics; // libreria para medir el tiempo o hacer medidas de tiempo en los procesos.

// See https://aka.ms/new-console-template for more information
// Esta aplicacion nos permite entneder el flujo de trabajo o como funciona el proceso asyncrono.

// Inicamos un contador de tiempo
// ========================= Proces sincrono =================================
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start(); // empezamos

Console.WriteLine("====================== Bienvenido a la calculadora de Hipotecas Sincrona ===========================");
var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"Anios de vida labora obtenido: {aniosVidaLaboral}");

var esTipoDeContratoIndefinido = CalculadoraHipotecaSync.EsContratoIndefinido();
Console.WriteLine($"Tipo de contrato indefinido: {esTipoDeContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"Sueldo neto obteneido {sueldoNeto}");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"Gastos mensuales obtenidos: {gastosMensuales}");

var hipotecaConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(
    aniosVidaLaboral,
    esTipoDeContratoIndefinido,
    sueldoNeto,
    gastosMensuales,
    cantidadSolicitada: 500, aniosPagar: 30);

var resultado = hipotecaConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"Analisis finalizado. Su solicitud de hipoteca ha sido concendido: {resultado}");

// Finalmente terminanosel stopWatch
stopwatch.Stop();

Console.WriteLine("====================== La operacion a tardado en completarse: " + stopwatch.Elapsed + "====================");

// ===================================== Reiniciamos para el proceso asyncrono ================================
stopwatch.Restart();
Console.WriteLine("====================== Bienvenido a la calculadora de Hipotecas Asyncrona ===========================");
Task<int> aniosVidaLaboralAsyncTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboral();

Task<bool> esTipoDeContratoIndefinidoAsyncTask = CalculadoraHipotecaAsync.EsContratoIndefinido();


var sueldoNetoAsyncTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();

var gastosMensualesAsyncTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var hipotecaConcedidaAsyncTask = new List<Task>
{
    aniosVidaLaboralAsyncTask,
    esTipoDeContratoIndefinidoAsyncTask,
    sueldoNetoAsyncTask,
    gastosMensualesAsyncTask,
};

while (hipotecaConcedidaAsyncTask.Any())
{
    Task tareaFinalizada = await Task.WhenAny(hipotecaConcedidaAsyncTask);
    if (tareaFinalizada == aniosVidaLaboralAsyncTask)
    {
       Console.WriteLine($"Anios de vida labora obtenido: {aniosVidaLaboralAsyncTask.Result}");

    } else if (tareaFinalizada == esTipoDeContratoIndefinidoAsyncTask) {
        Console.WriteLine($"Tipo de contrato indefinido: {esTipoDeContratoIndefinidoAsyncTask.Result}");

    } else if (tareaFinalizada == sueldoNetoAsyncTask)
    {
        Console.WriteLine($"Sueldo neto obteneido {sueldoNetoAsyncTask.Result}");

    } else if (tareaFinalizada == gastosMensualesAsyncTask)
    {
        Console.WriteLine($"Gastos mensuales obtenidos: {gastosMensualesAsyncTask.Result}");

    }
    hipotecaConcedidaAsyncTask.Remove(tareaFinalizada); // elimamos las tareas del array para que no caiga en un bucle infinito.
}


var hipotecaConcedidaAsyc = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(
    aniosVidaLaboralAsyncTask.Result,
    esTipoDeContratoIndefinidoAsyncTask.Result,
    sueldoNetoAsyncTask.Result,
    gastosMensualesAsyncTask.Result,
    cantidadSolicitada: 500, aniosPagar: 30);

var resultadoAsync = hipotecaConcedida ? "APROBADA" : "DENEGADA";
stopwatch.Stop();

Console.WriteLine("====================== La operacion Async a tardado en completarse: " + stopwatch.Elapsed + "====================");

Console.ReadLine();