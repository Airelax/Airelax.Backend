<template>
  <div class="page">
    <div v-if="isVideoBanner" class="rent-banner viedo-banner">
      <VideoBanner :image="img" :title="title"></VideoBanner>
    </div>
    <div v-else class="rent-banner">
      <Banner :title="title"></Banner>
    </div>
    <div
      :class="isVideoBanner ? 'video-rent-content' : ''"
      class="rent-content"
    >
      <Content :notFirst="notFirst">
        <slot></slot>
      </Content>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.page {
  display: block;
}

.rent-banner {
  height: 30vh;
  width: 100%;
  position: relative;
}

.rent-content {
  margin-top: -20px;
  padding-top: 40px;
  height: 80vh;
  width: 100%;
  background-color: #fff;
  border-radius: 20px 20px 0 0;
  position: relative;
  box-sizing: border-box;
}

.video-rent-content {
  height: 50vh;
}

.viedo-banner {
  height: 50vh;
}

@media screen and (min-width: 768px) {
  .page {
    display: flex;
  }

  .rent-banner {
    height: 100vh;
    margin-bottom: 0;
    width: 50%;
  }

  .rent-content {
    margin-top: 0;
    padding-top: 0;
    width: 50%;
    height: 100vh;
  }
}
</style>

<script>
import VideoBanner from "./VideoBanner.vue";
import Banner from "./Banner.vue";
import Content from "./Content.vue";

export default {
  props: {
    title: {
      type: String,
      default: "未命名標題",
    },
    notFirst: {
      type: Boolean,
      default: true,
    },
    isVideoBanner: {
      type: Boolean,
      default: false,
    },
    img: { type: String },
  },
  components: {
    Banner,
    Content,
    VideoBanner,
  },
};
</script>