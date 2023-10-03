using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class AgendaItem
    {
        public string Id
        {
            set; get;
        }

        public string Nume
        {
            set; get;
        }

        public string Descriere
        {
            set; get;
        }

        public string DataScadenta
        {
            set; get;
        }

        public string Prioritate
        {
            set; get;
        }


        override public string ToString()
        {
            return Id  + Nume + Descriere + DataScadenta + Prioritate;
        }

        public string NumeSiTelefon
        {
            get
            {
                return Id + Nume + Descriere + DataScadenta + Prioritate;
            }
        }

    }
}