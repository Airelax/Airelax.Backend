<template>
  <Layout :isVideoBanner="true" :img="img" :title="'來為房源取名吧'">
    <div class="all-center">
      <TextContent @onTextChanged="onTextChanged" :title="'建立標題'"></TextContent>
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
  created() {
    const houseId = this.$route.params.id;
    if (houseId) {
      this.$store.commit('setNewHouseNextAvailable', false);
      return;
    }

    //todo fetch house
    this.$store.commit('setNewHouseNextAvailable', true);
  },
  data() {
    return {
      img: require("@/assets/pic/rent_page/NameHouse.jpg"),
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
        url: houseId ? `/${houseId}/title` : "",
        redirectName: `HouseDescription`,
        body: {
          Title: message,
          //todo identity
          memberId: 'M00056b77d3'
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    },
  }
};
</script>