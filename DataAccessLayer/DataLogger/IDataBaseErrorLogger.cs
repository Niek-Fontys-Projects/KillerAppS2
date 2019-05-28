namespace DataLayer.DataLogger
{
    internal interface IDataBaseErrorLogger
    {
        void DataBaseErrorLogger(string _query, string _errorMessage, string _callStack, string _dateTime);
    }
}