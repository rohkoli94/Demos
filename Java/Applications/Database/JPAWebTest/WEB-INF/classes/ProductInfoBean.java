package sales;

import java.util.*;
import javax.persistence.*;
import javax.faces.bean.*;

@ManagedBean(name="productInfo")
public class ProductInfoBean{

	@PersistenceUnit
	private EntityManagerFactory emf;

	public List<ProductEntity> getProducts(){
		EntityManager em = emf.createEntityManager();
		try{
			TypedQuery<ProductEntity> query = em.createQuery("SELECT p FROM ProductEntity p WHERE p.stock > ?1", ProductEntity.class);
			query.setParameter(1, 0);
			return query.getResultList();
		}finally{
			em.close();
		}
	}

	private ProductEntity selectedProduct;

	public ProductEntity getSelectedProduct(){return selectedProduct;}

	public String selectProduct(ProductEntity entity){
		selectedProduct = entity;
		return "details";
	}
}

