module.exports = {
  devServer: {
    proxy: {
      "/api/*": {
        target: "http://localhost:5000",
        secure: false,
      },
    },
  },
  css: {
    loaderOptions: {
      sass: {
        implementation: require("sass"), // This line must in sass option
      },
    },
  },
};
