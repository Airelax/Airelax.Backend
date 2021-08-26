<template>
  <Layout :title="'下列哪項最能確切描述你的房源？'">
    <SelectHouseType></SelectHouseType>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import SelectHouseType from "../../components/NewHouse/SelectHouseTypeContent.vue";

export default {
  components: {
    Layout,
    SelectHouseType,
  },
};
</script>