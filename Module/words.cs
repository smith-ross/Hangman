using System;
using System.Collections.Generic;

public enum Category {
	MovieTitles,
	VideoGames,
	BrandNames
}

class Words {

	private static Dictionary<Category, string[]> availableWords = new Dictionary<Category, string[]>() {

		{Category.MovieTitles, new string[]{
				"The LEGO Movie",
				"The Last Guest",
				"The Angry Birds Movie"
			}
		},

		{Category.VideoGames, new string[]{
				"Fortnite",
				"Roblox",
				"Minecraft"
			}
		},

		{Category.BrandNames, new string[]{
				"McDonalds",
				"Gucci",
				"Konami"
			}
		},



	};

	public static string[] GetWords(Category topic) {
		return availableWords[topic];
	}
}