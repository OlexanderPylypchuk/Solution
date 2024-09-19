using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs
{
    public class Population
    {
        public int Red {  get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Steps { get; set; }
        public Population(int red, int green, int blue, int steps)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Steps = steps;
        }
        public bool IsUniform(int targetColor)
        {
            return (targetColor == 0 && Green == 0 && Blue == 0) ||
                   (targetColor == 1 && Red == 0 && Blue == 0) ||
                   (targetColor == 2 && Red == 0 && Green == 0);
        }
        public List<Population> GetNextStates()
        {
            List<Population> nextStates = new List<Population>();

            // Червоні + Зелені -> Сині
            if (Red > 0 && Green > 0)
                nextStates.Add(new Population(Red - 1, Green - 1, Blue + 2, Steps + 1));

            // Червоні + Сині -> Зелені
            if (Red > 0 && Blue > 0)
                nextStates.Add(new Population(Red - 1, Green + 2, Blue - 1, Steps + 1));

            // Зелені + Сині -> Червоні
            if (Green > 0 && Blue > 0)
                nextStates.Add(new Population(Red + 2, Green - 1, Blue - 1, Steps + 1));

            return nextStates;
        }
        public static int MinMeetings(int[] population, int target)
        {
            Population start = new Population(population[0], population[1], population[2], 0);

            if (start.IsUniform(target))
            {
                return 0;
            }

            Queue<Population> queue = new Queue<Population>();
            queue.Enqueue(start);

            HashSet<Population> visited = new HashSet<Population>();
            visited.Add(start);

            while (queue.Count > 0)
            {
                Population current = queue.Dequeue();

                foreach (Population next in current.GetNextStates())
                {
                    if (!visited.Contains(next))
                    {
                        if (next.IsUniform(target))
                        {
                            return next.Steps;
                        }

                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                }
            }
            return -1;
        }
        public override bool Equals(object obj)
        {
            if (obj is Population other)
            {
                return Red == other.Red && Green == other.Green && Blue == other.Blue;
            }
            return false;
        }

        // Перевизначимо метод GetHashCode для коректного використання в HashSet
        public override int GetHashCode()
        {
            return (Red, Green, Blue).GetHashCode();
        }
    }
}
