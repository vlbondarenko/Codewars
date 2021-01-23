using System;
using System.Collections.Generic;


namespace TCP_FinitieStateMachine_ClassLibrary
{
    public class TCP
    {
        public static string TraverseStates(string[] events)
        {
            var state = "CLOSED";
            var stateMachine = new StateMachine(state);

            state = stateMachine.OnEvents(events);

            return state;
        }
    }

   

    public sealed class StateMachine
    {
      
        private Dictionary<string, List<Rule>> _stringRules;
        private string _currentState;

        public string CurrentState { get { return _currentState; } }

        public StateMachine(string initialState)
        {
            InitializeRules();
            if (_stringRules.ContainsKey(initialState))
                _currentState = initialState;
            else
                throw new Exception();
        }



        private void InitializeRules()
        {
            _stringRules = new Dictionary<string, List<Rule>>
            {
                 { "CLOSED",  new List<Rule> {new Rule { Event = "APP_PASSIVE_OPEN" , NextState = "LISTEN"},new Rule { Event = "APP_ACTIVE_OPEN", NextState = "SYN_SENT" } }},
                 { "LISTEN",  new List<Rule> {new Rule { Event = "RCV_SYN", NextState = "SYN_RCVD" },new Rule { Event = "APP_SEND", NextState = "SYN_SENT" },new Rule { Event = "APP_CLOSE", NextState = "CLOSED" }}},
                 { "SYN_RCVD",  new List<Rule>  {new Rule { Event = "APP_CLOSE" , NextState = "FIN_WAIT_1" },new Rule { Event = "RCV_ACK", NextState = "ESTABLISHED" } }},
                 { "SYN_SENT",  new List<Rule> {new Rule { Event = "RCV_SYN", NextState = "SYN_RCVD" },new Rule { Event = "RCV_SYN_ACK", NextState = "ESTABLISHED" },new Rule { Event = "APP_CLOSE", NextState = "CLOSED" }}},
                 { "ESTABLISHED",  new List<Rule>  {new Rule { Event = "APP_CLOSE" , NextState = "FIN_WAIT_1" },new Rule { Event = "RCV_FIN", NextState = "CLOSE_WAIT" } }},
                 { "FIN_WAIT_1",  new List<Rule> {new Rule { Event = "RCV_FIN", NextState = "CLOSING" },new Rule { Event = "RCV_FIN_ACK", NextState = "TIME_WAIT" },new Rule { Event = "RCV_ACK", NextState = "FIN_WAIT_2" }}},
                 { "CLOSING",  new List<Rule> {new Rule { Event = "RCV_ACK", NextState = "TIME_WAIT" }}},
                 { "FIN_WAIT_2",  new List<Rule> {new Rule { Event = "RCV_FIN", NextState = "TIME_WAIT" }}},
                 { "TIME_WAIT",  new List<Rule> {new Rule { Event = "APP_TIMEOUT", NextState = "CLOSED" } }},
                 { "CLOSE_WAIT",  new List<Rule> {new Rule { Event = "APP_CLOSE", NextState = "LAST_ACK" } }},
                 { "LAST_ACK",  new List<Rule> {new Rule { Event = "RCV_ACK", NextState = "CLOSED" } }},
            };
        }

        public string OnEvents(string[] newEvents)
        {
            foreach (var ev in newEvents)
            {
                OnEvent(ev);
                if (_currentState == "ERROR")
                    return _currentState;
            }

            return _currentState;  
        }

        private void OnEvent(string newEvent)
        {
            var supportedRules = _stringRules[_currentState];
            var rule = supportedRules.Find(r => r.Event == newEvent);

            if (rule != null)
                _currentState = rule.NextState;
            else
                _currentState = "ERROR";

        }

        class Rule
        {
            public string Event;
            public string NextState;
        }
    }
}


