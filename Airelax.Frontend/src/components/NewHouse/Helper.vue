<template>
  <div class="helper">
    <button class="close">
      <svg
        viewBox="0 0 32 32"
        xmlns="http://www.w3.org/2000/svg"
        role="presentation"
        focusable="false"
      >
        <path d="m6 6 20 20"></path>
        <path d="m26 6-20 20"></path>
      </svg>
    </button>
    <button>
      <div>協助</div>
    </button>
    <button>
      <div>儲存並退出</div>
    </button>
  </div>
</template>

<style lang="scss" scoped>
@mixin all-center {
  display: flex;
  justify-content: center;
  align-items: center;
}

.helper {
  display: flex;
  justify-content: space-between;
  width: 100%;
  position: sticky;
  top: 0;
  z-index: 20;
}

button {
  @include all-center();
  color: #fff;
  border: none;
  background-color: rgba($color: rgb(241, 231, 231), $alpha: 0.4);
  border-radius: 32px;
  height: 32px;
  box-sizing: border-box;
  font-size: 14px;

  div {
    padding: 1px 10px;
  }

  &.close {
    width: 32px;
  }

  &:last-child {
    display: none;
  }

  svg {
    display: block;
    fill: none;
    height: 16px;
    width: 16px;
    stroke: rgb(255, 255, 255);
    stroke-width: 4;
    overflow: visible;
  }
}

@media screen and (min-width: 768px) {
  .helper {
    justify-content: flex-end;

    button {
      background-color: #eee;
      color: #000;
      &:first-child {
        display: none;
      }

      &:last-child {
        display: flex;
        margin-left: 1em;
      }
    }
  }
}
</style>

<script>
export default {
  data() {
    return {};
  },
};
</script>