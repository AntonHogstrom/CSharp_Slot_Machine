using System;

namespace CSharp_Proj
{
	public class Slot
	{
		//Define array of 5 arrays
		string[][] SlotImages = new string[5][];

		//Variables for amount of animals
		int Squirrels = 0;
		int Dolphines = 0;
		int Foxes = 0;
		int Owls = 0;
		int Wolves = 0;
		int Lions = 0;

		//Getters
		public string[][] GetSlotImages() => SlotImages;

		public int GetLions() => Lions;
		public int GetWolves() => Wolves;
		public int GetOwls() => Owls;
		public int GetFoxes() => Foxes;
		public int GetDolphines() => Dolphines;
		public int GetSquirrels() => Squirrels;

		//Depending on how many animal of same kind returned, return a value
		public int CalculateMultiplier(int animal)
        {
			if (animal == 6) return 1;
			else if (animal == 7) return 3;
			else if (animal == 8) return 4;
			else if (animal == 9) return 6;
			else if (animal == 10) return 8;
			else if (animal == 11) return 10;
			else if (animal == 12) return 15;
			else if (animal == 13) return 20;
			else if (animal == 14) return 26;
			else if (animal == 15) return 30;
			else if (animal == 16) return 36;
			else if (animal == 17) return 42;
			else if (animal == 19) return 50;
			else if (animal == 20) return 60;
			else if (animal == 21) return 70;
			else if (animal == 22) return 80;
			else if (animal == 23) return 100;
			else if (animal == 24) return 150;
			else if (animal == 25) return 300;
			else return 0;
		}

		//Calculate win with amount betted, base value of animals and multiplier
		//Add values of all animals together and return how much won
		public int CalculateWin(int betAmount)
		{
			int won;
			int squirrelBase = 0;
			int dolphineBase = 1;
			int foxBase = 2;
			int owlBase = 3;
			int wolfBase = 5;
			int lionBase = 10;

			int squirrelWin = squirrelBase * betAmount * CalculateMultiplier(Squirrels);
			int dolphineWin = dolphineBase * betAmount * CalculateMultiplier(Dolphines);
			int foxWin = foxBase * betAmount * CalculateMultiplier(Foxes);
			int owlWin = owlBase * betAmount * CalculateMultiplier(Owls);
			int wolfWin = wolfBase * betAmount * CalculateMultiplier(Wolves);
			int lionWin = lionBase * betAmount * CalculateMultiplier(Lions);

			won = squirrelWin + dolphineWin + foxWin + owlWin + wolfWin + lionWin;

			return won;
		}

		//constructor
		public Slot()
		{
			//Defines arrays of 5 integers
			SlotImages[0] = new string[5];
			SlotImages[1] = new string[5];
			SlotImages[2] = new string[5];
			SlotImages[3] = new string[5];
			SlotImages[4] = new string[5];

			//New instance of random class
			Random RandomNum = new Random();

			// j for index of arrays inside array
			int j = 0;

			// 25 loops, one for each index in each of array inside SlotImages
			for (int i = 0; i < 25; i++)
			{

				//Save random 100
				int random100 = RandomNum.Next(100);

				//Convertions to slot value / symbol
				string image;

				if (random100 > 92)
				{
					image = "lion.jpg";
					Lions++;
				}
				else if (random100 > 80)
				{
					image = "wolf.jpg";
					Wolves++;
				}
				else if (random100 > 64)
				{
					image = "owl.jpg";
					Owls++;
				}
				else if (random100 > 50)
				{
					image = "fox.jpg";
					Foxes++;
				}
				else if (random100 > 30)
				{
					image = "dolphine.jpg";
					Dolphines++;
				}
				else
				{
					image = "squirrel.jpg";
					Squirrels++;
				}

				// Put values to indexes
				if (i < 5)
				{
					SlotImages[0][j] = image;
				}
				else if (i < 10)
				{
					SlotImages[1][j] = image;
				}
				else if (i < 15)
				{
					SlotImages[2][j] = image;
				}
				else if (i < 20)
				{
					SlotImages[3][j] = image;
				}
				else if (i < 25)
				{
					SlotImages[4][j] = image;
				}
				else
				{
					Console.WriteLine("Error: Array Full");
				}

				//When true reset J to 0, should not go over index 4
				if (j == 4)
				{
					j = 0;
				}
				else
				{
					j++;
				}

			}
		}
	}
}

