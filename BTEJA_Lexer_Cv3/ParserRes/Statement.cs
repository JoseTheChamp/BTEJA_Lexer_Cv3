﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public abstract class Statement
    {
        public abstract void Execute(ExecutionContextC executionContextC);
    }
}
