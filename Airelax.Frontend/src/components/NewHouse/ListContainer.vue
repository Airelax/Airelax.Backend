<template>
  <div class="container">
    <ul>
      <slot></slot>
    </ul>
  </div>
</template>


<style lang="scss" scoped>
@import "../../assets/css/reset.css";

.container {
  display: flex;

  justify-content: center;
  height: 100%;
  overflow-y: auto;

  &::-webkit-scrollbar {
    display: none;
  }

  & {
    -ms-overflow-style: none;
    scrollbar-width: none;
  }
}

ul {
  box-sizing: border-box;
  width: 80%;
  max-width: 450px;
  padding: 0;
  margin: 0;
}
</style>


<script>
export default {
  data() {
    return {
      value: 0,
    };
  },
};
</script>