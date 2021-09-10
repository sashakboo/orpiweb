import block from 'bem-cn-lite';
import * as React from 'react';
import { autobind } from 'core-decorators';

import { getEntity } from './api';
import './test-button.css';

interface ITestButtonProps {
  text: string;
}

const b = block('test-button');

@autobind
export default class TestButton extends React.Component<ITestButtonProps> {

  private async handleClick(): Promise<void> {
    try {
      const entity = await getEntity();
      alert(`Entity loaded: ${entity.Name}`);
    }
    catch (error) {
      alert(error.message);
    }
  }

  public render(): React.ReactNode {
    return (
      <input
        className={b()}
        type='button'
        value={this.props.text}
        onClick={this.handleClick}
      />
    );
  }
}
