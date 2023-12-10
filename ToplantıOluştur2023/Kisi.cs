using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantıOluştur2023
{
    public class Kisi
    {
        private String fullName;

        public Kisi(String fullName)
        {
            this.fullName = fullName;
        }

        public void setFullName(String fullName)
        {
            this.fullName = fullName;
        }

        public String getFullName()
        {
            return fullName;
        }

    }
}
