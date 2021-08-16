module.exports = {
  devServer: {
    proxy: {
      '/api/*': {
        target: 'https://localhost:5001',
        secure: false
      }
    }
  },
  css: {
    loaderOptions: {
      sass: {
        implementation: require('sass'), // This line must in sass option
      },
    },
  }
};
