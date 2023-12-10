using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantıOluştur2023
{
    public class Konum
    {
        private String locName;
        private String[] locEquip;

        public Konum(String locName, String[] locEquip)
        {
            this.locName = locName;
            this.locEquip = locEquip;
        }

        public void setLocName(String locname)
        {
            this.locName = locName;
        }

        public String getLocName()
        {
            return locName;
        }

        public void setLocEquip(String[] locEquip)
        {
            this.locEquip = locEquip;
        }

        public String[] getLocEquip()
        {
            return locEquip;
        }
    }
}
