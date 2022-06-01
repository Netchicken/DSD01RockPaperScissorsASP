using DSD01RockPaperScissorsASP.Operations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSD01RockPaperScissorsASP.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {

        //https://www.learnrazorpages.com/razor-pages/forms/radios

        // public Game Game { get; set; }



        public string HumanChoice { get; set; }

        public List<string> HumanChoiceOptions;

        public string Result { get; set; }



        public string? Image { get; set; }

        public void OnPost()
        {

            //0 represents Rock, 1 represents Paper, 2 represents Scissors 

            string Human = HumanChoice;
            string Computer = ComputerChoice();
            Result = GameResult(Human, Computer);




        }

        private string GameResult(string human, string computer)
        {
            string message = "You chose " + human + ". The computer chose " + computer;

            if (human == computer)
            {
                Scores.Draw++;
                message += ". Its a Draw";
                Image = "draw.gif";
            }

            else if (human == "Rock" && computer == "Scissors" || human == "Paper" && computer == "Rock" || human == "Scissors" && computer == "Paper")
            {
                Scores.Win++;
                message += ". You Win";
                Image = "win.png";
            }
            else
            {
                Scores.Lose++;
                message += ". You Lose";
                Image = "lose.png";
            }

            ViewData["Draw"] = Scores.Draw;
            ViewData["Win"] = Scores.Win;
            ViewData["Lose"] = Scores.Lose;
            return message;
        }

        public string ComputerChoice()
        {
            //create a new instance of the Random Class
            Random CompGuess = new Random();
            //This code generates a random integer between 1 and 4, but 4 is not inclusive, meaning the only possibilities are 1, 2 and 3
            //Send the number back to the program
            return ComputerChoiceCalc(CompGuess.Next(0, 3));


        }


        private string ComputerChoiceCalc(int choice)
        {
            switch (choice)
            {
                case 0:
                    return "Rock";
                case 1:
                    return "Paper";
                case 2:
                    return "Scissors";

            }

            return null;

        }




        public IndexModel()
        {
            HumanChoiceOptions = new List<string>();
            HumanChoiceOptions.Add("Rock");
            HumanChoiceOptions.Add("Paper");
            HumanChoiceOptions.Add("Scissors");
        }

        public void OnGet()
        {
            Image = "psr.png";

        }
    }
}
