using System;

class MainClass {
  public static void Main (string[] args) {

		while(true) {
			Console.Clear();
			Category topic = chooseCategory();
			Word chosenWord = new Word(topic);
			Console.Clear();
			Hangman mainHangman = new Hangman(chosenWord.GetWord(), topic.ToString());
			while(mainHangman.Playing == true) {
				mainHangman.Guess();
			}
			
			string answer = "";
			while(answer != "Y" && answer != "N") {
				Console.WriteLine("Play Again? (Y/N):");
				answer = Console.ReadLine().ToUpper();
			}
			if(answer == "N") { break; }

		}


  }

	private static Category chooseCategory() {
		int finalIndex = 0;

		while(finalIndex == 0) {
			int i = 0;
			foreach (string name in Enum.GetNames(typeof(Category)))
			{
				i++;
				Console.WriteLine($"{i}) {name}");
			}
			Console.WriteLine("Please input the number of the category you wish to select: ");
			int chosenNumber;
			bool successfulParse = int.TryParse(Console.ReadLine(), out chosenNumber);

			if(successfulParse == true && chosenNumber > 0 && chosenNumber <= Enum.GetNames(typeof(Category)).Length) {
				finalIndex = chosenNumber;
			}
			else {
				Console.WriteLine("Invalid input!");
			}

		}

		return (Category)finalIndex - 1;
	}
}