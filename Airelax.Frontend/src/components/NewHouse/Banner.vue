<template>
  <div class="banner">
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
  background: linear-gradient(90deg, #441ca2, #d32677);
  height: 100%;
  position: relative;

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
  font-size: 26px;
  text-align: left;
  width: 70%;
}

@media screen and (min-width: 768px) {
  .banner {
    background: linear-gradient(to top, #441ca2, #d32677);
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
    font-size: 48px;
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
    title: String,
  },
  components: {
    Helper,
  },
};
</script>

