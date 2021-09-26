<template>
  <div class="cardTemplate">
    <h2>住宿地點</h2>
    <swiper
    :slides-per-view="3"
    navigation
    @swiper="onSwiper"
    @slideChange="onSlideChange" 
    class="rooms">
       <swiper-slide class="roomCards roomCardsWithOutPic" v-for="(room, index) in bedroom" :key="room.index">
        <div class="card">
          <div class="card-body p-0 py-2">
            <div class="beds"  v-for="(bed, index) in room.bedCount" :key="index">
              <div class="singleBed" v-if="room.bedType.includes('Single')">
                <img :src="require('@/assets/image/Room/bedWithoutPic/singleBed.svg')">
              </div>
            </div>

            <div
              class="beds"
              v-for="(bed, index) in room.bedCount"
              :key="index"
            >
              <div class="doubleBed" v-if="room.bedType.includes('Double')">
                <img :src="require('@/assets/image/Room/bedWithoutPic/doubleBed.svg')">
              </div>
            </div>

            <h3 class="card-text1 py-1"><strong>臥室{{ index + 1 }}</strong></h3>
            <h4 class="card-text2 py-1">{{ room.bedCount }}張{{ room.bedType == "Single" ? "單人床" : "雙人床" }}</h4>
          </div>
        </div>
      </swiper-slide>
    </swiper>
  </div>
</template>

<script>
// import axios from "axios";
import SwiperCore, { Navigation, Pagination, Scrollbar, A11y } from 'swiper';
import {Swiper,SwiperSlide} from'swiper/vue';
import "@/assets/sass/pagination.scss";
import "@/assets/sass/navigation.scss";
import "@/assets/sass/swiper.min.css";
SwiperCore.use([Navigation, Pagination, Scrollbar, A11y]);
export default {
  components: {
    Swiper,
    SwiperSlide
  },
  props:["bedroom"]
};
</script>

<style scoped lang="scss">
.swiper-container {
  width: 100%;
  height: 100%;
}

.cardTemplate {
  width: 100%;
  padding: 1.5rem 0;
  border-bottom: 1px solid rgba(138, 137, 137, 0.5);
  .swiper-button-prev,
  .swiper-button-next {
    display: flex;
    align-items: center;
    justify-content: center;
    color: rgb(255, 255, 255) !important;
    font-weight: 600;
    background-color: #ffffff80;
    border-radius: 50%;
  }
  h2 {
    font-size: 1.6rem;
    font-weight: 700;
    margin-bottom: 1.5rem;
  }
  .rooms {
    display: flex;
    .roomCards {
      margin-right: 1rem;
      .card {
        cursor: pointer;
        border: none;
        justify-content: start;
        text-align: start;
        .roomPic {
          width: 100%;
          border-radius: 10px;
        }
        .card-body {
          .beds {
            display: inline-block;
            .singleBed{
              width: 24px;
            }
            .doubleBed{
              width: 24px;
            }
          }
          h3{
            font-size: 16px;
          }
          h4{
            font-size: 4px;
          }
        }
      }
    }
  }
}
</style>