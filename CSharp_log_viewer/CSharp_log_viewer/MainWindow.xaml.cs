using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.VisualBasic.FileIO;
using System.Collections.ObjectModel;

namespace CSharp_log_viewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
         ObservableCollection<DataList> show_list = new ObservableCollection<DataList>();
         List<DataList> list = new List<DataList>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox1_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                e.Effects = System.Windows.DragDropEffects.Copy;
            }
            else
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void TextBox1_Drop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
            if (dropFiles == null) return;
            TextBox1.Text = dropFiles[0];
        }

        private void test1(object sender, RoutedEventArgs e)
        {
            TextFieldParser parser = new TextFieldParser(TextBox1.Text,System.Text.Encoding.GetEncoding("SHIFT_JIS"));

            using (parser)
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string[] row = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    row = parser.ReadFields();
                    list.Add(new DataList(row));
                }
                this.DataGrid1.ItemsSource = list;
            }

            
           /*
            GraphWindow1 gw1 = new GraphWindow1(lg);
            gw1.Show();*/
        }

    }
}

class DataList
{
    public int Time{get; set;}
    public int UserData1{get; set;}
    public int UserData2{get; set;}
    public int Battery{get; set;}
    public int MotorA{get; set;}
    public int MotorB{get; set;}
    public int MotorC{get; set;}
    public int S1{get; set;}
    public int S2{get; set;}
    public int S3{get; set;}
    public int S4{get; set;}
    public int IC2{get; set;}

    private int[] s2int = new int[12];

    public DataList() 
    { 

    }

     public DataList(string[] str) 
    { 
          for (int i = 0;i < 12; i++)
        {
            s2int[i] = int.Parse(str[i]);
        }

        Time = s2int[0];
        UserData1 = s2int[1];
        UserData2 = s2int[2];
        Battery = s2int[3];
        MotorA = s2int[4];
        MotorB = s2int[5];
        MotorC = s2int[6];
        S1 = s2int[7];
        S2 = s2int[8];
        S3 = s2int[9];
        S4 = s2int[10];
        IC2 = s2int[11];
    }
    

    public void SetData(string[] str)
    {
        for (int i = 0;i < 12; i++)
        {
            s2int[i] = int.Parse(str[i]);
        }

        Time = s2int[0];
        UserData1 = s2int[1];
        UserData2 = s2int[2];
        Battery = s2int[3];
        MotorA = s2int[4];
        MotorB = s2int[5];
        MotorC = s2int[6];
        S1 = s2int[7];
        S2 = s2int[8];
        S3 = s2int[9];
        S4 = s2int[10];
        IC2 = s2int[11];
    }

}