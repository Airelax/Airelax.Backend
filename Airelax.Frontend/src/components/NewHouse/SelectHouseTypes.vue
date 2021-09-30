<template>
  <li v-for="houseType in houseTypes" :key="houseType.mapping">
    <HouseType
        :isActive="houseType.mapping === value"
        :houseType="houseType"
        @selected="selected"
    ></HouseType>
  </li>
</template>

<style lang="scss" scoped>
li {
  list-style: none;
  padding: 0;
}
</style>
<script>
import HouseType from "./HouseType.vue";

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
    return {value: 0};
  },
  props: {
    houseTypes: {
      type: Object,
    },
  },
  components: {
    HouseType,
  },
  methods: {
    selected: function (mapping) {
      this.$store.commit('setNewHouseNextAvailable', true);
      this.value = mapping;
      const req = {
        method: "PUT",
        url: `/${this.$route.params.id}/type`,
        redirectName: `RoomType`,
        body: {
          houseType: this.value,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    },
  },
};
</script>