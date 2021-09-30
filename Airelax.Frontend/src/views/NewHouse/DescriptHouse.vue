<template>
  <Layout :isVideoBanner="true" :img="img" :title="'請描述你的房源'">
    <div class="all-center">
      <TextContent :title="'撰寫房源描述'"></TextContent>
    </div>
  </Layout>
</template>


<style lang="scss" scoped>
.all-center {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%;
}
</style>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import TextContent from "../../components/NewHouse/TextContent.vue";

export default {
  data() {
    return {
      img: require("@/assets/pic/rent_page/DescriptHouse.jpg"),
    };
  },
  components: {
    Layout,
    TextContent,
  },
  methods: {
    onTextChanged(message) {
      if (message) {
        this.$store.commit('setNewHouseNextAvailable', true);
      }
      const houseId = this.$route.params.id;
      const req = {
        method: houseId ? "PUT" : "POST",
        url: houseId ? `/${houseId}/Description` : "",
        redirectName: `Price`,
        body: {
          Title: message,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    },
  }
};
</script>