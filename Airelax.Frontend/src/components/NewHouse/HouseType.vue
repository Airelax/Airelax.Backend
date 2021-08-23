<template>
  <button :class="{ active: isActive }" @click="choose">
    <div class="item">
      <div class="all-center">
        <div class="title">{{ houseType.chinese }}</div>
        <div class="description">{{ houseType.description }}</div>
      </div>
    </div>
  </button>
</template>

<style lang="scss" src="../../../assets/css/rentSelection.scss" scoped >
</style>

<style lang="scss" scoped>
.all-center {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  justify-content: center;
  text-align: left;

  .title,
  .description {
    width: 100%;
    text-align: left;
  }
}

.active {
  border: 2px solid #000;
  background-color: #fff;
}
</style>

<script>
export default {
  props: {
    houseType: { type: Object },
    isActive: { type: Boolean },
  },
  methods: {
    choose: function () {
      this.$emit("selected", this.houseType.mapping);
    },
  },
};
</script>