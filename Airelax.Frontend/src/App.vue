<template>
  <Layout>
    <router-view />
  </Layout>
</template>

<script>
import Layout from './components/Layout/Default';
export default {
  components:{Layout},
  mounted(){
    let vm = this;
    vm.$store.state.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function() {
        vm.$store.state.fullWidth = document.body.clientWidth;
    });
  }  
}
</script>

<style lang="scss">
#app {
  position: relative;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
}
</style>


