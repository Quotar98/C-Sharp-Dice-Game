using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_kosci_tutorial
{
    public class Score : NotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _points;

        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnProperyChanged();
            }
        }

        private bool _isSet;

        public bool IsSet
        {
            get { return _isSet; }
            set
            {
                _isSet = value;
                OnProperyChanged();
            }
        }
        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                OnProperyChanged();
            }
        }

        public Score(string name)
        {
            Name = name;
            Points = 0;
            IsSet = false;
            IsEnabled = true;
        }
    }
}