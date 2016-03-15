using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Day {
		public int number;
		public List<Event> events;
		public Day() { }
		public Day(int num) {
			number = num;
			events = new List<Event>();
		}
	}
}
