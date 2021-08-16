<template>
  <div class="row eachRoom me-0 p-0" v-for="room in rooms" :key="room.id">
    <div class="col-12 col-md-5">
      <div class="label d-flex position-relative">
        <div class="perfect me-auto">超讚房東</div>
        <Heart
          class="d-md-none"
          data-bs-target="#wish"
          data-bs-toggle="offcanvas"
          aria-controls="offcanvasBottom"
          style="
            height: 24px;
            width: 24px;
            fill: rgba(0, 0, 0, 0.5);
            stroke: #fff;
            stroke-width: 2;
            overflow: visible;
          "
        ></Heart>
      </div>
      <CreateWish></CreateWish>
      <Wish></Wish>
      <div>
        <RoomSwiper :roomPicture="room.picture[0]"></RoomSwiper>
      </div>
    </div>
    <div
      class="
        col-12 col-md-7
        d-md-flex
        flex-md-column
        justify-content-md-between
        my-1 px-md-2
      "
    >
      <div class="row">
        <div class="col col-md-10 ">
          <div class="comment d-inline-flex d-md-none my-1">
            <Star></Star>
            <span class="starScore" id="starScore">
              {{ room.comment.star }}
            </span>
            <span class="commentCount" id="commentCount"
              >({{ room.comment.TotalComments }})</span
            >
          </div>
          <div class="typeAddress d-md-none my-1">
            {{ room.houseType }}．{{ room.address }}
          </div>
          <div class="mdTypeAddress d-none d-md-block ">
            位於{{ room.address }}的{{ room.houseType }}
          </div>
          <div class="title my-1">
            {{ room.Title }}
          </div>
        </div>
        <div class="col-md-2 d-none d-md-block text-md-end">
          <Heart
            class="d-none d-md-block"
            data-bs-toggle="modal"
            data-bs-target="#mdWish"
            style="
              width: 45px;
              height: 45px;
              border-radius: 50%;
              padding: 10px;
              fill: transparent;
              stroke: #000;
              stroke-width: 2;
              overflow: visible;
            "
          ></Heart>
        </div>
      </div>
      <div class="row d-none d-md-block ">
        <div class="space">
          <span v-if="room.Space.CustomerNumber" class="customer">
            {{ room.Space.CustomerNumber }}位．</span
          >
          <span v-if="room.Space.Bedroom" class="bedRoom">
            {{ room.Space.Bedroom }}間臥室．</span
          >
          <span v-if="room.Space.Bed" class="bed">
            {{ room.Space.Bed }}張床．</span
          >
          <span v-if="room.Space.Bathroom" class="bathRoom">
            {{ room.Space.Bathroom }}間衛浴
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
        <div class="originAndSweet text-md-end my-1">
          <span class="origin">
            $ {{ convertToLocaleString(room.Price.origin) }}
          </span>
          <span class="sweetPrice">
            $
            {{ plusServiceFee(room.Price, nightCount) }}
            TWD
          </span>
          / 晚
        </div>
        <div class="total d-md-flex">
          <div class="mdComment d-none d-md-inline-flex align-items-center">
            <Star></Star>
            <span class="starScore fw-bold" id="starScore">
              {{ room.comment.star }}
            </span>
            <span class="commentCount" id="commentCount"
              >({{ room.comment.TotalComments }}則評論)</span
            >
          </div>
          <div
            class="totalLink d-md-none my-1"
            type="button"
            data-bs-target="#PriceDetail"
            data-bs-toggle="offcanvas"
            aria-controls="offcanvasBottom"
            v-on:click="deliverDataToDetail(room.Price)"
          >
            總計 ${{ getTotal(room.Price, nightCount) }} TWD
          </div>
          <a
            class="btn mdTotalLink d-none d-md-inline ms-md-auto"
            id="mdTotalLink"
            role="button"
            data-bs-toggle="modal" data-bs-target="#myModal"
            v-on:click="deliverDataToDetail(room.Price)"
          >
            總計 ${{ getTotal(room.Price, nightCount) }} TWD
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
</style>


<script>
import Star from "./Star.vue";
import RoomSwiper from "./Swiper.vue";
import PriceDetail from "./PriceDetail.vue";
import MdPriceDetail from "./MdPriceDetail.vue";
import Wish from "./Wish.vue";
import CreateWish from "./CreateWish.vue";
import Heart from "./Heart.vue";
export default {
  components: {
    Star,
    RoomSwiper,
    PriceDetail,
    MdPriceDetail,
    Wish,
    CreateWish,
    Heart,
  },
  data() {
    return {
      priceDetail: null,
    };
  },
  props: {
    rooms: { type: Object },
    nightCount: { type: Number },
  },
  methods: {
    convertToLocaleString(price) {
      return price.toLocaleString();
    },
    plusServiceFee(price, nightCount) {
      return Math.round(
        (Number(price.sweetPrice) * nightCount + Number(price.Fee.ServiceFee)) /
          nightCount
      ).toLocaleString();
    },
    getTotal(price, nightCount) {
      let feeTotal;
      let sweetprice = price.sweetPrice;
      let cleanFee = price.Fee.CleanFee;
      let taxFee = price.Fee.taxFee;
      let serviceFee = price.Fee.ServiceFee;
      if (cleanFee && taxFee && serviceFee) {
        feeTotal = Number(cleanFee) + Number(serviceFee) + Number(taxFee);
      } else if (!cleanFee && !taxFee && !serviceFee) {
        feeTotal = Number(serviceFee);
      } else if (cleanFee && !taxFee && serviceFee) {
        feeTotal = Number(serviceFee) + Number(cleanFee);
      } else if (!cleanFee && taxFee && serviceFee) {
        feeTotal = Number(taxFee) + Number(serviceFee);
      }
      return (Number(sweetprice) * nightCount + feeTotal).toLocaleString();
    },
    deliverDataToDetail(price) {
      this.priceDetail = price
    },
  },
};
</script>
