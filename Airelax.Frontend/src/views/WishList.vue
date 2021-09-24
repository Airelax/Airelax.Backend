<template>
  <div class="heard">
    <router-link :to="{ name: 'wishLists' }">
      <img src="@/assets/image/WishList/comeBack.svg" alt="comeBack"
    /></router-link>
    <div class="checkWidth" v-if="$store.state.fullWidth < 768">
      <img
        data-bs-target="#editWish"
        data-bs-toggle="offcanvas"
        aria-controls="offcanvasBottom"
        src="@/assets/image/WishList/setUp.svg"
        alt="setUp"
      />
    </div>
    <div class="checkWidth" v-if="$store.state.fullWidth > 768">
      <img
        data-bs-target="#mdEditWish"
        data-bs-toggle="modal"
        src="@/assets/image/WishList/setUp.svg"
        alt="setUp"
      />
    </div>
  </div>
  <EditWishList></EditWishList>
  <DelWishList></DelWishList>
  <div class="main">
    <div class="title">
      <h2>{{ $store.state.wishListData.wishName }}</h2>
    </div>
    <div class="body">
      <div class="container-fluid">
        <div class="row">
          <WishCar :wishList="wishList"></WishCar>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import WishCar from "../components/WishList/WishCar.vue";
import EditWishList from "../components/WishList/EditWishList.vue";
import DelWishList from "../components/WishList/DelWishList.vue";
export default {
  data() {
    return {
      wishList: null,
    };
  },
  created() {
    const dataUrl = `/api/wishLists/${this.$store.state.wishListData.id}`;
    axios({
      method: "Get",
      url: dataUrl,
      headers: {
        "Content-Type": "application/json",
      },
      data: {
        wishId: this.$store.state.wishListData.id,
      },
    })
      .then((res) => {
        this.wishList = res.data;
      })
      .catch((err) => console.log(err));
  },
  components: {
    WishCar,
    EditWishList,
    DelWishList,
  },
};
</script>

<style scoped>
.heard {
  padding: 28px 24px 16px;
  margin-top: 120px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.heard a img,
.checkWidth img {
  width: 48px;
  height: 48px;
  border-radius: 50%;
  cursor: pointer;
}
.heard a img:hover,
.checkWidth img:hover {
  background-color: #eee;
}
.heard a img {
  padding: 15px;
  margin-left: -15px;
}
.checkWidth img {
  padding: 11px;
  margin-right: -11px;
}
.main {
  color: #222;
  padding: 0 24px;
  text-align: start;
}
.main .title h2 {
  font-size: 32px;
  font-weight: 600;
  line-height: 36px;
  margin: 20px 0 36px;
}
.container-fluid {
  padding: 0;
}
</style>