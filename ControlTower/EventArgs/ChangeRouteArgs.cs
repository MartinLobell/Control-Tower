/// Assignment 5
/// Martin Lobell
/// 2020-05-14

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class ChangeRouteArgs:EventArgs
    {
        private string m_flightCode;
        private string m_status;

        public ChangeRouteArgs(string flightcode, string status)
        {
            m_flightCode = flightcode;
            m_status = status;
        }

        public string FlightCode
        {
            get { return m_flightCode; }
            set { m_flightCode = value; }
        }

        public string Status
        {
            get { return m_status; }
            set { m_status = value; }
        }
    }
}