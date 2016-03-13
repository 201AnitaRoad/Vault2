using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class Dweller : Topic
    {
        public string name;
        public KnowledgeBase kbase;

		public Dweller() {
			name = "none";
			kbase = new KnowledgeBase();
		}

		public Dweller(string n) {
			name = n;
			kbase = new KnowledgeBase();
		}

		public void receiveMessage(Message m) {
			kbase.inputMessage(m.t, m);
		}
    }
}
