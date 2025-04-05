using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;


namespace Northwind.DataContext.SqlServer
{
    public class NorthwindContextLogger
    {
        public static void WriteLine(string message)
        {
            string path = Path.Combine(GetFolderPath(SpecialFolder.DesktopDirectory), "Northwindlog.txt");
            StreamWriter textFile = File.AppendText(path);
            textFile.WriteLine(message);
            textFile?.Close();
        }
    }
}
