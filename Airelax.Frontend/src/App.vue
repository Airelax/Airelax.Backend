<template>
  
  <!-- 創建new-house -->
  <div v-if="$route.meta.plainLayout">
      <router-view />
  </div>

  <!-- default -->
  <div v-else>
    <DefaultLayout>
      <router-view v-if="isRouterAlive"/>
    </DefaultLayout>
  </div>

</template>

<script>
import DefaultLayout from "./components/Layout/Default";
export default {
  components: { DefaultLayout },
  data() {
    return {
      isRouterAlive: true
    };
  },
  provide() {
    return {
      reload: this.reload
    };
  },
  mounted() {
    let vm = this;
    vm.$store.state.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function () {
      vm.$store.state.fullWidth = document.body.clientWidth;
    });
  },
  computed:{
    start(){
      return this.$store.state.date.start
    },
    end(){
      return this.$store.state.date.end
    },
  },
  watch: {
    start(){
      if(this.$store.state.date.toString().includes('標準時間')) return
      this.Diff()
    },
    end(){
      if(this.$store.state.date.toString().includes('標準時間')) return
      this.Diff()
    },
  },
  methods:{
    getDate(x){
      let year = x.slice(0,4)
      let month = x.slice(5,7)
      let day = x.slice(8,10)
      return Date.parse(`${year}-${month}-${day}`);
    },
    Diff(){
      let diff = this.getDate(this.$store.state.date.end)-this.getDate(this.$store.state.date.start);
      this.$store.state.nightCount =  Math.abs(diff)/1000/24/60/60;
    },
    reload() {
      this.isRouterAlive = false;
      this.$nextTick(() => {
        this.isRouterAlive = true;
      });
    }
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



