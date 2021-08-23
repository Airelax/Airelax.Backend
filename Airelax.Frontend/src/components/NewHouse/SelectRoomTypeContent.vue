<template>
  <ListContainer>
    <SelectRoomTypes :roomTypes="roomTypes"> </SelectRoomTypes>
  </ListContainer>
</template>

<script>
import ListContainer from "./ListContainer.vue";
import SelectRoomTypes from "./SelectRoomTypes.vue";
import setting from "./setting";

export default {
  data() {
    return {
      roomTypes: setting.roomTypes,
    };
  },

  components: {
    ListContainer,
    SelectRoomTypes,
  },
  props: {
    category: {
      type: Number,
      default: 1,
    },
  },
};
</script>