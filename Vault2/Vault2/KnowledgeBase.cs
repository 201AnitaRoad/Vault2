using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class KnowledgeBase
    {
        Dictionary<Topic, List<Message>> knowledge;

		public KnowledgeBase() {
			knowledge = new Dictionary<Topic, List<Message>>();
		}

        public bool knowsTopic(Topic t){
            return knowledge.ContainsKey(t);
        }

		//presumes knowsTopic sanitation has occurred
		public List<Message> getMessages(Topic t) {
			List<Message> messages = new List<Message>();
			knowledge.TryGetValue(t, out messages);
			return messages;
		}

        public bool knowsMessage(Topic t, Message m){
            if (!knowsTopic(t)){
                return false;
            }
            else{
				return getMessages(t).Contains(m);
            }
        }

        public bool inputMessage(Topic t, Message m){
            if (knowsTopic(t)){
				if (knowsMessage(t, m)) {
					return false;
				}
				else {
					List<Message> newMessages = getMessages(t);
					newMessages.Add(m);
					knowledge.Remove(t);
					knowledge.Add(t, newMessages);
				}
            }
			else{
				List<Message> newMessages = new List<Message>();
				newMessages.Add(m);
				knowledge.Add(t, newMessages);
			}
			return true;
        }

    }
}
