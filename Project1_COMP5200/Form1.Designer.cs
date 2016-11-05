using System;
using System.Windows.Forms;

namespace Project1_COMP5200
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.selectedAlgorithm = new System.Windows.Forms.ComboBox();
            this.sort = new System.Windows.Forms.Button();
            this.SortedResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the sorting algorithm:";
            // 
            // selectedAlgorithm
            // 
            this.selectedAlgorithm.FormattingEnabled = true;
            this.selectedAlgorithm.Items.AddRange(new object[] {
            "Counting Sort",
            "Insertion Sort",
            "Selection Sort",
            "Quick Sort",
            "Merge Sort",
            "Heap Sort"});
            this.selectedAlgorithm.Location = new System.Drawing.Point(74, 113);
            this.selectedAlgorithm.Name = "selectedAlgorithm";
            this.selectedAlgorithm.Size = new System.Drawing.Size(220, 39);
            this.selectedAlgorithm.TabIndex = 1;
            // 
            // sort
            // 
            this.sort.Location = new System.Drawing.Point(386, 113);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(209, 56);
            this.sort.TabIndex = 2;
            this.sort.Text = "Select && Sort";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // SortedResult
            // 
            this.SortedResult.FormattingEnabled = true;
            this.SortedResult.ItemHeight = 31;
            this.SortedResult.Location = new System.Drawing.Point(74, 247);
            this.SortedResult.Name = "SortedResult";
            this.SortedResult.Size = new System.Drawing.Size(754, 438);
            this.SortedResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "The sorted first 100 numbers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1059, 740);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SortedResult);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.selectedAlgorithm);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedAlgorithm;

        public int[] input;
        public int heapSize;

        public void ReadNum()
        {
            string line;

            int counter = 0;
            System.IO.StreamReader file1 = new System.IO.StreamReader("numbers.txt");

            while ((line = file1.ReadLine()) != null)
            {
                counter++;
            }
            file1.Close();

            input = new int[counter];
            counter = 0;

            System.IO.StreamReader file2 = new System.IO.StreamReader("numbers.txt");

            while ((line = file2.ReadLine()) != null)
            {
                input[counter] = int.Parse(line);
                counter++;
            }

            file2.Close();

            heapSize = input.Length;

            MessageBox.Show("Finish reading numbers.txt");

            return;
        }

        public void SelectionSort(int[] input)
        {
            int imin;
            int tmp;

            for (int i = 0; i < input.Length - 1; i++)
            {
                imin = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[imin] > input[j])
                    {
                        imin = j;
                    }
                }

                tmp = input[i];
                input[i] = input[imin];
                input[imin] = tmp;
            }

            return;
        }

        public void InsertionSort(int[] input)
        {
            int j;
            int key;

            for (int i = 1; i < input.Length; i++)
            {
                j = i - 1;
                key = input[i];

                while (j >= 0 && key < input[j])
                {
                    input[j + 1] = input[j];
                    j = j - 1;
                }
                input[j + 1] = key;
            }

            return;
        }

        public void MergeSort(int[] input, int p, int r)
        {
            int q;

            if (p < r)
            {
                q = Convert.ToInt32(Math.Floor((p + r) / 2.0));
                MergeSort(input, p, q);
                MergeSort(input, q + 1, r);
                Merge(input, p, q + 1, r);
            }
            return;
        }

        public void Merge(int[] input, int p, int q, int r)
        {
            int n1 = q - p;
            int n2 = r - q + 1;

            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];

            for (int k = 0; k < n1; k++)
            {
                L[k] = input[p + k];
            }
            for (int k = 0; k < n2; k++)
            {
                R[k] = input[q + k];
            }

            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;

            int i = 0, j = 0;

            for (int k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    input[k] = L[i];
                    i++;
                }
                else
                {
                    input[k] = R[j];
                    j++;
                }
            }

            return;
        }

        public void QuickSort(int[] input, int p, int r)
        {
            int q;

            if (p < r)
            {
                q = Partition(input, p, r);
                QuickSort(input, p, q - 1);
                QuickSort(input, q + 1, r);
            }

            return;
        }

        public int Partition(int[] input, int p, int r)
        {
            int pivot = input[r];
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    int tmp1 = input[i];
                    input[i] = input[j];
                    input[j] = tmp1;
                }
            }

            int tmp2 = input[r];
            input[r] = input[i + 1];
            input[i + 1] = tmp2;

            return i + 1; 
        }

        public int[] CountingSort(int[] input, int k)
        {
            int[] Count = new int[k + 1];

            for (int i = 0; i < k + 1; i++)
            {
                Count[i] = 0;
            }

            for (int j = 0; j < input.Length; j++)
            {
                Count[input[j]]++;
            }

            for (int i = 1; i < k + 1; i++)
            {
                Count[i] += Count[i - 1];
            }

            int[] output = new int[input.Length];

            for (int j = input.Length - 1; j > 0; j--)
            {
                output[Count[input[j]] - 1] = input[j];
                Count[input[j]]--;
            }

            return output;
        }

        public void HeapSort(int[] input)
        {
            int tmp;

            buildHeap(input);
            int keepSize = heapSize;

            for (int i = heapSize - 1; i >= 1; i--)
            {
                tmp = input[heapSize - 1];
                input[heapSize - 1] = input[0];
                input[0] = tmp;
                heapSize--;
                heapify(input, 0);
            }
            heapSize = keepSize;
        }

        public void heapify(int[] input, int parent)
        {
            int Lson, Rson, largest, tmp;
            Lson = 2 * parent + 1;
            Rson = 2 * parent + 2;

            if (Lson <= heapSize - 1 && input[Lson] > input[parent])
            {
                largest = Lson;
            }
            else
            {
                largest = parent;
            }

            if (Rson <= heapSize - 1 && input[Rson] > input[largest])
            {
                largest = Rson;
            }
            
            if (largest != parent)
            {
                tmp = input[parent];
                input[parent] = input[largest];
                input[largest] = tmp;
                heapify(input, largest);
            }
        }

        public void buildHeap(int[] input)
        {
            for (int i = (heapSize - 1) / 2; i >= 0; i--)
            {
                heapify(input, i);
            }
        }

        public void WriteToFile(string filename, int[] input)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename + "_sorted.txt");

            foreach (int num in input)
            {
                file.WriteLine(num);
            }

            file.Close();
        }

        private Button sort;
        private ListBox SortedResult;
        private Label label2;
    }
}

