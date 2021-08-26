<template>
  <div class="banner">
    <img :src="image" alt="" />
    <div class="logo">
      <img src="https://picsum.photos/50/50/?random=1" />
    </div>
    <div class="content">
      <Helper></Helper>
      <h1>{{ title }}</h1>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.banner {
  height: 100%;
  position: relative;
  background-repeat: no-repeat;
  background-size: 100% 100%;
  img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    position: absolute;
    top: 0;
    left: 0;
    z-index: -1;
  }
  &::after {
    content: "";
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    margin: auto;
    background-color: rgba($color: #000000, $alpha: 0.5);
    position: absolute;
    z-index: -2;
  }
  .content {
    height: 100%;
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    margin: 0 5%;
  }
}
.helper {
  display: flex;
}

.logo {
  display: none;
}

h1 {
  color: #fff;
  position: relative;
  font-weight: 900;
  font-size: 26px;
  z-index: 1;
  text-align: left;
  width: 70%;
}

@media screen and (min-width: 768px) {
  .banner {
    background-size: 100% 100%;
    &::after {
      content: "";
      top: 0;
      left: 0;
      bottom: 0;
      right: 0;
      margin: auto;
      background-color: red;
      position: relative;
    }
  }

  .content {
    display: block;
    margin: 0 5%;
  }

  .logo {
    top: 20px;
    left: 20px;
    display: block;
    position: absolute;
  }

  .helper {
    display: none;
  }

  h1 {
    position: absolute;
    font-size: 48px;
    bottom: 80px;
    background-color: transparent;
  }
}
</style>
<script>
import Helper from "./Helper.vue";
export default {
  data() {
    return {};
  },
  props: {
    title: { type: String },
    image: { type: String },
  },
  components: {
    Helper,
  },
};
</script>