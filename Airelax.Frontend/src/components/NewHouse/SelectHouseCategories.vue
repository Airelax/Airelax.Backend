<template>
  <li v-for="houseCategory in houseCategories" :key="houseCategory.mapping">
    <HouseCategory
      :isActive="houseCategory.mapping === value"
      :houseCategory="houseCategory"
      @selected="selected"
    ></HouseCategory>
  </li>
</template>

<style lang="scss" scoped>
li {
  list-style: none;
  padding: 0;
}
</style>

<script>
import setting from "./setting";
import HouseCategory from "./HouseCategory.vue";
export default {
  data() {
    return {
      houseCategories: setting.houseCategories,
      value: 0,
    };
  },
  components: {
    HouseCategory,
  },
  methods: {
    selected: function (mapping) {
      this.value = mapping;
      this.$emit("selected", mapping);
    },
  },
};
</script>