using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmer_crossing_the_river
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetListBoxDataSource();
            Farmerwhereleft();
            Farmerwhereright();
            gamefinish();
            ChangeData();
        }
        private void CreateList()
        {
            _leftList = new List<string>()
            {
                "農夫" ,"狼" ,"羊" ,"菜"
            };
            _rightList = new List<string>();
        }
        private void SetListBoxDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
        }
        private void Farmerwhereleft()
        {
            bool result_f = _leftList.Any((x) => x == "農夫");
            bool result_w = _leftList.Any((x) => x == "狼");
            bool result_s = _leftList.Any((x) => x == "羊");
            bool result_v = _leftList.Any((x) => x == "菜");
            if (result_f)
            {
            }
            else
            {
                if ((result_w && result_s)|| (result_v && result_s))
                {
                    MessageBox.Show("失敗");
                    CreateList();
                    ChangeData();
                }
            }
        }



        private void Farmerwhereright()
        {
            bool result_f = _rightList.Any((x) => x == "農夫");
            bool result_w = _rightList.Any((x) => x == "狼");
            bool result_s = _rightList.Any((x) => x == "羊");
            bool result_v = _rightList.Any((x) => x == "菜");
            if (result_f)
            {
            }
            else
            {
                if ((result_w && result_s) || (result_v && result_s))
                {
                    MessageBox.Show("失敗");
                    CreateList();
                    ChangeData();
                }
            }
        }
        private void gamefinish()
        {
            bool result_f = _rightList.Any((x) => x == "農夫");
            bool result_w = _rightList.Any((x) => x == "狼");
            bool result_s = _rightList.Any((x) => x == "羊");
            bool result_v = _rightList.Any((x) => x == "菜");

            if (result_w && result_s && result_f && result_v)
            {
                MessageBox.Show("成功");
                CreateList();
                ChangeData();
            }

            //switch (_rightList.Count())
            //{
            //    case 1:
            //    case 2:
            //    case 3:
            //        break;
            //    case 4:
            //        MessageBox.Show("成功");
            //        CreateList();
            //        ChangeData();
            //        break;
            //    default:
            //        break;

            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (_leftList.Contains("農夫")) 
            {
                if (listBox1.SelectedItem != null)
                {
                    string item = (string)listBox1.SelectedItem;
                    if (item != "農夫")
                    {
                        _leftList.Remove(item);
                        _leftList.Remove("農夫");
                        _rightList.Add(item);
                        _rightList.Add("農夫");
                    }
                    else
                    {
                        _leftList.Remove(item);
                        _rightList.Add(item);

                    }
                    ChangeData();
                    Farmerwhereleft();
                    Farmerwhereright();
                    gamefinish();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_rightList.Contains("農夫"))
            {

                if (listBox2.SelectedItem != null)
                {

                    string item = (string)listBox2.SelectedItem;
                    if (item != "農夫")
                    {
                        _rightList.Remove(item);
                        _rightList.Remove("農夫");
                        _leftList.Add(item);
                        _leftList.Add("農夫");
                    }
                    else
                    {
                        _rightList.Remove(item);
                        _leftList.Add(item);
                    }
                    ChangeData();
                    Farmerwhereleft();
                    Farmerwhereright();
                    
                }
            }

        }
    }
}
