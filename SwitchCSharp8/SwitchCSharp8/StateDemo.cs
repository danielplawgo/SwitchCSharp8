using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCSharp8
{
    class StateDemo
    {
        public void Run()
        {
            var state = State.Canceled;
            var operation = Operation.Cancel;

            state = (state, operation) switch
            {
                (State.Created, Operation.Process) => State.Processing,
                (State.Processing, Operation.Deliver) => State.Processed,
                (State.Canceled, _) => throw new InvalidOperationException(),
                (_, Operation.Cancel) => State.Canceled,
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine(state);
        }
    }

    public enum State
    {
        Created,
        Processing,
        Processed,
        Canceled
    }

    public enum Operation
    {
        Process,
        Deliver,
        Cancel
    }
}
