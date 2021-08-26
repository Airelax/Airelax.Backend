<template>
  <div class="controls">
    <button class="back">返回</button>
    <button
      :disabled="isSelected"
      :class="{ active: !isSelected }"
      class="next"
    >
      下一步
    </button>
  </div>
</template>

<style lang="scss" scoped>
.controls {
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-sizing: border-box;

  button {
    display: block;
    border: none;
    box-sizing: border-box;

    &.back {
      background-color: transparent;
      font-weight: 900;
      text-decoration: underline;
    }

    &.next {
      color: #fff;
      background-color: #ddd;
      padding: 14px 24px;
      cursor: not-allowed;
      border-radius: 8px;
    }
  }
}
</style>


<script>
export default {
  props: {
    isSelected: {
      type: Boolean,
      default: true,
    },
  },
};
</script>