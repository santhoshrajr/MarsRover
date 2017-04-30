using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Controller class contians information on the letters passed by NASA to control the Rover.
    /// </summary>
    public class Controller
    {
        private string _commands;
        public Controller(string _commands)
        {
            this._commands = _commands;
        }

        public string getCommands()
        {
            return _commands;
        }
    }
}
