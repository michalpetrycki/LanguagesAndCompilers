using System;
using System.Collections.Generic;

namespace Week3.IO
{
    /// <summary>
    /// An object for reporting errors in the compilation process
    /// </summary>
    public class ErrorReporter
    {
        /// <summary>
        /// Whether or not any errors have been encountered
        /// </summary>
        public bool HasErrors { get; set; }

        public int ErrorsNumber { get { return Errors.Count;  } }

        public List<ErrorOccured> Errors = new List<ErrorOccured>();

        public void RecordAndReportError(string message, Position tokenPosition)
        {
            Console.WriteLine($"Error occured: {message} at line: {tokenPosition.LineNumber} at position: {tokenPosition.ColumnPosition}");
            Errors.Add(new ErrorOccured(message, tokenPosition));
        }

    }

    public class ErrorOccured
    {

        public string ErrorMessage { get; set; }
        public Position Position { get; set; }

        public ErrorOccured(string m, Position p)
        {
            ErrorMessage = m;
            Position = p;
        }

    }
}