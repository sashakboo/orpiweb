module.exports = {
  'extends': 'stylelint-config-recommended',
  'rules': {
    'at-rule-no-unknown': [ true, {
      'ignoreAtRules': [
        'b', 'e', 'm', 'each'
      ]
    }],
    'shorthand-property-no-redundant-values': null,
    // Stylistic issues
    'color-hex-case': 'lower',
    'function-name-case': 'lower',
    'value-keyword-case': 'lower',
    'property-case': 'lower',
    'selector-pseudo-class-case': 'lower',
    'selector-pseudo-element-case': 'lower',
    'selector-type-case': 'lower',
    'unit-case': 'lower',
    'at-rule-name-case': 'lower',
    'string-quotes': 'single',
    'function-url-quotes': 'always',
    'length-zero-no-unit': true,
    'at-rule-name-space-after': 'always',
    'at-rule-semicolon-space-before': 'never',
    'at-rule-semicolon-newline-after': 'always',
    'declaration-block-semicolon-newline-after': 'always',
    'declaration-block-trailing-semicolon': 'always',
    'indentation': 2,
    'declaration-colon-space-after': 'always'
  }
};
