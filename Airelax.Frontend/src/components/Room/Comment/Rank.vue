<template>
  <div class="char">
    <div class="name">
      <span>{{ chineseName }}</span>
    </div>
    <div class="charValue">
      <div class="char-box">
        <div
          :style="{ width: (value / 5) * 100 + '%' }"
          class="char-mask"
        ></div>
      </div>
    </div>
    <span>{{ Number.parseFloat(value).toFixed(1) }}</span>
  </div>
</template>


<style lang="scss" scoped>
.char {
  width: 100%;

  display: flex;
  justify-content: space-between;
  span {
    text-align: left;
    box-sizing: border-box;
  }

  .name {
    width: 100%;
    text-align: left;
  }
}
.charValue {
  display: flex;
  position: relative;
  width: 75%;
  margin: 0 15px;
  flex-grow: 1;
}
.charValue .char-box,
.charValue .char-mask {
  height: 4px;
  border-radius: 2px;
  margin: auto;
}
.charValue .char-box {
  width: 100%;
  background-color: rgb(221, 221, 221);
}
.charValue .char-mask {
  background-color: #222;
  position: absolute;
}
.charValue span {
  font-size: 12px;
  margin-left: 10px;
  display: block;
}
@media screen and (min-width: 768px) {
  .char {
    height: 36px;
    line-height: 36px;
  }
}
</style>

<script>
export default {
  props: {
    chineseName: {
      type: String,
    },
    value: {
      type: Number,
    },
  },
  method: {
    percent(item) {
      return item / 5;
    },
  },

  mounted() {},
};
</script>