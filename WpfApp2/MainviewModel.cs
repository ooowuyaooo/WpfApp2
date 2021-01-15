using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using LiveCharts;

namespace WpfApp2
{
    public class MainviewModel : NotifyBase
    {
        private string myVar="";

       

        public string MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                this.DoNotify();
            }
        }

        private ChartValues<double> _firstChartValues ;

        public ChartValues<double> FirstChartValues
        {
            get { return _firstChartValues; }
            set { _firstChartValues = value; this.DoNotify(); }
        }





        private string myVar1 = "";



        public string MyProperty1
        {
            get { return myVar1; }
            set
            {
                myVar1 = value;
                this.DoNotify();
            }
        }

        bool taskSwitch = true;
        List<Task> taskList = new List<Task>();

        public MainviewModel()
        {
            //Inita();
            

            FirstChartValues = new ChartValues<double>();

            this.RefreshViewValueFromDatabase();
        }

        

        private void RefreshViewValueFromDatabase()
        {
            var task = Task.Factory.StartNew(new Action(async () =>
            {
                while (taskSwitch)
                {
                    MyProperty = LocalDataAccess.GetInstance().GetTeachers()[0];

                    if (LocalDataAccess.GetInstance().GetBigdoorstatus()[0] == "off")
                    {
                        MyProperty1 = "已关闭";
                    }
                    else
                    {
                        MyProperty1 = "已打开";
                    }

                    await Task.Delay(3000);
                }
            }));
            taskList.Add(task);

            var task1 = Task.Factory.StartNew(new Action(async () =>
            {
                while (taskSwitch)
                {

                    double point1 = double.Parse(LocalDataAccess.GetInstance().GetTeachers()[0]);
                    FirstChartValues.Add(point1);



                    await Task.Delay(10000);
                }
            }));
            taskList.Add(task1);




        }


       


        


    }
}
