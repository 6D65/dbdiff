using report_extractor;
using report_extractor.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dbdiff
{
    class Program
    {
        static void Main(string[] args)
        {
            RedgateReport report = new RedgateReport("report.xml");
            List<string> changedTables = report.GetChangedTables();

            //foreach (var table in changedTables)
            //{
            //    Console.WriteLine(table);
            //}

            var tableNames = changedTables.Select(x => x.Remove(0, 7)).Select(x => x.Remove(x.Length - 1)).ToList();
            commandline commandLine = new commandline
            {
                username1 = "name",
                password1 = "password",
                database1 = "database",

                username2 = "name",
                password2 = "password",
                database2 = "database",

                include = tableNames[0],
                exclude = string.Join(",", tableNames.Skip(1).ToList())
            };

            new XmlSerializer(typeof(commandline)).Serialize(Console.Out, commandLine);
            Console.ReadLine();
        }
    }
}
