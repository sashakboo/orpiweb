import * as React from 'react';
import { NavLink } from 'react-router-dom';
import block from 'bem-cn-lite';

import './Header.css';

const b = block('header');

export const Header: React.FC = (props) => {
  return (
    <nav className={b()}>
      <img src='../../images/header_logo.svg' />
      <NavLink
        to='/basket'
        exact={true}
        className={b('navlink')}
        activeClassName={b('navlink', { active: true })}
      >
        Корзина
      </NavLink>
    </nav>
  );
};