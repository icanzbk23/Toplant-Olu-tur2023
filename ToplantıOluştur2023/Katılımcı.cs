using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantıOluştur2023
{
    public class Katılımcı
    {
        private String fullName;
        private bool important;


        public Katılımcı()
        {
            fullName = "";
            important = false;
        }

        public Katılımcı(String fullName, bool important)
        {
            this.fullName = fullName;
            this.important = important;
        }

        public void setFullName(String fullName)
        {
            this.fullName = fullName;
        }

        public String getFullName()
        {
            return fullName;
        }

        public void setImportance(bool important)
        {
            this.important = important;
        }

        public bool getImportance()
        {
            return important;
        }

    }
}
