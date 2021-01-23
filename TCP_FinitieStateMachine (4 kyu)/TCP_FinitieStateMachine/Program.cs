using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_FinitieStateMachine_ClassLibrary;

namespace TCPFinitieStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TCPFinitieStateMachineClassLibrary.TraverseStates(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN" }));
        }
    }
}
