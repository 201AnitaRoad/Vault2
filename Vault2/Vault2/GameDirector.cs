using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class GameDirector {
		//WHAT THE GAME DIRECTOR IS STORING
		//FUNCTIONALLY: THE GAME STATE
		public List<Dweller> dwellers;
		public DispositionMap map;
		public List<Day> history;
		public Day currentDay;
		public Vault vault;
		public EventBase events;

		//CONTEMPTIBLE UI JUNK
		public enum View { VaultMap, DwellerProfile, DispositionMap, History, Help, NewDay }
		public struct ViewState {
			public View current;
			public View previous;
		}
		public Dweller currentDweller;
		public ViewState viewState;

		public GameDirector() {
			//UI JUNK
			viewState = new ViewState { };
			viewState.current = View.NewDay;
			viewState.previous = View.Help;

			//GLORIOUS GAMESTATE INITIATION
			dwellers = new List<Dweller>();
			dwellers.Add(new Dweller("Chadwick"));
			dwellers.Add(new Dweller("Steve"));
			dwellers.Add(new Dweller("Dan"));
			map = new DispositionMap(dwellers);
			currentDay = new Day(0);
			events = new EventBase();
			
			Event.Impression firstDayImpression;
			firstDayImpression.dweller = new Dweller("World");
			firstDayImpression.disposition = new Disposition(0, 0, 0, 2);
			currentDay.events.Add(new Event("The Vault is founded!", firstDayImpression));
			currentDay = determineDay(currentDay);
			history = new List<Day>();
			vault = new Vault();
			currentDweller = dwellers[0];
			startDay(currentDay);
		}

		public Day determineDay(Day d) {
			Random seed = new Random();
			int globals = Convert.ToInt32((4 * seed.NextDouble()));
			int individ = Convert.ToInt32((4 * seed.NextDouble()));
			int pair = Convert.ToInt32((4 * seed.NextDouble()));
			for (int i = 0; i < globals; i++) {
				d.events.Add(events.getRandomGlobal());
			}
			return d;
		}

		public void startDay(Day d){
			history.Add(d);
		}

	}
}
