using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool isNumericA = double.TryParse(textBox9.Text, out double A); //取得數字
            if (isNumericA)
            {
                label10.Text = Math.Sqrt(A).ToString(); //計算並顯示
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // 檢查開根號textBox是否是數字
            bool isOK = double.TryParse(textBox9.Text, out _);
            button5.Enabled = isOK; // 符合條件按鈕才啟亮
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNumericA = double.TryParse(textBox9.Text, out double A);
            bool isNumericB = double.TryParse(textBox9.Text, out double B);
            if (isNumericA && isNumericB)
            {
                // 只有在兩個輸入都正確時才進行運算
                double C = A + B;
                label2.Text = C.ToString();
            }
            else
            {
                // 告知使用者哪裡出錯
                MessageBox.Show("請確認兩個欄位皆已輸入有效的數字！", "輸入錯誤");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //使用迴圈實作連加法
            //double ans = 0;
            //if (
            //  double.TryParse(textBox11.Text, out double A) &&
            //  double.TryParse(textBox12.Text, out double B) &&
            //  double.TryParse(textBox13.Text, out double C))
            //{
            //    for (double i = A; i <= B; i=i+C)
            //    {
            //        ans += i;
            //    }
            //    label16.Text = ans.ToString();
            //}
            //else
            //{
            //   MessageBox.Show("請輸入有效的數字！");
            //}

            //使用LINQ語法實作連加法
            if (
              double.TryParse(textBox11.Text, out double A) &&
              double.TryParse(textBox12.Text, out double B) &&
              double.TryParse(textBox13.Text, out double C))
            {
                // 1. 先算出總共有幾個數字：個數 = (結束值 - 起始值) / 間距值 + 1
                int count = (int)((B - A) / C) + 1;

                // 2. 用 LINQ 產生序列並加總
                // i 從 0 開始，數 count 個，然後利用 A + i * C 算出每一個正確的數字
                var sum = Enumerable.Range(0, count)
                                    .Select(i => A + (i * C))
                                    .Sum();

                label16.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("請輸入有效的數字！");
            }
        }
    }
}
