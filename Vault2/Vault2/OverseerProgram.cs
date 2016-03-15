using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class OverseerProgram
    {

        static void Main(string[] args)
        {
			GameDirector g = new GameDirector();

			do{
				g.map = new DispositionMap(g.dwellers);
				drawConsole(g);
				g = queryInput(g);
			} while(true);

			Console.Write("We're outside the game loop!");
			Console.Read();
        }

		static void drawConsole(GameDirector g) {
			GameDirector.View current = g.viewState.current;
			Console.Clear();
			//Console.WriteLine("Day " + g.currentDay.number + " // Vault 815\n\n");
			switch (current) {
				case GameDirector.View.NewDay: {
					Console.WriteLine("\n\n\n");
					staggerWriteLine("\t\tDay " + g.currentDay.number + " //\n\t\tVault 815\n\n\n");
					foreach (Event e in g.currentDay.events) {
						staggerWriteLine("\t"+e.description);
					}
					Console.WriteLine("\n\n");
					break;
				};
				case GameDirector.View.DwellerProfile: {
					Console.WriteLine("Dweller Profile: ");
					Console.WriteLine("\t" + g.currentDweller.name);
					Console.WriteLine("\n");
					Console.WriteLine("\tMemories: ");
					break;
				};
				case GameDirector.View.VaultMap: {
					Console.WriteLine("Vault Map");
					Console.WriteLine("\n");
					for (int i = 0; i < 3; i++) {
						for (int k = 0; k < 5; k++) {
							for (int j = 0; j < 3; j++) {
								if (k == 2) {
									Console.Write("[  " + g.vault.rooms[i, j].name.Substring(0, 1) + "  ] ");
								}
								else {
									Console.Write("[     ] ");
								}
							}
							Console.Write("\n");
						}
						Console.Write("\n");
					}
					break;
				};
				case GameDirector.View.DispositionMap:{
					Console.WriteLine("Disposition Map");
					break;
				};
				case GameDirector.View.History: {
					Console.WriteLine("History Overview");
					Console.WriteLine("\n");
					foreach (Day d in g.history) {
						Console.WriteLine("\tDay " + d.number + ", Vault 815");
						foreach (Event e in d.events) {
							Console.WriteLine("\t\t" + e.description);
						}
					}
					break;
				};
				case GameDirector.View.Help: {
					Console.WriteLine("Console Commands");
					Console.WriteLine("\n");
					Console.WriteLine("[v]ault\n\tDisplays a map and overview of the vault.");
					Console.WriteLine("[r]ecord\n\tDisplays the history of the vault.");
					Console.WriteLine("[d]isposition\n\tDisplays the disposition matrix of vault\n\tinhabitants.");
					Console.WriteLine("[p]rofile NAME\n\tDisplays a profile of the named dweller.");
					Console.WriteLine("[h]elp\n\tDisplays the usable console commands.");
					Console.WriteLine("[t]urn\n\tAdvance to the next turn, ending the day.");
					Console.WriteLine("[b]ack\n\tReturns the to previous view.");
					break;
				};
			}
		}

		static GameDirector queryInput(GameDirector g) {
			Console.WriteLine("\n====");
			Console.Write("> ");
			GameDirector newState = processInput(g, Console.ReadLine());
			return newState;
		}

		static GameDirector processInput(GameDirector g, string input) {
			input = input.ToLower();
			string[] parsedinput = input.Split(' ');
			GameDirector temp = new GameDirector();

			GameDirector.ViewState newState = temp.viewState;
			newState.previous = g.viewState.previous;
			newState.current = g.viewState.current;
			switch (parsedinput[0]) {
				case "v": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.VaultMap;
						break;
					};
				case "vault": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.VaultMap;
						break;
					};
				case "p": {
						bool foundProfile = false;
						foreach (Dweller d in g.dwellers) {
							if (d.name.Equals(parsedinput[1].ToLower())) {
								g.currentDweller = d;
								foundProfile = true;
							}
						}
						if (foundProfile) {
							newState.previous = g.viewState.current;
							newState.current = GameDirector.View.DwellerProfile;
						}
						break;
					}
				case "profile": {
						bool foundProfile = false;
						foreach (Dweller d in g.dwellers) {
							if (d.name.Equals(parsedinput[1].ToLower())) {
								g.currentDweller = d;
								foundProfile = true;
							}
						}
						if (foundProfile) {
							newState.previous = g.viewState.current;
							newState.current = GameDirector.View.DwellerProfile;
						}
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.DwellerProfile;
						break;
					};
				case "d": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.DispositionMap;
						break;
					};
				case "disposition": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.DispositionMap;
						break;
					};
				case "r": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.History;
						break;
					};
				case "record": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.History;
						break;
					};
				case "h": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.Help;
						break;
					};
				case "help": {
						newState.previous = g.viewState.current;
						newState.current = GameDirector.View.Help;
						break;
					};
				case "b": {
						newState.current = g.viewState.previous;
						newState.previous = g.viewState.current;
						break;
					};
				case "back": {
						newState.current = g.viewState.previous;
						newState.previous = g.viewState.current;
						break;
					};
				default: {
						newState = g.viewState;
						break;
					};
			}
			g.viewState = newState;
			return g;
		}

		public static void staggerWriteLine(string s) {
			for (int i = 0; i < s.Length; i++) {
				Console.Write(s.Substring(i, 1));
				System.Threading.Thread.Sleep(40);
			}
			Console.Write("\n");
		}
    }
}
