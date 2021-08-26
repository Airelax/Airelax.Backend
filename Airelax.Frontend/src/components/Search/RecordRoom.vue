<template>
  <div
    class="col-12 col-md-4 eachRoomCol"
    type="button"
    v-for="room in rooms"
    :key="room.id"
  >
    <div class="row">
      <div class="label d-flex position-relative">
        <div class="perfect me-auto">超讚房東</div>
        <Heart
          class="d-none d-md-block"
          data-bs-target="#mdWish"
          data-bs-toggle="modal"
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
      <Wish></Wish>
      <div><RoomSwiper :roomPicture="room.picture[0]"></RoomSwiper></div>
    </div>
    <div class="row">
      <div class="col">
        <div class="comment d-inline-flex my-1">
          <Star></Star>
          <span class="starScore">
            {{ room.comment.star }}
          </span>
          <span class="commentCount">({{ room.comment.TotalComments }})</span>
        </div>
        <div class="typeAddress my-1">
          {{ room.houseType }}．{{ room.address }}
        </div>
        <div class="title my-1">
          {{ room.Title }}
        </div>
      </div>
    </div>
    <div class="row">
      <div class="originAndSweet my-1">
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
      <div class="total my-1">
        <div
          class="totalLink d-md-none"
          data-bs-target="#recordPriceDetail"
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
          data-bs-toggle="modal"
          data-bs-target="#myModal"
          v-on:click="deliverDataToDetail(room.Price)"
        >
          總計 ${{ getTotal(room.Price, nightCount) }} TWD
        </a>
      </div>
    </div>
  </div>
  <RecordPriceDetail
    :price="priceDetail"
    :nightCount="nightCount"
  ></RecordPriceDetail>
  <MdPriceDetail :price="priceDetail" :nightCount="nightCount"></MdPriceDetail>
</template>  

<style lang="scss" scoped>
@import url("https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap");
* {
  font-family: "Noto Sans TC", sans-serif;
  a {
    color: #000;
    text-decoration: none;
  }
  a:hover {
    color: #000;
  }
  .eachRoomCol {
    padding: 0.5rem;
    position: relative;
    bottom: 20px;
    .row {
      text-align: start;
    }
    .row:nth-of-type(1) {
      .label {
        top: 38px;
        z-index: 10;
        padding: 0 20px;
        .perfect {
          font-size: 12px;
          letter-spacing: 1px;
          color: #000;
          background-color: #fff;
          border: 1px solid transparent;
          border-radius: 5px;
          padding: 3px 8px;
        }
      }
    }
    .row:nth-of-type(2) {
      font-weight: 300;
      .col {
        .comment {
          .star {
            height: 14px;
            width: 14px;
            fill: #ff385c;
            margin: auto 4px;
          }
          .starScore,
          .commentCount {
            font-size: 14px;
          }
          .starScore {
            color: #000;
          }
          .commentCount {
            color: #717374;
            margin-left: 1px;
          }
        }
        .typeAddress,
        .mdTypeAddress {
          color: #000;
        }

        .title {
          color: #000;
          overflow: hidden;
          text-overflow: ellipsis;
          white-space: nowrap;
        }
      }
    }
    .row:nth-of-type(3) {
      color: #000;
      .originAndSweet {
        .sweetPrice,
        .origin {
          font-weight: 700;
        }
        .origin {
          color: #717176;
          text-decoration: line-through;
        }
      }
      .total {
        .totalLink,
        .mdTotalLink {
          font-size: 15px;
          text-decoration: underline;
          color: #717171;
        }
        .totalLink:hover,
        .mdTotalLink:hover {
          text-decoration: underline #000;
        }
      }
    }
  }
}
</style>


<script>
import Star from "./Star.vue";
import RecordPriceDetail from "./RecordPriceDetail.vue";
import RoomSwiper from "./Swiper.vue";
import Wish from "./Wish.vue";
import Heart from "./Heart.vue";
import MdPriceDetail from "./MdPriceDetail.vue";
export default {
  components: {
    Star,
    RecordPriceDetail,
    RoomSwiper,
    Wish,
    Heart,
    MdPriceDetail,
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
      this.priceDetail = price;
    },
  },
};
</script>
