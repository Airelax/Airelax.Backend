<template>
  <div class="my-row" v-for="item in com" :key="item.id">
    <div class="box">
      <Message :msg="item"></Message>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.my-row {
  color: #222;
  height: 236px;
  padding: 16px;
  border: 1px solid rgb(221, 221, 221);
  border-radius: 12px;
  margin-right: 12px;
  box-sizing: border-box;
}
.box {
  width: 75.103vw;
}

@media screen and (min-width: 768px) {
  .my-row {
    height: 132px;
    border: none;
    padding: 0;
    margin-right: 0;
  }
  .my-row:nth-child(6) {
    margin-right: 0;
  }
  .box {
    width: 100%;
  }
}
@media screen and (min-width: 1200px) {
  .my-row {
    height: 136px;
    width: 50%;
  }
}
</style>

<script>
import Message from "./Message.vue";
export default {
  props: ["com"],
  components: {
    Message,
  },
};
</script>