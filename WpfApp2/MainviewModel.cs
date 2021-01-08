using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class MainviewModel
    {
        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public MainviewModel()
        {
            Inita();
        }

        public void Inita()
        {
            MyProperty = LocalDataAccess.GetInstance().GetTeachers()[0];
            
            Console.WriteLine(MyProperty);
        }

        



    }
}
