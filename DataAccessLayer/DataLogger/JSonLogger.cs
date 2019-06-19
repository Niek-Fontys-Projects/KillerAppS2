using ModelLayer.Structural_Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DataLayer.DataLogger
{
    internal class JSonLogger : IDataBaseErrorLogger, ISMTPErrorLogger
    {
        private string errorLogLocation;

        internal JSonLogger(string _errorLogLocation)
        {
            errorLogLocation = _errorLogLocation;
        }

        private void Write(string _section, JObject _error)
        {
            bool successFull = false;
            while (!successFull)
            {
                try
                {
                    JObject dbErrors = JObject.Parse(File.ReadAllText(errorLogLocation));
                    ((JArray)((JObject)dbErrors["errorlog"])[_section]).Add(_error);
                    StreamWriter stream = new StreamWriter(errorLogLocation);
                    stream.Write(JsonConvert.SerializeObject(dbErrors, Formatting.Indented));
                    stream.Close();
                    successFull = true;
                }
                catch { System.Threading.Thread.Sleep(10); }
            }
        }

        public void LogDataBaseError(string _query, string _errorMessage, string _dateTime)
        {
            JObject error = new JObject();
            error.Add("query", _query);
            error.Add("errormessage", _errorMessage);
            error.Add("datetime", _dateTime);
            Write("database", error);
        }

        public void LogSMTPError(string _client, string _fromAddress, string _subject, string _content, string _toAddress, string _time)
        {
            JObject error = new JObject();
            error.Add("client", _client);
            error.Add("fromaddress", _fromAddress);
            error.Add("subject", _subject);
            error.Add("content", _content);
            error.Add("toaddress", _toAddress);
            error.Add("time", _time);
            Write("smtpclient", error);
        }
    }
}
