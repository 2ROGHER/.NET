using CollegeAPI;
using CollegeAPI.Models.DataModels;
using NuGet.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace CollegeAPI
//{
//    public class Employee
//    {
//        public Employee(int id, string name) {
//            id = id;
//            name = name;
//        }
//        public int Id { get; set; }
//        public string Name { get; set; }
//    }
//}
//namespace CollegeAPI

//{
//    public class Enterprice
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public Employee[]? Employees { get; set; }

//    }


    
//}


//namespace CollegeApi
//{
//    public class Snippets
//    {
//        static public void BasicLinQ()
//        {
//            string[] cars =
//            {
//                "vw golf",
//                "vw california",
//                "Audi a5",
//                "Fiat punto",
//                "Seant PUnto",
//                "Sean Leon",
//            };


//            // 1. Select * of cars;
//            var carList = from car in cars select car;

//            // 2. SELECT WHERE 
//            var audiCarList = from car in cars where car.Contains("audi") select car;

//            // 3. 
//        }

//        public static void LinQNumber()
//        {
//            List<int> numbers = new List<int> { 1, 3, 2, 4, 92, 100, 23, 234 };

//            // CAda numero multiplicado por 3
//            // Tomamos el numero meno el 4 y ordenamos asc
//            var res = numbers
//                .Select(num => num * 3)
//                .Where(num => num != 8)
//                .OrderBy(num => num);


//        }

//        public static void SearchExamples()
//        {
//            List<string> texts = new List<string>
//            {
//                "a",
//                "bd",
//                "c",
//                "d",
//                "e",
//                "m",
//                "p"
//            };
//            // 1. Primer elemento
//            var first = texts.First();

//            // 2. First element that is "c"
//            var res = texts.First(txt => txt.Equals("c"));

//            // 3. Primer elemento que contenga "f"
//            var res1 = texts.Select(txt => txt.Contains("f"));

//            // 4. Primer elemento que contenga "z" o default
//            var res2 = texts.FirstOrDefault(txt => txt.Contains('z')); // el elemento buscado o valor vacion.

//            // 5. Ultimo element o por default elemtno
//            var res3 = texts.LastOrDefault(txt => txt.Contains("z"));

//            // 6. Un solo valor
//            var res4 = texts.SingleOrDefault();
//            var res6 = texts.Single();

//            int[] evenNumbers = { 2, 4, 8, 10, 12, 14 };
//            int[] oddNumbers = { 3, 1, 9, 7 };

//            // 7. Obtener {4, 8}
//            var rest7 = evenNumbers.Except(oddNumbers);


//        }

//        public static void MultiplesSelects()
//        {
//            string[] myOpinions =
//            {
//                "Opinion 1 text",
//                "Opinion 2 text",
//                "Opinion 3 text",
//                "Opinion 4 text",
//                "Opinion 5 text",
//                "Opinion 6 text",

//            };

//            var res8 = myOpinions.SelectMany(item => item.Split(","));

//            var Empresas = new Employee[]
//            {
//                new Employee(1, "name 1"),
//                new Employee(2, "name 2"),
//                new Employee(3, "name 3")

//            };


//        }

//        public static void LinqCollections()
//        {
//            var firstList = new List<string> { "a", "b", "c" };
//            var secondList = new List<string> { "1", "2", "3" };

//            // INNEr JOIN
//            var innerJoin = from item in firstList join secondItem in secondList on item equals secondItem select new { item, secondItem };

//            // other way 
//            var innerJoin2 = firstList.Join(
//                    secondList,
//                    item => item,
//                    secondItem => secondItem,
//                    (item, secondItem) => new { item, secondItem }
//                );

//            // OUTER JOIN - LEFT
//            var leftJoin = from item in firstList
//                           join secondItem in secondList
//                           on item equals secondItem
//                           into temporalList
//                           from temporalElement in temporalList.DefaultIfEmpty()
//                           where item != temporalElement
//                           select new { Item = item };

//            var leftJoin2 = from item in firstList
//                            from secondItem in secondList.Where(s => s == item).DefaultIfEmpty()
//                            select new { Item = item, secondItem = secondItem };

//            // OUTERJOIN - RIGHT
//            var rightJoin = from secondElement in secondList
//                            join item in firstList
//                            on secondElement equals item
//                            into temporalList
//                            from temporalItem in temporalList.DefaultIfEmpty()
//                            where secondElement != temporalItem
//                            select new { Item = secondElement };

//            // UNION
//            var Join = leftJoin.Union(rightJoin); 

//        }

//        public static void SkipTakeLinQ ()
//        {
//            var myList = new[]
//            {
//                1, 2, 3, 4, 5, 29, 29, 329
//            };

//            var skiptTwoFirstValues = myList.Skip(2); // salta los 2 primeros numeros.
//            var skipLastTwoValues = myList.SkipLast(2);

//            var skipWhile = myList.SkipWhile(num => num < 4);

//            // TAke 
//            var takeFirstTwoValue = myList.Take(2);

//            var takeLastTwoValues = myList.TakeLast(2);

//            var takeWhile = myList.TakeWhile(num => num <= 2);
//        }

//        // TODO Session - 4
//        // Paging
//        public static IEnumerable<T> GetPage<T>(IEnumerable<T>collection, int pageNumber, int resultPerPage) 
//        { 
//            int startIndex  = (pageNumber - 1) * resultPerPage; //Este es el index de la paginacion
//            return collection.Skip(startIndex).Take(resultPerPage);
//        }

//        // Varibles de sentencias dentro de LinQ
//        public static void LinqVariables ()
//        {
//            // Aqui podremos declarar variables dentro de las consultas de LinQ
//            int[] numbers = [1, 3, 4, 5, 6, 8, 10];
//            var average = from number in numbers
//                          let averageValue = numbers.Average() // definimos una variable a nivel local con "let"
//                          let nSquared = Math.Pow(number, 2)
//                          where nSquared > averageValue
//                          select number; // obtenme de la lista de numeros cuyos valores esten por encima de la media de los valores de este.

//            foreach(var i in average)
//            {
//                Console.WriteLine($"Number: {0} square: {1}, {i} ,{Math.Pow(i, 2)}"); // print all values que cumplan con la condicion.
//            } 

//        }

//        // Undestand ZIP
//        public static void ZipLinq()
//        {
//            int[] numbers = [1, 3, 23, 382, 9];
//            string[] stringNumbers = { "uno", "dos", "tres", "cuatro", "cinco" };

//            // Zip es una forma de intercalar los valores de "INumerables"
//            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word); // esta una solucion de mezaclar dos listas de datos entre ellos
//            // {"1 = uno", "3 = tres", "23 = tres", ... }

//        }

//        // Repeat & Range
//        public static void ReapeatRangeLinq()
//        {
//            // son metodos que tiene enumerable que se puede usar en LINQ, que se usa para generar secuencias simples.

//            // Range
//            // Genrate collection from 1 - 1000
//            IEnumerable<int> first1000 = Enumerable.Range(0, 1000); // easy to range values min - max

//            // Repeat
//            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // XXXXX se repite 5 veces el caracter "X". Esto itera cada uno de ellso y los imprime la cantidad de veces.


//        }

//        public static void studentLinq ()
//        {
//            // Aqui tenemos una lista de Estudiantes.
//            var classRoom = new[]
//            {
//                // new Student(),
//                // new Student(),
//                // new Student(),
//            }

//            // Obtener los estudiantes que no estan cerficdos, para esto el estudiante tiene como propiedad un "certificados"
//            var cerficados = from student in classRoom
//                             where student.Certified == false
//                             select student;

//            // Selecinar una lista de estudiantes aprobados
//            var approved = from student in classRoom
//                           where student.Grade >= 50 && student.Certified == true
//                           select student;

//            // Seleccionar solo el nombre de todos los estudiantes aprovados 
//            var approvedName = from student in classRoom
//                           where student.Grade >= 50 && student.Certified == true
//                           select student.name;



//        }

//        // All |Contraste with Any| esto nos indica que se cumple para todos los valores
//        public static void AllLinq ()
//        {
//            int[] numbers = { 1, 3, 4, 5, 38 };

//            // Calcular si todos los numeros son mayores de 10
//            var allAreSmallerThan10 = numbers.All(x => x > 10); // esto es true si todos son mayores or false sino.

//            bool allAreBiggerOrEqualThan10 = numbers.All(x => (x >= 10)); // false

//            var empyList = new List<int>();
//            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // false
//        }

//        // Aggregate |Similar a Reduce() in other lenguajes | 
//        public static void AgregateLinq ()
//        {
//            // Esto es una secuencia acumulativa de funciones, cuya previa salida de una funcin es la entrada de otra
//            int[] numbers = { 1, 3, 4, 6, 8, 8, 94, 193 };
//            // sum all numbers
//            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

//            string[] words = { "hello", "my", "name", "is", "martin" }; // Hello, my name is martin

//            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current); // "hello" // "hello name" // "hello name is"
//        }

//        // Distinct
//        public static void DisctinctLinq ()
//        {
//            // Esta funcin es util cuando queremos obtener valore distintos de una lista
//            int[] numbers = {1, 34, 29, 2, 0, 2, 3, 4, 1, 3, 4, 5, 6, 7, 8, 9, 10 };
//            IEnumerable<int> distinctValues = numbers.Distinct(); // podemos colocar cualquire callback como entrada de la funcin "Distinct"

//        }

//        // GroupBy
//        public static void GroupByLinq ()
//        {
//            List<int> numbers = new List<int> { 1, 3, 4, 5, 239, 293, 19 };
//            // obtain only even numbers adn generate two groups
//            // Tendremos 2 grupos
//            // 1. Grupo que no cumple con la condicion (impares |odd| ) .
//            // 2. Grupo que si cumple con la condicion (pares |even|).
//            var grouped = numbers.GroupBy(x => x % 2 == 0); // Agrupamos entre valores pares 
//            foreach(var group in grouped)
//            {
//               foreach(var j in group)
//                {
//                    Console.WriteLine(j);
//                }
//            }
//        }


//    }
//}
