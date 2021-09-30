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
  box-sizing: border-box;
}
</style>

<script>
import setting from "./setting";
import HouseCategory from "./HouseCategory.vue";

export default {
  created() {
    const houseId = this.$route.params.id;
    if (houseId) {
      this.$store.commit('setNewHouseNextAvailable', false);
      return;
    }
    this.$store.commit('setNewHouseNextAvailable', true);
  },
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
      this.$store.commit('setNewHouseNextAvailable', true);
      this.value = mapping;

      const houseId = this.$route.params.id;
      const req = {
        method: houseId ? "PUT" : "POST",
        url: houseId ? `/${houseId}/category` : "",
        redirectName: `HouseType`,
        body: {
          category: this.value,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    },
  },
};
</script>