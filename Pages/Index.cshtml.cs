﻿using DSD01RockPaperScissorsASP.Operations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSD01RockPaperScissorsASP.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        //https://www.learnrazorpages.com/razor-pages/forms/radios

        //holds the selected choice from the radio button
        public string HumanChoice { get; set; }
        //is the list of 3 options

        public List<string> HumanChoiceOptions;
        //give the result as text
        public string Result { get; set; }
        //shos the image
        public string? Image { get; set; }

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

        public void OnPost()
        {
            //0 represents Rock, 1 represents Paper, 2 represents Scissors 
            string Human = HumanChoice;
            //random number 0,1,2
            string Computer = ComputerChoice();
            //run the result method
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







    }
}
