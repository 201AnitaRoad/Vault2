using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class Message
    {
		public int dispmod;
		public string desc;
		public Topic t;

		public Message() { }
		public Message(Topic tp, int m, string d) {
			t = tp;
			dispmod = m;
			desc = d;
		}
    }
}
