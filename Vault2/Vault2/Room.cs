using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Room {
		public string name;
		//public double condition;

		public Room() {
			name = "empty";	
		}

		public Room(string n) {
			name = n;
		}

		public Room(Room r) {
			name = r.name;
		}
	}
}
