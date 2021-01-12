using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

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
            this.RefreshViewValueFromDatabase();
        }

        public void Inita()
        {



            MyProperty = LocalDataAccess.GetInstance().GetTeachers()[1];

            Console.WriteLine(MyProperty);


            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new System.Timers.ElapsedEventHandler(dt_Tick);
            //aTimer.Interval = 1000;//每秒执行一次
            //aTimer.Enabled = true;
            //void dt_Tick(object sender, EventArgs e)
            //{

            //    MyProperty = LocalDataAccess.GetInstance().GetTeachers()[1];
            //    Console.WriteLine(MyProperty);
            //}



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


            
        }



    }
}
