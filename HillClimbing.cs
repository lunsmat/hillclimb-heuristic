using System.Diagnostics;

namespace HillClimbingHeuristic
{
    class HillClimbing(Problem problem)
    {
        private Problem CurrentState { get; set; } = new Problem(ref problem);

        private Problem InitialState { get; } = new Problem(ref problem);

        private Problem BestState { get; set; } = new Problem(ref problem);

        private int Iterations { get; set; } = 0;

        private Stopwatch Watch { get; set; } = Stopwatch.StartNew(); 

        public static HillClimbing Run(ref Problem problem, int limitIterations = -1)
        {
            var result = new HillClimbing(problem);
            var neighbour = new Problem(ref problem);

            do {
                result.CurrentState.FillState(neighbour.GetState());

                if (result.BestState.CalculateObjective() > neighbour.CalculateObjective()) 
                    result.BestState.FillState(neighbour.GetState());

                var bestNeighbour = neighbour.GenerateBestNeighbour(ref neighbour);
                if (bestNeighbour.Equals(neighbour)) break;

                if (bestNeighbour.CalculateObjective() == neighbour.CalculateObjective())  {
                    bestNeighbour.MixRandomPositions();
                }
                neighbour.FillState(bestNeighbour.GetState());

                result.AddIteration();
            } while (limitIterations == -1 || limitIterations > result.Iterations);

            return result;
        }

        private void AddIteration()
        {
            Iterations++;
        }

        public Problem GetBestState()
        {
            return CurrentState;
        }

        public int GetIterations()
        {
            return Iterations;
        }

        private void FinishWatch()
        {
            Watch.Stop();
        }

        public long GetWatchMS()
        {
            return Watch.ElapsedMilliseconds;
        }

        public override string ToString()
        {
            string result = String.Empty;

            result += $"Estado Inicial: {InitialState}\n";
            result += $"Melhor estado: {BestState}\n";
            result += $"Objetivo: {BestState.CalculateObjective()}\n";
            result += $"Iterações: {Iterations}\n";
            result += $"Tempo de Execução: {Watch.ElapsedMilliseconds}ms";

            return result;
        }
    }
}