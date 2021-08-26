<template>
  <Layout :title="'讓房客知道房源內有提供哪些設備與服務'">
    <SelectFacility></SelectFacility>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import SelectFacility from "../../components/NewHouse/SelectFacilityContent.vue";

export default {
  components: {
    Layout,
    SelectFacility,
  },
};
</script>