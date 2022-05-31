namespace DSD01RockPaperScissorsASP.Model
{
    public class Game
    {
        //https://www.learnrazorpages.com/razor-pages/forms/radios

        public string HumanChoice { get; set; }
        public string[] HumanChoiceOptions = new[] { "Rock", "Paper", "Scissors" };
        public string Result { get; set; }



    }
}
