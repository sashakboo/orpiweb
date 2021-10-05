import * as React from 'react';
import {
  NavLink
} from 'react-router-dom';
import block from 'bem-cn-lite';

import Loader from '../UI/Loader/Loader';
import { IProductCategory } from '../../types/ProductCategory';

import './Sidebar.css';

const b = block('sidebar');

const navLinkStyle = b('navlink');
const activeNavlinkStyle = b('navlink', { active: true });

interface ISidebarProps {
  title: string;
  links: Array<IProductCategory>;
}

export const Sidebar: React.FC<ISidebarProps> = (props: ISidebarProps) => {
  const renderLinks = () => {
    if (props.links.length === 0)
      return (
        <Loader />
      );

    return props.links.map((link, index: number) => {
      return (
        <li key={index}>
          <NavLink
            to={'/category/' + link.Name}
            exact={true}
            className={navLinkStyle}
            activeClassName={activeNavlinkStyle}
          >
            {link.Title}
          </NavLink>
        </li>
      );
    });
  };

  return (
    <div className={b()}>
      <h2>
        {props.title}
      </h2>
      <ul className={b('list')}>
        {
          renderLinks()
        }
      </ul>
    </div>
  );
};