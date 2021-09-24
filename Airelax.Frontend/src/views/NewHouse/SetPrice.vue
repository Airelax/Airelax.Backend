<template>
  <Layout :title="'有趣的部分來了！現在請設定價格'">
    <SetPriceContent @setPrice="setPrice"></SetPriceContent>
  </Layout>
</template>

<style lang="scss" scoped>
</style>


<script>
import Layout from "../../components/NewHouse/Layout.vue";
import SetPriceContent from "../../components/NewHouse/SetPriceContent.vue";

export default {
  created() {
    const houseId = this.$route.params.id;
    if (houseId) {
      this.$store.commit('setNewHouseNextAvailable', false);
      return;
    }
    //todo fetch house
    this.$store.commit('setNewHouseNextAvailable', true);
  },
  components: {
    Layout,
    SetPriceContent,
  },
  methods: {
    setPrice: function (price) {
      if (!price) {
        this.$store.commit('setNewHouseNextAvailable', false);
        return;
      }

      const houseId = this.$route.params.id;
      const req = {
        method: houseId ? "PUT" : "POST",
        url: houseId ? `/${houseId}/price` : "",
        redirectName: `/`,
        body: {
          price: price,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    }
  }
};
</script>