import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import block from 'bem-cn-lite';

import { Header } from './components/Header/Header';
import { Sidebar } from './components/Sidebar/Sidebar';
import Products from './containers/Products/Products';
import { IProductCategory } from './types/ProductCategory';
import { getProductCategories } from './api';
import './App.css';

const b = block('app-container');

interface IAppProps {

}

interface IAppState {
  categories: Array<IProductCategory>;
}

export default class App extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps) {
    super(props);
    this.state = {
      categories: []
    };
  }

  public async componentDidMount(): Promise<void> {
    const categories = await getProductCategories();
    this.setState({
      categories
    });
  }

  private renderRoutes = () => {
    return (
      <Switch>
        {
          this.state.categories.map((cat, index) => {
            return (
              <Route
                exact={true}
                key={cat.Name}
                path={`/category/${cat.Name}`}
              >
                <Products
                  title={cat.Title}
                  category={cat}
                />
              </Route>
            );
          })
        }
        <Route path='/basket'>
          <Products
            isBasket={true}
            title='Корзина'
          />
        </Route>

        <Route path={'/'} >
          <Products
            title='Не выбрано'
          />
        </Route>

      </Switch>
    );
  }

  public render(): React.ReactNode {
    return (
      <div className={b()}>
        <div className={b('header')}>
          <Header />
        </div>
        <div className={b('sidebar')}>
          <Sidebar
            links={this.state.categories}
            title={'Категории товаров'}
          />
        </div>
        <div className={b('content')}>
          {this.renderRoutes()}
        </div>
      </div>
    );
  }
}