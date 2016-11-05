using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_COMP5200
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sort_Click(object sender, EventArgs e)
        {
            ReadNum();

            string outputfilename = "";

            var watch = System.Diagnostics.Stopwatch.StartNew();

            switch (selectedAlgorithm.Text.ToString())
            {
                case "Counting Sort":
                    outputfilename = "CountingSort";
                    int[] output = CountingSort(input, input.Max());
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(output[i].ToString());
                    }
                    break;
                case "Insertion Sort":
                    outputfilename = "InsertionSort";
                    InsertionSort(input);
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(input[i].ToString());
                    }
                    break;
                case "Selection Sort":
                    outputfilename = "SelectionSort";
                    SelectionSort(input);
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(input[i].ToString());
                    }
                    break;
                case "Quick Sort":
                    outputfilename = "QuickSort";
                    QuickSort(input, 0, input.Length - 1);
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(input[i].ToString());
                    }
                    break;
                case "Merge Sort":
                    outputfilename = "MergeSort";
                    MergeSort(input, 0, input.Length - 1);
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(input[i].ToString());
                    }
                    break;
                case "Heap Sort":
                    outputfilename = "HeapSort";
                    HeapSort(input);
                    MessageBox.Show("Finish sorting.");
                    SortedResult.Items.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        SortedResult.Items.Add(input[i].ToString());
                    }
                    break;
                default:
                    break;
            }

            watch.Stop();

            MessageBox.Show("Sorting method runing time is: " + watch.ElapsedMilliseconds.ToString() + " ms.");

            WriteToFile(outputfilename, input);
            MessageBox.Show("Finish saving result in " + outputfilename + "_sorted.txt");
        }
    }
}
