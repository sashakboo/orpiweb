import { IProductCategory } from './ProductCategory';

export interface IProduct {
  Id: number;
  Category: IProductCategory;
  Name: string;
  Price: number;
  InBasket: boolean;
}