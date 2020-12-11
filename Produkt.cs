class Produkt
{
   
    private int ProductId;
    private string ProductName;
    private string Description;
    private int Price;

    //Konstruktor
    public Produkt()
    {

    }

    //Konstruktor som är overloaded, används för att skapa nya Objekt med alla värden
    public Produkt(int id, string name, string description, int price)
    {
        ProductId = id;
        ProductName = name;
        Description = description;
        Price = price;
    }

    //Används för att få tag på ID, viktigt att använda (ArrayName, position i array)
    public static int GetProductId(Produkt[] ArrayName, int x)
    {

        if (ArrayName[x] != null)
        {
            Produkt SelectedInArray = ArrayName[x];
            return SelectedInArray.GetProductId();
        }

        return -1;
    }

    //Används för att få tag på namnet, viktigt att använda (ArrayName, position i array)
    public static string GetProductName(Produkt[] ArrayName, int x)
    {

        if (ArrayName[x] != null)
        {
            Produkt SelectedInArray = ArrayName[x];
            return SelectedInArray.GetProductName();
        }
        else
        {
            string NotValid = "This is not a valid Product";
            return NotValid;
        }

    }

    //Används för att få tag på description, viktigt att använda (ArrayName, position i array)
    public static string GetProductDescription(Produkt[] ArrayName, int x)
    {

        if (ArrayName[x] != null)
        {
            Produkt SelectedInArray = ArrayName[x];
            return SelectedInArray.GetProductDescription();
        }
        else
        {
            string NotValid = "This product has no description";
            return NotValid;
        }

    }

    //Används för att få tag i priset, viktigt att använda (ArrayName, position i array)
    public static int GetProductPrice(Produkt[] ArrayName, int x)
    {

        if (ArrayName[x] != null)
        {
            Produkt SelectedInArray = ArrayName[x];
            return SelectedInArray.GetProductPrice();
        }
        else
        {
            return -1;
        }


    }

    //Dessa används i andra methoder för att skapa större funktioner, tex när vi loopar igenom hela Arrayn och skriver ut allt.
    //Ska vi få tag på specifik information använder vi de Overloaded metoderna längre upp
    public int GetProductId()
    {
        return ProductId;
    }

    public string GetProductName()
    {
        return ProductName;
    }

    public string GetProductDescription()
    {
        return Description;
    }

    public int GetProductPrice()
    {
        return Price;
    }

    public void SetProductId(int x)
    {
        ProductId = x;

    }

    public void SetProductName(string x)
    {
        ProductName = x;
    }
    public void SetDescription(string x)
    {
        Description = x;
    }

    public void SetPrice(int x)
    {
        Price = x;
    }

}

