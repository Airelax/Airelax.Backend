<template>
  <div class="container">
    <h2>{{ title }}</h2>
    <ul class="row">
      <SelectFacilities :facilities="facilities"></SelectFacilities>
    </ul>
  </div>
</template>


<style lang="scss" scoped>
ul {
  padding: 0;
  margin: 0;
}
h2 {
  font-size: 22px;
  font-weight: 900;
  text-align: left;
  margin-bottom: 30px;
}
</style>

<script>
import SelectFacilities from "./SelectFacilities.vue";
export default {
  props: ["title", "facilities"],
  components: {
    SelectFacilities,
  },
};
</script>