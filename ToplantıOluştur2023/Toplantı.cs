using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantıOluştur2023
{
    public class Toplantı
    {
        private Katılımcı mInit;
        private String mName;
        private String mDesc;
        private List<Katılımcı> participantsList;
        private String meetingSlot;
        private List<String> prefSlot;
        private List<String> excSlot;
        private Konum loc;

        public Toplantı()
        {
            mInit = null;
            mName = "";
            mDesc = "";
            participantsList = new List<Katılımcı>();
            meetingSlot = "";
            excSlot = new List<String>();
            prefSlot = new List<String>();
            loc = null;
        }

        public Toplantı(Katılımcı mInit, String mName, String mDesc, List<Katılımcı> participantsList, String meetingSlot, List<String> prefSlot, List<String> excSlot, Konum loc)
        {
            this.mInit = mInit;
            this.mName = mName;
            this.mDesc = mDesc;
            this.participantsList = participantsList;
            this.meetingSlot = meetingSlot;
            this.excSlot = excSlot;
            this.prefSlot = prefSlot;
            this.loc = loc;
        }

        public void setMeetingInit(Katılımcı mInit)
        {
            this.mInit = mInit;
        }

        public Katılımcı getMeetingInit()
        {
            return mInit;
        }

        public void setMeetingName(String mName)
        {
            this.mName = mName;
        }

        public String getMeetingName()
        {
            return mName;
        }

        public void setMeetingDesc(String mDesc)
        {
            this.mDesc = mDesc;
        }

        public String getMeetingDesc()
        {
            return mDesc;
        }

        public void addParticipantList(Katılımcı pa)
        {
            participantsList.Add(pa);
        }

        public void removeParticipantList(Katılımcı pa)
        {
            participantsList.Remove(pa);
        }

        public void setParticipantList(List<Katılımcı> participantsList)
        {
            this.participantsList = participantsList;
        }

        public List<Katılımcı> getParticipantsList()
        {
            return participantsList;
        }

        public void setSlot(String meetingSlot)
        {
            this.meetingSlot = meetingSlot;
        }

        public String getSlot()
        {
            return meetingSlot;
        }

        public void addPrefList(String ps)
        {
            prefSlot.Add(ps);
        }

        public void removePrefList(String ps)
        {
            prefSlot.Remove(ps);
        }

        public void setPrefList(List<String> prefSlot)
        {
            this.prefSlot = prefSlot;
        }

        public List<String> getPrefList()
        {
            return prefSlot;
        }

        public void addexcList(String ps)
        {
            excSlot.Add(ps);
        }

        public void removeexcList(String ps)
        {
            excSlot.Remove(ps);
        }

        public void setExcluList(List<String> excSlot)
        {
            this.excSlot = excSlot;
        }

        public List<String> getExcluSlotList()
        {
            return excSlot;
        }

        public void setLocation(Konum loc)
        {
            this.loc = loc;
        }

        public Konum getLocation()
        {
            return loc;
        }

    }
}
