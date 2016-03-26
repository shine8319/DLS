﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerProgram
{
    public static class CommandCenter
    {
        public static StaticCommand StateChanged { get; private set; }

        static CommandCenter()
        {
            StateChanged = new StaticCommand("StateChanged");
        }
    }
}
