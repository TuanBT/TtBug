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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Bug_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(37, 37);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Bug_Test";
            this.ResumeLayout(false);

        }
    }
}
