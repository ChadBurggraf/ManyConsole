﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;

namespace ManyConsole.Tests
{
    public class InlinedCommand : ConsoleCommand
    {
        private InlinedCommand(string commandText = "", string oneLineDescription = "", string remaingArgumentsHelpText = "", OptionSet options = null, Func<int> runAction = null)
        {
            this.IsCommand(commandText, oneLineDescription);
            Options = options ?? new OptionSet();
            RunAction = runAction ?? delegate { return 0; };

            HasAdditionalArguments(0, remaingArgumentsHelpText);
        }

        private Func<int> RunAction;

        public override int Run(string[] remainingArguments)
        {
            return RunAction();
        }
    }
}
