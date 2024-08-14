using MongoDB.Driver;
public class ProductoServicio {

ProductoRepositorio repo;

public ProductoServicio(ProductoRepositorio repo){
this.repo = repo;
}

}