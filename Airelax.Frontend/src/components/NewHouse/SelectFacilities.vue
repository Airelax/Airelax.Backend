<template>
  <li
      class="col-6 col-sm-6 col-md-4"
      v-for="facility in facilities"
      :key="facility.mapping"
  >
    <div>
      <Facility
          :isActive="facilityMappings.includes(facility.mapping)"
          :facility="facility"
          @selected="selected"
      ></Facility>
    </div>
  </li>
</template>


<style lang="scss" scoped>
li {
  animation-delay: 543.3429593403143ms;
  list-style: none;
  margin-bottom: 15px;
  min-height: 68px;
  padding: 0 15px 0 0;
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
  data() {
    return {
      facilityMappings: [],
    }
  },
  props: ["facilities"],
  components: {
    Facility,
  },
  methods: {
    selected: function (mapping) {
      const index = this.facilityMappings.indexOf(mapping);
      if (index > -1)
        this.facilityMappings.splice(index, 1);
      else
        this.facilityMappings.push(mapping);
      this.$emit('selected', this.facilityMappings);
    }
  }
};
</script>