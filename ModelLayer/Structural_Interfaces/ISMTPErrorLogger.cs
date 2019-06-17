using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public interface ISMTPErrorLogger
    {
        void LogSMTPError(string _client, string _fromAddress, string _subject, string _content, string _toAddress, string _time);
    }
}
