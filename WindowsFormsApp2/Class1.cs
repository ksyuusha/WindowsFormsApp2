public interface ITovar
{
    string GetName();  // Получение имени товара
    decimal GetPrice();  // Получение стоимости товара
    int GetStock();  // Получение остатка на складе
    void Restock(int quantity);  // Добавление товара на склад
    void Sell(int quantity);  // Продажа товара
}
