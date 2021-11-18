const path = require('path');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const Dotenv = require('dotenv-webpack');

module.exports = {
  entry: './src/main.ts',
  devtool: 'inline-source-map',
  plugins: [
    new CopyWebpackPlugin([{
      from: './index.html'
    }]),
    new CopyWebpackPlugin([{
      from: './styles/*'
    }]),
    new CopyWebpackPlugin([{
      from: './assets/*'
    }]),
    new Dotenv({
      path:"../.env",
      systemvars: true
    })
  ],
  module: {
    rules: [
      {
        test: /\.ts?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader']
      }
    ]
  },
  resolve: {
    extensions: [ '.ts', '.tsx', '.js' ]
  },
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist')
  }
};
