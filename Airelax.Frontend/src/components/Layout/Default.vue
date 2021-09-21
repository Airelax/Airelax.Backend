<template>
    <div id="banner"></div>
    <Header v-if="$store.state.fullWidth>768 && !$route.meta.homeLayout"></Header>
    <HomeHeader v-if="$store.state.fullWidth>768 && $route.meta.homeLayout"></HomeHeader>
    <slot/>
    <Footer v-if="!$route.meta.messageLayout || ($route.meta.searchPage && $store.state.fullWidth>768)"></Footer>
    <RwdNavbar v-if="$store.state.fullWidth<768 && isRwdShow"></RwdNavbar>
</template>

<script>
import Footer from './Footer';
import Header from './Header';
import HomeHeader from './HomeHeader';
import RwdNavbar from './RwdNavbar';
export default {
    data(){
        return{
            isRwdShow: true,
        }
    },
    components:{Footer, Header, RwdNavbar, HomeHeader},
    mounted(){
        const vm = this;
        window.addEventListener("scroll",function(){
          let cHeight = document.documentElement.clientHeight;
          let sHeight = document.documentElement.scrollHeight;
          let sTop = document.documentElement.scrollTop;
          if(sHeight <= cHeight+ sTop +200)
            vm.isRwdShow = false;
          else
            vm.isRwdShow = true;
        })
    }
}
</script>

<style lang="scss" scoped>
#banner {
    display: none;
    position: absolute;
    top: 0;
    width: 100%;
    height: 100vh;
    z-index: 5;
}
</style>