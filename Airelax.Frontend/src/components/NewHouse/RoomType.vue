<template>
  <button :class="{ active: isActive }" @click="choose">
    <div class="item">
      <div>
        {{ roomType.chinese }}
      </div>
    </div>
  </button>
</template>


<style lang="scss" scoped>
.item {
  display: flex;
  color: #000;
  cursor: pointer;
  align-items: center;
  padding: 24px 16px;

  box-sizing: border-box;
  width: 100%;
  justify-content: space-between;
  font-size: 18px;
  font-weight: 900;

  span {
    display: block;
    text-align: left;
    padding: 0 10px;
    width: 80%;
    white-space: wrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }

  .cover {
    width: 32px;
    height: 32px;

    img {
      width: 100%;
      height: 100%;
      display: block;
      object-fit: cover;
      border-radius: 8px;
    }
  }
}

button {
  text-decoration: none;
  display: block;
  background-color: #fff;
  border: none;
  width: 100%;
  padding: 0;
  margin-top: 15px;
  border: 2px solid #ddd;
  border-radius: 12px;

  &:hover {
    border-color: #000;
  }

  &.active {
    border-color: #000;
    background-color: #fff;
  }
}
</style>

<script>
export default {
  props: {
    roomType: {
      type: Object,
    },
    isActive: { type: Boolean },
  },
  methods: {
    choose: function () {
      this.$emit("selected", this.roomType.mapping);
    },
  },
};
</script>