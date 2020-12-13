const path = require('path');

module.exports = {
  entry: {
		main: [
			'@babel/polyfill',
			'./src/index.js',
		]
	},
  output: {
    filename: 'app.js',
    path: path.resolve(__dirname, 'dist'),
  },
  module: {
    rules: [
      {
        test: /\.m?js$/,
        exclude: /(node_modules|bower_component)/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: ['@babel/preset-env'],
            plugins: [
              '@babel/plugin-transform-runtime',
              '@babel/plugin-transform-dotall-regex'
            ]
          }
        }
      }
    ]
  }
};