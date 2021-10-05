import { IProduct } from './types/Product';
import { IProductCategory } from './types/ProductCategory';

export async function getProductCategories(): Promise<Array<IProductCategory>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };

  const response = await fetch('api/products/categories', options);
  if (response.status === 200) {
    return await response.json();
  }

  throw new Error(`Error: ${response.statusText}`);
}

export async function getProducts(typeId: number): Promise<Array<IProduct>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };

  const response = await fetch('api/products/GetProducts?productTypeId=' + typeId.toString(), options);
  if (response.status === 200) {
    return await response.json();
  }

  throw new Error(`Error: ${response.statusText}`);
}

export async function getBasket(): Promise<Array<IProduct>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };

  const response = await fetch('api/products/GetBasket', options);
  if (response.status === 200) {
    return await response.json();
  }

  throw new Error(`Error: ${response.statusText}`);
}

export async function addToBasket(product: IProduct) {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'POST',
    body: JSON.stringify(product)
  };

  const response = await fetch('api/products/AddToBasket', options);
  if (response.status !== 200) {
    throw new Error(`Error: ${response.statusText}`);
  }
}

export async function deleteFromBasket(product: IProduct) {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'POST',
    body: JSON.stringify(product)
  };

  const response = await fetch('api/products/DeleteFromBasket', options);
  if (response.status !== 200) {
    throw new Error(`Error: ${response.statusText}`);
  }
}