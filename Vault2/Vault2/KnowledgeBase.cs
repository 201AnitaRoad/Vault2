using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class KnowledgeBase
    {
        Dictionary<Dweller, List<Event>> knowledge;

		public KnowledgeBase() {
			knowledge = new Dictionary<Dweller, List<Event>>();
		}

        public bool knowsDweller(Dweller t){
            return knowledge.ContainsKey(t);
        }

		//presumes knowsTopic sanitation has occurred
		public List<Event> getEvents(Dweller t) {
			List<Event> messages = new List<Event>();
			knowledge.TryGetValue(t, out messages);
			return messages;
		}

        public bool knowsMessage(Dweller t, Event m){
            if (!knowsDweller(t)){
                return false;
            }
            else{
				return getEvents(t).Contains(m);
            }
        }

        public void inputMessage(Event m){
			List<Event.Impression> impressions = m.impressions;
			foreach (Event.Impression i in impressions) {
				Dweller t = i.dweller;
				if (knowsDweller(t)) {
					if (knowsMessage(t, m)) {
						//Nothing happens; they have the equivalent memory
					}
					else {
						List<Event> newMessages = getEvents(t);
						newMessages.Add(m);
						knowledge.Remove(t);
						knowledge.Add(t, newMessages);
					}
				}
				else {
					List<Event> newMessages = new List<Event>();
					newMessages.Add(m);
					knowledge.Add(t, newMessages);
				}
			}
        }

    }
}
