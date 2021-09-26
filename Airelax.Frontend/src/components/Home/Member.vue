<template>
  <div class="List-pill rounded-pill" @click="show">
    <div class="ham"></div>
    <i class="fas fa-user-circle"></i>
    <i v-if="haveMessage" class="fas fa-circle ms-2 haveMessage"></i>
    <ul class="list-group text-start" v-if="$store.state.login.token != ''">
      <router-link :to="{ path: `/message`}" class="text-decoration-none"> 
        <li class="list-group-item border-0 rounded-top d-flex align-items-center">
            <strong>訊息</strong> <i v-if="haveMessage" class="fas fa-circle ms-2" style="font-size:.5rem;color: #ff385c;"></i>
        </li>
      </router-link>
      <a href="/trip" class="text-decoration-none">
        <li class="list-group-item border-0">
            <strong>旅程</strong>
        </li>
      </a>
      <router-link to="/wishLists" class="text-decoration-none">
        <li class="list-group-item border-0 border-bottom">
            <strong>心願單</strong>
        </li>
      </router-link>
      <a href="/member/today" class="text-decoration-none">
        <li class="list-group-item border-0">
            <strong>管理房源</strong>
        </li>
      </a>
      <a href="/member" class="text-decoration-none">
        <li class="list-group-item border-0 border-bottom">
            <strong>帳號</strong>
        </li>
      </a>
      <router-link to="/" class="text-decoration-none">
        <li class="list-group-item border-0">
            <strong>協助</strong>
        </li>
      </router-link>
      <a href="/account/logout" class="text-decoration-none">
        <li class="list-group-item border-0 rounded-end">
            <strong>登出</strong>
        </li>
      </a>
    </ul>
    <ul class="list-group text-start" v-else>
      <a href="/account/login" class="text-decoration-none">
        <li class="list-group-item border-0 rounded-top">
            <strong>登入</strong>
        </li>
      </a>
      <a href="/account/register"  class="text-decoration-none">
        <li class="list-group-item border-0 border-bottom">
            <strong>註冊</strong>
        </li>
      </a>
      <router-link to="/become-host" class="text-decoration-none">
        <li class="list-group-item border-0">
            <strong>出租房源</strong>
        </li>
      </router-link>
      <router-link to="/" class="text-decoration-none">
        <li class="list-group-item border-0">
            <strong>協助</strong>
        </li>
      </router-link>
    </ul>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data(){
    return{
      haveMessage: false
    }
  },
  methods: {
    show() {
      let banner = document.getElementById('banner');
      let listGroup = document.querySelector('.list-group');
      listGroup.style.display = 'block';
      banner.style.display = 'block';
      banner.addEventListener('click', (e) => {
        listGroup.style.display = 'none';
        e.target.style.display = 'none';
      })
    },
    redirect(){
      this.$router.push({
          path: `/room/${this.mes.landlord.houseId}`,
      });
    }
  },
  mounted() {
    let listGroup = document.querySelector('.list-group');
    window.addEventListener("scroll", function () {
      listGroup.style.display = 'none';
    });

    let vm = this;
      if(vm.$store.state.login.memberId != ""){
          axios.get(`/api/messages/${this.$store.state.login.memberId}`, {
              headers: {"Access-Control-Allow-Origin": "*",}})
              .then((res) => {
                  res.data.forEach(x=>{
                      if(vm.$store.state.login.memberId == x.landlord.id){
                          if(x.memberOneStatus != 0) vm.haveMessage = true;
                      }
                      else{
                          if(x.memberTwoStatus != 0) vm.haveMessage = true;
                      }
                  });
          });
      }
  }
}
</script>

<style lang="scss" scoped>
.haveMessage{
  position: absolute;
  right: -28%;
  top: -8%;
  font-size: 1rem;
  color: #ff385c;
}

.List-pill {
  background-color: #ffffff;
  width: 77px;
  height: 42px;
  display: flex;
  flex-direction: row;
  align-items: center;
  position: relative;
  cursor: pointer;
  border-radius: 18px;
  border: 1px solid rgb(184, 184, 184);
}

.list-group {
  position: absolute;
  top: 53px;
  right: 0;
  width: 225px;
  display: none;
  z-index: 10;
  border-radius: 18px;
  overflow: hidden;
  border: 1px solid rgb(184, 184, 184);
}

.ham {
  display: block;
  content: '';
  height: 2px;
  width: 15px;
  background-color: #222222;
  margin: auto;
  box-shadow: 0px 4px 0px #222222,
  0px -4px 0px #222222;
}

.list-group-item {
  padding: 15px;
}

.list-group li a {
  text-decoration: none;
  color: black;
}

.list-group li:hover {
  background-color: #E7F0EB;
}

.list-group li {
  font-size: .5rem;
  line-height: 18px;
}

i {
  width: 2rem;
  font-size: 1.5rem;
  text-align: left;
}

strong {
  font-weight: 400;
  font-size: 1rem;
}
</style>