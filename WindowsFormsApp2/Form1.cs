using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        // Список для хранения товаров
        private List<ITovar> tovarList = new List<ITovar>();

        public Form1()
        {
            InitializeComponent();
            UpdateProductList();
        }

        // Обновление списка товаров на форме
        private void UpdateProductList()
        {
            listBox1.Items.Clear();
            foreach (var tovar in tovarList)
            {
                listBox1.Items.Add($"{tovar.GetName()} - Цена: {tovar.GetPrice()} руб. Остаток: {tovar.GetStock()}");
            }
        }

        // Добавление товара в список
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;  // Название товара
                decimal price = decimal.Parse(textBox2.Text);  // Цена товара
                int stock = int.Parse(textBox3.Text);  // Остаток товара на складе

                // Добавляем товар в список
                Product product = new Product(name, price, stock);
                tovarList.Add(product);

                UpdateProductList();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара: " + ex.Message);
            }
        }

        // Продажа товара
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedProduct = tovarList[listBox1.SelectedIndex];

                try
                {
                    int quantity = int.Parse(textBox4.Text);  // Количество для продажи
                    selectedProduct.Sell(quantity);
                    UpdateProductList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при продаже товара: " + ex.Message);
                }
            }
        }

        // Очистка полей ввода
        private void ClearInputFields()
        {
            textBox1.Clear();  // Очистка поля с названием товара
            textBox2.Clear();  // Очистка поля с ценой товара
            textBox3.Clear();  // Очистка поля с количеством товара на складе
            textBox4.Clear();  // Очистка поля с количеством для продажи
        }

        // Обработчик события изменения выбранного элемента в listBox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Действие при выборе товара (например, вывод информации)
            if (listBox1.SelectedIndex != -1)
            {
                var selectedProduct = tovarList[listBox1.SelectedIndex];
                MessageBox.Show($"Вы выбрали товар: {selectedProduct.GetName()} - Остаток: {selectedProduct.GetStock()} шт.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
