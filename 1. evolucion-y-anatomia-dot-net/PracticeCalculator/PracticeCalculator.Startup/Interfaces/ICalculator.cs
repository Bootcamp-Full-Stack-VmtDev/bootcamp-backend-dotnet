using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCalculator.Startup.Interfaces
{
    public interface ICalculator
    {
        void ShowMenu();
        double GetNumber(string value);
        void Start();
    }
}
