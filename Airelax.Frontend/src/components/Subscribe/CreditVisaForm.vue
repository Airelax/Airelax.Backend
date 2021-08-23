<template>
  <Card></Card>
  <BillingAddress></BillingAddress>
</template>
<script>
import Card from "./Card.vue";
import BillingAddress from "./BillingAddress.vue";
export default {
  components: {
    BillingAddress,
    Card,
  },
};
</script>