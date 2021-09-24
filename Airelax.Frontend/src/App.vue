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
    //login-check
    this.loginChcek();
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
    //登入檢查
    loginChcek(){
      const token = this.getCookie('yee_mother_fucker');
      this.$store.state.login.token = token;
      // if(!token)  window.location.href = 'https://localhost:5001/account/login';
      if(token != ""){
        const memberInfo = this.parseJwt(token);
        this.$store.state.login.memberId = memberInfo['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      }
    },
    parseJwt(token){
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
      }).join(''));

      return JSON.parse(jsonPayload);
    },
    getCookie(cname){
      let name = cname + "=";
      let decodedCookie = decodeURIComponent(document.cookie);
      let ca = decodedCookie.split(';');
      for (let i = 0; i < ca.length; i++) {
          let c = ca[i];
          while (c.charAt(0) === ' ') {
              c = c.substring(1);
          }
          if (c.indexOf(name) === 0) {
              return c.substring(name.length, c.length);
          }
      }
      return "";
    },
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



