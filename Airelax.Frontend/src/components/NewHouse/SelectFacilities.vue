<template>
  <li
    class="col-6 col-sm-6 col-md-4"
    v-for="facility in facilities"
    :key="facility.mapping"
  >
    <div>
      <Facility :facility="facility"></Facility>
    </div>
  </li>
</template>


<style lang="scss" scoped>
li {
  animation-delay: 543.3429593403143ms;
  list-style: none;
  margin-bottom: 15px;
  padding: 0;
  min-height: 68px;
  padding-right: 15px;
  box-sizing: border-box;
  &:nth-child(2n + 2) {
    padding-right: 0;
  }

  > div {
    height: 100%;
  }
}

@media screen and (min-width: 768px) {
  li {
    &:nth-child(2n + 2) {
      padding-right: 15px;
    }
    &:nth-child(3n + 3) {
      padding-right: 0;
    }
  }
}
</style>

<script>
import Facility from "./Facility.vue";

export default {
  props: ["facilities"],
  components: {
    Facility,
  },
};
</script>