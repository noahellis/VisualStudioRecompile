using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsClone
{
	public class RomanConversions
	{
		private List<string> RomanList = new List<string>();

		private List<char> NumeralList = new List<char>();

		private int remainder;

		private int romans2Add;

		private int decConvertTotal;

		public RomanConversions()
		{
		}

		public void ConvertFromRome(string UserInput)
		{
			int num = this.NumeralList.Count<char>();
			for (int i = 1; i < num - 1; i++)
			{
				char firstRoman = this.NumeralList.ElementAt<char>(i);
				char secondRoman = this.NumeralList.ElementAt<char>(i + 1);
				char thirdRoman = this.NumeralList.ElementAt<char>(i - 1);
				if (i != 1)
				{
					if (firstRoman == thirdRoman)
					{
						this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstRoman);
					}
					else if ((firstRoman == thirdRoman ? false : firstRoman != secondRoman))
					{
						if (this.RomeConverter(secondRoman) <= this.RomeConverter(firstRoman))
						{
							this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstRoman);
						}
						else
						{
							this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(secondRoman) - this.RomeConverter(firstRoman));
							i++;
						}
					}
				}
				else if (firstRoman == secondRoman)
				{
					this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstRoman);
				}
				else if (i + 2 == num)
				{
					this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstRoman);
				}
				else if (firstRoman != secondRoman)
				{
					if (this.RomeConverter(secondRoman) <= this.RomeConverter(firstRoman))
					{
						this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstRoman);
					}
					else
					{
						this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(secondRoman) - this.RomeConverter(firstRoman));
						i++;
					}
				}
			}
			Console.WriteLine(string.Concat(new object[] { "The Roman Numeral ", UserInput, " is equal to a decimal value of ", this.decConvertTotal }));
			this.NumeralList.Clear();
			this.MainBuild();
		}

		public void ListConverter()
		{
			Console.WriteLine(string.Join("", this.RomanList));
			this.MainBuild();
		}

		public string ListCreator(string UserInput)
		{
			int num = UserInput.Count<char>();
			string upper = UserInput.ToUpper();
			this.NumeralList.Add('P');
			for (int i = 0; i <= num - 1; i++)
			{
				this.NumeralList.Add(upper.ElementAt<char>(i));
			}
			this.NumeralList.Add('P');
			return upper;
		}

		public void MainBuild()
		{
			Console.WriteLine("Would you like to check a 1) Roman Numeral or 2) a regular Integer?");
			int num = int.Parse(Console.ReadLine());
			if (num == 2)
			{
				Console.WriteLine("Please input your Number.");
				int num1 = int.Parse(Console.ReadLine());
				this.decConvertTotal = 0;
				this.SwitchtoStart(num1);
			}
			else if (num == 1)
			{
				Console.WriteLine("Please input your Number.");
				string str = Console.ReadLine();
				this.decConvertTotal = 0;
				this.ConvertFromRome(this.ListCreator(str));
			}
		}

		public void RomanAssigner(int Num2Convert, int Divisor, int SecondaryDivisor, string Letter2Add, string SecondaryOpp)
		{
			if (Num2Convert < Divisor)
			{
				this.RomanList.Add(SecondaryOpp);
				this.RomanList.Add(Letter2Add);
				this.remainder = Num2Convert % SecondaryDivisor;
				this.SwitchtoStart(this.remainder);
			}
			else if (Num2Convert >= Divisor)
			{
				this.romans2Add = Num2Convert / Divisor;
				this.remainder = Num2Convert % Divisor;
				for (int i = 0; i < this.romans2Add; i++)
				{
					this.RomanList.Add(Letter2Add);
				}
				this.SwitchtoStart(this.remainder);
			}
		}

		public int RomeConverter(char RomeDig)
		{
			int num;
			char romeDig = RomeDig;
			if (romeDig > 'D')
			{
				switch (romeDig)
				{
					case 'I':
					{
						num = 1;
						break;
					}
					case 'J':
					case 'K':
					{
						num = 0;
						return num;
					}
					case 'L':
					{
						num = 50;
						break;
					}
					case 'M':
					{
						num = 1000;
						break;
					}
					default:
					{
						if (romeDig == 'V')
						{
							num = 5;
							break;
						}
						else if (romeDig == 'X')
						{
							num = 10;
							break;
						}
						else
						{
							num = 0;
							return num;
						}
					}
				}
			}
			else if (romeDig == 'C')
			{
				num = 100;
			}
			else
			{
				if (romeDig != 'D')
				{
					num = 0;
					return num;
				}
				num = 500;
			}
			return num;
		}

		public void SwitchtoStart(int Num2Convert)
		{
			if (Num2Convert >= 900)
			{
				this.RomanAssigner(Num2Convert, 1000, 900, "M", "C");
			}
			else if (Num2Convert >= 400)
			{
				this.RomanAssigner(Num2Convert, 500, 400, "D", "C");
			}
			else if (Num2Convert >= 90)
			{
				this.RomanAssigner(Num2Convert, 100, 90, "C", "X");
			}
			else if (Num2Convert >= 40)
			{
				this.RomanAssigner(Num2Convert, 50, 40, "L", "X");
			}
			else if (Num2Convert >= 9)
			{
				this.RomanAssigner(Num2Convert, 10, 9, "X", "I");
			}
			else if (Num2Convert >= 4)
			{
				this.RomanAssigner(Num2Convert, 5, 4, "V", "I");
			}
			else if (Num2Convert < 1)
			{
				this.ListConverter();
				this.RomanList.Clear();
			}
			else
			{
				this.RomanAssigner(Num2Convert, 1, 0, "I", "I");
                
			}
		}
	}
}