namespace Products;
    
public class Product {
    private int _id;
    private string _name;

    public bool Public {get; set;}

    public int ID {
        get{
            return this._id;
        }
    }

    public string Name {
        get{
            return this._name;
        }

        set {
            string newName = value.Trim();
            if(newName != ""){
                this._name = value;
            }
        }
    }

    public Product(int ID, string Name){
        this._id = ID;
        this._name = Name;
        this.Public = true;
    }

    public Product(int ID, string Name, bool Public){
        this._id = ID;
        this._name = Name;
        this.Public = Public;
    }
}

public class ProductsDB {
    private static List<Product> _products = new List<Product>{
        new Product(ID: 1, Name: "God of War"),
        new Product(ID: 2, Name: "Uncharted 4: Among Thieves"),
        new Product(ID: 3, Name: "Horizon Zero Dawn", Public: false),
        new Product(ID: 4, Name: "Player Uknown's Battle Grounds"),
    };

    // CREATE
    public static Product? CreateProduct(Product NewProduct){
        bool IDAlreadyUsed = ProductsDB._products.FindAll(Product => Product.ID == NewProduct.ID).Count > 0; 
        if(IDAlreadyUsed){
            return null;
        }

        ProductsDB._products.Add(NewProduct);
        return NewProduct;
    } 

    // READ
    public static List<Product> Products {
        get {
            return ProductsDB._products.FindAll(Product => Product.Public);
        }
    }

    public static Product GetProduct(int id){
        return _products.SingleOrDefault(product => product.ID == id);
    }

    // UPDATE
    // I'll implement later
    // public static Product? UpdateProduct(int )

    public static void DeleteProduct(int id){
        ProductsDB._products = ProductsDB._products.FindAll(Product => Product.ID != id); 
    }
}