using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ApiExamples.Core.BackgroundRunners
{

    public abstract class BaseBackgroundRunner
    {
        private struct Message
        {
            public string Descriptor;
            public object[] Args;
        } 

        private Queue<Message> _messageQueue = new Queue<Message>();

        public BaseBackgroundRunner()
        {
            PushMessage("start", null);
        }

        public void PushMessage(string  descriptor, params object[] args)
        {
           _messageQueue.Enqueue(new Message { Descriptor = descriptor, Args = args }); 
        }

        private void PopMessage(object state) {
            if (_messageQueue.Count > 0)
            {
                Message m = _messageQueue.Dequeue();
                ProcessMessage(m.Descriptor, m.Args);
            }
        }

        public void Run()
        {
            Timer timer = new Timer(PopMessage, null, 0, 100);
        }

        public virtual void ProcessMessage(string descriptor, params object[] args)
        {
            // main loop
        }
    }
}
