﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailboxLogParser.Common.Parsing.Objects
{
    public class ParsedObjectBase
    {
        public ParsedObjectType ParsedObjectType { get; private set; }

        protected ParsedObjectBase(ParsedObjectType type)
        {
            this.ParsedObjectType = type;
        }
    }
}
