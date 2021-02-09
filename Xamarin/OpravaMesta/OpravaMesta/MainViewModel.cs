using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OpravaMesta
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string meno = "Meno";
        private string priezvisko = "Priezvisko";
        private string mesto = "Mesto";
        private int hodnotenie = 0;
        private int prispevky = 0;

        public string Meno
        {
            get { return meno; }
            set { meno = value; }
        }

        public string Priezvisko
        {
            get { return priezvisko; }
            set { priezvisko = value; }
        }

        public string Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        public int Hodnotenie
        {
            get { return hodnotenie; }
            set { hodnotenie = value; }
        }

        public int Prispevky
        {
            get { return prispevky; }
            set { prispevky = value; }
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
