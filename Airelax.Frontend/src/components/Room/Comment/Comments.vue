<template>
  <div
    class="my-row col-6"
    v-for="(item, key, index) in rank"
    :key="index"
    v-show="key !== 'star'"
  >
    <Rank
      :chineseName="setting.find((x) => x.eng === key).ch"
      :value="item"
    ></Rank>
  </div>
</template>

<style scoped>
.container {
  width: 100%;
}

.my-row {
  padding-right: 5%;
  color: #222;
}
@media screen and (min-width: 1200px) {
  .my-row {
    padding-right: 10%;
  }
}
</style>

<script>
import setting from "./msgSetting";
import Rank from "./Rank.vue";

export default {
  props: ["rank"],
  data() {
    return {
      setting: setting.chineseTranslation,
    };
  },
  components: { Rank }
};
</script>