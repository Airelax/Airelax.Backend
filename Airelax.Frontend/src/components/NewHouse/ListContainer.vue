<template>
  <div class="contain">
    <ul>
      <slot></slot>
    </ul>
  </div>
</template>


<style lang="scss" scoped>
.contain {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
}
ul {
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