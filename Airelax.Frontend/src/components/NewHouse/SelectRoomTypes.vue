<template>
  <li v-for="roomType in roomTypes" :key="roomType.mapping">
    <RoomType
        :isActive="roomType.mapping === value"
        :roomType="roomType"
        @selected="selected"
    ></RoomType>
  </li>
</template>

<style lang="scss" scoped>
li {
  list-style: none;
  padding: 0;
}
</style>
<script>
import RoomType from "./RoomType.vue";

export default {
  created() {
    const houseId = this.$route.params.id;
    if (houseId) {
      this.$store.commit('setNewHouseNextAvailable', false);
      return;
    }
    //todo fetch house
    this.$store.commit('setNewHouseNextAvailable', true);
  },
  data() {
    return {value: 0};
  },
  props: {
    roomTypes: {
      type: Object,
    },
  },
  components: {
    RoomType,
  },
  methods: {
    selected: function (mapping) {
      this.value = mapping;
      this.$store.commit('setNewHouseNextAvailable', true);
      const houseId = this.$route.params.id;
      const req = {
        method: "PUT",
        url: `/${houseId}/RoomCategory`,
        redirectName: `HouseLocation`,
        body: {
          category: this.value,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    },
  },
};
</script>