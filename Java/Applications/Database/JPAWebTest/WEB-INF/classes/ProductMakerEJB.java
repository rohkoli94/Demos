package sales;

import javax.ejb.*;
import javax.persistence.*;

@LocalBean
@Stateless
public class ProductMakerEJB{

	@PersistenceContext
	private EntityManager em;

	public void addNewProduct(double price, int stock){
		CounterEntity ctr = em.find(CounterEntity.class, "products");
		int productNo = ctr.getNextValue() + 100;
		ProductEntity entity = new ProductEntity();
		entity.setProductNo(productNo);
		entity.setPrice(price);
		entity.setStock(stock);
		em.persist(entity);
	}
}

