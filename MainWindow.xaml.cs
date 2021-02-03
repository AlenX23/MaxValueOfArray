using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MaximumValueOfArray
{

    public partial class MainWindow : Window
    {
        private static readonly Regex onlyNumbers = new Regex("[^0-9]");

        public MainWindow()
        {
            InitializeComponent();
        }
            
        //Проверка ввода    
        public static bool IsTextAllowed(string text)
        {    
            return !onlyNumbers.IsMatch(text);
        }
            
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)    
        {
            e.Handled = !IsTextAllowed(e.Text);    
        }

        //Обновление
        private void DidUpdate(string v)
        {
            TEXT_BLOCK.Text = $"{v}";
        }
        private void DidUpdate(int v)
        {
            TEXT_BLOCK.Text = $"{v}";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int q = 0;
            for (int i = 0; i < TEXT_BOX.Text.Length; i++)
            {
                if (TEXT_BOX.Text[i] == ' ') 
                {
                    q += 1;
                    DidUpdate("Неправильный ввод");
                }       
            };
            if (TEXT_BOX.Text == "") DidUpdate("Введите значение");
            else if(q == 0) DidUpdate(Msc(TEXT_BOX.Text));
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {    
            TEXT_BOX.Clear();    
            DidUpdate("");
        }

        public int Msc(string value)
        {
            int[] arr = value.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();

            int max = arr[0], maxIndex = 0;          
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return max;
        }
    }
}   
