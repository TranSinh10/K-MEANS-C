using System.Data;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Diagnostics.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;
using CsvHelper;
using static KMeansClustering.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KMeansClustering
{
    public partial class Form1 : Form
    {
        private List<Customer> customers;
        private List<Cluster> clusterList;

        public Form1()
        {
            InitializeComponent();
            numClustersTextBox.Text = "4";
        }
        public class Customer
        {
            public int ID { get; set; }
            public int Gender { get; set; }
            public int Age { get; set; }
            public int Income { get; set; }
            public int Spending { get; set; }

            public Cluster Cluster;
        }

        private List<Customer> LoadDataFromCsv(string filename)
        {
            var customers = new List<Customer>();

            using (var sr = new StreamReader(filename))
            {
                var headers = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    var values = sr.ReadLine().Split(',');

                    var customer = new Customer();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (checkedListBox1.CheckedItems.Contains(headers[i]))
                        {
                            var property = typeof(Customer).GetProperty(headers[i]);
                            if (property != null)
                            {
                                var convertedValue = Convert.ChangeType(values[i], property.PropertyType);
                                property.SetValue(customer, convertedValue);
                            }
                        }
                    }

                    customers.Add(customer);
                }
            }

            return customers;
        }
        public class Cluster
        {
            public Customer Centroid { get; set; }
            public List<Customer> Customers { get; set; }

            public Cluster()
            {
                Customers = new List<Customer>();
            }
        }
        string filename = string.Empty;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select a CSV File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dataTable = new DataTable();
                filename = openFileDialog.FileName;
                textBox1.Text = filename;
                var headers = File.ReadLines(filename).First().Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                using (var sr = new StreamReader(filename))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var rows = sr.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                checkedListBox1.Items.AddRange(headers);
                List<string> defautchecked = new List<string>();
                foreach (string field in headers)
                {
                    defautchecked.Add(field);
                }

                for (int i = 0; i < defautchecked.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                dataGridView1.DataSource = dataTable;
            }
        }
        private double GetEuclideanDistance(Customer customer, Customer centroid)
        {
            double distance = 0;

            PropertyInfo[] properties = typeof(Customer).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];

                if (checkedListBox1.CheckedItems.Contains(property.Name))
                {
                    int value1 = Convert.ToInt32(property.GetValue(customer));
                    int value2 = Convert.ToInt32(property.GetValue(centroid));
                    distance += Math.Pow(value1 - value2, 2);
                }
            }

            return Math.Sqrt(distance);
        }
        private void clusterButton_Click(object sender, EventArgs e)
        {
            customers = LoadDataFromCsv(filename);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            var headers = File.ReadLines(filename).First().Split(',');
            foreach (string header in headers)
            {
                dataGridView1.Columns.Add(header, header);
            }
            for (int i = 0; i < headers.Length; i++)
            {
                if (!checkedListBox1.CheckedItems.Contains(headers[i]))
                {
                    dataGridView1.Columns[headers[i]].Visible = false;
                }
            }
            dataGridView1.Columns.Add("Cluster", "Cluster");
            int k = int.Parse(numClustersTextBox.Text);
            // Khởi tạo K centroid ngẫu nhiên
            clusterList = new List<Cluster>();
            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                int index = rand.Next(customers.Count);
                Cluster cluster = new Cluster { Centroid = customers[index] };
                clusterList.Add(cluster);
            }

            // Thực hiện phân cụm K-Means
            bool isClusterChanged = true;
            int iteration = 0;
            while (isClusterChanged && iteration < 1000)
            {
                isClusterChanged = false;
                iteration++;

                // Gán mỗi dòng dữ liệu vào cụm gần nhất
                foreach (Customer customer in customers)
                {
                    double minDistance = double.MaxValue;
                    Cluster nearestCluster = null;
                    foreach (Cluster cluster in clusterList)
                    {
                        double distance = GetEuclideanDistance(customer, cluster.Centroid);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestCluster = cluster;
                        }
                    }
                    if (nearestCluster != customer.Cluster)
                    {
                        isClusterChanged = true;
                        customer.Cluster?.Customers.Remove(customer);
                        nearestCluster.Customers.Add(customer);
                        customer.Cluster = nearestCluster;
                    }
                }

                // Cập nhật vị trí centroid
                List<string> selectedFields = new List<string>();
                foreach (string header in checkedListBox1.CheckedItems)
                {
                    selectedFields.Add(header);
                }

                for (int i = 0; i < clusterList.Count; i++)
                {
                    Cluster cluster = clusterList[i];
                    List<Customer> customers = cluster.Customers;
                    int count = customers.Count;

                    if (count > 0)
                    {
                        Customer newCentroid = new Customer
                        { };
                        foreach (string header in selectedFields)
                        {
                            PropertyInfo propertyInfo = typeof(Customer).GetProperty(header);
                            if (propertyInfo != null)
                            {
                                double average = customers.Average(c => Convert.ToDouble(propertyInfo.GetValue(c)));
                                newCentroid.GetType()?.GetProperty(header)?.SetValue(newCentroid, Convert.ToInt32(Math.Round(average)));
                            }

                        }
                        cluster.Centroid = newCentroid;
                    }
                }
            }
            // Hiển thị kết quả phân cụm
            PlotModel plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            for (int i = 0; i < clusterList.Count; i++)
            {
                //Color color = Color.FromArgb(255, i * 50, 255 - i * 50);
                Random random = new Random();
                Color color = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
                ScatterSeries series = new ScatterSeries { Title = $"Cluster {i}" };
                foreach (Customer customer in clusterList[i].Customers)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = customer.ID;
                    dataGridView1.Rows[index].Cells[1].Value = customer.Gender;
                    dataGridView1.Rows[index].Cells[2].Value = customer.Age;
                    dataGridView1.Rows[index].Cells[3].Value = customer.Income;
                    dataGridView1.Rows[index].Cells[4].Value = customer.Spending;
                    dataGridView1.Rows[index].Cells["Cluster"].Value = "Cụm " + i;
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = color;
                    //series.Points.Add(new ScatterPoint(customer.Gender, customer.Age, 3));
                    series.Points.Add(new ScatterPoint(customer.Income, customer.Spending, 3));
                }
                plotModel.Series.Add(series);
            }

            // Thêm các cột dữ liệu vào combobox
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "Cluster") // Loại bỏ cột "Cluster"
                {
                    comboBox1.Items.Add(column.Name);
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Kiểm tra nếu không phải là dòng mới
                {
                    var clusterValue = row.Cells["Cluster"].Value?.ToString();
                    if (!string.IsNullOrEmpty(clusterValue) && !comboBox2.Items.Contains(clusterValue))
                    {
                        comboBox2.Items.Add(clusterValue);
                    }
                }
            }
            for (int i = 0; i < clusterList.Count; i++)
            {
                Cluster cluster = clusterList[i];
                ScatterSeries centroidSeries = new ScatterSeries { Title = $"Centroid {i}" };
                centroidSeries.MarkerFill = OxyColor.FromRgb(0, 100, 100);
                //centroidSeries.Points.Add(new ScatterPoint(cluster.Centroid.Gender, cluster.Centroid.Age, 5));
                centroidSeries.Points.Add(new ScatterPoint(cluster.Centroid.Income, cluster.Centroid.Spending, 5));
                plotModel.Series.Add(centroidSeries);
            }

            plotView1.Model = plotModel;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked) // If item is being unchecked
            {
                var columnName = checkedListBox1.Items[e.Index].ToString();
                dataGridView1.Columns.Remove(columnName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy tên của cột được chọn từ combobox1
            var columnName = comboBox1.SelectedItem.ToString();
            var selectedCluster = comboBox2.SelectedItem.ToString();
            List<double> data = new List<double>();
            List<int> data2 = new List<int>();
            var tansuat = new Dictionary<double, int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["Cluster"].Value.ToString() == selectedCluster)
                {
                    data.Add(Convert.ToDouble(row.Cells[columnName].Value));
                    data2.Add(Convert.ToInt32(row.Cells[columnName].Value));
                }
            }
            // Tính mean 
            double mean = data.Sum() / data.Count;
            // Tính giá trị midrange và hiển thị lên textbox2
            double midrange = (data.Min() + data.Max()) / 2; ;

            // Sắp xếp danh sách giá trị
            data.Sort();
            foreach (var value in data)
            {
                if (tansuat.ContainsKey(value))
                {
                    tansuat[value]++;
                }
                else
                {
                    tansuat[value] = 1;
                }
            }
            // Tính giá trị median
            double median;
            int counnt = data.Count;
            if (counnt % 2 == 0)
            {
                median = (data[counnt / 2] + data[counnt / 2 + 1]) / 2;
            }
            else
            {
                median = data[counnt / 2];
            }
            // Tính giá trị mode
            data2.Sort();
            int currentNumber = data2[0];
            int currentCount = 1;
            int maxNumber = data2[0];
            int maxCount = 1;

            for (int i = 1; i < data2.Count; i++)
            {
                if (data2[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxNumber = currentNumber;
                        maxCount = currentCount;
                    }
                    currentNumber = data2[i];
                    currentCount = 1;
                }
            }
            if (currentCount > maxCount)
            {
                maxNumber = currentNumber;
                maxCount = currentCount;
            }
            int mode = maxNumber;
            // Tính vị trí của quartiles
            int n = data.Count;
            int q1Index = (int)Math.Ceiling(n * 0.25);
            int q2Index = (int)Math.Ceiling(n * 0.5);
            int q3Index = (int)Math.Ceiling(n * 0.75);

            // Tính giá trị của quartiles
            double q1 = data[q1Index];
            double q2 = data[q2Index];
            double q3 = data[q3Index];

            // Tính giá trị interquartile range
            double iqrValue = q3 - q1;
            // Tính giá trị variance của cột dữ liệu
            double variance = 0;
            if (data.Count > 0)
            {
                variance = data.Sum(v => Math.Pow(v - mean, 2)) / data.Count;
            }

            // Hiển thị kết quả lên textbox
            textBox2.Text = mean.ToString();
            textBox3.Text = median.ToString();
            textBox4.Text = midrange.ToString();
            textBox5.Text = variance.ToString();
            textBox6.Text = iqrValue.ToString();
            textBox7.Text = mode.ToString();
            textBox8.Text = string.Format("Q1: {0}\r\nQ2: {1}\r\nQ3: {2}", q1, q2, q3);
            // Hiển thị kết quả lên biểu đồ
            PlotModel plotModel1 = new PlotModel();
            var lineSeries = new LineSeries();
            foreach (var ts in tansuat)
            {
                lineSeries.Points.Add(new DataPoint(ts.Key, ts.Value));
            }
            var means = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = mean,
                Color = OxyColors.Blue,
                Text = "Mean",
                TextColor = OxyColors.Red
            };
            var medians = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = median,
                Color = OxyColors.Blue,
                Text = "Median",
                TextColor = OxyColors.Red
            };
            var modes = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = mode,
                Color = OxyColors.Blue,
                Text = "Mode",
                TextColor = OxyColors.Red
            };
            var Q1s = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = q1,
                Color = OxyColors.Blue,
                Text = "Q1",
                TextColor = OxyColors.Red
            };
            var Q2s = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = q2,
                Color = OxyColors.Blue,
                Text = "Q2",
                TextColor = OxyColors.Red
            };
            var Q3s = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = q3,
                Color = OxyColors.Blue,
                Text = "Q3",
                TextColor = OxyColors.Red
            };
            var iqrs = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = iqrValue,
                Color = OxyColors.Blue,
                Text = "IQR",
                TextColor = OxyColors.Red
            };
            var midranges = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = midrange,
                Color = OxyColors.Blue,
                Text = "Midrange",
                TextColor = OxyColors.Red
            };
            var variances = new OxyPlot.Annotations.LineAnnotation
            {
                Type = OxyPlot.Annotations.LineAnnotationType.Vertical,
                X = variance,
                Color = OxyColors.Blue,
                Text = "Variance",
                TextColor = OxyColors.Red
            };
            plotModel1.Series.Add(lineSeries);
            plotModel1.Annotations.Add(means);
            plotModel1.Annotations.Add(medians);
            plotModel1.Annotations.Add(modes);
            plotModel1.Annotations.Add(Q1s);
            plotModel1.Annotations.Add(Q2s);
            plotModel1.Annotations.Add(Q3s);
            plotModel1.Annotations.Add(midranges);
            plotModel1.Annotations.Add(iqrs);
            plotModel1.Annotations.Add(variances);
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Giá trị" }); // Trục hoành
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Tần suất xuất hiện" }); // Trục tung
            plotView2.Model = plotModel1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị lại các hàng và ẩn các cột không được chọn
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != comboBox1.SelectedItem?.ToString())
                {
                    column.Visible = false;
                }
                else
                {
                    column.Visible = true;
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["Cluster"].Value.ToString() != comboBox2.Text)
                {
                    row.Visible = false; // ẩn các hàng không cùng cụm với giá trị của combobox2
                }
                else
                {
                    row.Visible = true; // hiển thị các hàng cùng cụm với giá trị của combobox2
                }
            }
        }
    }
}