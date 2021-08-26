<template>
  <div class="container-xl">
    <FrontPage></FrontPage>
    <div class="row rwd flex-md-row-reverse">
      <div class="col-12 col-md-6">
        <div class="sticky">
          <SubRoom v-if="get" :room="room" :nightCount="nightCount"></SubRoom>
          <SubPriceDetail
            v-if="get && fullWidth >= 768"
            :room="room"
            :nightCount="nightCount"
          ></SubPriceDetail>
        </div>
      </div>
      <div class="col-12 col-md-6">
        <YourTrip :fullWidth="fullWidth"></YourTrip>
        <PayWay :fullWidth="fullWidth"></PayWay>
        <SubPriceDetail
          v-if="get && fullWidth < 768"
          :room="room"
          :nightCount="nightCount"
        ></SubPriceDetail>
        <RequiredInfo :fullWidth="fullWidth"></RequiredInfo>
        <Unsubscribe></Unsubscribe>
        <CheckAndSub></CheckAndSub>
      </div>
    </div>
  </div>
</template>
<style lang="scss">
@import "../assets/css/reset.css";
@import url(https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap);
@import "../assets/sass/Subscribe/Subscribe.scss";
</style>
<script>
import axios from "axios";
import SubRoom from "../components/Subscribe/SubRoom.vue";
import FrontPage from "../components/Subscribe/FrontPage.vue";
import YourTrip from "../components/Subscribe/YourTrip.vue";
import PayWay from "../components/Subscribe/PayWay.vue";
import SubPriceDetail from "../components/Subscribe/SubPriceDetail.vue";
import RequiredInfo from "../components/Subscribe/RequiredInfo.vue";
import Unsubscribe from "../components/Subscribe/Unsubscribe.vue";
import CheckAndSub from "../components/Subscribe/CheckAndSub.vue";
export default {
  components: {
    SubRoom,
    FrontPage,
    YourTrip,
    PayWay,
    SubPriceDetail,
    RequiredInfo,
    Unsubscribe,
    CheckAndSub,
  },
  created() {
    axios
      .get(
        "https://raw.githubusercontent.com/Airelax/Airelax.Frontend/SHOP-67/fake-room-data.json"
      )
      .then((res) => {
        this.room = res.data;
        this.get = true;
      });
  },
  data() {
    return {
      room: Object,
      nightCount: 3,
      get: false,
      fullWidth: 0,
    };
  },
  watch: {
    fullWidth(val) {
      this.fullWidth = val;
    },
  },
  mounted() {
    window.scrollTo(0, 0);
    const vm = this;
    this.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function () {
      vm.fullWidth = document.body.clientWidth;
    });
  },
};
</script>
