import * as React from 'react';
import block from 'bem-cn-lite';

import ProductCart from '../../components/ProductCart/ProductCart';
import Loader from '../..//components/UI/Loader/Loader';
import { IProductCategory } from '../../types/ProductCategory';
import { IProduct } from '../../types/Product';
import {
  addToBasket,
  deleteFromBasket,
  getBasket,
  getProducts,
 } from '../../api';

import './Products.css';

const b = block('products');

interface IProductsProps {
  isBasket?: boolean;
  title: string;
  category?: IProductCategory;
}

interface IProductsState {
  products: Array<IProduct>;
  isLoaded: boolean;
}

export default class Products extends React.Component<IProductsProps, IProductsState> {
  constructor(props: IProductsProps) {
    super(props);
    this.state = {
      products: [],
      isLoaded: false
    };
  }

  public async componentDidMount(): Promise<void> {
    let products: Array<IProduct> = [];

    if (this.props.category != null) {
      products = await getProducts(this.props.category.Id);
    } else {
      if (this.props.isBasket)
        products = await getBasket();
    }

    this.setState({
      products,
      isLoaded: true
    });
  }

  private addProductToBasket = async (productToBasket: IProduct) => {
    const product = { ...productToBasket };
    product.InBasket = true;

    await addToBasket(product);
    this.setState((prevState) => {
      const products = [...prevState.products].map(x => x.Id === product.Id ? product : x);
      return {
        products
      };
    });
  }

  private deleteProductFromBasket = async (productToBasket: IProduct) => {
    const product = { ...productToBasket };
    product.InBasket = false;

    await deleteFromBasket(product);
    this.setState((prevState => {
      let products = [...prevState.products].map(x => x.Id === product.Id ? product : x);
      if (this.props.isBasket)
        products = products.filter(x => x.InBasket);

      return {
        products
      };
    }));
  }

  private renderContent = (): React.ReactNode => {
    if (!this.state.isLoaded) {
      return (
        <Loader />
      );
    }

    const products = [...this.state.products];

    if (products.length > 0) {
      return products.map((product, index) => {
        return (
          <div key={index} className={b('item')}>
            <ProductCart
              product={product}
              onAddHandler={this.addProductToBasket}
              onDeleteHanler={this.deleteProductFromBasket}
            />
          </div>
        );
      });
    }

    if (products.length === 0 && this.props.isBasket)
      return (
        <div>Корзина пуста</div>
      );

    if (products.length === 0 && this.props.category != null)
      return (
        <div>Нет товаров в выбранной категории</div>
      );

    return null;
  }

  public render(): React.ReactNode {
    return (
      <div className={b()}>
        <h2 className={b('header')}>{this.props.title}</h2>

          { this.renderContent() }

      </div>
    );
  }
}