using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_StreamingSearch_App
{
    public class DatabaseQueryServiceStub
    {
        public static Show FindShow(string searchTerm)
        {
            return new Show() { Name = searchTerm };
        }
    }
}
