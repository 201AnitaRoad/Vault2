using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Vault {
		public Room[,] rooms;

		static Room DormitoryTemplate = new Room("Dormitory");
		static Room MessHallTemplate = new Room("Mess Hall");
		static Room GymnasiumTemplate = new Room("Gymnasium");

		public Vault() {
			rooms = new Room[3, 3];
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					rooms[i, j] = new Room();
				}
			}
			rooms[2, 0] = new Room(DormitoryTemplate);
			rooms[2, 1] = new Room(MessHallTemplate);
			rooms[2, 2] = new Room(GymnasiumTemplate);
		}
	}
}
