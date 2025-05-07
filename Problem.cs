namespace HillClimbingHeuristic
{
    public class Problem
    {
        private int[] State { get; set; } = new int[9];

        public Problem() {}

        public Problem(ref Problem problem)
        {
            for (int i = 0; i < 9; i++)
                State[i] = problem.State[i];
        }

        public void FillRandomly()
        {
            var sortArray = new List<int>();
            for (int i = 0; i < 9; i++)
                sortArray.Add(i);

            var random = new Random();

            for (int i = 0; i < 9; i++) {
                var sortedIndex = random.Next(0, sortArray.Count);
                var sorted = sortArray[sortedIndex];
                sortArray.Remove(sorted);
                State[i] = sorted;
            }
        }

        public int GetStatePosition(int index)
        {
            return State[index];
        }

        public int[] GetState()
        {
            return State;
        }

        public void FillState(int[] state)
        {
            for (int i = 0; i < 9; i++) 
                State[i] = state[i];
        }

        public bool Equals(Problem other)
        {
            return EqualsState(other.State);
        }

        private bool EqualsState(int[] state)
        {
            for (int i = 0; i < 9; i++)
                if (State[i] != state[i]) return false;

            return true;
        }

        public int CalculateObjective()
        {
            int[][] enterpriseProjectValues = [
                [12, 18, 15, 22, 9, 14, 20, 11, 17],
                [19, 8, 13, 25, 16, 10, 7, 21, 24],
                [6, 14, 27, 10, 12, 19, 23, 16, 8],
                [17, 11, 20, 9, 18, 13, 25, 14, 22],
                [10, 23, 16, 14, 7, 21, 12, 19, 15],
                [13, 25, 9, 17, 11, 8, 16, 22, 20],
                [21, 16, 24, 12, 20, 15, 9, 18, 10],
                [8, 19, 11, 16, 22, 17, 14, 10, 13],
                [15, 10, 18, 21, 13, 12, 22, 9, 16]
            ];

            int objective = 0;

            for (int i = 0; i < 9; i++) {
                objective += enterpriseProjectValues[i][State[i]];
            }

            return objective;
        }

        public void ChangePositions(int i, int j)
        {
            (State[j], State[i]) = (State[i], State[j]);
        }

        public void MixRandomPositions()
        {
            var random = new Random();

            var from = random.Next(0, 9);
            int to;

            do {
                to = random.Next(0, 9);
            } while (from == to);

            Console.WriteLine(from + " " + to);

            ChangePositions(from, to);
        }

        public Problem GenerateBestNeighbour(ref Problem state)
        {
            var opState = new Problem(ref state);
            var neighbour = new Problem(ref state);

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    neighbour.ChangePositions(i, j);

                    // Console.WriteLine(neighbour.CalculateObjective() + " " + opState.CalculateObjective());
                    
                    if (neighbour.CalculateObjective() < opState.CalculateObjective()) 
                        opState.FillState(neighbour.GetState());

                    neighbour.FillState(State);
                }
            }

            return opState;
        }

        public override string ToString()
        {
            string data = "";

            for (int i = 0; i < 9; i++)
                data += $"{State[i]} ";

            return data;
        }
    }
}