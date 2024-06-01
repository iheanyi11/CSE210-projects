using System;

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal TotalCost()
    {
        return _price * _quantity;
    }

    public string Name 
    {
        get{return _name; }
    }

    public int ProductId
    {
        get{return _productId;}
    }

    public decimal price
    {
        get{return _price; }
    }

    public int quantity
    {
        get {return _quantity; }
    }
}

