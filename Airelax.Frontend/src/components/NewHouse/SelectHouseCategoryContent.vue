<template>
  <ListContainer>
    <SelectedHouseList> </SelectedHouseList>
  </ListContainer>
</template>

<script>
import ListContainer from "./ListContainer.vue";
import SelectedHouseList from "./SelectHouseCategories.vue";

export default {
  components: {
    ListContainer,
    SelectedHouseList,
  },
};
</script>