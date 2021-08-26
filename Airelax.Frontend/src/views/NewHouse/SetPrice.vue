<template>
  <Layout :title="'有趣的部分來了！現在請設定價格'">
    <SetPriceContent></SetPriceContent>
  </Layout>
</template>

<style lang="scss" scoped>
</style>



<script>
import Layout from "../../components/NewHouse/Layout.vue";
import SetPriceContent from "../../components/NewHouse/SetPriceContent.vue";

export default {
  components: {
    Layout,
    SetPriceContent,
  },
};
</script>