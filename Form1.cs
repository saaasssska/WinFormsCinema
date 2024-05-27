using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
namespace WinFormsCinema
{
    public partial class Cinema : Form
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fedye\\source\\repos\\WinFormsCinema\\DatabaseCinema.accdb");
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        Button[,] buttons = new Button[9, 10];
        int totalCost = 0;
        List<List<int>> myPlaces = new List<List<int>>();

        public Cinema()
        {
            InitializeComponent();
            int rows = 9; // количество строк
            int columns = 10; // количество столбцов
            CreateButtonsInGroupBox(rows, columns, new Size(70, 50));
            comboFilm();
        }

        private void comboFilm()
        {
            myConn.Open();
            string query = "SELECT DISTINCT film_name FROM Sittings";
            OleDbCommand command = new OleDbCommand(query, myConn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "film_name";
            myConn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //myConn.Open();
            string film = comboBox1.Text;
            string query = "SELECT time FROM Sittings WHERE film_name = ?";
            OleDbCommand command = new OleDbCommand(query, myConn);
            command.Parameters.AddWithValue("?", film);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "time";
            //myConn.Close();
        }

        private void CreateButtonsInGroupBox(int rows, int columns, Size buttonSize)
        {
            int spacing = 10;

            for (int i = 0; i < rows; i++)
            {
                Label label = new Label();
                label.Text = $"Ряд {i + 1}";
                label.Location = new Point(10, 50 + i * (buttonSize.Height + spacing));
                label.Size = new Size(70, 50);
                groupBox1.Controls.Add(label);
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    button.BackColor = Color.Lime;
                    if (i == 8)
                    {
                        button.BackColor = Color.Thistle;
                    }
                    button.Text = $"{j + 1}";
                    button.Size = buttonSize;
                    button.Location = new Point(80 + j * (buttonSize.Width + spacing), 40 + i * (buttonSize.Height + spacing));
                    button.Click += new EventHandler(Button_Click);
                    button.Tag = new Point(i, j); // Сохраняем индекс кнопки в Tag

                    groupBox1.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private void delChoise(int x, int y)
        {
            for (int i = 0; i < myPlaces.Count; i++)
            {
                if (myPlaces[i][0] == x && myPlaces[i][1] == y)
                {
                    myPlaces.RemoveAt(i);
                }
            }
        }

        private void getDatas()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Выбранные места");
            for (int i = 0; i < myPlaces.Count; i++)
            {
                listBox1.Items.Add($"Ряд {myPlaces[i][0]} Место {myPlaces[i][1]}");
            }
            listBox1.Items.Add($"Итог {totalCost}");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Выберите сеанс");
                return;
            }
            // Определяем, какая кнопка была нажата
            Button clickedButton = sender as Button;
            if (clickedButton.BackColor == Color.Red)
            {
                MessageBox.Show("Это место уже занято");
                return;
            }

            if (clickedButton != null && clickedButton.BackColor != Color.Red)
            {
                Point buttonIndex = (Point)clickedButton.Tag;
                if (clickedButton.BackColor != Color.Yellow)
                {
                    if (buttonIndex.X == 8)
                    {
                        totalCost += 500;


                    }
                    else
                    {
                        totalCost += 300;
                    }

                    List<int> testList = new List<int> { buttonIndex.X + 1, buttonIndex.Y + 1 };
                    myPlaces.Add(testList);

                    clickedButton.BackColor = Color.Yellow;
                }
                else
                {

                    if (buttonIndex.X == 8)
                    {
                        clickedButton.BackColor = Color.Thistle;
                        totalCost -= 500;
                    }
                    else
                    {
                        clickedButton.BackColor = Color.Lime;
                        totalCost -= 300;
                    }
                    delChoise(buttonIndex.X + 1, buttonIndex.Y + 1);
                }
                getDatas();
            }
        }

        private void ResetButtonColors()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    Button button = buttons[i, j];
                    button.BackColor = (i == 8) ? Color.Thistle : Color.Lime;
                }
            }
        }


        private void buttonSitting(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Пожалуйста, выберите фильм и время сеанса.");
                return;
            }
            ResetButtonColors();

            myPlaces.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Add("Выбранные места");
            totalCost = 0;
            groupBox1.Enabled = true;
            myConn.Open();
            string film = comboBox1.Text;
            string time = comboBox2.Text;

            string query = "SELECT sitting FROM Sittings WHERE film_name = @film AND time = @time";
            OleDbCommand command = new OleDbCommand(query, myConn);
            command.Parameters.AddWithValue("@film", film);
            command.Parameters.AddWithValue("@time", time);

            object id = command.ExecuteScalar();
            if (id != null)
            {
                int sittingId = Convert.ToInt32(id);

                string query2 = "SELECT row, place FROM Tickets WHERE sitting = @id";
                OleDbCommand command2 = new OleDbCommand(query2, myConn);
                command2.Parameters.AddWithValue("@id", sittingId);

                using (OleDbDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int row = Convert.ToInt32(reader["row"]) - 1;
                        int place = Convert.ToInt32(reader["place"]) - 1;

                        if (row >= 0 && row < buttons.GetLength(0) && place >= 0 && place < buttons.GetLength(1))
                        {
                            buttons[row, place].BackColor = Color.Red;
                        }
                    }
                }
                myConn.Close();
            }

        }

        private void buttonResult(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите свое имя");
                return;
            }
            else if (!myPlaces.Any(innerList => innerList.Count > 0))
            {
                MessageBox.Show("Выберите хотя бы одно место");
                return;
            }
            string film = comboBox1.Text;
            string time = comboBox2.Text;

            myConn.Open();
            try
            {
                string query = "SELECT sitting FROM Sittings WHERE film_name = @film AND time = @time";
                OleDbCommand command = new OleDbCommand(query, myConn);
                command.Parameters.AddWithValue("@film", film);
                command.Parameters.AddWithValue("@time", time);

                object id = command.ExecuteScalar();
                int sittingId = Convert.ToInt32(id);

                for (int i = 0; i < myPlaces.Count; i++)
                {
                    int x = myPlaces[i][0];
                    int y = myPlaces[i][1];

                    string query2 = "INSERT INTO Tickets (sitting, row, place) VALUES (?, ?, ?)";
                    OleDbCommand command2 = new OleDbCommand(query2, myConn);
                    command2.Parameters.AddWithValue("?", sittingId);
                    command2.Parameters.AddWithValue("?", x);
                    command2.Parameters.AddWithValue("?", y);

                    command2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }

            myPlaces.Clear();
            SaveListBoxToFile(listBox1);
            listBox1.Items.Clear();
            listBox1.Items.Add("Выбранные места");
            totalCost = 0;
            ResetButtonColors();
            groupBox1.Enabled = false;
        }

        private void SaveListBoxToFile(ListBox listBox)
        {
            listBox1.Items.Add(textBox1.Text);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Выберите где сохранить чек";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var item in listBox.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Файл успешно сохранен", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
