using System;
using System.Collections.Generic;

class Hangman {
	string Word;
	int totalDrawn = 0;
	string Topic;
	public bool Playing = true;
	List<char> guessedChars = new List<char>();

	public Hangman(string word, string topic) {
		this.Word = word;
		this.Topic = topic;
	}

	public void Guess() {
		char guessedChar = Convert.ToChar(" ");
		bool valid = false;

		while (valid == false) {
			Console.WriteLine("Input a letter to guess:");
			string input = Console.ReadLine().ToLower();
			char inputChar;
			bool successfulParse = char.TryParse(input, out inputChar);
			
			if(successfulParse == true) {
				if(hasGuessedCharacter(inputChar) == false) {
					guessedChar = inputChar;
					valid = true;
				}
				else Console.WriteLine("You've already guessed that letter!");
			}
			else Console.WriteLine("Please enter a valid letter.");
		}

		guessedChars.Add(guessedChar);
		if(!Word.ToLower().Contains(guessedChar)) {totalDrawn++;}
		Draw();

	}

	public void Draw() {
		Console.Clear();
		Console.WriteLine($"SELECTED CATEGORY: {this.Topic}");

		int unguessedCharacters = 0;

		foreach(char letter in this.Word.ToCharArray()) {
			if(hasGuessedCharacter(char.ToLower(letter))) {
				Console.Write($"{letter.ToString()} ");
			}
			else {
				if(letter.ToString() != " ") {
					Console.Write("_ ");
					unguessedCharacters++;
				}
				else Console.Write(" ");
			}
		}

		Console.WriteLine("\n");

		DrawHangman();

		Console.WriteLine("\n");

		Console.WriteLine($"Guessed Characters: {String.Join(", ", guessedChars.ToArray())}");

		if (unguessedCharacters == 0) {Playing = false; Console.WriteLine("Complete!");}

	}

	private bool hasGuessedCharacter(char letter) {
		foreach(char c in guessedChars) {
			if(c == letter) {
				return true;
			}
		}
		return false;
	}

	private void DrawHangman() {
		Console.WriteLine("--------");
		Console.WriteLine($"|	 {totalDrawn > 0 ? "O" : " "}");
		Console.WriteLine($"|	{totalDrawn > 2 ? "/" : " "}{totalDrawn > 1 ? "|" : " "}{totalDrawn > 3 ? @"\" : ""}" );
		Console.WriteLine($"|	{totalDrawn > 4 ? "/" : " "} {totalDrawn > 5 ? @"\" : ""}");
		Console.WriteLine("|");
		Console.WriteLine("--");
		
		if(totalDrawn > 5) {
			Playing = false;
			Console.WriteLine("You lose!");
		}

	}

	
}