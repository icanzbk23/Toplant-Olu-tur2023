using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace ToplantıOluştur2023
{
    public partial class Form1 : Form
    {
        //Random kod oluşturucu
        private bool kodOlusturucuAktif = false;
        //toplantıların listesi
        List<Toplantı> meetingList = new List<Toplantı>();

        //Burada Çalışan üyelere yer verdim
        Kisi p1 = new Kisi("Can Zeybek");
        Kisi p2 = new Kisi("Aslı Aslan");
        Kisi p3 = new Kisi("Leyla Kurtulmuş");
        Kisi p4 = new Kisi("Timur Güçlü");
        Kisi p5 = new Kisi("Murat Atıl");

        //Konumlar kısmı
        static String[] equipList1 = new String[2] { "Bilgisayar", "Projektör" };
        Konum cantor1 = new Konum("1 Numaralı Oda", equipList1);
        static String[] equipList2 = new String[2] { "Apple Mac", "Akıllı Tahta" };
        Konum cantor2 = new Konum("2 Numaralı Oda", equipList2);
        static String[] equipList3 = new String[3] { "Bilgisayar", "Projektör", "Uzman Bilgisayar" };
        Konum cantor3 = new Konum("3 Numaralı Oda", equipList3);
        static String[] equipList4 = new String[4] { "Bilgisayar", "Projektör", "Apple Mac", "Akıllı Tahta" };
        Konum cantor4 = new Konum("4 Numaralı Oda", equipList4);
        static String[] equipList5 = new String[4] { "Projector", "Apple Mac", "Akıllı Tahta", "Uzman Bilgisayar" };
        Konum cantor5 = new Konum("5 Numaralı Oda", equipList5);
        static String[] equipList6 = new String[5] { "Bilgisayar", "Projektör", "Apple Mac", "Akıllı Tahta", "Uzman Bilgisayar" };
        Konum cantor6 = new Konum("6 Numaralı Oda", equipList6);

        //Toplantı oluşturma
        Katılımcı pa1 = new Katılımcı("Can Zeybek", true);
        Katılımcı pa2 = new Katılımcı("Alice Chambers", true);
        Katılımcı pa3 = new Katılımcı("Leyla Kurtulmuş", true);
        Katılımcı pa4 = new Katılımcı("Timur Güçlü", true);
        Katılımcı pa5 = new Katılımcı("Murat Atıl", true);

        Toplantı m10 = new Toplantı();
        List<Katılımcı> pL1 = new List<Katılımcı>();

        public Form1()
        {
            InitializeComponent();
            hardCoded();

            foreach (Toplantı m in meetingList)
            {
                Toplantı_Listesi.Items.Add(m.getMeetingName() + "\t\t" + m.getSlot());
            }

        }

        public void hardCoded()
        {
            //Toplantılar
            Katılımcı pa1 = new Katılımcı("Can Zeybek", true);
            Katılımcı pa2 = new Katılımcı("Aslı Aslan", true);
            Katılımcı pa3 = new Katılımcı("Leyla Kurtulmuş", false);
            Katılımcı pa4 = new Katılımcı("Timur Güçlü", false);
            Katılımcı pa5 = new Katılımcı("Murat Atıl", false);

            List<Katılımcı> paList1 = new List<Katılımcı>();
            paList1.Add(pa1);
            paList1.Add(pa2);
            paList1.Add(pa5);

            List<String> prefSlot1 = new List<String>();
            prefSlot1.Add("Monday 1pm");
            prefSlot1.Add("Monday 9am");

            List<String> excSlot1 = new List<String>();
            excSlot1.Add("Monday 2pm");
            excSlot1.Add("Monday 10am");

            Toplantı m1 = new Toplantı(pa1, "Pazarlama Toplantısı", "Yaklaşan pazarlama hedefleri hakkında toplantı", paList1, "Pazartesi 13.00", prefSlot1, excSlot1, cantor6);
            meetingList.Add(m1);

            ///////////////////////////////////////////

            List<Katılımcı> paList2 = new List<Katılımcı>();
            paList1.Add(pa3);
            paList1.Add(pa2);
            paList1.Add(pa4);

            List<String> prefSlot2 = new List<String>();
            prefSlot2.Add("Monday 11am");
            prefSlot2.Add("Monday 9am");

            List<String> excSlot2 = new List<String>();
            excSlot2.Add("Monday 1pm");
            excSlot2.Add("Monday 10am");
            excSlot2.Add("Monday 2pm");

            Toplantı m2 = new Toplantı(pa1, "Satış Toplantısı", "Yaklaşan satış hedefleri hakkında toplantı", paList2, "Pazartesi 11.00", prefSlot2, excSlot2, cantor2);
            meetingList.Add(m2);

            ////////////////////////////////////////////

            List<Katılımcı> paList3 = new List<Katılımcı>();
            paList3.Add(pa1);
            paList3.Add(pa5);
            paList3.Add(pa4);

            List<String> prefSlot3 = new List<String>();
            prefSlot3.Add("Monday 12pm");
            prefSlot3.Add("Monday 11am");

            List<String> excSlot3 = new List<String>();
            excSlot3.Add("Monday 9am");
            excSlot3.Add("Monday 10am");

            Toplantı m3 = new Toplantı(pa4, "Müşterilerle Toplantı", "Müşterilerle Toplantı", paList3, "Pazartesi 12.00", prefSlot3, excSlot3, cantor3);
            meetingList.Add(m3);
        }

        private void bookBut_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = true;
            kodOlusturucuAktif = true;

            //Toplantı oluşturma - ön alanı doldurma kısmı

            mName.Text = "Grup Toplantısı";
            mDesc.Text = "Grup Toplantısını Lütfen Katılım Gösteriniz !";
            checkBox6.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox17.Checked = false;
            checkBox16.Checked = false;
            checkBox15.Checked = false;
            checkBox14.Checked = false;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox18.Checked = true;
            checkBox19.Checked = true;
            checkBox20.Checked = true;
            checkBox21.Checked = true;
            checkBox22.Checked = true;
            checkBox7.Checked = true;
            checkBox13.Checked = true;
            checkBox12.Checked = true;
            listBox1.SelectedItem = "Apple Mac";
            listBox2.SelectedItem = "2.Oda";
            saveBut.Enabled = false;

            Katılımcı pg1 = new Katılımcı("Can Zeybek", true);
            Katılımcı pg2 = new Katılımcı("Aslı Aslan", true);
            Katılımcı pg3 = new Katılımcı("Leyla Kurtulmuş", true);
            Katılımcı pg4 = new Katılımcı("Timur Güçlü", true);
            Katılımcı pg5 = new Katılımcı("Murat Atıl", true);

            List<Katılımcı> paListGroupm = new List<Katılımcı>();
            paListGroupm.Add(pg1);
            paListGroupm.Add(pg2);
            paListGroupm.Add(pg3);
            paListGroupm.Add(pg4);
            paListGroupm.Add(pg5);

            List<String> prefSlotGroupm = new List<String>();
            prefSlotGroupm.Add("Monday 1pm");
            prefSlotGroupm.Add("Monday 9am");

            List<String> excSlotGroupm = new List<String>();
            excSlotGroupm.Add("Monday 2pm");
            excSlotGroupm.Add("Monday 10am");

        }

        private void meetingsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
            button5.Visible = true;


            switch (Toplantı_Listesi.SelectedIndex)
            {
                case 0:
                    {
                        checkBox23.Checked = false;
                        checkBox25.Checked = false;
                        checkBox26.Checked = false;
                        checkBox27.Checked = false;
                        checkBox30.Checked = false;
                        checkBox31.Checked = false;
                        checkBox33.Checked = false;
                        checkBox34.Checked = false;
                        checkBox24.Checked = true;
                        checkBox28.Checked = true;
                        checkBox29.Checked = true;
                        checkBox32.Checked = true;
                        break;
                    }
                case 1:
                    {
                        checkBox23.Checked = false;
                        checkBox24.Checked = false;
                        checkBox25.Checked = false;
                        checkBox26.Checked = false;
                        checkBox31.Checked = false;
                        checkBox33.Checked = false;
                        checkBox34.Checked = false;
                        checkBox27.Checked = true;
                        checkBox28.Checked = true;
                        checkBox29.Checked = true;
                        checkBox30.Checked = true;
                        checkBox32.Checked = true;
                        break;
                    }
                case 2:
                    {
                        checkBox23.Checked = false;
                        checkBox24.Checked = false;
                        checkBox26.Checked = false;
                        checkBox28.Checked = false;
                        checkBox29.Checked = false;
                        checkBox30.Checked = false;
                        checkBox31.Checked = false;
                        checkBox33.Checked = false;
                        checkBox25.Checked = true;
                        checkBox27.Checked = true;
                        checkBox32.Checked = true;
                        checkBox34.Checked = true;
                        break;
                    }
                case 3:
                    {
                        checkBox23.Checked = false;
                        checkBox24.Checked = false;
                        checkBox25.Checked = false;
                        checkBox26.Checked = false;
                        checkBox28.Checked = false;
                        checkBox31.Checked = false;
                        checkBox32.Checked = false;
                        checkBox33.Checked = false;
                        checkBox34.Checked = false;
                        checkBox27.Checked = true;
                        checkBox30.Checked = true;
                        checkBox29.Checked = true;
                        break;
                    }
                default:
                    {
                        checkBox23.Checked = false;
                        checkBox24.Checked = false;
                        checkBox25.Checked = false;
                        checkBox26.Checked = false;
                        checkBox27.Checked = false;
                        checkBox28.Checked = false;
                        checkBox29.Checked = false;
                        checkBox30.Checked = false;
                        checkBox31.Checked = false;
                        checkBox32.Checked = false;
                        checkBox33.Checked = false;
                        checkBox34.Checked = false;
                        break;
                    }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                m10.addParticipantList(pa1);
                checkBox18.Visible = true;
            }
            else
            {
                m10.removeParticipantList(pa1);
                checkBox18.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                m10.addParticipantList(pa2);
                checkBox19.Visible = true;
            }
            else
            {
                m10.removeParticipantList(pa2);
                checkBox19.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                m10.addParticipantList(pa3);
                checkBox20.Visible = true;
            }
            else
            {
                m10.removeParticipantList(pa3);
                checkBox20.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                m10.addParticipantList(pa4);
                checkBox21.Visible = true;
            }
            else
            {
                m10.removeParticipantList(pa4);
                checkBox21.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                m10.addParticipantList(pa5);
                checkBox22.Visible = true;
            }
            else
            {
                m10.removeParticipantList(pa5);
                checkBox22.Visible = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                pa1.setImportance(true);
            }
            else
            {
                pa1.setImportance(false);
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                pa2.setImportance(true);
            }
            else
            {
                pa2.setImportance(false);
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
                pa3.setImportance(true);
            }
            else
            {
                pa3.setImportance(false);
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                pa4.setImportance(true);
            }
            else
            {
                pa4.setImportance(false);
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                pa5.setImportance(true);
            }
            else
            {
                pa5.setImportance(false);
            }
        }


        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Pazartesi 9.00 - 15.00";

            if (checkBox17.Checked == false)
            {
                if (checkBox6.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Pazartesi 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Salı 9.00 - 15.00";

            if (checkBox15.Checked == false)
            {
                if (checkBox8.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Salı 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Çarşamba 9.00 - 15.00";

            if (checkBox16.Checked == false)
            {
                if (checkBox7.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Çarşamba 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Perşembe 9.00 - 15.00";

            if (checkBox14.Checked == false)
            {
                if (checkBox9.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Perşembe 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Cuma 9.00 - 15.00";

            if (checkBox13.Checked == false)
            {
                if (checkBox10.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Cuma 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Cumartesi 9.00 - 15.00";

            if (checkBox12.Checked == false)
            {
                if (checkBox11.Checked == true)
                {
                    m10.addPrefList(ps);
                    mReason.Text = "";
                    m10.setSlot("Cumartesi 9.00 - 15.00");
                }
                else
                {
                    m10.removePrefList(ps);
                    mReason.Text = "";
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 9am";

            if (checkBox6.Checked == false)
            {
                if (checkBox17.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {

                    m10.removeexcList(ps);
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 10am";

            if (checkBox8.Checked == false)
            {
                if (checkBox15.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {
                    m10.removeexcList(ps);
                }
            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 11am";

            if (checkBox7.Checked == false)
            {
                if (checkBox16.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {
                    m10.removeexcList(ps);
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 12pm";

            if (checkBox9.Checked == false)
            {
                if (checkBox14.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {
                    m10.removeexcList(ps);
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "Tercih saatleri çakışmaktadır, lütfen tekrar deneyiniz!";
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 1pm";

            if (checkBox10.Checked == false)
            {
                if (checkBox13.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {
                    m10.removeexcList(ps);
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "You cannot book this meeting with preference slots that are equal to exclusion slots. Try again";
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            String ps = "Monday 2pm";

            if (checkBox11.Checked == false)
            {
                if (checkBox12.Checked == true)
                {
                    m10.addexcList(ps);
                }
                else
                {
                    m10.removeexcList(ps);
                }

            }
            else
            {
                mname1.Text = mName.Text;
                mReason.Text = "You cannot book this meeting with preference slots that are equal to exclusion slots. Try again";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Computer":
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add(cantor1.getLocName());
                        listBox2.Items.Add(cantor3.getLocName());
                        listBox2.Items.Add(cantor4.getLocName());
                        listBox2.Items.Add(cantor6.getLocName());
                        break;
                    }
                case "Projector":
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add(cantor1.getLocName());
                        listBox2.Items.Add(cantor3.getLocName());
                        listBox2.Items.Add(cantor4.getLocName());
                        listBox2.Items.Add(cantor5.getLocName());
                        listBox2.Items.Add(cantor6.getLocName());
                        break;
                    }
                case "Apple Mac":
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add(cantor2.getLocName());
                        listBox2.Items.Add(cantor4.getLocName());
                        listBox2.Items.Add(cantor5.getLocName());
                        listBox2.Items.Add(cantor6.getLocName());
                        break;
                    }
                case "Whiteboard":
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add(cantor2.getLocName());
                        listBox2.Items.Add(cantor4.getLocName());
                        listBox2.Items.Add(cantor5.getLocName());
                        listBox2.Items.Add(cantor6.getLocName());
                        break;
                    }
                case "Specialist Software PC's":
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add(cantor3.getLocName());
                        listBox2.Items.Add(cantor5.getLocName());
                        listBox2.Items.Add(cantor6.getLocName());
                        break;
                    }
            }
        }
        // Aşağıdaki kısımda çakışan toplantılar için olsaı çözümlere ve onların sonuçlarına yer verdim.
        public void conflict()
        {
            if (pa1.getImportance() == true || pa2.getImportance() == true && checkBox7.Checked == true)
            {
                saveBut.Enabled = false;
                mname1.Text = mName.Text;
                mReason.Text = "Önemli katılımcılar şuan müsait değiller !";
                sol1.Text = "İlgili katılımcılar için önemi kaldırın";
                sol2.Text = "Tecih edilen slotu değiştirin";
                sol3.Text = "Belirlediğiniz katılımcının slotlarını değiştiriniz";
                sol4.Text = "Çakışan Toplantıların rezervasyonunu siliniz";
                sol5.Text = "Müsait olmayan katılımcıyı başka biriyle değiştiriniz";
            }
            saveBut.Enabled = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conflict();

            switch (listBox2.SelectedItem)
            {
                case "Cantor room 1":
                    {
                        m10.setLocation(cantor1);

                        break;
                    }

                case "Cantor room 2":
                    {
                        if (m10.getSlot() == "Monday 11am")
                        {
                            MessageBox.Show("Slot Monday 11am in Cantor Room 2 is taken", "Error!");
                            saveBut.Enabled = false;
                        }
                        else
                        {
                            m10.setLocation(cantor2);
                        }
                        break;
                    }

                case "Cantor room 3":
                    {
                        if (m10.getSlot() == "Monday 12pm")
                        {
                            MessageBox.Show("Slot Monday 12pm in Cantor Room 3 is taken", "Error!");
                            saveBut.Enabled = false;
                        }
                        else
                        {
                            m10.setLocation(cantor3);
                        }
                        break;
                    }

                case "Cantor room 4":
                    {
                        m10.setLocation(cantor4);
                        break;
                    }

                case "Cantor room 5":
                    {
                        m10.setLocation(cantor5);
                        break;
                    }

                case "Cantor room 6":
                    {
                        if (m10.getSlot() == "Monday 1pm")
                        {
                            MessageBox.Show("Slot Monday 1pm in Cantor Room 6 is taken", "Error!");
                            saveBut.Enabled = false;
                        }
                        else
                        {
                            m10.setLocation(cantor6);
                        }
                        break;
                    }

            }
        }

        private void solvBut1_Click(object sender, EventArgs e)
        {
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            mReason.Text = "";
            solvBut1.Enabled = false;
            saveBut.Enabled = true;
        }

        private void solveBut2_Click(object sender, EventArgs e)
        {
            checkBox7.Checked = false;
            checkBox6.Checked = true;
            mReason.Text = "";
            solveBut2.Enabled = false;
            saveBut.Enabled = true;

        }

        private void solveBut3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            solveBut3.Enabled = false;
            checkBox27.Checked = true;
            checkBox30.Checked = true;
            checkBox29.Checked = true;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = listBox3.SelectedItem.ToString();
            button3.Enabled = true;
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true)
            {
                checkBox6.Checked = true;
                m10.setSlot("Pazartesi 9.00-15.00");

            }
            else { checkBox6.Checked = false; }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked == true)
            {
                checkBox8.Checked = true;
                m10.setSlot("Salı 9.00-15.00");
            }
            else { checkBox8.Checked = false; }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                checkBox7.Checked = true;
                m10.setSlot("Çarşamba 9.00 - 15.00");
            }
            else { checkBox7.Checked = false; }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                checkBox9.Checked = true;
                m10.setSlot("Perşembe 9.00-15.00");
            }
            else { checkBox9.Checked = false; }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true)
            {
                checkBox10.Checked = true;
                m10.setSlot("Cuma 9.00-15.00");
            }
            else { checkBox10.Checked = false; }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                checkBox11.Checked = true;
                m10.setSlot("Cumartesi 9.00-15.00");
            }
            else { checkBox11.Checked = false; }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true)
            {
                checkBox17.Checked = true;
            }
            else { checkBox17.Checked = false; }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked == true)
            {
                checkBox15.Checked = true;
            }
            else { checkBox15.Checked = false; }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true)
            {
                checkBox16.Checked = true;
            }
            else { checkBox16.Checked = false; }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                checkBox14.Checked = true;
            }
            else { checkBox14.Checked = false; }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                checkBox13.Checked = true;
            }
            else { checkBox13.Checked = false; }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                checkBox12.Checked = true;
            }
            else { checkBox12.Checked = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveBut.Enabled = true;
            groupBox4.Visible = false;
        }

        private void solveBut4_Click(object sender, EventArgs e)
        {
            meetingList.RemoveAt(1);

            Toplantı_Listesi.Items.Clear();
            foreach (Toplantı m in meetingList)
            {
                Toplantı_Listesi.Items.Add(m.getMeetingName() + "\t\t" + m.getSlot());
            }

            mReason.Text = "";
            solveBut4.Enabled = false;
            saveBut.Enabled = true;
        }

        private void solveBut5_Click(object sender, EventArgs e)
        {

        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            m10.setMeetingName(mName.Text);
            m10.setMeetingDesc(mDesc.Text);

            meetingList.Add(m10);
            Toplantı_Listesi.Items.Clear();

            foreach (Toplantı m in meetingList)
            {
                Toplantı_Listesi.Items.Add(m.getMeetingName() + "\t\t" + m.getSlot());
            }

            groupBox3.Visible = false;
            groupBox2.Visible = false;
            clearForm();
        }

        public void clearForm()
        {
            mname1.Text = "";
            mReason.Text = "";
            mName.Text = "";
            mDesc.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox6.Checked = false;
            checkBox8.Checked = false;
            checkBox7.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            listBox2.Items.Clear();
            listBox2.Items.Add(cantor1.getLocName());
            listBox2.Items.Add(cantor2.getLocName());
            listBox2.Items.Add(cantor3.getLocName());
            listBox2.Items.Add(cantor4.getLocName());
            listBox2.Items.Add(cantor5.getLocName());
            listBox2.Items.Add(cantor6.getLocName());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            meetingList.RemoveAt(Toplantı_Listesi.SelectedIndex);

            Toplantı_Listesi.Items.Clear();
            foreach (Toplantı m in meetingList)
            {
                Toplantı_Listesi.Items.Add(m.getMeetingName() + "\t\t" + m.getSlot());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kodOlusturucuAktif)
            {
                // Burada kod oluşturucu işlemini gerçekleştirin
                // Örneğin, rastgele bir kod oluşturarak kullanıcıya gösterme:
                Random random = new Random();
                string randomCode = GenerateRandomCode(random);
                MessageBox.Show("Oluşturulan random kod: " + randomCode, "Kod Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kodOlusturucuAktif = false; // Kod oluşturucuyu tekrar pasif hale getir
            }
            else
            {
                MessageBox.Show("Önce toplantıyı  ayarlayın!"); // Kullanıcıya uyarı göster
            }
        }

        private string GenerateRandomCode(Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Kullanılabilecek karakterler
            int codeLength = 8; // Örneğin 8 karakter uzunluğunda bir kod oluşturulacak

            char[] code = new char[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new string(code);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
