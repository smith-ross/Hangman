using System;

class Word {

	Category Topic;
	string chosenWord;

	public Word(Category topic) {
		this.Topic = topic;
		this.chosenWord = SelectWord();
	}

	public string GetWord() {
		return this.chosenWord;
	}

	private string SelectWord() {
		string[] availableWords = Words.GetWords(this.Topic);
		Random rand = new Random();
		int index = rand.Next(0, availableWords.Length);
		return availableWords[index];
	}
}