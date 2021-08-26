<template>
  <button @click="choose">
    <div class="item">
      <div class="icon"><img :src="facility.img" alt="" /></div>
      <div class="name">
        {{ facility.chinese }}
      </div>
    </div>
  </button>
</template>

<style lang="scss" scoped>
.item {
  color: #000;
  cursor: pointer;
  padding: 24px 16px;

  box-sizing: border-box;
  width: 100%;
  justify-content: space-between;
  font-size: 18px;
  font-weight: 900;
  height: 100%;
}

button {
  text-decoration: none;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  background-color: #fff;
  border: none;
  width: 100%;
  padding: 0;
  border: 2px solid #ddd;
  border-radius: 12px;
  height: 100%;

  &:hover {
    border-color: #000;
  }

  &.active {
    border-color: #000;
  }
}

.icon {
  display: flex;
  justify-content: center;
}

img {
  display: block;
  height: 52px;
  width: 52px;
  fill: currentColor;
}
</style>


<script>
export default {
  props: ["facility"],
};
</script>

