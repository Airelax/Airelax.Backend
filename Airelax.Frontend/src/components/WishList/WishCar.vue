<template>
  <div class="col-12 col-md-6 col-xl-4" v-for="i in wishList" :key="i">
    <div class="car">
      <img :src="i.photo" alt="Photo" />
      <div class="content">
        <div class="starContainer">
          <Star></Star>&nbsp;4.5&nbsp;
          <span> &nbsp;({{ i.comment.totalComments }}則評論) </span>
        </div>
        <div class="title">
          <span>{{ i.houseCategory }}．位於{{ i.location }}</span>
          <span>{{ i.title }}</span>
        </div>
        <div class="price">
          <span>每晚${{ i.pricePerNight }} TWD</span>
        </div>
      </div>
      <div class="foot">
        <span>最多{{ i.customerNumber }}人</span>
      </div>
    </div>
  </div>
</template>

<script>
import Star from "../Search/Star.vue";
export default {
  components: { Star },
  props: {
    wishList: { type: Array },
  },
};
</script>

<style scoped>
.car {
  padding: 8px 0 12px;
}
.car img {
  width: 100%;
  border-radius: 12px;
}
.car .content .starContainer {
  font-size: 15px;
  padding: 12px 0 9px;
  display: flex;
  align-items: center;
}
.car .content .starContainer span {
  font-size: 14px;
  color: #747474;
}
.car .content .title span:nth-child(1) {
  display: block;
}
.car .content .price span {
  font-weight: 600;
  text-decoration: underline;
}
.car .foot span {
  display: none;
}
@media screen and (min-width: 768px) {
  .row .col-12.col-md-6.col-xl-4:nth-child(odd) .car {
    padding-right: 12px;
  }
  .row .col-12.col-md-6.col-xl-4:nth-child(even) .car {
    padding-left: 12px;
  }
  .car .content .price span {
    display: block;
    margin: 9px 0;
  }
  .car .foot span {
    width: fit-content;
    font-size: 14px;
    font-weight: 600;
    color: #727272;
    padding: 9px 0;
    display: block;
    border-top: 1px solid #bfbfbf;
  }
}
@media screen and (min-width: 1200px) {
  .row .col-12.col-md-6.col-xl-4:nth-child(odd) .car {
    padding-right: 0;
  }
  .row .col-12.col-md-6.col-xl-4:nth-child(even) .car {
    padding-left: 0;
  }
  .row .col-12.col-md-6.col-xl-4:first-child .car {
    padding-right: 16px;
  }
  .row .col-12.col-md-6.col-xl-4:nth-child(2n) .car {
    padding-right: 8px;
    padding-left: 8px;
  }
  .row .col-12.col-md-6.col-xl-4:nth-child(3n) .car {
    padding-left: 16px;
  }
}
</style>