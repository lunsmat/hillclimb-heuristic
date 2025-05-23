﻿namespace HillClimbingHeuristic
{   
    class Program
    {
        const int IterationsLimit = 500;

        public static void Main()
        {
            var results = new List<HillClimbing>();

            int rounds = 50;

            for (int i = 0; i < rounds; i++)
            {
                var problem = new Problem();
                problem.FillRandomly();

                var result = HillClimbing.Run(ref problem, IterationsLimit);
                results.Add(result);
            }

            var timeList = from result in results select result.GetWatchMS();
            var iterationList = from result in results select (long) result.GetIterations();

            var timeAverage = timeList.Average();
            var iterationAverage = iterationList.Average();

            var timeStandardDeviation = StandardDeviation(timeList);
            var iterationStandardDeviation = StandardDeviation(iterationList);

            var minorTime = timeList.Min();
            var minorIterations = iterationList.Min();

            var fiveBestSolutions = (from result in results
                orderby result.GetBestState().CalculateObjective() ascending
                select result).Take(5);

            Console.WriteLine($"======================================= Resultados =======================================");
            Console.WriteLine($"Media de Tempo: {timeAverage}ms");
            Console.WriteLine($"Media de Iterações: {iterationAverage} Iterações");
            Console.WriteLine($"Desvio Padrão de Tempo: {timeStandardDeviation}ms");
            Console.WriteLine($"Desvio Padrão de Iterações: {iterationStandardDeviation} Iterações");
            Console.WriteLine($"Menor Tempo: {minorTime}ms");
            Console.WriteLine($"Menor Número de Iterações: {minorIterations} Iterações");

            Console.WriteLine();
            Console.WriteLine("5 Melhores resultados");

            foreach (var result in fiveBestSolutions)
            {
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }

        public static double StandardDeviation(IEnumerable<long> values)
        {
            double ret = 0;
            int count = values.Count();
            double avg = values.Average();
            double sum = values.Sum(d => (d - avg) * (d - avg));
            ret = Math.Sqrt(sum / count);
            
            return ret;
        }
    }
}