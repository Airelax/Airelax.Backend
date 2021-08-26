<template>
  <Layout
    :isVideoBanner="true"
    :img="require('@/assets/pic/rent_page/ChooseHouseHighlight.jpg')"
    :title="'下列哪項最能確切描述你的房源？'"
  >
    <SelectHighlight></SelectHighlight>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import SelectHighlight from "../../components/NewHouse/SelectHighlight.vue";

export default {
  components: {
    Layout,
    SelectHighlight,
  },
};
</script>