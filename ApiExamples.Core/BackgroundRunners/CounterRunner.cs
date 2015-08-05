using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ApiExamples.Core.BackgroundRunners
{
    public class CounterRunner : BaseBackgroundRunner
    {
        public int CounterState { get; private set; }


        public void IncrementCounter(object state)
        {
            CounterState++;
        }

        public override void ProcessMessage(string descriptor, params object[] args)
        {
            if (descriptor == "start")
            {
                Timer timer = new Timer(IncrementCounter, null, 0, 1000);
            }
        }
    }
}
