<template>
  <ListContainer>
    <SelectHouseTypes :houseTypes="houseCategory.houseTypes">
    </SelectHouseTypes>
  </ListContainer>
</template>

<script>
import ListContainer from "./ListContainer.vue";
import SelectHouseTypes from "./SelectHouseTypes.vue";
import setting from "./setting";

export default {
  data() {
    return {
      houseCategory: {},
    };
  },
  created() {
    this.houseCategory = setting.houseCategories.find(
      (x) => x.mapping === this.category
    );
  },
  components: {
    ListContainer,
    SelectHouseTypes,
  },
  props: {
    category: {
      type: Number,
      default: 1,
    },
  },
};
</script>