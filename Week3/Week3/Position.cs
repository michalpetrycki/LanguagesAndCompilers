namespace Week3
{
    /// <summary>
    /// A position in a file
    /// </summary>
    public class Position
    {

        public int LineNumber { get; set; }
        public int ColumnPosition { get; set; }

        public Position(int ln, int cp)
        {

            LineNumber = ln;
            ColumnPosition = cp;

        }

        public override string ToString()
        {
            return $"Line number: {LineNumber}: ; Position in the line: {ColumnPosition}";
        }

    }
}