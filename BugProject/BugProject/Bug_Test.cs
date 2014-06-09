using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace BugProject
{
    /// <summary>
    /// File name: Bug_Test.cs
    /// Description: Test class for basic Bug
    /// How to use: 
    /// Author: TrungDQ
    /// </summary>
    class Bug_Test : Bug
    {
        public Bug_Test()
        {
            AppearLocation(500, 500);
            this.MoveBug(700, 700, 10, (r) => done(r));
            
        }

        private object done(bool r)
        {
            return null;
        }
    }
}
