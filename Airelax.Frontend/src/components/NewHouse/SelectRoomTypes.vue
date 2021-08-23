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
  data() {
    return { value: 0 };
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
      this.$emit("selected", mapping);
    },
  },
};
</script>