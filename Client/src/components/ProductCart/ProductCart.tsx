import * as React from 'react';
import block from 'bem-cn-lite';

import { IProduct } from '../../types/Product';

import './ProductCart.css';

const b = block('ProductCart');

interface IProductCartProps {
  product: IProduct;
  onDeleteHanler: (product: IProduct) => void;
  onAddHandler: (product: IProduct) => void;
}

const ProductCart: React.FC<IProductCartProps> = props => {
  const product = props.product;

  const addToBasket = () => props.onAddHandler(product);
  const deleteFromBasket = () => props.onDeleteHanler(product);

  return (
    <div className={b()}>
      <img src='../../images/product_logo.svg' className={b('logo')} />
      <h3>{product.Name}</h3>
      <h4>Категория: {product.Category.Title}</h4>
      <h4>Цена: {product.Price}</h4>
      {
        !props.product.InBasket
          ? <button className={b('button')} onClick={addToBasket}>Добавить в корзину</button>
          : <button className={b('button')} onClick={deleteFromBasket}>Удалить из корзины</button>
      }
    </div>
  );
};

export default ProductCart;