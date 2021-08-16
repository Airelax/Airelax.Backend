<template>
  <swiper
    :slidesPerView="1"
    :spaceBetween="0"
    :loop="false"
    :pagination="{
      clickable: true,
    }"
    :navigation="true"
    class="roomPicture"
  >
    <swiper-slide v-for="picture in roomPicture" :key="picture.index" >
      <img :src="picture" />
    </swiper-slide>
  </swiper>
</template>

<style scoped>
.swiper-container {
  width: 100%;
  height: 100%;
  overflow: hidden;
  border-radius: 18px;
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.swiper-slide img {
  display: block;
  width: 100%;
  height: 100%;
}

.swiper-container {
  margin-left: auto;
  margin-right: auto;
}
</style>

<script>
import { Swiper, SwiperSlide } from "swiper/vue";
import SwiperCore, { Pagination, Navigation } from "swiper/core";
SwiperCore.use([Pagination, Navigation]);
import "@/assets/sass/pagination.scss";
import "@/assets/sass/navigation.scss";
import "@/assets/sass/swiper.min.css";

export default {
  components: {
    Swiper,
    SwiperSlide,
  },
  props: ["roomPicture"],
};
</script>