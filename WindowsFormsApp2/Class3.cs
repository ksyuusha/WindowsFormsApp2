using System;

public class FoodProduct : ITovar
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public FoodProduct(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public string GetName() => Name;
    public decimal GetPrice() => Price;
    public int GetStock() => Stock;

    public void Restock(int quantity)
    {
        Stock += quantity;
    }

    public void Sell(int quantity)
    {
        if (quantity > Stock)
        {
            throw new InvalidOperationException("Недостаточно товара на складе.");
        }
        Stock -= quantity;
    }
}
