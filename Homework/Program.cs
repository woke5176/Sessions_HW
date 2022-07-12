using LinqExamples.Services;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new TestService();

            //service.GenerateMarksCard();

            //var highestScorerInMaths = service.HighestScorerIn("Maths");
            //Console.WriteLine(highestScorerInMaths);

            //var topFiveScorersInMaths = service.HighestScorerIn("maths");
            //Console.WriteLine(topFiveScorersInMaths);

            var totalScores = service.GetTotalScores();

            foreach (var item in totalScores)
            {
                Console.WriteLine($"{item.StudentId}, {item.StudentName}, {item.TotalMarks}");
            }
        }
    }
}