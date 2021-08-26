<template>
  <Layout :title="'成為房東'" :notFirst="false">
    <CreateStep></CreateStep>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import CreateStep from "../../components/NewHouse/CreateStep.vue";

export default {
  components: {
    Layout,
    CreateStep,
  },
};
</script>