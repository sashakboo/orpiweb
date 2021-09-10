import * as React from 'react';

const Loader: React.FC = () => {
  return (
    <div
      style={{
        margin: '0 auto',
        border: '2px solid black',
        borderRadius: '5px',
        background: '#2135eb',
        opacity: 0.5,
        padding: '2px'
      }}
    >
      Loading...
    </div>
  );
};

export default Loader;