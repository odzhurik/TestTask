using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services
{
    public interface IUrlParser
    {
        SortedSet<string> AllUrls { get; set; }
        SortedSet<string> LevelUrls { get; set; }
        SortedSet<string> PageUrls { get; set; }
        string Domain { get; set; }
        int Depth { get; set; }
        SortedSet<string> GetAllUrls();
    }
}
