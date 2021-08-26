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
  data() {
    return { value: 0 };
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
      this.value = mapping;
      this.$emit("selected", mapping);
    },
  },
};
</script>