<template>
  
  <!-- 創建new-house -->
  <div v-if="$route.meta.newHouseLayout">
      <router-view />
  </div>

  <!-- default -->
  <div v-else>
    <DefaultLayout>
      <router-view />
    </DefaultLayout>
  </div>

</template>

<script>
import DefaultLayout from "./components/Layout/Default";
export default {
  components: { DefaultLayout },
  mounted() {
    let vm = this;
    vm.$store.state.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function () {
      vm.$store.state.fullWidth = document.body.clientWidth;
    });
  }
};
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



