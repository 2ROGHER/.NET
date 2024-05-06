﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncStream
{
    internal class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAniosVidaLaboral()
        {
            // ahora tenemos que retonarn un proceso asyncrono
            Console.WriteLine("===================== Obteniendo anios de vida laboral =========================");
            //usamos Task, el cual realiza una tareas asincrona
            await Task.Delay(5000); // esperamos 
            return new Random().Next(1, 34);
        }

        // funcion para agreagar nuevas tareas en la Cola
        public static async Task<bool> EsContratoIndefinido()
        {
            Console.WriteLine("==================== Verificando si el tipo de contrado es indefinido =====================");
            await Task.Delay(5000); // otro segundo mas
            return (new Random().Next(1, 34)) % 2 == 0; // es par return true el se false.
        }

        // obtener el sueldo neto del usuario
        public static async Task<int> ObtenerSueldoNeto()
        {
            Console.WriteLine("==================== Obteniendo el sueldo neto =====================");
            await Task.Delay(500);
            return new Random().Next(8000, 90000);

        }

        // obtener gastos mensualess
        public static async Task<int> ObtenerGastosMensuales()
        {
            Console.WriteLine("==================== Obteniendo gastos mensuales =====================");
            await Task.Delay(500);
            return new Random().Next(200, 5000);

        }

        public static async Task<bool> AnalizarInformacionParaConcederHipoteca(int aniosVidaLaboral, bool tipoDeContratoEsIndefinido, int sueldoNeto, int gastosMensuales, int cantidadSolicitada, int aniosPagar)
        {
            Console.WriteLine("==================== Aniadiendo informacion para conceder hipoteca =====================");
            if (aniosVidaLaboral < 2)
            {
                return false;
            }

            //obtener la cuota
            var cuota = (cantidadSolicitada / aniosPagar) / 12;

            // si la cuota es valida a pagar
            if (cuota >= sueldoNeto || cuota > sueldoNeto / 2)
            {
                return false;
            }

            // porcentaje de gastos mensuales sobre el sueldo
            var porcentajeGastosSobreSueldo = ((gastosMensuales * 100) / sueldoNeto);

            if (porcentajeGastosSobreSueldo > 30)
            {
                return false;
            }

            if ((cuota + gastosMensuales) > sueldoNeto)
            {
                return false;
            }

            if (!tipoDeContratoEsIndefinido)
            {
                if ((cuota + gastosMensuales) > (sueldoNeto / 3))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }

    
}
}
