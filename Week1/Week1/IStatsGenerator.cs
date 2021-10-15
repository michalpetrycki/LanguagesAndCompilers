using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    interface IStatsGenerator<T>
    {

        int GetLineCount();
        int GetCharacterCount();
        string GetEndLine();
        string GetFirstWord();
        int GetWordCount();
        string GetFirstLetter();


    }
}
