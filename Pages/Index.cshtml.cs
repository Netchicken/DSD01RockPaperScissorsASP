using DSD01RockPaperScissorsASP.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSD01RockPaperScissorsASP.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {

        //https://www.learnrazorpages.com/razor-pages/forms/radios

        public Game Game { get; set; }


        public void OnPost()
        {

            //0 represents Rock, 1 represents Paper, 2 represents Scissors 

            string Human = HumanChoiceCalc(Game.HumanChoice);
            string Computer = ComputerChoice();
            Game.Result = GameResult(Human, Computer);




        }

        private string GameResult(string human, string computer)
        {

            if (human == computer)
            {
                return "Draw";
            }

            if (human == "Rock" && computer == "Scissors" || human == "Paper" && computer == "Rock" || human == "Scissors" && computer == "Paper")
            {
                return "Win";
            }
            else
            {
                return "Lose";
            }

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


        // RadioButton checkchanged displays the image when the button changes
        private string HumanChoiceCalc(string name)
        {
            if (name == "Rock")
            {
                //  pbHumanPic.Image = Resource1.rock;

            }
            else if (name == "Paper")
            {
                // pbHumanPic.Image = Resource1.paper;
            }
            else if (name == "Scissors")
            {
                //  pbHumanPic.Image = Resource1.scissors;

            }
            return name;
        }



        public void OnGet()
        {

        }
    }
}
