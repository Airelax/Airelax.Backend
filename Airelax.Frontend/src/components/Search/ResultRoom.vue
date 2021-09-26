<template>

  <div
      class="row eachRoom me-0 p-0"
      v-for="room in rooms"
      :key="room.id"
      style="cursor: pointer"
  >
    <div class="col-12 col-md-5">
      <div class="label d-flex position-relative">
        <div class="perfect me-auto">超讚房東</div>
        <Heart
            class="d-md-none .heart"
            data-bs-target="#wish"
            data-bs-toggle="offcanvas"
            aria-controls="offcanvasBottom"
            @click="updateWishList(room.id)"
            style="
            height: 24px;
            width: 24px;
            stroke: #fff;
            stroke-width: 2;
            overflow: visible;
          "
            :class="{
            wishHeart: wishLists
              ? wishLists
                  .flatMap((x) => x.houses)
                  .flatMap((x) => x)
                  .includes(room.id)
              : false,
          }"
        ></Heart>
      </div>
      <div>
        <RoomSwiper
            :roomPicture="room.picture"
            style="cursor: default"
            :houseId="room.id"
        ></RoomSwiper>
      </div>
    </div>
    <div
        class="
        col-12 col-md-7
        d-md-flex
        flex-md-column
        justify-content-md-between
        my-1
        px-md-2
      "
    >
      <div class="row">
        <div class="col col-md-10" @click="SearchRoom(room)">
          <div class="comment d-inline-flex d-md-none my-1">
            <Star></Star>
            <span class="starScore" id="starScore">
              {{ room.comment.star }}
            </span>
            <span class="commentCount" id="commentCount"
            >({{ room.comment.totalComments }})</span
            >
          </div>
          <div class="typeAddress d-md-none my-1">
            {{ room.houseType }}．{{ room.address }}
          </div>
          <div class="mdTypeAddress d-none d-md-block">
            位於{{ room.address }}的{{ room.houseType }}
          </div>
          <div class="title my-1" style="font-size: 1.3rem">
            {{ room.title }}
          </div>
        </div>
        <div class="col-md-2 d-none d-md-block text-md-end">
          <!--Todo 與愛心獨立事件有關的地方-->
          <Heart
              class="d-none d-md-block .heart"
              data-bs-toggle="modal"
              data-bs-target="#mdWish"
              @click="updateWishList(room.id)"
              style="
              width: 45px;
              height: 45px;
              border-radius: 50%;
              padding: 10px;
              stroke: #000;
              stroke-width: 2;
              overflow: visible;
            "
              :class="{
              wishHeart: wishLists
                ? wishLists
                    .flatMap((x) => x.houses)
                    .flatMap((x) => x)
                    .includes(room.id)
                : false,
            }"
          ></Heart>
        </div>
      </div>
      <div class="row d-none d-md-block" @click="SearchRoom(room)">
        <div class="space">
          <span v-if="room.space.customerNumber" class="customer">
            {{ room.space.customerNumber }}位．</span
          >
          <span v-if="room.space.bedroom" class="bedRoom">
            {{ room.space.bedroom }}間臥室．</span
          >
          <span v-if="room.space.bed" class="bed">
            {{ room.space.bed }}張床．</span
          >
          <span v-if="room.space.bathroom" class="bathRoom">
            {{ room.space.bathroom }}間衛浴
          </span>
        </div>
        <div class="facility">
          <span v-if="room.facility.AirConditioner">冷氣．</span>
          <span v-if="room.facility.Kitchen">廚房．</span>
          <span v-if="room.facility.wifi">Wifi．</span>
          <span v-if="room.facility.WashingMachine">洗衣機</span>
        </div>
      </div>
      <div class="row">
        <div class="originAndSweet text-md-end my-1" @click="SearchRoom(room)">
          <span class="origin">
            $ {{ convertToLocaleString(room.price.origin) }}
          </span>
          <span class="sweetPrice">
            $ {{ plusServiceFee(room.price) }} TWD
          </span>
          / 晚
        </div>
        <div class="total d-md-flex">
          <div
              class="mdComment d-none d-md-inline-flex align-items-center"
              @click="SearchRoom(room)"
          >
            <Star></Star>
            <span class="starScore fw-bold" id="starScore">
              {{ room.comment.star }}
            </span>
            <span class="commentCount" id="commentCount"
            >({{ room.comment.totalComments }}則評論)</span
            >
          </div>
          <div
              class="totalLink d-md-none my-1"
              type="button"
              data-bs-target="#PriceDetail"
              data-bs-toggle="offcanvas"
              aria-controls="offcanvasBottom"
              v-on:click="deliverDataToDetail(room.price)"
          >
            總計 ${{ getTotal(room.price, nightCount).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }} TWD
          </div>
          <a
              class="btn mdTotalLink d-none d-md-inline ms-md-auto"
              id="mdTotalLink"
              role="button"
              data-bs-toggle="modal"
              data-bs-target="#myModal"
              v-on:click="deliverDataToDetail(room.price)"
          >
            總計 ${{ getTotal(room.price, nightCount).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }} TWD
          </a>
        </div>
      </div>
    </div>
  </div>
  <PriceDetail :price="priceDetail" :nightCount="nightCount"></PriceDetail>
  <MdPriceDetail :price="priceDetail" :nightCount="nightCount"></MdPriceDetail>
</template>

<style lang="scss" scoped>
@import url("https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap");
@import "@/assets/sass/search.scss";

.heart {
  fill: transparent;
}

.wishHeart {
  fill: rgb(255, 56, 92);
}
</style>

<script>
import Star from "./Star.vue";
import RoomSwiper from "./Swiper.vue";
import PriceDetail from "./PriceDetail.vue";
import MdPriceDetail from "./MdPriceDetail.vue";

import Heart from "./Heart.vue";

export default {
  components: {
    Star,
    RoomSwiper,
    PriceDetail,
    MdPriceDetail,

    Heart,
  },
  created() {
    console.log(this.wishLists);
  },
  data() {
    return {
      priceDetail: null,
    };
  },
  props: {
    rooms: {type: Object},
    nightCount: {type: Number},
    wishLists: {type: Array},
  },
  methods: {
    SearchRoom(room) {
      this.$store.state.roomPicture = room.picture
      this.$router.push({
        path: `/room/${room.id}`,
      });
    },
    convertToLocaleString(price) {
      return price.toLocaleString();
    },
    plusServiceFee(price) {
      return Number(
          price.sweetPrice == null ? price.origin : price.sweetPrice
      ).toLocaleString();
    },
    getTotal(price, nightCount) {
      let feeTotal;
      let sweetPrice =
          price.sweetPrice == null ? price.origin : price.sweetPrice;
      let cleanFee = this.getPrice(price.fee.cleanFee);
      let taxFee = this.getPrice(price.fee.taxFee);
      let serviceFee = this.getPrice(price.fee.serviceFee);
      feeTotal = cleanFee + taxFee + serviceFee;

      return Number(sweetPrice) * nightCount + feeTotal;
    },
    deliverDataToDetail(price) {
      this.priceDetail = price;
    },

    getPrice(price) {
      if (typeof price == undefined) return 0;
      return Number(price);
    },

    updateWishList(houseId) {
      this.$store.state.selectedWishHouseId = houseId;
    },
  },
};
</script>